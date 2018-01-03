using System;
using System.Collections.Generic;

namespace ARBDashboard.Models
{
    public partial class ActionItemAttachment
    {
        public int ActionitemAttachmentId { get; set; }
        public string AttachmentLocation { get; set; }
        public int ActionItemId { get; set; }
        public string AttachmentName { get; set; }

        public ActionItem ActionItem { get; set; }
    }
}
