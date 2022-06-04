using System;
using Newtonsoft.Json;
namespace All_In_One_Planner.Models
{
    public class Memo
    {   
        public string MemoID { get; set; }
        [JsonProperty ("text")]
        public string Text { get; set; }
        [JsonProperty("date")]
        public DateTime Date { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}