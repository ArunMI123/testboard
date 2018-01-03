using System;
using System.Collections.Generic;

namespace ARBDashboard.Models
{
    public partial class RequestForm
    {
        public RequestForm()
        {
            ActionItems = new HashSet<ActionItem>();
            Attachments = new HashSet<Attachment>();
            DmacceptComments = new HashSet<DmacceptComment>();
            EventLogs = new HashSet<EventLog>();
            GheastandardsUseds = new HashSet<GheastandardsUsed>();
            QuestionResponses = new HashSet<QuestionResponse>();
            ResourceAssignments = new HashSet<ResourceAssignment>();
            ReviewerAssignments = new HashSet<ReviewerAssignment>();
        }

        public int RequestId { get; set; }
        public string ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string Phase { get; set; }
        public int? ProjectType { get; set; }
        public DateTime? DateRequested { get; set; }
        public DateTime? DateOfArb { get; set; }
        public string ProjectManager { get; set; }
        public string InfrastructurePm { get; set; }
        public string SolutionArchitect { get; set; }
        public string SecurityArchitect { get; set; }
        public string BusinessScope { get; set; }
        public string TechScope { get; set; }
        public int Region { get; set; }
        public DateTime? SubmissionDate { get; set; }
        public int? Stage { get; set; }
        public DateTime? DateEntered { get; set; }
        public string EnteredBy { get; set; }
        public int? EstProjectHoursJ0 { get; set; }
        public decimal? EstProjectCostJ0 { get; set; }
        public int? EstTotalHours { get; set; }
        public decimal? EstTotalCost { get; set; }
        public string ReviewerReviewDecision { get; set; }
        public DateTime? ReviewerReviewDecisionDate { get; set; }
        public string DmreviewDecision { get; set; }
        public string DmreviewDecisionComment { get; set; }
        public DateTime? DmreviewDecisionDate { get; set; }
        public int? NetNew { get; set; }
        public int? StandardBased { get; set; }
        public DateTime? JeventDate { get; set; }
        public string NetNewComments { get; set; }
        public string StandardBasedComments { get; set; }
        public DateTime? DuebyDate { get; set; }
        public DateTime? PackageSubmissionDate { get; set; }

        public Region Region1 { get; set; }
        public ReviewStage ReviewStage { get; set; }
        public ICollection<ActionItem> ActionItems { get; set; }
        public ICollection<Attachment> Attachments { get; set; }
        public ICollection<DmacceptComment> DmacceptComments { get; set; }
        public ICollection<EventLog> EventLogs { get; set; }
        public ICollection<GheastandardsUsed> GheastandardsUseds { get; set; }
        public ICollection<QuestionResponse> QuestionResponses { get; set; }
        public ICollection<ResourceAssignment> ResourceAssignments { get; set; }
        public ICollection<ReviewerAssignment> ReviewerAssignments { get; set; }
    }
}
