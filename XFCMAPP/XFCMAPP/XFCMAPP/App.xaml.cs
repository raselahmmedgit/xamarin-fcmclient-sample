using Plugin.FirebasePushNotification;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFCMAPP.Services;
using XFCMAPP.Utility;

namespace XFCMAPP
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();

            InitializeFcmPushNotification();
            InitializeRapidPro();

        }

        private void InitializeFcmPushNotification()
        {
            CrossFirebasePushNotification.Current.Subscribe("all");
            CrossFirebasePushNotification.Current.OnTokenRefresh += Current_OnTokenRefresh;
        }

        private void InitializeRapidPro()
        {
            RapidProService rapidProService = new RapidProService();
            string rapidProUrn = RapidProHelper.GetUrnFromGuid();
            rapidProService.RapidProUrn = rapidProUrn;
        }

        private void Current_OnTokenRefresh(object source, FirebasePushNotificationTokenEventArgs e)
        {
            RapidProService rapidProService = new RapidProService();
            string fcmPushNotificationToken = e.Token;
            rapidProService.RapidProFcmToken = fcmPushNotificationToken;
            Console.WriteLine($"App - Current_OnTokenRefresh: {fcmPushNotificationToken}");
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
