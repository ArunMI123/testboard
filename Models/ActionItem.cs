using System;
using System.Collections.Generic;

namespace ARBDashboard.Models
{
    public partial class ActionItem
    {
        public ActionItem()
        {
            ActionItemAttachments = new HashSet<ActionItemAttachment>();
            RiskCategoryAssignments = new HashSet<RiskCategoryAssignment>();
        }

        public int ActionItemId { get; set; }
        public int RequestId { get; set; }
        public int? ActionItemType { get; set; }
        public string ActionItemText { get; set; }
        public DateTime? DateEntered { get; set; }
        public DateTime? DueByDate { get; set; }
        public DateTime? DateResolved { get; set; }
        public string Resolution { get; set; }
        public int? RiskCategory { get; set; }
        public bool? Closed { get; set; }
        public DateTime? DateClosed { get; set; }
        public int? DomainId { get; set; }
        public int? ActionItemSubType { get; set; }
        public string DueByEvent { get; set; }
        public string RiskCategoryComments { get; set; }
        public int? ResolutionStrategy { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public ActionItemType ActionItemTypeNavigation { get; set; }
        public Domain Domain { get; set; }
        public RequestForm Request { get; set; }
        public ICollection<ActionItemAttachment> ActionItemAttachments { get; set; }
        public ICollection<RiskCategoryAssignment> RiskCategoryAssignments { get; set; }
    }
}
