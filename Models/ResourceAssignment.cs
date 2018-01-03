using System;
using System.Collections.Generic;

namespace ARBDashboard.Models
{
    public partial class ResourceAssignment
    {
        public int ResourceAssignmentId { get; set; }
        public int RequestId { get; set; }
        public string ResourceName { get; set; }
        public string ResourceEmail { get; set; }

        public RequestForm Request { get; set; }
    }
}
