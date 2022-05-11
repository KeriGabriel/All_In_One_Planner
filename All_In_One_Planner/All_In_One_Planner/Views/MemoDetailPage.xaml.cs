using All_In_One_Planner.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace All_In_One_Planner.Views
{
    public partial class MemoDetailPage : ContentPage
    {
        public MemoDetailPage()
        {
            InitializeComponent();
            BindingContext = new MemoDetailViewModel();
        }
    }
}