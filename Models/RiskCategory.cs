using System;
using System.Collections.Generic;

namespace ARBDashboard.Models
{
    public partial class RiskCategory
    {
        public RiskCategory()
        {
            RiskCategoryAssignments = new HashSet<RiskCategoryAssignment>();
        }

        public int RiskCategoryId { get; set; }
        public string RiskCategory1 { get; set; }

        public ICollection<RiskCategoryAssignment> RiskCategoryAssignments { get; set; }
    }
}
