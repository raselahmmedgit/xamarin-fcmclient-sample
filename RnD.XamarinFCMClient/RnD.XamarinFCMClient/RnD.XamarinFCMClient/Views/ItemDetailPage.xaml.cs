using RnD.XamarinFCMClient.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace RnD.XamarinFCMClient.Views
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