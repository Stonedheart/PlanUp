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
        public EventCategory EventCategory { get; set; }
        public int Duration { get; set; }

        public HomeEvent(string name, EventCategory eventCategory, int duration)
        {
            this.HomeEventName = name;
            this.EventCategory = eventCategory;
            this.Duration = duration;
        }

    }
}