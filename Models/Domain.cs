using System;
using System.Collections.Generic;

namespace ARBDashboard.Models
{
    public partial class Domain
    {
        public Domain()
        {
            ActionItems = new HashSet<ActionItem>();
            Questions = new HashSet<Question>();
            ReviewerAssignments = new HashSet<ReviewerAssignment>();
            ReviewerDomainAssignments = new HashSet<ReviewerDomainAssignment>();
        }

        public int DomainId { get; set; }
        public string DomainName { get; set; }
        public string Type { get; set; }

        public ICollection<ActionItem> ActionItems { get; set; }
        public ICollection<Question> Questions { get; set; }
        public ICollection<ReviewerAssignment> ReviewerAssignments { get; set; }
        public ICollection<ReviewerDomainAssignment> ReviewerDomainAssignments { get; set; }
    }
}
