using All_In_One_Planner.Models;
using All_In_One_Planner.Services;
using All_In_One_Planner.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace All_In_One_Planner.ViewModels
{
    public class MemosViewModel : BaseViewModel
    {
        private Memo _selectedItem;

        public ObservableCollection<Memo> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Memo> ItemTapped { get; }
        public Command<Memo> DeleteItem { get; }
       
       
        public MemosViewModel()
        {
            Title = "Memos";
            Items = new ObservableCollection<Memo>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            ItemTapped = new Command<Memo>(OnItemSelected);
            AddItemCommand = new Command(OnAddItem);
            DeleteItem = new Command<Memo>(OnDelete);
        }
        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();

                var items = await MyAPI.GetMemoAsync(true);

                // var items = await DataStore.GetMemoAsync(true);

                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }
        public Memo SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }     
        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewMemoPage));
        }

        async void OnItemSelected(Memo item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(MemoDetailPage)}?{nameof(MemoDetailViewModel.ItemId)}={item.MemoID}");
        }
        async void OnDelete(Memo item)
        {
            await MyAPI.DeleteMemoAsync(item.MemoID);
            await Application.Current.MainPage.DisplayAlert("Alert ", item.Text+" has been Deleted", "OK");
            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
            await Shell.Current.GoToAsync($"//{nameof(MemosPage)}");           
        }
    }
}