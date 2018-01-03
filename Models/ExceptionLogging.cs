using System;
using System.Collections.Generic;

namespace ARBDashboard.Models
{
    public partial class ExceptionLogging
    {
        public long LogId { get; set; }
        public DateTime? LogDate { get; set; }
        public string LoggedBy { get; set; }
        public string LogType { get; set; }
        public string ExceptionUrl { get; set; }
        public string Exception { get; set; }
        public string ExceptionDetails { get; set; }
        public string AdditionalInfo { get; set; }
    }
}
