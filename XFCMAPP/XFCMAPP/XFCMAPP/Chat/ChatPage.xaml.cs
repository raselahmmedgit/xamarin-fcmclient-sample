using Newtonsoft.Json;
using Plugin.FirebasePushNotification;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFCMAPP.Chat.Helpers;
using XFCMAPP.Chat.Models;
using XFCMAPP.Chat.ViewModels;
using XFCMAPP.Utility;
using XFCMAPP.ViewModel;

namespace XFCMAPP.Chat
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatPage : ContentPage
    {
        private readonly ChatPageViewModel _chatPageViewModel;
        
        public ChatPage()
        {
            InitializeComponent();
            //this.BindingContext = new ChatPageViewModel();
            this.BindingContext = _chatPageViewModel = new ChatPageViewModel();

            if (Device.RuntimePlatform == Device.Android)
            {
                CrossFirebasePushNotification.Current.OnNotificationAction += Current_OnNotificationAction;
                CrossFirebasePushNotification.Current.OnNotificationOpened += Current_OnNotificationOpened;
                CrossFirebasePushNotification.Current.OnNotificationReceived += Current_OnNotificationReceived;
            }

            if (Device.RuntimePlatform == Device.iOS)
            {
                CrossFirebasePushNotification.Current.OnNotificationAction += Current_OnNotificationAction;
                CrossFirebasePushNotification.Current.OnNotificationOpened += Current_OnNotificationOpened;
                CrossFirebasePushNotification.Current.OnNotificationReceived += Current_OnNotificationReceived;
            }
        }

        public void ScrollTap(object sender, System.EventArgs e)
        {
            lock (new object())
            {
                if (BindingContext != null)
                {
                    var vm = BindingContext as ChatPageViewModel;

                    Device.BeginInvokeOnMainThread(() =>
                    {
                        //while (vm.DelayedMessages.Count > 0)
                        //{
                        //    vm.Messages.Insert(0, vm.DelayedMessages.Dequeue());
                        //}
                        vm.ShowScrollTap = false;
                        vm.LastMessageVisible = true;
                        //vm.PendingMessageCount = 0;
                        ChatList?.ScrollToFirst();
                    });


                }

            }
        }

        public void OnListTapped(object sender, ItemTappedEventArgs e)
        {
            chatInput.UnFocusEntry();
        }

        
        private void Current_OnNotificationAction(object source, FirebasePushNotificationResponseEventArgs e)
        {
            try
            {
                Console.WriteLine("ChatPage - OnNotificationAction");

                if (e.Data != null)
                {
                    var rapidProFcmPushNotification = new RapidProFcmPushNotification();

                    foreach (var item in e.Data)
                    {
                        if (item.Key.Contains("title"))
                        {
                            Console.WriteLine($"ChatPage - OnNotificationAction: Data - title - {item.Value}");
                        }
                        else if (item.Key.Contains("body"))
                        {
                            Console.WriteLine($"ChatPage - OnNotificationAction: Data - body - {item.Value}");
                        }
                        else if (item.Key.Contains("type"))
                        {
                            Console.WriteLine($"ChatPage - OnNotificationAction: Data - type - {item.Value}");
                        }
                        else if (item.Key.Contains("message_id"))
                        {
                            Console.WriteLine($"ChatPage - OnNotificationAction: Data - message_id - {item.Value}");
                        }
                        else if (item.Key.Contains("message"))
                        {
                            Console.WriteLine($"ChatPage - OnNotificationAction: Data - message - {item.Value}");
                        }
                        else if (item.Key.Contains("quick_replies"))
                        {
                            Console.WriteLine($"ChatPage - OnNotificationAction: Data - quick_replies - {item.Value}");
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"ChatPage - OnNotificationAction: Exception - {ex.Message.ToString()}");
            }
        }

        private void Current_OnNotificationOpened(object source, FirebasePushNotificationResponseEventArgs e)
        {
            try
            {
                Console.WriteLine("ChatPage - OnNotificationOpened");

                if (e.Data != null)
                {
                    var rapidProFcmPushNotification = new RapidProFcmPushNotification();

                    foreach (var item in e.Data)
                    {
                        if (item.Key.Contains("title"))
                        {
                            Console.WriteLine($"ChatPage - OnNotificationOpened: Data - title - {item.Value}");
                        }
                        else if (item.Key.Contains("body"))
                        {
                            Console.WriteLine($"ChatPage - OnNotificationOpened: Data - body - {item.Value}");
                        }
                        else if (item.Key.Contains("type"))
                        {
                            Console.WriteLine($"ChatPage - OnNotificationOpened: Data - type - {item.Value}");
                        }
                        else if (item.Key.Contains("message_id"))
                        {
                            Console.WriteLine($"ChatPage - OnNotificationOpened: Data - message_id - {item.Value}");
                        }
                        else if (item.Key.Contains("message"))
                        {
                            Console.WriteLine($"ChatPage - OnNotificationOpened: Data - message - {item.Value}");
                        }
                        else if (item.Key.Contains("quick_replies"))
                        {
                            Console.WriteLine($"ChatPage - OnNotificationOpened: Data - quick_replies - {item.Value}");
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"ChatPage - OnNotificationOpened: Exception - {ex.Message.ToString()}");
            }
        }

        private void Current_OnNotificationReceived(object source, FirebasePushNotificationDataEventArgs e)
        {
            try
            {
                Console.WriteLine("ChatPage - OnNotificationReceived");

                if (e.Data != null)
                {
                    var rapidProFcmPushNotification = new RapidProFcmPushNotification();

                    foreach (var item in e.Data)
                    {
                        if (item.Key.Contains("title"))
                        {
                            Console.WriteLine($"ChatPage - OnNotificationReceived: Data - title - {item.Value}");
                            rapidProFcmPushNotification.Title = item.Value.ToString();
                        }
                        else if (item.Key.Contains("body"))
                        {
                            Console.WriteLine($"ChatPage - OnNotificationReceived: Data - body - {item.Value}");
                            rapidProFcmPushNotification.Body = item.Value.ToString();
                        }
                        else if (item.Key.Contains("type"))
                        {
                            Console.WriteLine($"ChatPage - OnNotificationReceived: Data - type - {item.Value}");
                            rapidProFcmPushNotification.Type = item.Value.ToString();
                        }
                        else if (item.Key.Contains("message_id"))
                        {
                            Console.WriteLine($"ChatPage - OnNotificationReceived: Data - message_id - {item.Value}");
                            rapidProFcmPushNotification.MessageId = item.Value.ToString();
                        }
                        else if (item.Key.Contains("message"))
                        {
                            Console.WriteLine($"ChatPage - OnNotificationReceived: Data - message - {item.Value}");
                            rapidProFcmPushNotification.Message = item.Value.ToString();
                        }
                        else if (item.Key.Contains("quick_replies"))
                        {
                            Console.WriteLine($"ChatPage - OnNotificationReceived: Data - quick_replies - {item.Value}");
                            rapidProFcmPushNotification.QuickReplies = item.Value.ToString();
                        }
                    }

                    if (rapidProFcmPushNotification != null)
                    {
                        _chatPageViewModel.Messages.Insert(0, new Message() { Text = rapidProFcmPushNotification.Body, Value = rapidProFcmPushNotification.Body, User = MessageUserEnum.UserHealthBuddy.ToDescriptionAttr(), MessageAction = false });

                        if (rapidProFcmPushNotification.QuickReplies != null)
                        {
                            var quickReplies = JsonConvert.DeserializeObject<List<string>>(rapidProFcmPushNotification.QuickReplies);
                            if (quickReplies != null)
                            {
                                foreach (var quickReplie in quickReplies)
                                {
                                    _chatPageViewModel.Messages.Insert(0, new Message() { Text = quickReplie, Value = quickReplie, User = MessageUserEnum.UserHealthBuddy.ToDescriptionAttr(), MessageAction = true });
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"ChatPage - OnNotificationReceived: Exception - {ex.Message.ToString()}");
            }
        }

    }
}