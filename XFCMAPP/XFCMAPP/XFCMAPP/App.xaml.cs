using Plugin.FirebasePushNotification;
using System;
using Xamarin.Forms;
using XFCMAPP.Service;
using XFCMAPP.Utility;

namespace XFCMAPP
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //InitializeRapidPro();
            //InitializeFcmPushNotification();

            InitializeFcmAndRapidPro();

            MainPage = new MainPage();
        }

        private void InitializeFcmPushNotification()
        {
            CrossFirebasePushNotification.Current.Subscribe("all");
            CrossFirebasePushNotification.Current.OnTokenRefresh += Current_OnTokenRefresh;
        }

        private void InitializeRapidPro()
        {
            RapidProContainer rapidProContainer = new RapidProContainer();
            if (string.IsNullOrEmpty(rapidProContainer.RapidProUrn))
            {
                string rapidProUrn = RapidProHelper.GetUrnFromGuid();
                rapidProContainer.RapidProUrn = rapidProUrn;

                Console.WriteLine($"App - InitializeRapidPro: Urn - {rapidProUrn}");
            }
        }

        private void Current_OnTokenRefresh(object source, FirebasePushNotificationTokenEventArgs e)
        {
            RapidProContainer rapidProContainer = new RapidProContainer();

            if (string.IsNullOrEmpty(rapidProContainer.RapidProFcmToken))
            {
                string fcmPushNotificationToken = e.Token;
                rapidProContainer.RapidProFcmToken = fcmPushNotificationToken;

                Console.WriteLine($"App - Current_OnTokenRefresh: {fcmPushNotificationToken}");
            }
        }

        private void InitializeFcmAndRapidPro()
        {
            CrossFirebasePushNotification.Current.Subscribe("all");

            RapidProContainer rapidProContainer = new RapidProContainer();

            if (string.IsNullOrEmpty(rapidProContainer.RapidProFcmToken))
            {
                string fcmPushNotificationToken = CrossFirebasePushNotification.Current?.Token;
                rapidProContainer.RapidProFcmToken = fcmPushNotificationToken;

                Console.WriteLine($"App - InitializeFcmAndRapidPro: Token - {fcmPushNotificationToken}");
            }

            if (string.IsNullOrEmpty(rapidProContainer.RapidProUrn))
            {
                string rapidProUrn = RapidProHelper.GetUrnFromGuid();
                rapidProContainer.RapidProUrn = rapidProUrn;

                Console.WriteLine($"App - InitializeFcmAndRapidPro: Urn - {rapidProUrn}");
            }

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
