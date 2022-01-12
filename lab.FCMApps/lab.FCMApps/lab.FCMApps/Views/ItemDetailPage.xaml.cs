using lab.FCMApps.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace lab.FCMApps.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}