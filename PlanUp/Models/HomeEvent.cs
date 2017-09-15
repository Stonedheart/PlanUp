using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlanUp.Models
{
    public class HomeEvent
    {
        public int Id { get; set; }
        public string HomeEventName { get; set; }
        public int EventCategory { get; set; }
        public int Duration { get; set; }

        public HomeEvent()
        {
    
        }

        public HomeEvent(string name, int eventCategory, int duration)
        {
            this.HomeEventName = name;
            this.EventCategory = eventCategory;
            this.Duration = duration;
        }

    }
}