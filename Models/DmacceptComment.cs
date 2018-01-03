using System;
using System.Collections.Generic;

namespace ARBDashboard.Models
{
    public partial class DmacceptComment
    {
        public int DmacceptCommentsId { get; set; }
        public int RequestId { get; set; }
        public int Phase { get; set; }
        public string Comments { get; set; }
        public int Acceptance { get; set; }

        public ReviewType ReviewType { get; set; }
        public RequestForm Request { get; set; }
    }
}
