using All_In_One_Planner.Models;
using All_In_One_Planner.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace All_In_One_Planner.Views
{
    public partial class NewMemoPage : ContentPage
    {
        public Memo Item { get; set; }

        public NewMemoPage()
        {
            InitializeComponent();
            BindingContext = new NewMemoViewModel();
        }
    }
}