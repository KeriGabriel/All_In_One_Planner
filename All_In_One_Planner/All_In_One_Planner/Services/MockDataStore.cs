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
                new Item { Id = Guid.NewGuid().ToString(), Text = "Christmas", Description="Christmas Shopping.", Date=new DateTime(2022, 12, 25) },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Holloween", Description="Spoopy day",Date=new DateTime(2022, 10, 31, 0, 0, 0) },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Thanksgiving", Description="Turkey day",Date=new DateTime(2022, 12, 25, 0, 0, 0) },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Independance Day", Description="Fireworks and Freedom",  Date=new DateTime(2022, 7, 4, 0, 0, 0)}
            };
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}