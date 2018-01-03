using System;
using System.Collections.Generic;

namespace ARBDashboard.Models
{
    public partial class ReviewStage
    {
        public ReviewStage()
        {
            RequestForms = new HashSet<RequestForm>();
        }

        public int StageId { get; set; }
        public string StageName { get; set; }
        public string RequestStatus { get; set; }
        public bool? Active { get; set; }

        public ICollection<RequestForm> RequestForms { get; set; }
    }
}
