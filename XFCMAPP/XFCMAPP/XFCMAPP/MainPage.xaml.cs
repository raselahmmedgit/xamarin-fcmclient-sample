using Plugin.FirebasePushNotification;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFCMAPP.Service;
using XFCMAPP.Utility;

namespace XFCMAPP
{
    public partial class MainPage : ContentPage
    {
        private readonly RapidProContainer _rapidProContainer;
        private readonly RapidProService _rapidProService;
        private const string RapidProInitPhrase = "riseup";

        public MainPage()
        {
            InitializeComponent();

            _rapidProContainer = new RapidProContainer();
            _rapidProService = new RapidProService();

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

        private void InitializeFcmAndRapidPro()
        {
            if (string.IsNullOrEmpty(_rapidProContainer.RapidProFcmToken))
            {
                string fcmPushNotificationToken = CrossFirebasePushNotification.Current?.Token;
                _rapidProContainer.RapidProFcmToken = fcmPushNotificationToken;

                Console.WriteLine($"MainPage - InitializeFcmAndRapidPro: Token - {fcmPushNotificationToken}");
            }

            if (string.IsNullOrEmpty(_rapidProContainer.RapidProUrn))
            {
                string rapidProUrn = RapidProHelper.GetUrnFromGuid();
                _rapidProContainer.RapidProUrn = rapidProUrn;

                Console.WriteLine($"MainPage - InitializeFcmAndRapidPro: Urn - {rapidProUrn}");
            }
        }

        private async void RapidProRegisterAndReceive()
        {
            try
            {
                string rapidProUrn = _rapidProContainer.RapidProUrn;
                string rapidProFcmToken = _rapidProContainer.RapidProFcmToken;

                if (_rapidProContainer.RapidProRegisterDone)
                {
                    var rapidProReceive = await _rapidProService.RapidProReceive(rapidProUrn, rapidProFcmToken, "test_rasel");
                }
                else
                {
                    if (!string.IsNullOrEmpty(rapidProUrn) && !string.IsNullOrEmpty(rapidProFcmToken))
                    {
                        var rapidProRegister = await _rapidProService.RapidProRegister(rapidProUrn, rapidProFcmToken);
                        if (!string.IsNullOrEmpty(rapidProRegister.ContactUuid))
                        {
                            _rapidProContainer.RapidProRegisterDone = true;
                            var rapidProReceive = await _rapidProService.RapidProReceive(rapidProUrn, rapidProFcmToken, RapidProInitPhrase);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"MainPage - RapidProRegister: Exception - {ex.Message.ToString()}");
            }
        }

        private void Current_OnNotificationAction(object source, FirebasePushNotificationResponseEventArgs e)
        {
            try
            {
                Console.WriteLine("MainPage - OnNotificationAction");

                if (e.Data != null)
                {
                    string msg = $"title: {e.Data["title"]}, message: {e.Data["message"]}";

                    foreach (var item in e.Data)
                    {
                        if (item.Key.Contains("title"))
                        {
                            Console.WriteLine($"MainPage - OnNotificationAction: Data - title - {item.Value}");
                        }
                        else if (item.Key.Contains("body"))
                        {
                            Console.WriteLine($"MainPage - OnNotificationAction: Data - body - {item.Value}");
                        }
                        else if (item.Key.Contains("type"))
                        {
                            Console.WriteLine($"MainPage - OnNotificationAction: Data - type - {item.Value}");
                        }
                        else if (item.Key.Contains("message_id"))
                        {
                            Console.WriteLine($"MainPage - OnNotificationAction: Data - message_id - {item.Value}");
                        }
                        else if (item.Key.Contains("message"))
                        {
                            Console.WriteLine($"MainPage - OnNotificationAction: Data - message - {item.Value}");
                        }
                        else if (item.Key.Contains("quick_replies"))
                        {
                            Console.WriteLine($"MainPage - OnNotificationAction: Data - quick_replies - {item.Value}");
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"MainPage - OnNotificationAction: Exception - {ex.Message.ToString()}");
            }
        }

        private void Current_OnNotificationOpened(object source, FirebasePushNotificationResponseEventArgs e)
        {
            try
            {
                Console.WriteLine("MainPage - OnNotificationOpened");

                if (e.Data != null)
                {
                    string msg = $"title: {e.Data["title"]}, message: {e.Data["message"]}";

                    foreach (var item in e.Data)
                    {
                        if(item.Key.Contains("title"))
                        {
                            Console.WriteLine($"MainPage - OnNotificationOpened: Data - title - {item.Value}");
                        }
                        else if (item.Key.Contains("body"))
                        {
                            Console.WriteLine($"MainPage - OnNotificationOpened: Data - body - {item.Value}");
                        }
                        else if (item.Key.Contains("type"))
                        {
                            Console.WriteLine($"MainPage - OnNotificationOpened: Data - type - {item.Value}");
                        }
                        else if (item.Key.Contains("message_id"))
                        {
                            Console.WriteLine($"MainPage - OnNotificationOpened: Data - message_id - {item.Value}");
                        }
                        else if (item.Key.Contains("message"))
                        {
                            Console.WriteLine($"MainPage - OnNotificationOpened: Data - message - {item.Value}");
                        }
                        else if (item.Key.Contains("quick_replies"))
                        {
                            Console.WriteLine($"MainPage - OnNotificationOpened: Data - quick_replies - {item.Value}");
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"MainPage - OnNotificationOpened: Exception - {ex.Message.ToString()}");
            }
        }

        private void Current_OnNotificationReceived(object source, FirebasePushNotificationDataEventArgs e)
        {
            try
            {
                Console.WriteLine("MainPage - OnNotificationReceived");

                if (e.Data != null)
                {
                    string msg = $"title: {e.Data["title"]}, message: {e.Data["message"]}";

                    foreach (var item in e.Data)
                    {
                        if (item.Key.Contains("title"))
                        {
                            Console.WriteLine($"MainPage - OnNotificationReceived: Data - title - {item.Value}");
                        }
                        else if (item.Key.Contains("body"))
                        {
                            Console.WriteLine($"MainPage - OnNotificationReceived: Data - body - {item.Value}");
                        }
                        else if (item.Key.Contains("type"))
                        {
                            Console.WriteLine($"MainPage - OnNotificationReceived: Data - type - {item.Value}");
                        }
                        else if (item.Key.Contains("message_id"))
                        {
                            Console.WriteLine($"MainPage - OnNotificationReceived: Data - message_id - {item.Value}");
                        }
                        else if (item.Key.Contains("message"))
                        {
                            Console.WriteLine($"MainPage - OnNotificationReceived: Data - message - {item.Value}");
                        }
                        else if (item.Key.Contains("quick_replies"))
                        {
                            Console.WriteLine($"MainPage - OnNotificationReceived: Data - quick_replies - {item.Value}");
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"MainPage - OnNotificationReceived: Exception - {ex.Message.ToString()}");
            }
        }

        private async void BtnRapidProInit_Clicked(object sender, EventArgs e)
        {
            try
            {
                string rapidProUrn = _rapidProContainer.RapidProUrn;
                string rapidProFcmToken = _rapidProContainer.RapidProFcmToken;

                if (!string.IsNullOrEmpty(rapidProUrn) && !string.IsNullOrEmpty(rapidProFcmToken))
                {
                    var rapidProRegister = await _rapidProService.RapidProRegister(rapidProUrn, rapidProFcmToken);
                    if (!string.IsNullOrEmpty(rapidProRegister.ContactUuid))
                    {
                        _rapidProContainer.RapidProRegisterDone = true;
                        var rapidProReceive = await _rapidProService.RapidProReceive(rapidProUrn, rapidProFcmToken, RapidProInitPhrase);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"MainPage - BtnRapidProInit_Clicked: Exception - {ex.Message.ToString()}");
            }
        }

        private async void BtnRapidProQuickReplies_Clicked(object sender, EventArgs e)
        {
            try
            {
                string rapidProUrn = _rapidProContainer.RapidProUrn;
                string rapidProFcmToken = _rapidProContainer.RapidProFcmToken;

                if (!string.IsNullOrEmpty(rapidProUrn) && !string.IsNullOrEmpty(rapidProFcmToken))
                {
                    var rapidProReceive = await _rapidProService.RapidProReceive(rapidProUrn, rapidProFcmToken, "test_rasel");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"MainPage - BtnRapidProQuickReplies_Clicked: Exception - {ex.Message.ToString()}");
            }
        }

        private async void BtnRapidProEnd_Clicked(object sender, EventArgs e)
        {
            try
            {
                string rapidProUrn = _rapidProContainer.RapidProUrn;
                string rapidProFcmToken = _rapidProContainer.RapidProFcmToken;

                if (!string.IsNullOrEmpty(rapidProUrn) && !string.IsNullOrEmpty(rapidProFcmToken))
                {
                    var rapidProReceive = await _rapidProService.RapidProReceive(rapidProUrn, rapidProFcmToken, "end");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"MainPage - BtnRapidProEnd_Clicked: Exception - {ex.Message.ToString()}");
            }
        }

        private void BtnInit_Clicked(object sender, EventArgs e)
        {
            try
            {
                InitializeFcmAndRapidPro();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"MainPage - BtnInit_Clicked: Exception - {ex.Message.ToString()}");
            }
        }
    }
}
