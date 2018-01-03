using System;
using System.Collections.Generic;

namespace ARBDashboard.Models
{
    public partial class RiskCategoryAssignment
    {
        public int RiskCategoryAssignmentId { get; set; }
        public int ActionItemId { get; set; }
        public int? RiskCategoryId { get; set; }

        public ActionItem ActionItem { get; set; }
        public RiskCategory RiskCategory { get; set; }
    }
}
