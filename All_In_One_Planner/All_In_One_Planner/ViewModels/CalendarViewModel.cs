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

            Events = new EventCollection
            {
                [DateTime.Now] = new List<Memo>

                {
                    new Memo { Text = "Dr Appt", Description = " 8:00 be early to fill out paperwork" },
                    new Memo { Text = "Lecture", Description = "Last Day of lecture" }   
                },
                // 5 days from today
                [DateTime.Now.AddDays(5)] = new List<Memo>
                {
                    new Memo { Text = "Oil Change", Description = "Check windshild wipers" },
                    new Memo { Text = "Tires", Description = "Check Breaks" }
                },
                // 3 days ago
                [DateTime.Now.AddDays(-3)] = new List<Memo>
                {
                    new Memo { Text = "This is the past", Description = "Back to the future" }
                },
                // custom date
                [new DateTime(2022, 6, 17)] = new List<Memo>
                {
                    new Memo { Text = "Graduation Day", Description = "Centralia College Graduation 2022" }
                }
            };

        }
    }
}