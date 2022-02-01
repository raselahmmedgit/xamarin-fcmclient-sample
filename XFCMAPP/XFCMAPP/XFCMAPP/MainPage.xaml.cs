using Plugin.FirebasePushNotification;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFCMAPP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

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


        private void Current_OnNotificationAction(object source, FirebasePushNotificationResponseEventArgs e)
        {
            try
            {
                Console.WriteLine("MainPage - OnNotificationAction");

                Console.WriteLine($"MainPage - OnNotificationAction: Data - title - {e.Data["title"]}");
                Console.WriteLine($"MainPage - OnNotificationAction: Data - body - {e.Data["body"]}");
                Console.WriteLine($"MainPage - OnNotificationAction: Data - type - {e.Data["type"]}");
                Console.WriteLine($"MainPage - OnNotificationAction: Data - message_id - {e.Data["message_id"]}");
                Console.WriteLine($"MainPage - OnNotificationAction: Data - message - {e.Data["message"]}");
                Console.WriteLine($"MainPage - OnNotificationAction: Data - quick_replies - {e.Data["quick_replies"]}");
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

                Console.WriteLine($"MainPage - OnNotificationOpened: Data - title - {e.Data["title"]}");
                Console.WriteLine($"MainPage - OnNotificationOpened: Data - body - {e.Data["body"]}");
                Console.WriteLine($"MainPage - OnNotificationOpened: Data - type - {e.Data["type"]}");
                Console.WriteLine($"MainPage - OnNotificationOpened: Data - message_id - {e.Data["message_id"]}");
                Console.WriteLine($"MainPage - OnNotificationOpened: Data - message - {e.Data["message"]}");
                Console.WriteLine($"MainPage - OnNotificationOpened: Data - quick_replies - {e.Data["quick_replies"]}");
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

                Console.WriteLine($"MainPage - OnNotificationReceived: Data - title - {e.Data["title"]}");
                Console.WriteLine($"MainPage - OnNotificationReceived: Data - body - {e.Data["body"]}");
                Console.WriteLine($"MainPage - OnNotificationReceived: Data - type - {e.Data["type"]}");
                Console.WriteLine($"MainPage - OnNotificationReceived: Data - message_id - {e.Data["message_id"]}");
                Console.WriteLine($"MainPage - OnNotificationReceived: Data - message - {e.Data["message"]}");
                Console.WriteLine($"MainPage - OnNotificationReceived: Data - quick_replies - {e.Data["quick_replies"]}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"MainPage - OnNotificationReceived: Exception - {ex.Message.ToString()}");
            }
        }
    }
}
