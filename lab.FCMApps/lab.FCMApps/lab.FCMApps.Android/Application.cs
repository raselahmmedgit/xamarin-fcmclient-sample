using Android.App;
using Android.OS;
using Android.Runtime;
using Firebase;
using lab.FCMApps.ViewModels;
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
                try
                {
                    Console.WriteLine("MainApplication - OnNotificationReceived");
                    var fcmNotificationViewModel = GetFirebasePushNotificationData(p);
                    //Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new NotificationPage(fcmNotificationViewModel));
                    Xamarin.Forms.Application.Current.MainPage = new NotificationPage(fcmNotificationViewModel);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"MainApplication - OnNotificationReceived: Exception - {ex.Message.ToString()}");
                }
            };

            CrossFirebasePushNotification.Current.OnNotificationAction += (s, p) =>
            {
                try
                {
                    Console.WriteLine("MainApplication - OnNotificationAction");
                    var fcmNotificationViewModel = GetFirebasePushNotificationResponse(p);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"MainApplication - OnNotificationAction: Exception - {ex.Message.ToString()}");
                }
                
            };

            CrossFirebasePushNotification.Current.OnNotificationOpened += (s, p) =>
            {
                try
                {
                    Console.WriteLine("MainApplication - OnNotificationOpened");
                    var fcmNotificationViewModel = GetFirebasePushNotificationResponse(p);
                    //Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new NotificationPage(fcmNotificationViewModel));
                    Xamarin.Forms.Application.Current.MainPage = new NotificationPage(fcmNotificationViewModel);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"MainApplication - OnNotificationOpened: Exception - {ex.Message.ToString()}");
                }
            };
        }

        private FcmNotificationViewModel GetFirebasePushNotificationResponse(FirebasePushNotificationResponseEventArgs p)
        {
            try
            {
                FcmNotificationViewModel fcmNotificationViewModel = new FcmNotificationViewModel();

                foreach (var data in p.Data)
                {
                    //Console.WriteLine($"GetFirebasePushNotificationResponse: {data.Key} : {data.Value}");
                    if (data.Key == "title")
                    {
                        fcmNotificationViewModel.Title = data.Value.ToString();
                        Console.WriteLine($"GetFirebasePushNotificationResponse: title - {fcmNotificationViewModel.Title}");
                    }
                    else if (data.Key == "subtitle")
                    {
                        fcmNotificationViewModel.SubTitle = data.Value.ToString();
                        Console.WriteLine($"GetFirebasePushNotificationResponse: sub_title - {fcmNotificationViewModel.SubTitle}");
                    }
                    else if (data.Key == "body")
                    {
                        fcmNotificationViewModel.Body = data.Value.ToString();
                        Console.WriteLine($"GetFirebasePushNotificationResponse: body - {fcmNotificationViewModel.Body}");
                    }
                    else if (data.Key == "priority")
                    {
                        fcmNotificationViewModel.Priority = data.Value.ToString();
                        Console.WriteLine($"GetFirebasePushNotificationResponse: priority - {fcmNotificationViewModel.Priority}");
                    }
                    else if (data.Key == "icon")
                    {
                        fcmNotificationViewModel.Icon = data.Value.ToString();
                        Console.WriteLine($"GetFirebasePushNotificationResponse: icon - {fcmNotificationViewModel.Icon}");
                    }
                    else if (data.Key == "sound")
                    {
                        fcmNotificationViewModel.Sound = data.Value.ToString();
                        Console.WriteLine($"GetFirebasePushNotificationResponse: sound - {fcmNotificationViewModel.Sound}");
                    }
                    else if (data.Key == "chat_data_available")
                    {
                        fcmNotificationViewModel.ChatDataAvailable = Convert.ToBoolean(data.Value);
                        Console.WriteLine($"GetFirebasePushNotificationResponse: chat_data_available - {fcmNotificationViewModel.ChatDataAvailable}");
                    }
                    else if (data.Key == "chat_data")
                    {
                        fcmNotificationViewModel.ChatData = data.Value.ToString();
                        Console.WriteLine($"GetFirebasePushNotificationResponse: chat_data - {fcmNotificationViewModel.ChatData}");
                    }
                }

                return fcmNotificationViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private FcmNotificationViewModel GetFirebasePushNotificationData(FirebasePushNotificationDataEventArgs p)
        {
            try
            {
                FcmNotificationViewModel fcmNotificationViewModel = new FcmNotificationViewModel();

                foreach (var data in p.Data)
                {
                    //Console.WriteLine($"GetFirebasePushNotificationData: {data.Key} : {data.Value}");
                    if (data.Key == "title")
                    {
                        fcmNotificationViewModel.Title = data.Value.ToString();
                        Console.WriteLine($"GetFirebasePushNotificationData: title - {fcmNotificationViewModel.Title}");
                    }
                    else if (data.Key == "subtitle")
                    {
                        fcmNotificationViewModel.SubTitle = data.Value.ToString();
                        Console.WriteLine($"GetFirebasePushNotificationData: sub_title - {fcmNotificationViewModel.SubTitle}");
                    }
                    else if (data.Key == "body")
                    {
                        fcmNotificationViewModel.Body = data.Value.ToString();
                        Console.WriteLine($"GetFirebasePushNotificationData: body - {fcmNotificationViewModel.Body}");
                    }
                    else if (data.Key == "priority")
                    {
                        fcmNotificationViewModel.Priority = data.Value.ToString();
                        Console.WriteLine($"GetFirebasePushNotificationData: priority - {fcmNotificationViewModel.Priority}");
                    }
                    else if (data.Key == "icon")
                    {
                        fcmNotificationViewModel.Icon = data.Value.ToString();
                        Console.WriteLine($"GetFirebasePushNotificationData: icon - {fcmNotificationViewModel.Icon}");
                    }
                    else if (data.Key == "sound")
                    {
                        fcmNotificationViewModel.Sound = data.Value.ToString();
                        Console.WriteLine($"GetFirebasePushNotificationData: sound - {fcmNotificationViewModel.Sound}");
                    }
                    else if (data.Key == "chat_data_available")
                    {
                        fcmNotificationViewModel.ChatDataAvailable = Convert.ToBoolean(data.Value);
                        Console.WriteLine($"GetFirebasePushNotificationData: chat_data_available - {fcmNotificationViewModel.ChatDataAvailable}");
                    }
                    else if (data.Key == "chat_data")
                    {
                        fcmNotificationViewModel.ChatData = data.Value.ToString();
                        Console.WriteLine($"GetFirebasePushNotificationData: chat_data - {fcmNotificationViewModel.ChatData}");
                    }
                }

                return fcmNotificationViewModel;
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
}