using System;
using System.Collections.Generic;

namespace ARBDashboard.Models
{
    public partial class Question
    {
        public Question()
        {
            QuestionResponses = new HashSet<QuestionResponse>();
        }

        public int QuestionId { get; set; }
        public int? Ordinal { get; set; }
        public string QuestionText { get; set; }
        public bool? Active { get; set; }
        public int? Domain { get; set; }
        public string Commentoptions { get; set; }

        public Domain DomainNavigation { get; set; }
        public ICollection<QuestionResponse> QuestionResponses { get; set; }
    }
}
