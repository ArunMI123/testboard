using System;
using System.Collections.Generic;

namespace ARBDashboard.Models
{
    public partial class Reviewer
    {
        public Reviewer()
        {
            ReviewerAssignments = new HashSet<ReviewerAssignment>();
            ReviewerDomainAssignments = new HashSet<ReviewerDomainAssignment>();
        }

        public int ReviewerId { get; set; }
        public string ReviewerName { get; set; }
        public string ReviewerEmail { get; set; }
        public string Role { get; set; }
        public bool? Active { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public ICollection<ReviewerAssignment> ReviewerAssignments { get; set; }
        public ICollection<ReviewerDomainAssignment> ReviewerDomainAssignments { get; set; }
    }
}
