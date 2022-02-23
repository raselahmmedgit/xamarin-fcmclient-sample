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
        public MainPage()
        {
            InitializeComponent();
        }

        private void BtnRapidProInit_Clicked(object sender, EventArgs e)
        {
            try
            {
                //string rapidProUrn = _rapidProContainer.RapidProUrn;
                //string rapidProFcmToken = _rapidProContainer.RapidProFcmToken;

                //if (!string.IsNullOrEmpty(rapidProUrn) && !string.IsNullOrEmpty(rapidProFcmToken))
                //{
                //    var rapidProRegister = await _rapidProService.RapidProRegister(rapidProUrn, rapidProFcmToken);
                //    if (!string.IsNullOrEmpty(rapidProRegister.ContactUuid))
                //    {
                //        _rapidProContainer.RapidProRegisterDone = true;
                //        var rapidProReceive = await _rapidProService.RapidProReceive(rapidProUrn, rapidProFcmToken, RapidProInitPhrase);
                //    }
                //}

            }
            catch (Exception ex)
            {
                Console.WriteLine($"MainPage - BtnRapidProInit_Clicked: Exception - {ex.Message.ToString()}");
            }
        }

        private void BtnRapidProQuickReplies_Clicked(object sender, EventArgs e)
        {
            try
            {
                //string rapidProUrn = _rapidProContainer.RapidProUrn;
                //string rapidProFcmToken = _rapidProContainer.RapidProFcmToken;

                //if (!string.IsNullOrEmpty(rapidProUrn) && !string.IsNullOrEmpty(rapidProFcmToken))
                //{
                //    var rapidProReceive = await _rapidProService.RapidProReceive(rapidProUrn, rapidProFcmToken, "test_rasel");
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine($"MainPage - BtnRapidProQuickReplies_Clicked: Exception - {ex.Message.ToString()}");
            }
        }

        private void BtnRapidProEnd_Clicked(object sender, EventArgs e)
        {
            try
            {
                //string rapidProUrn = _rapidProContainer.RapidProUrn;
                //string rapidProFcmToken = _rapidProContainer.RapidProFcmToken;

                //if (!string.IsNullOrEmpty(rapidProUrn) && !string.IsNullOrEmpty(rapidProFcmToken))
                //{
                //    var rapidProReceive = await _rapidProService.RapidProReceive(rapidProUrn, rapidProFcmToken, "end");
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine($"MainPage - BtnRapidProEnd_Clicked: Exception - {ex.Message.ToString()}");
            }
        }

        private void BtnGoChatPage_Clicked(object sender, EventArgs e)
        {
            try
            {
                App.Current.MainPage = new Chat.ChatPage();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"MainPage - BtnGoChatPage_Clicked: Exception - {ex.Message.ToString()}");
            }
        }

        private void BtnGoPollPage_Clicked(object sender, EventArgs e)
        {
            try
            {
                App.Current.MainPage = new Poll.PollPage();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"MainPage - BtnGoPollPage_Clicked: Exception - {ex.Message.ToString()}");
            }
        }

        private void BtnInit_Clicked(object sender, EventArgs e)
        {
            try
            {
                //if (string.IsNullOrEmpty(_rapidProContainer.RapidProFcmToken))
                //{
                //    string fcmPushNotificationToken = CrossFirebasePushNotification.Current?.Token;
                //    _rapidProContainer.RapidProFcmToken = fcmPushNotificationToken;

                //    Console.WriteLine($"MainPage - BtnInit_Clicked: Token - {fcmPushNotificationToken}");
                //}

                //if (string.IsNullOrEmpty(_rapidProContainer.RapidProUrn))
                //{
                //    string rapidProUrn = RapidProHelper.GetUrnFromGuid();
                //    _rapidProContainer.RapidProUrn = rapidProUrn;

                //    Console.WriteLine($"MainPage - BtnInit_Clicked: Urn - {rapidProUrn}");
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine($"MainPage - BtnInit_Clicked: Exception - {ex.Message.ToString()}");
            }
        }
    }
}
