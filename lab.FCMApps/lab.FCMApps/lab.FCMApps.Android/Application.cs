using Android.App;
using Android.OS;
using Android.Runtime;
using Firebase;
using lab.FCMApps.Views;
using Plugin.FirebasePushNotification;
using System;

namespace lab.FCMApps.Droid
{
    [Application]
    public class MainApplication : Application
    {
        public MainApplication(IntPtr handle, JniHandleOwnership transer) : base(handle, transer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();

            //FirebaseApp.InitializeApp(this);

            //Set the default notification channel for your app when running Android Oreo
            if (Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.O)
            {
                //Change for your default notification channel id here
                FirebasePushNotificationManager.DefaultNotificationChannelId = "FirebasePushNotificationChannel";

                //Change for your default notification channel name here
                FirebasePushNotificationManager.DefaultNotificationChannelName = "General";

                FirebasePushNotificationManager.DefaultNotificationChannelImportance = NotificationImportance.Max;
            }

            //If debug you should reset the token each time.
#if DEBUG
            FirebasePushNotificationManager.Initialize(this, true);
#else
            FirebasePushNotificationManager.Initialize(this, false);
#endif

            //Handle notification when app is closed here
            CrossFirebasePushNotification.Current.OnNotificationReceived += (s, p) =>
            {
                Console.WriteLine("MainApplication - OnNotificationReceived");
            };

            CrossFirebasePushNotification.Current.OnNotificationAction += (s, p) =>
            {
                Console.WriteLine("MainApplication - OnNotificationAction");
            };

            CrossFirebasePushNotification.Current.OnNotificationOpened += (s, p) =>
            {
                string googleMessageId = string.Empty;

                //Console.WriteLine(p.Identifier);

                Console.WriteLine("MainApplication - OnNotificationOpened");
                foreach (var data in p.Data)
                {
                    Console.WriteLine($"MainApplication - OnNotificationOpened: {data.Key} : {data.Value}");
                    if (data.Key.Contains("google.message_id"))
                    {
                        googleMessageId = data.Value.ToString();
                        Console.WriteLine($"MainApplication - OnNotificationOpened: google.message_id {googleMessageId}");
                        Xamarin.Forms.Application.Current.MainPage = new NotificationPage(googleMessageId);
                    }
                }

                if (!string.IsNullOrEmpty(p.Identifier))
                {
                    //Device.BeginInvokeOnMainThread(() =>
                    //{
                    //    App.OpenNotification(pp.Identifier);
                    //    //textLabel.Text = p.Identifier;
                    //});
                }
                else if (p.Data.ContainsKey("aps.alert.title"))
                {
                    //Device.BeginInvokeOnMainThread(() =>
                    //{
                    //    //textLabel.Text = p.Data["aps.alert.title"];
                    //});
                }
            };
        }
    }
}