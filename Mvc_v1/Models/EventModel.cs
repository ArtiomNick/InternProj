using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc_v1.Models
{
    public class EventModel
    {
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string Subject { get; set; }
    }
}