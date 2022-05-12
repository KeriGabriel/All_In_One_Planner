using All_In_One_Planner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace All_In_One_Planner.Services
{
    public class MockDataStore : IDataStore<Memo>
    {
        readonly List<Memo> items;

        public MockDataStore()
        {
            items = new List<Memo>()
            {
                new Memo { MemoID = 0, Text = "Christmas", Description="Christmas Shopping.", Date=new DateTime(2022, 12, 25) },
                new Memo { MemoID = 1, Text = "Holloween", Description="Spoopy day",Date=new DateTime(2022, 10, 31, 0, 0, 0) },
                new Memo { MemoID = 2, Text = "Thanksgiving", Description="Turkey day",Date=new DateTime(2022, 11, 24, 0, 0, 0) },
                new Memo { MemoID = 3, Text = "Independance Day", Description="Fireworks and Freedom",  Date=new DateTime(2022, 7, 4, 0, 0, 0)}
            };
        }

        public async Task<bool> AddItemAsync(Memo item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Memo item)
        {
            var oldItem = items.Where((Memo arg) => arg.MemoID == item.MemoID).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = items.Where((Memo arg) => arg.MemoID == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Memo> GetItemAsync(int id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.MemoID == id));
        }

        public async Task<IEnumerable<Memo>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
        public async Task<Memo> GetItemAsync(DateTime date)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Date == date));
        }
    }
}