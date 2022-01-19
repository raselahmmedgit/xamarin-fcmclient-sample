using lab.FCMApps.ViewModels;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace lab.FCMApps.Views
{
    public partial class AboutPage : ContentPage
    {
        AboutViewModel _viewModel;

        public AboutPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new AboutViewModel();

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}