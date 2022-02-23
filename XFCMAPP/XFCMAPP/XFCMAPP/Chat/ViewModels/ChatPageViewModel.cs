using Plugin.FirebasePushNotification;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XFCMAPP.Chat.Helpers;
using XFCMAPP.Chat.Models;
using XFCMAPP.Service;
using XFCMAPP.Utility;

namespace XFCMAPP.Chat.ViewModels
{
    public class ChatPageViewModel : INotifyPropertyChanged
    {
        private readonly RapidProContainer _rapidProContainer;
        private readonly RapidProService _rapidProService;

        public string RapidProInitPhrase = "riseup";
        public string RapidProInitMsgPhrase = "test_rasel";

        public bool RapidProInit { get; set; } = false;
        public bool RapidProInitMsg { get; set; } = false;
        public bool RapidProInitSend { get; set; } = false;

        public bool ShowScrollTap { get; set; } = false;
        public bool LastMessageVisible { get; set; } = true;
        //public int PendingMessageCount { get; set; } = 0;
        //public bool PendingMessageCountVisible { get { return PendingMessageCount > 0; } }

        //public Queue<Message> DelayedMessages { get; set; } = new Queue<Message>();

        public ObservableCollection<Message> Messages { get; set; } = new ObservableCollection<Message>();
        public string InputText { get; set; }
        public ICommand OnSendCommand { get; set; }
        public string ActionInputText { get; set; }
        public ICommand OnActionSendCommand { get; set; }
        public ICommand MessageAppearingCommand { get; set; }
        public ICommand MessageDisappearingCommand { get; set; }

        public ChatPageViewModel()
        {
            _rapidProContainer = new RapidProContainer();
            _rapidProService = new RapidProService();

            InitializeFcmAndRapidPro();

            //Messages.Insert(0, new Message() { Text = "Hi" });
            //Messages.Insert(0, new Message() { Text = "How are you?", User = "RAB" });
            //Messages.Insert(0, new Message() { Text = "What's new?" });
            //Messages.Insert(0, new Message() { Text = "How is your family", User = "RAB" });
            //Messages.Insert(0, new Message() { Text = "How is your dog?", User = "RAB" });
            //Messages.Insert(0, new Message() { Text = "How is your cat?", User = "RAB" });
            //Messages.Insert(0, new Message() { Text = "How is your sister?" });
            //Messages.Insert(0, new Message() { Text = "When we are going to meet?" });
            //Messages.Insert(0, new Message() { Text = "I want to buy a laptop" });
            //Messages.Insert(0, new Message() { Text = "Where I can find a good one?" });
            //Messages.Insert(0, new Message() { Text = "Also I'm testing this chat" });
            //Messages.Insert(0, new Message() { Text = "Oh My God!" });
            //Messages.Insert(0, new Message() { Text = " No Problem", User = "RAB" });
            //Messages.Insert(0, new Message() { Text = "Hugs and Kisses", User = "RAB" });
            //Messages.Insert(0, new Message() { Text = "When we are going to meet?" });
            //Messages.Insert(0, new Message() { Text = "I want to buy a laptop" });
            //Messages.Insert(0, new Message() { Text = "Where I can find a good one?" });
            //Messages.Insert(0, new Message() { Text = "Also I'm testing this chat" });
            //Messages.Insert(0, new Message() { Text = "Oh My God!" });
            //Messages.Insert(0, new Message() { Text = " No Problem" });
            //Messages.Insert(0, new Message() { Text = "Hugs and Kisses" });

            MessageAppearingCommand = new Command<Message>(OnMessageAppearing);
            MessageDisappearingCommand = new Command<Message>(OnMessageDisappearing);

            OnSendCommand = new Command(() =>
            {
                if (!string.IsNullOrEmpty(InputText))
                {
                    //Messages.Insert(0, new Message() { Text = InputText, User = "RAB" });
                    SendCommand(InputText);
                    InputText = string.Empty;
                }

            });

            OnActionSendCommand = new Command(() =>
            {
                if (!string.IsNullOrEmpty(ActionInputText))
                {
                    //Messages.Insert(0, new Message() { Text = InputText, User = "RAB" });
                    SendCommand(ActionInputText);
                    ActionInputText = string.Empty;
                }

            });

            ////Code to simulate reveing a new message procces
            //Device.StartTimer(TimeSpan.FromSeconds(5), () =>
            //{
            //    if (LastMessageVisible)
            //    {
            //        Messages.Insert(0, new Message() { Text = "New message test by rab", User = "RAB" });
            //    }
            //    else
            //    {
            //        DelayedMessages.Enqueue(new Message() { Text = "New message test by rab", User = "RAB" });
            //        PendingMessageCount++;
            //    }
            //    return true;
            //});

        }

        void OnMessageAppearing(Message message)
        {
            var idx = Messages.IndexOf(message);
            if (idx <= 6)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    //while (DelayedMessages.Count > 0)
                    //{
                    //    Messages.Insert(0, DelayedMessages.Dequeue());
                    //}
                    ShowScrollTap = false;
                    LastMessageVisible = true;
                    //PendingMessageCount = 0;
                });
            }
        }

        void OnMessageDisappearing(Message message)
        {
            var idx = Messages.IndexOf(message);
            if (idx >= 6)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    ShowScrollTap = true;
                    LastMessageVisible = false;
                });

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #region Fcm And RapidPro
        
        private async void InitializeFcmAndRapidPro()
        {
            if (string.IsNullOrEmpty(_rapidProContainer.RapidProFcmToken))
            {
                string fcmPushNotificationToken = CrossFirebasePushNotification.Current?.Token;
                _rapidProContainer.RapidProFcmToken = fcmPushNotificationToken;

                Console.WriteLine($"ChatPageViewModel - InitializeFcmAndRapidPro: Token - {fcmPushNotificationToken}");
            }

            if (string.IsNullOrEmpty(_rapidProContainer.RapidProUrn))
            {
                string rapidProUrn = RapidProHelper.GetUrnFromGuid();
                _rapidProContainer.RapidProUrn = rapidProUrn;

                Console.WriteLine($"ChatPageViewModel - InitializeFcmAndRapidPro: Urn - {rapidProUrn}");
            }

            await RapidProRegisterAndReceiveInit();
        }

        private async Task RapidProRegisterAndReceiveInit()
        {
            try
            {
                string rapidProUrn = _rapidProContainer.RapidProUrn;
                string rapidProFcmToken = _rapidProContainer.RapidProFcmToken;

                if (RapidProInit == false)
                {
                    if (!string.IsNullOrEmpty(rapidProUrn) && !string.IsNullOrEmpty(rapidProFcmToken))
                    {
                        var rapidProRegister = await _rapidProService.RapidProRegister(rapidProUrn, rapidProFcmToken);
                        if (!string.IsNullOrEmpty(rapidProRegister.ContactUuid))
                        {
                            var rapidProReceive = _rapidProService.RapidProReceive(rapidProUrn, rapidProFcmToken, RapidProInitPhrase);
                            RapidProInit = true;
                            //RapidProRegisterAndReceiveInitMsg(RapidProInitMsgPhrase);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"ChatPageViewModel - RapidProRegisterAndReceiveInit: Exception - {ex.Message.ToString()}");
            }
        }

        private void RapidProRegisterAndReceiveInitMsg(string inputText)
        {
            try
            {
                string rapidProUrn = _rapidProContainer.RapidProUrn;
                string rapidProFcmToken = _rapidProContainer.RapidProFcmToken;

                if (!string.IsNullOrEmpty(rapidProUrn) && !string.IsNullOrEmpty(rapidProFcmToken))
                {
                    if (RapidProInit)
                    {
                        Messages.Insert(0, new Message() { Text = RapidProInitMsgPhrase, User = MessageUserEnum.UserLogin.ToDescriptionAttr() });
                        var rapidProReceive = _rapidProService.RapidProReceive(rapidProUrn, rapidProFcmToken, inputText);
                        RapidProInitMsg = true;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"ChatPageViewModel - RapidProRegisterAndReceiveInitMsg: Exception - {ex.Message.ToString()}");
            }
        }

        private void SendCommand(string inputText)
        {
            try
            {
                string rapidProUrn = _rapidProContainer.RapidProUrn;
                string rapidProFcmToken = _rapidProContainer.RapidProFcmToken;

                if (!string.IsNullOrEmpty(rapidProUrn) && !string.IsNullOrEmpty(rapidProFcmToken))
                {
                    //if (RapidProInit && RapidProInitMsg)
                    if (RapidProInit)
                    {
                        Messages.Insert(0, new Message() { Text = inputText, User = MessageUserEnum.UserLogin.ToDescriptionAttr() });

                        var rapidProReceive = _rapidProService.RapidProReceive(rapidProUrn, rapidProFcmToken, inputText);
                        RapidProInitSend = true;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"ChatPageViewModel - SendCommand: Exception - {ex.Message.ToString()}");
            }
        }


        #endregion
    }
}
