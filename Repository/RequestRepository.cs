using ARBDashboard.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ARBDashboard.Repository
{
    public class RequestRepository : IRequestRepository
    {
        private ARB_DevelopContext dbcontext;

        public RequestRepository(ARB_DevelopContext _context)
        {
            dbcontext = _context;

        }

        public IEnumerable<WorkQueueRequest> GetAllWorkQueueData()
        {
            IEnumerable<WorkQueueRequest> wqlst = null;
            wqlst = (from requestForms in dbcontext.RequestForms.Include("QuestionResponses").Include("ReviewStage").Include("EventLogs").Include("ReviewerAssignments").Include("ReviewerAssignments.Reviewer")
                     from evntLog in dbcontext.EventLogs.Where(o => requestForms.ReviewStage.StageName == o.EventText && o.RequestId == requestForms.RequestId)
                      .Take(1).DefaultIfEmpty()
                     orderby evntLog.EventDate descending
                     from DMaccept in dbcontext.DmacceptComments.Where(x => requestForms.RequestId == x.RequestId)
                      .Take(1).DefaultIfEmpty()


                     select new WorkQueueRequest
                     {
                         ProjectID = requestForms.ProjectId,
                         RequestID = requestForms.RequestId,
                         DateRequested = requestForms.DateRequested,
                         Phase = requestForms.Phase,
                         ProjectType = requestForms.ProjectType,
                         ProjectName = requestForms.ProjectName,
                         StageDesc = requestForms.ReviewStage.StageName,
                         Status = requestForms.ReviewStage.RequestStatus,
                         StageID = requestForms.ReviewStage.StageId,
                         SA = requestForms.SolutionArchitect,
                         Requester = requestForms.EnteredBy,
                         Priority = (int?)(DateTime.Now.Subtract(evntLog.EventDate ?? DateTime.Now)).TotalDays,
                         //Priority = ((requestForms.ReviewStage.StageId == 9 || requestForms.ReviewStage.StageId == 10) ? -1 : DbFunctions.DiffDays(evntLog.EventDate ?? DateTime.Now, DateTime.Now)),
                         Region1 = requestForms.Region1,
                         ReviewStage = requestForms.ReviewStage,
                         ProjectManager = requestForms.ProjectManager,
                         InfrastructurePM = requestForms.InfrastructurePm,
                         SolutionArchitect = requestForms.SolutionArchitect,
                         SecurityArchitect = requestForms.SecurityArchitect,
                         EnteredBy = requestForms.EnteredBy,
                         //ReviewerAssignments = requestForms.ReviewerAssignments,
                         ReviewType = DMaccept.ReviewType.Description
                     } into anon
                     orderby anon.Priority descending
                     select anon);

            return wqlst;
        }

        public Reviewer GetUser(string email)
        {
            Reviewer result = dbcontext.Reviewers.Where(x => x.ReviewerEmail == email).FirstOrDefault();
            return result;
        }

        /// <summary>
        /// Description:function to retrive review stage from db
        /// </summary>
        /// <returns></returns>
        public IQueryable<ReviewStage> RetrieveReviewStages()
        {
            IQueryable<ReviewStage> stagesQuery = from stages in dbcontext.ReviewStages
                                                  select stages;
            return stagesQuery;
        }

        /// <summary>
        /// Description:function to retrive regions from db
        /// </summary>
        /// <returns></returns>
        public IQueryable<Region> RetrieveRegions()
        {
            IQueryable<Region> regionsQuery = from regions in dbcontext.Regions
                                              select regions;
            return regionsQuery;
        }

        /// <summary>
        /// Description:function to retrive reviewers for given email from db
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        public IQueryable<Reviewer> RetrieveReviewer(string emailAddress)
        {
            IQueryable<Reviewer> reviewersQuery = from reviewer in dbcontext.Reviewers
                                                  where reviewer.ReviewerEmail.Equals(emailAddress)
                                                  select reviewer;
            return reviewersQuery;
        }

        /// <summary>
        /// Description:function to retrive all reviewers from db
        /// </summary>
        /// <returns></returns>
        public IQueryable<Reviewer> RetrieveReviewers()
        {
            IQueryable<Reviewer> reviewersQuery = from reviewers in dbcontext.Reviewers.Include("Domains").Include("ReviewerDomainAssignments")

                                                  select reviewers;
            return reviewersQuery;
        }

    }
}