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

        private void InitializeFcmAndRapidPro()
        {
            CrossFirebasePushNotification.Current.Subscribe("all");
            CrossFirebasePushNotification.Current.OnTokenRefresh += Current_OnTokenRefresh;

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

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        public void ClearNavigationAndGoToPage(ContentPage page)
        {
            if (page is MainPage)
            {
                MainPage = new NavigationPage(new MainPage());
            }
            else
            {
                MainPage = page;
            }
        }
    }
}
