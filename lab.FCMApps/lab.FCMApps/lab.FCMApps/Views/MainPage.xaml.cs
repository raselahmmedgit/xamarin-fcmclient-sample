using lab.FCMApps.ViewModels;
using Plugin.FirebasePushNotification;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace lab.FCMApps.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        MainViewModel _viewModel;

        public MainPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new MainViewModel();

            if (Device.RuntimePlatform == Device.iOS)
            {
                CrossFirebasePushNotification.Current.OnNotificationReceived += Current_OnNotificationReceived;
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private void Current_OnNotificationReceived(object source, FirebasePushNotificationDataEventArgs e)
        {
            DisplayAlert("Notification", $"Data: {e.Data["myData"]}", "OK");
        }
    }
}