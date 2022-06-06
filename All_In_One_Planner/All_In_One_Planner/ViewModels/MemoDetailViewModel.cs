using All_In_One_Planner.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace All_In_One_Planner.ViewModels
{
    [QueryProperty(nameof(MemoId), nameof(MemoId))]
    public class MemoDetailViewModel : BaseViewModel
    {
        private string itemId;
        private string text;
        private string description;
        private string type;
        private DateTime date;
        public string ID {get;set;}

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
        public string MemoId
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

        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await MyAPI.GetMemoAsync(itemId);


                ID = item.MemoID;
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
