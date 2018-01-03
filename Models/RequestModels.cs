using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ARBDashboard.Models
{
    public class WorkQueueRequest
    {

        public WorkQueueRequest()
        {
            Attachments = new HashSet<Attachment>();
            QuestionResponses = new HashSet<QuestionResponse>();
            ResourceAssignments = new HashSet<ResourceAssignment>();
            ReviewerAssignments = new HashSet<ReviewerAssignment>();
        }

        public int RequestID { get; set; }
        public string ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string Phase { get; set; }
        public Nullable<int> ProjectType { get; set; }
        public Nullable<System.DateTime> DateRequested { get; set; }
        public string StageDesc { get; set; }
        public string Status { get; set; }
        public IEnumerable<QuestionResponse> QuestionResponses { get; set; }
        public IEnumerable<GheastandardsUsed> GHEAStandardsUseds { get; set; }
        public IEnumerable<Attachment> Attachments { get; set; }
        public int StageID { get; set; }
        public string Requester { get; set; }
        public string SA { get; set; }
        public int? Priority { get; set; }

        public virtual Region Region1 { get; set; }
        public virtual ReviewStage ReviewStage { get; set; }

        public string ProjectManager { get; set; }
        public string InfrastructurePM { get; set; }
        public string SolutionArchitect { get; set; }
        public string SecurityArchitect { get; set; }
        public string EnteredBy { get; set; }
        public virtual IEnumerable<ResourceAssignment> ResourceAssignments { get; set; }
        public virtual IEnumerable<ReviewerAssignment> ReviewerAssignments { get; set; }
        public string ReviewType { get; set; }
    }

    public class Request : WorkQueueRequest
    { 
        public Nullable<System.DateTime> DateOfARB { get; set; }
        public string BusinessScope { get; set; }
        public string TechScope { get; set; }
        public string Region { get; set; }
        public Nullable<System.DateTime> SubmissionDate { get; set; }
        public Nullable<System.DateTime> DateEntered { get; set; }
        public Nullable<int> EstProjectHoursJ0 { get; set; }
        public Nullable<decimal> EstProjectCostJ0 { get; set; }
        public Nullable<int> EstTotalHours { get; set; }
        public Nullable<decimal> EstTotalCost { get; set; }
        public IEnumerable<DomainReviews> Reviews { get; set; }
        public Nullable<int> Stage { get; set; }
        public string ReviewerReviewDecision { get; set; }
        public DateTime? ReviewerReviewDecisionDate { get; set; }
        public string DMReviewDecision { get; set; }
        public string DMReviewDecisionComment { get; set; }
        public DateTime? DMReviewDecisionDate { get; set; }
        public Nullable<int> NetNew { get; set; }
        public Nullable<int> StandardBased { get; set; }
        public Nullable<System.DateTime> JEventDate { get; set; }
        public string NetNewComments { get; set; }
        public string StandardBasedComments { get; set; }
        public Nullable<System.DateTime> DueByDate { get; set; }
        public Nullable<System.DateTime> PackageSubmissionDate { get; set; }
    }

    public class Stage
    {
        public int StageId { get; set; }
        public string Comments { get; set; }
        public string Status { get; set; }

    }

    public class Result
    {
        public int ResultId { get; set; }
        public string Comments { get; set; }

    }

}