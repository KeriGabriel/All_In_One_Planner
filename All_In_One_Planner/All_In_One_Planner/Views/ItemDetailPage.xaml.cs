using All_In_One_Planner.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace All_In_One_Planner.Views
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