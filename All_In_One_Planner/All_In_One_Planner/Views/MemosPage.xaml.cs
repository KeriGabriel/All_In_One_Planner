using All_In_One_Planner.Models;
using All_In_One_Planner.ViewModels;
using All_In_One_Planner.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using All_In_One_Planner.Services;

namespace All_In_One_Planner.Views
{
    public partial class MemosPage : ContentPage
    {
        MemosViewModel _viewModel;
        private PlannerAPIService _plannerAPIService = new PlannerAPIService();

        public MemosPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new MemosViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}