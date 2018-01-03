using System;
using System.Collections.Generic;

namespace ARBDashboard.Models
{
    public partial class QuestionResponse
    {
        public int QuestionResponseId { get; set; }
        public int RequestId { get; set; }
        public string ResponseValue { get; set; }
        public int? QuestionId { get; set; }
        public string ResposeAnswer { get; set; }

        public Question Question { get; set; }
        public RequestForm Request { get; set; }
    }
}
