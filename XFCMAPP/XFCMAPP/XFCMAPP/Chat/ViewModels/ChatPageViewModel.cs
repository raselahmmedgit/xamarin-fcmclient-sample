using Newtonsoft.Json;
using Plugin.FirebasePushNotification;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XFCMAPP.Chat.Data;
using XFCMAPP.Chat.Helpers;
using XFCMAPP.Chat.Models;
using XFCMAPP.Service;
using XFCMAPP.Utility;
using XFCMAPP.ViewModel;

namespace XFCMAPP.Chat.ViewModels
{
    public class ChatPageViewModel : INotifyPropertyChanged
    {
        private readonly RapidProContainer _rapidProContainer;
        private readonly RapidProService _rapidProService;
        private readonly FirebaseContainer _firebaseContainer;

        public string RapidProInitPhrase = "riseup";
        public string RapidProInitMsgPhrase = "test_rasel";

        public bool ShowScrollTap { get; set; } = false;
        //public bool LastMessageVisible { get; set; } = true;

        public ObservableCollection<Message> Messages { get; set; } = new ObservableCollection<Message>();
        public string InputText { get; set; }
        public ICommand OnSendCommand { get; set; }
        public string MessageId { get; set; }
        public string ActionInputText { get; set; }
        public ICommand OnActionSendCommand { get; set; }
        public ICommand MessageAppearingCommand { get; set; }
        public ICommand MessageDisappearingCommand { get; set; }

        public ChatPageViewModel()
        {
            _rapidProContainer = new RapidProContainer();
            _rapidProService = new RapidProService();

            _firebaseContainer = new FirebaseContainer();
            if (string.IsNullOrEmpty(_firebaseContainer.FirebaseChannelHost) && string.IsNullOrEmpty(_firebaseContainer.FirebaseChannelId))
            {
                _firebaseContainer.FirebaseChannelHost = "https://rapidpro.ilhasoft.mobi/c/fcm/";
                _firebaseContainer.FirebaseChannelId = "4a2e5997-f435-4e20-829f-743b86ce0550";
            }

            InitializeFcmAndRapidPro();

            //Messages.Insert(0, new Message() { Text = "Hi", IsVisible = true });
            //Messages.Insert(0, new Message() { Text = "How are you?", User = MessageUserEnum.UserLogin.ToDescriptionAttr(), IsVisible = true });
            //Messages.Insert(0, new Message() { Text = "What's new?", IsVisible = true });
            //Messages.Insert(0, new Message() { Text = "How is your family", User = MessageUserEnum.UserLogin.ToDescriptionAttr(), IsVisible = true });
            //Messages.Insert(0, new Message() { Text = "How is your dog?", User = MessageUserEnum.UserLogin.ToDescriptionAttr(), IsVisible = true });
            //Messages.Insert(0, new Message() { Text = "How is your cat?", User = MessageUserEnum.UserLogin.ToDescriptionAttr(), IsVisible = true });
            //Messages.Insert(0, new Message() { Text = "How is your sister?", IsVisible = true });
            //Messages.Insert(0, new Message() { Text = "When we are going to meet?", IsVisible = true });
            //Messages.Insert(0, new Message() { Text = "I want to buy a laptop", IsVisible = true });
            //Messages.Insert(0, new Message() { Text = "Where I can find a good one?", IsVisible = true });
            //Messages.Insert(0, new Message() { Text = "Also I'm testing this chat", IsVisible = true });
            //Messages.Insert(0, new Message() { Text = "Oh My God!", IsVisible = true });
            //Messages.Insert(0, new Message() { Text = " No Problem", User = MessageUserEnum.UserLogin.ToDescriptionAttr(), IsVisible = true });
            //Messages.Insert(0, new Message() { Text = "Hugs and Kisses", User = MessageUserEnum.UserLogin.ToDescriptionAttr(), IsVisible = true });
            //Messages.Insert(0, new Message() { Text = "When we are going to meet?", IsVisible = true });
            //Messages.Insert(0, new Message() { Text = "I want to buy a laptop", IsVisible = true });
            //Messages.Insert(0, new Message() { Text = "Where I can find a good one?", IsVisible = true });
            //Messages.Insert(0, new Message() { Text = "Also I'm testing this chat", IsVisible = true });
            //Messages.Insert(0, new Message() { Text = "Oh My God!", IsVisible = true });
            //Messages.Insert(0, new Message() { Text = " No Problem", IsVisible = true });
            //Messages.Insert(0, new Message() { Text = "Hugs and Kisses", IsVisible = true });

            MessageAppearingCommand = new Command<Message>(OnMessageAppearing);
            MessageDisappearingCommand = new Command<Message>(OnMessageDisappearing);

            OnSendCommand = new Command(() =>
            {
                if (!string.IsNullOrEmpty(InputText))
                {
                    //Messages.Insert(0, new Message() { Text = InputText, User = MessageUserEnum.UserLogin.ToDescriptionAttr() });
                    SendCommand(InputText);
                    InputText = string.Empty;
                }

            });

            OnActionSendCommand = new Command(() =>
            {
                if (!string.IsNullOrEmpty(ActionInputText))
                {
                    //Messages.Insert(0, new Message() { Text = InputText, User = MessageUserEnum.UserLogin.ToDescriptionAttr() });
                    SendCommand(ActionInputText);
                    ActionInputText = string.Empty;
                }

            });

            ////Code to simulate reveing a new message procces
            //Device.StartTimer(TimeSpan.FromSeconds(5), () =>
            //{
            //    if (LastMessageVisible)
            //    {
            //        Messages.Insert(0, new Message() { Text = "New message test by rab", User = MessageUserEnum.UserLogin.ToDescriptionAttr() });
            //    }
            //    else
            //    {
            //        DelayedMessages.Enqueue(new Message() { Text = "New message test by rab", User = MessageUserEnum.UserLogin.ToDescriptionAttr() });
            //        PendingMessageCount++;
            //    }
            //    return true;
            //});

        }

        private static ChatDatabase _chatDatabase;
        // Create the database connection as a singleton.
        public static ChatDatabase ChatDatabase
        {
            get
            {
                if (_chatDatabase == null)
                {
                    _chatDatabase = new ChatDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "xfcmapp_db.db3"));
                }
                return _chatDatabase;
            }
        }

        void OnMessageAppearing(Message message)
        {
            var idx = Messages.IndexOf(message);
            if (idx <= 8)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    //while (DelayedMessages.Count > 0)
                    //{
                    //    Messages.Insert(0, DelayedMessages.Dequeue());
                    //}
                    ShowScrollTap = false;
                    //LastMessageVisible = true;
                    //PendingMessageCount = 0;
                });
            }
        }

        void OnMessageDisappearing(Message message)
        {
            var idx = Messages.IndexOf(message);
            if (idx >= 8)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    ShowScrollTap = true;
                    //LastMessageVisible = false;
                });

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
        public void InsertMessages(RapidProFcmPushNotification rapidProFcmPushNotification)
        {
            var message = new Message() { Text = rapidProFcmPushNotification.Body, Value = rapidProFcmPushNotification.Body, User = MessageUserEnum.UserHealthBuddy.ToDescriptionAttr(), MessageAction = false, IsVisible = true, ChannelId = _firebaseContainer.FirebaseChannelId, CreatedDateTime = DateTime.UtcNow };
            InsertChatMessage(message);


            if (rapidProFcmPushNotification.QuickReplies != null)
            {
                var quickReplies = JsonConvert.DeserializeObject<List<string>>(rapidProFcmPushNotification.QuickReplies);
                if (quickReplies != null)
                {
                    string messageId = Guid.NewGuid().ToString();
                    foreach (var quickReplie in quickReplies)
                    {
                        var messageQuickReplie = new Message() { Id = messageId, Text = quickReplie, Value = quickReplie, User = MessageUserEnum.UserHealthBuddy.ToDescriptionAttr(), MessageAction = true, IsVisible = false, ChannelId = _firebaseContainer.FirebaseChannelId, CreatedDateTime = DateTime.UtcNow };
                        InsertChatMessage(messageQuickReplie);
                    }
                }
            }
        }

        private async void GetChatMessages()
        {
            try
            {
                var messages = await ChatDatabase.GetMessagesByChannelIdAsync(_firebaseContainer.FirebaseChannelId);
                if (messages != null)
                {
                    foreach (var message in messages)
                    {
                        Messages.Insert(0, message);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ChatPageViewModel - GetChatMessages: Exception - {ex.Message.ToString()}");
            }
        }

        private async void GetChatMessage(string id)
        {
            try
            {
                var message = await ChatDatabase.GetMessageAsync(id);
                if (message != null)
                {
                    Messages.Insert(0, message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ChatPageViewModel - GetChatMessage: Exception - {ex.Message.ToString()}");
            }
        }

        private async void InsertChatMessage(Message message)
        {
            try
            {
                if (message != null)
                {
                    Messages.Insert(0, message);
                    await ChatDatabase.InsertMessageAsync(message);
                    if (_rapidProContainer.RapidProIsChatDatabase == false)
                    {
                        _rapidProContainer.RapidProIsChatDatabase = true;
                        Console.WriteLine($"ChatPageViewModel - InsertChatMessage: RapidProChatDatabase");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ChatPageViewModel - InsertChatMessage: Exception - {ex.Message.ToString()}");
            }
        }

        private async void DeleteChatMessage(Message message)
        {
            try
            {
                if (message != null)
                {
                    Messages.Remove(message);
                    await ChatDatabase.DeleteMessageAsync(message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ChatPageViewModel - DeleteChatMessage: Exception - {ex.Message.ToString()}");
            }
        }

        #region RapidPro Fcm Push Notification

        private async void InitializeFcmAndRapidPro()
        {
            try
            {
                if (_rapidProContainer.RapidProIsChatDatabase == true)
                {
                    GetChatMessages();

                    Console.WriteLine($"ChatPageViewModel - InitializeFcmAndRapidPro: ChatDatabase");
                }
                else
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
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ChatPageViewModel - InitializeFcmAndRapidPro: Exception - {ex.Message.ToString()}");
            }
        }

        private async Task RapidProRegisterAndReceiveInit()
        {
            try
            {
                string rapidProUrn = _rapidProContainer.RapidProUrn;
                string rapidProFcmToken = _rapidProContainer.RapidProFcmToken;

                if (_rapidProContainer.RapidProIsInit == false)
                {
                    if (!string.IsNullOrEmpty(rapidProUrn) && !string.IsNullOrEmpty(rapidProFcmToken))
                    {
                        var rapidProRegister = await _rapidProService.RapidProRegister(rapidProUrn, rapidProFcmToken);
                        if (!string.IsNullOrEmpty(rapidProRegister.ContactUuid))
                        {
                            var rapidProReceive = _rapidProService.RapidProReceive(rapidProUrn, rapidProFcmToken, RapidProInitPhrase);
                            _rapidProContainer.RapidProIsInit = true;
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
                    if (_rapidProContainer.RapidProIsInit == true)
                    {
                        var message = new Message() { Text = RapidProInitMsgPhrase, User = MessageUserEnum.UserLogin.ToDescriptionAttr(), IsVisible = true, ChannelId = _firebaseContainer.FirebaseChannelId, CreatedDateTime = DateTime.UtcNow };
                        InsertChatMessage(message);
                        var rapidProReceive = _rapidProService.RapidProReceive(rapidProUrn, rapidProFcmToken, inputText);
                        _rapidProContainer.RapidProIsInitMsg = true;
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
                    //if (_rapidProContainer.RapidProIsInit == true && _rapidProContainer.RapidProIsInitMsg == true)
                    if (_rapidProContainer.RapidProIsInit == true)
                    {
                        var message = new Message() { Text = inputText, Value = inputText, User = MessageUserEnum.UserLogin.ToDescriptionAttr(), IsVisible = true, ChannelId = _firebaseContainer.FirebaseChannelId, CreatedDateTime = DateTime.UtcNow };
                        InsertChatMessage(message);

                        var rapidProReceive = _rapidProService.RapidProReceive(rapidProUrn, rapidProFcmToken, inputText);
                        _rapidProContainer.RapidProIsInitSend = true;
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
