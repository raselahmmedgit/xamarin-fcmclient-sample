using lab.FCMApps.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace lab.FCMApps.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotificationPage : ContentPage
    {
        NotificationViewModel _viewModel;

        public NotificationPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new NotificationViewModel();
        }

        public NotificationPage(string notificationId)
        {
            InitializeComponent();

            BindingContext = _viewModel = new NotificationViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}