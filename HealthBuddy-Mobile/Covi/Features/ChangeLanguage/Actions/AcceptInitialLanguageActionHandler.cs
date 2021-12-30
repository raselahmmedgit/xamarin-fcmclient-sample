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
using System.Threading;
using System.Threading.Tasks;

using Covi.Features.Welcome.Routes;
using Covi.Services.Navigation;

using MediatR;

namespace Covi.Features.ChangeLanguage.Actions
{
    public class AcceptInitialLanguageActionHandler : AsyncRequestHandler<AcceptInitialLanguageAction>
    {
        private readonly IWelcomeRoute _welcomeRoute;
        private readonly INavigationServiceDelegate _navigationServiceDelegate;

        public AcceptInitialLanguageActionHandler(IWelcomeRoute welcomeRoute, INavigationServiceDelegate navigationServiceDelegate)
        {
            _welcomeRoute = welcomeRoute;
            _navigationServiceDelegate = navigationServiceDelegate;
        }

        protected override async Task Handle(AcceptInitialLanguageAction request, CancellationToken cancellationToken)
        {
            await _welcomeRoute.ExecuteAsync(_navigationServiceDelegate).ConfigureAwait(false);
        }
    }
}
