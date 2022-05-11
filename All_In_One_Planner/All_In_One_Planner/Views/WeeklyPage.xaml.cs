using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using All_In_One_Planner.Models;
using All_In_One_Planner.ViewModels;

namespace All_In_One_Planner.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeeklyPage : ContentPage
    {
        public WeeklyPage()
        {
            InitializeComponent();
            BindingContext = new CalendarViewModel();
        }
    }
}