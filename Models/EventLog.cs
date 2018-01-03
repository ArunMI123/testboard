using System;
using System.Collections.Generic;

namespace ARBDashboard.Models
{
    public partial class EventLog
    {
        public int EventLogItemId { get; set; }
        public int RequestId { get; set; }
        public int? EventType { get; set; }
        public string EventText { get; set; }
        public DateTime? EventDate { get; set; }
        public string Author { get; set; }
        public string Domain { get; set; }
        public string StageDescription { get; set; }

        public RequestForm Request { get; set; }
    }
}
