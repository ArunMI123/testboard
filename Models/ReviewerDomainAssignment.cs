using System;
using System.Collections.Generic;

namespace ARBDashboard.Models
{
    public partial class ReviewerDomainAssignment
    {
        public int ReviewerId { get; set; }
        public int DomainId { get; set; }
        public int DomainAssignmentId { get; set; }

        public Domain Domain { get; set; }
        public Reviewer Reviewer { get; set; }
    }
}
