using All_In_One_Planner.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading;
namespace All_In_One_Planner.ViewModels
{
    public class NewMemoViewModel : BaseViewModel
    {
        //private int _id;
        private string text;
        private string description;
        private string type;
        private DateTime date;
        public NewMemoViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(text)
                && !String.IsNullOrWhiteSpace(description);
        }

        //public int GenerateId(int _id)
        //{

        //    {
        //        Interlocked.Increment(ref _id);
        //    }
        //    return _id;
        //}

        // Remainder of Program unchange
        //public int ID 
        //{
        //    get => _id;
        //    set => SetProperty(ref _id, value);
        //}
        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }
        public string Type
        {
            get => type;
            set => SetProperty(ref type, value);
        }
        public DateTime Date
        {
            get => date;
            set => SetProperty(ref date, value);
        }
        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
        private async void OnSave()
        {
            Item newItem = new Item()
            {
                //ID = GenerateId(_id),
                Text = Text,
                Description = Description,
                Date = Date,
                Type = Type
            };

            await DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
