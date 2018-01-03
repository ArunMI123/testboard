using System;
using System.Collections.Generic;

namespace ARBDashboard.Models
{
    public partial class Region
    {
        public Region()
        {
            RequestForms = new HashSet<RequestForm>();
        }

        public int RegionId { get; set; }
        public string RegionToken { get; set; }
        public string RegionName { get; set; }

        public ICollection<RequestForm> RequestForms { get; set; }
    }
}
