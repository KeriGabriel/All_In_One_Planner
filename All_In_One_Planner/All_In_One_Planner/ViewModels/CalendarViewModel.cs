using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Plugin.Calendar.Models;
using Xamarin.Forms;
using All_In_One_Planner.Models;
using All_In_One_Planner.Services;




namespace All_In_One_Planner.ViewModels
{
    public class CalendarViewModel : BaseViewModel
    {
        public EventCollection Events { get; set; }
        public CalendarViewModel()
        {
            Title = "Calendar";
            int count = 0;
            MockData mockData = new MockData();
            DateTime date;
            // date = mockData.GetItemAsync(date);

            //for (int i = 0; i < items.ToArray().Length; i++)
            //{

            //}
            Events = new EventCollection
            {

                [DateTime.Now] = new List<Memo>

                {
                    new Memo { Text = "Cool event1", Description = "This is Cool event1's description!" },
                    new Memo { Text = "Cool event2", Description = "This is Cool event2's description!" }
                },
                // 5 days from today
                [DateTime.Now.AddDays(5)] = new List<Memo>
                {
                    new Memo { Text = "Cool event3", Description = "This is Cool event3's description!" },
                    new Memo { Text = "Cool event4", Description = "This is Cool event4's description!" }
                },
                // 3 days ago
                [DateTime.Now.AddDays(-3)] = new List<Memo>
                {
                    new Memo { Text = "Cool event5", Description = "This is Cool event5's description!" }
                },
                // custom date
                [new DateTime(2020, 3, 16)] = new List<Memo>
                {
                    new Memo { Text = "Cool event6", Description = "This is Cool event6's description!" }
                }
            };

        }
    }
}