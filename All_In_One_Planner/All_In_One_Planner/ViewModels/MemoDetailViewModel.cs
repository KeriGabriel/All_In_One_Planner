using All_In_One_Planner.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace All_In_One_Planner.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class MemoDetailViewModel : BaseViewModel
    {
        private int itemId;
        private string text;
        private string description;
        private string type;
        private DateTime date;
        public int ID
        {
            get => itemId;
            set => SetProperty(ref itemId, value);
        }

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
        public DateTime DateSet
        {
            get => date;
            set => SetProperty(ref date, value);
        }
        public int ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(int itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                ID = item.ID;
                Text = item.Text;
                Type = item.Type;
                Description = item.Description;
                DateSet = item.Date;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
