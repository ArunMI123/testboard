using System;
using System.Collections.Generic;

namespace ARBDashboard.Models
{
    public partial class GheastandardsUsed
    {
        public int GheastandardsUsedId { get; set; }
        public int GheastandardId { get; set; }
        public int RequestId { get; set; }

        public Gheastandard Gheastandard { get; set; }
        public RequestForm Request { get; set; }
    }
}
