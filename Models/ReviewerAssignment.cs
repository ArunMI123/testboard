using System;
using System.Collections.Generic;

namespace ARBDashboard.Models
{
    public partial class ReviewerAssignment
    {
        public int ReviewerAssignmentId { get; set; }
        public int RequestId { get; set; }
        public int ReviewerId { get; set; }
        public int DomainId { get; set; }
        public int? Stage { get; set; }
        public string Comments { get; set; }
        public string Result { get; set; }
        public DateTime? LastModified { get; set; }

        public Domain Domain { get; set; }
        public RequestForm Request { get; set; }
        public Reviewer Reviewer { get; set; }
    }
}
