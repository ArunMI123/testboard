using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ARBDashboard.Models
{
    public class SearchModel
    {
        public string ProjectID { get; set; }
        public Nullable<int> Stage { get; set; }
        public string Status { get; set; }
        public User User { get; set; }
    }
}