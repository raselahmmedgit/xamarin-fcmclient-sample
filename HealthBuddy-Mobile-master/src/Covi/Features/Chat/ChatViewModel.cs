// =========================================================================
// Copyright 2020 EPAM Systems, Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// =========================================================================

using System;
using System.Reactive.Disposables;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Covi.Features.Analytics;
using Covi.Features.Chat.Handlers;
using Covi.Features.Components.InfoView;
using Covi.Features.Controls.HybridWebView;
using Covi.Features.UserProfile.Services;
using Covi.Services.Http.UriHandlers;
using Covi.Services.Navigation;
using Covi.Services.Serialization;
using Microsoft.Extensions.Logging;
using ReactiveUI;

namespace Covi.Features.Chat
{
    public class ChatViewModel : ViewModelBase, IInteractionChannelHandler
    {
        private const string ErrorImgSource = "connection_problem.svg";
        private const string InitPhrase = "chat";
        private readonly IMessagesProcessor _messagesProcessor;
        private readonly ILogger _logger;
        private readonly IMessageInteractor _messageInteractor;
        private readonly INavigationServiceDelegate _navigationServiceDelegate;

        public ChatViewModel(
            ISerializer serializer,
            ILoggerFactory loggerFactory,
            IMessagesProcessor messagesProcessor,
            INavigationServiceDelegate navigationServiceDelegate,
            IUserAccountContainer userAccountContainer)
        {
            _messagesProcessor = messagesProcessor;
            _logger = loggerFactory.CreateLogger<ChatViewModel>();
            _navigationServiceDelegate = navigationServiceDelegate;
            Uri = Configuration.Constants.HybridConstants.HybridEndpointUrl;
            SendMessageInteraction = new Interaction<Message, bool>();
            _messageInteractor = new MessageInteractor(loggerFactory, serializer, userAccountContainer, SendMessageInteraction);
            UriOpeningHandler = new HybridWebViewUriOpeningHandler(Uri);

            _messagesProcessor.AddHandler(new InputMessageHandler(b => IsInputVisible = b));
            _messagesProcessor.AddHandler(new WebSessionConnectionHandler(loggerFactory, isConnected => IsBusy = !isConnected));

            HandleMessageCommand = ReactiveCommand.CreateFromTask<Message>(HandleMessageAsync);
            SendCommand = ReactiveCommand.CreateFromTask(SendAsync);
            NavigateBackCommand = ReactiveCommand.CreateFromTask(NavigateBackAsync);
            IsBusy = true;
        }

        public string Uri { get; }

        public string InputText { get; set; }

        public bool IsInputVisible { get; private set; } = true;

        public Interaction<Message, bool> SendMessageInteraction { get; }

        public IInfoViewModel InfoViewModel { get; private set; }

        public ICommand SendCommand { get; }

        public ICommand NavigateBackCommand { get; }

        public ICommand HandleMessageCommand { get; }

        public IUriOpeningHandler UriOpeningHandler { get; }

        public async void ApiReadyMessage()
        {
            await _messageInteractor.SendInit(InitPhrase);
            OnInitialized();
        }

        public void SetErrorState()
        {
            InfoViewModel = InfoViewModelFactory.CreateViewModel(ErrorImgSource, Covi.Resources.Localization.Exception_NoInternetConnection);
            IsBusy = false;
        }

        public override void OnActivated(CompositeDisposable lifecycleDisposable)
        {
            base.OnActivated(lifecycleDisposable);

            AnalyticsProvider.Instance.LogViewModel(nameof(ChatViewModel));
        }

        private void OnInitialized()
        {
            IsBusy = false;
        }

        private async Task SendAsync()
        {
            await _messageInteractor.SendText(InputText);
            InputText = string.Empty;
        }

        private async Task NavigateBackAsync()
        {
            await _navigationServiceDelegate.GoBackAsync();
        }

        private async Task HandleMessageAsync(Message message, CancellationToken ct = default)
        {
            await _messagesProcessor.HandleAsync(message);
        }
    }
}
