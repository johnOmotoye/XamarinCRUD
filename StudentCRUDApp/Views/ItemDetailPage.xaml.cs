using StudentCRUDApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace StudentCRUDApp.Views
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