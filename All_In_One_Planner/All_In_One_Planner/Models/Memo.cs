using System;

namespace All_In_One_Planner.Models
{
    public class Memo
    {
        public int MemoID { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
    }
}