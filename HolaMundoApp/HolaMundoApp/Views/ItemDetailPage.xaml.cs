using HolaMundoApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace HolaMundoApp.Views
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