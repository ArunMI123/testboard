using System;
using System.Collections.Generic;

namespace ARBDashboard.Models
{
    public partial class Attachment
    {
        public int AttachmentId { get; set; }
        public int RequestId { get; set; }
        public string AttachmentLocation { get; set; }
        public string AttachmentName { get; set; }

        public RequestForm Request { get; set; }
    }
}
