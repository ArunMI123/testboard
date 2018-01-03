using System;
using System.Collections.Generic;

namespace ARBDashboard.Models
{
    public partial class PackageAcceptance
    {
        public int RequestId { get; set; }
        public string PackageResult { get; set; }
        public string PackageComment { get; set; }
        public string CreatedBy { get; set; }
        public int AcceptanceId { get; set; }
    }
}
