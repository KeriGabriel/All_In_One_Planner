using All_In_One_Planner.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace All_In_One_Planner.Services
{
    public class PlannerAPIService<T>
    {
        public PlannerAPIService() { }

        public async Task<bool> AddMemoAsync(Memo item)
        {

            string json = JsonConvert.SerializeObject(item);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();

            string url = "http://73.42.234.61:5192/api/Memos";
            client.BaseAddress = new Uri(url);
            HttpResponseMessage response = await client.PostAsync("", content);

            if (response.IsSuccessStatusCode)
            {
                return await Task.FromResult(true);
            }
            //if (item.MemoID == null)
            //{
            //    string json = JsonConvert.SerializeObject(item);
            //    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            //    HttpClient client = new HttpClient();

            //    string url = "http://10.0.2.2:5192/api/Memos";
            //    client.BaseAddress = new Uri(url);
            //    HttpResponseMessage response = await client.PostAsync("", content);

            //    if (response.IsSuccessStatusCode)
            //    {
            //        return await Task.FromResult(true);
            //    }
            //}
            //else
            //{
            //    string json = JsonConvert.SerializeObject(item);
            //    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            //    HttpClient client = new HttpClient();
            //    string url = "http://10.0.2.2:5192/api/Memos/" + item.MemoID;
            //    client.BaseAddress = new Uri(url);
            //    HttpResponseMessage response = await client.PutAsync("", content);

            //    if (response.IsSuccessStatusCode)
            //    {
            //        return await Task.FromResult(true);
            //    }
            //}
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteMemoAsync(string id)
        {

            HttpClient client = new HttpClient();
            string url = "http://73.42.234.61:5192/api/Memos/" + id;
            client.BaseAddress = new Uri(url);
            HttpResponseMessage response = await client.DeleteAsync("");
            if (response.IsSuccessStatusCode)
            {
                return await Task.FromResult(true);
            }
            else
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<Memo> GetMemoAsync(string id)
        {
            var memo = new Memo();
            HttpClient client = new HttpClient();
            string url = "http://73.42.234.61:5192/api/Memos/" + id;
            client.BaseAddress = new Uri(url);
            HttpResponseMessage response = await client.GetAsync("");
            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                memo = JsonConvert.DeserializeObject<Memo>(content);
            }
            return await Task.FromResult(memo);
        }

        public async Task<IEnumerable<Memo>> GetMemoAsync(bool forceRefresh = false)
        {
            var memos = new List<Memo>();
            HttpClient client = new HttpClient();
            string url = "http://73.42.234.61:5192/api/Memos";
            client.BaseAddress = new Uri(url);
            HttpResponseMessage response = await client.GetAsync("");
            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                memos = JsonConvert.DeserializeObject<List<Memo>>(content);
            }
            return await Task.FromResult(memos);
        }

        public async Task<bool> UpdateMemoAsync(Memo item)
        {

            string json = JsonConvert.SerializeObject(item);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            string url = "http://73.42.234.61:5192/api/Memos/" + item.MemoID;
            client.BaseAddress = new Uri(url);
            HttpResponseMessage response = await client.PutAsync("", content);

            if (response.IsSuccessStatusCode)
            {
                return await Task.FromResult(true);
            }
            return await Task.FromResult(true);
        }
    }
}
