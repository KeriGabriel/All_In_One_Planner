using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Plugin.Calendar.Models;
using Xamarin.Forms;
using All_In_One_Planner.Models;




namespace All_In_One_Planner.ViewModels
{
    public class CalendarViewModel : BaseViewModel
    {
        public EventCollection Events { get; set; }
        public CalendarViewModel()
        {
            Title = "Calendar";
            Events = new EventCollection
            {
                [DateTime.Now] = new List<Item>
    {
                new Item { Text = "Cool event1", Description = "This is Cool event1's description!" },
                new Item { Text = "Cool event2", Description = "This is Cool event2's description!" }
    },
                // 5 days from today
                [DateTime.Now.AddDays(5)] = new List<Item>
    {
                new Item { Text = "Cool event3", Description = "This is Cool event3's description!" },
                new Item { Text = "Cool event4", Description = "This is Cool event4's description!" }
    },
                // 3 days ago
                [DateTime.Now.AddDays(-3)] = new List<Item>
    {
                new Item { Text = "Cool event5", Description = "This is Cool event5's description!" }
    },
                // custom date
                [new DateTime(2020, 3, 16)] = new List<Item>
    {
                new Item { Text = "Cool event6", Description = "This is Cool event6's description!" }
    }
            };
        }
           
    }
    
}