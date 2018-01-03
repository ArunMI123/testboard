using System;
using System.Collections.Generic;

namespace ARBDashboard.Models
{
    public partial class ActionItemType
    {
        public ActionItemType()
        {
            ActionItems = new HashSet<ActionItem>();
        }

        public int ActionItemTypeId { get; set; }
        public string ActionItemType1 { get; set; }
        public int? ParentTypeId { get; set; }
        public int? ParentLevel { get; set; }

        public ICollection<ActionItem> ActionItems { get; set; }
    }
}
