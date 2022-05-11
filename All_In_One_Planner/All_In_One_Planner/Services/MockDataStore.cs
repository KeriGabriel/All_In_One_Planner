using All_In_One_Planner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace All_In_One_Planner.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>()
            {
                new Item { ID = 0, Text = "Christmas", Description="Christmas Shopping.", Date=new DateTime(2022, 12, 25) },
                new Item { ID = 1, Text = "Holloween", Description="Spoopy day",Date=new DateTime(2022, 10, 31, 0, 0, 0) },
                new Item { ID = 2, Text = "Thanksgiving", Description="Turkey day",Date=new DateTime(2022, 11, 24, 0, 0, 0) },
                new Item { ID = 3, Text = "Independance Day", Description="Fireworks and Freedom",  Date=new DateTime(2022, 7, 4, 0, 0, 0)}
            };
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.ID == item.ID).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = items.Where((Item arg) => arg.ID == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(int id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.ID == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
        public async Task<Item> GetItemAsync(DateTime date)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Date == date));
        }
    }
}