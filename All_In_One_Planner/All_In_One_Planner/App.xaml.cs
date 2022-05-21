using All_In_One_Planner.Models;
using All_In_One_Planner.Services;
using All_In_One_Planner.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace All_In_One_Planner
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            //DependencyService.Register<MockData>();
            DependencyService.Register<PlannerAPIService>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
