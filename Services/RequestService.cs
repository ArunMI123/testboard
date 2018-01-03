using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using ARBDashboard.Models;
using ARBDashboard.Repository;
using Serilog;


namespace ARBDashboard.Services
{
    public class RequestService : IRequestService
    {
        private IRequestRepository requestRepository;

        public RequestService(IRequestRepository _requestRepository)
        {
            requestRepository = _requestRepository;
        }

        /*
          Description: Retrieve All request that the logged in user party to

          LastUpdated: 11/15/2016 - Perumal: Initial Creation
          */

        /// <summary>
        /// Description:Function to retrive request for workqueue.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public IEnumerable<WorkQueueRequest> GetRequests(Models.User user)
        {
            IEnumerable<WorkQueueRequest> result = null;
            String email = user.Email.ToLower();
            try
            {
                var requestForms = requestRepository.GetAllWorkQueueData();

                var Test = requestForms.ToList();

                if (user.Role == "DM")
                {
                    string region = user.Region;
                    requestForms = requestForms.Where(x => x.Region1.RegionName.Equals(region));
                }
                else if (user.Role == "Reviewer")
                {
                    int reviewerId = GetDomainUser(email).ReviewerId;

                    requestForms = requestForms.Where(x =>
                            x.InfrastructurePM.Equals(email) ||
                            x.ProjectManager.Equals(email) ||
                            x.SecurityArchitect.Equals(email) ||
                            x.SolutionArchitect.Equals(email) ||
                            x.EnteredBy.Equals(email) ||
                            x.ReviewerAssignments.Any(y => y.ReviewerId.Equals(reviewerId))
                            );
                }
                else if (user.Role != "Public")
                {

                    requestForms = requestForms.Where(x =>
                            x.InfrastructurePM.Equals(email) ||
                            x.ProjectManager.Equals(email) ||
                            x.SecurityArchitect.Equals(email) ||
                            x.SolutionArchitect.Equals(email) ||
                            x.EnteredBy.Equals(email)
                            );
                }
                if (user.IsAll == false)
                {
                    requestForms = requestForms.Where(x => x.ReviewStage.StageId != 10 && x.ReviewStage.RequestStatus != "Close");
                }

                //var workqueueList = requestForms.Select(x => new WorkQueueRequest
                //{
                //    ProjectID = x.ProjectID,
                //    RequestID = x.RequestID,
                //    DateRequested = x.DateRequested,
                //    Phase = x.Phase,
                //    ProjectType = x.ProjectType,
                //    ProjectName = x.ProjectName,
                //    StageDesc = x.ReviewStage.StageName,
                //    Status = x.ReviewStage.RequestStatus,
                //    StageID = x.ReviewStage.StageID,
                //    SA = x.SolutionArchitect,
                //    Requester = x.EnteredBy,
                //    Priority = ((x.ReviewStage.StageID == 8 && x.ReviewerAssignments.Where(y => y.RequestID == x.RequestID && y.Reviewer.ReviewerEmail == user.Email && y.Stage == 7).FirstOrDefault().Comments == null) || (x.ReviewStage.StageID == 5 && x.ReviewerAssignments.Where(y => y.RequestID == x.RequestID && y.Reviewer.ReviewerEmail == user.Email && y.Stage == 5).FirstOrDefault().Comments == null)) ? 0 : 1,
                //}).ToList();


                result = requestForms.Select(x => new WorkQueueRequest
                {
                    ProjectID = x.ProjectID,
                    RequestID = x.RequestID,
                    DateRequested = x.DateRequested,
                    Phase = x.Phase,
                    ProjectType = x.ProjectType,
                    ProjectName = x.ProjectName, //x.ProjectName,
                    StageDesc = x.StageDesc,
                    Status = x.Status,
                    StageID = x.StageID,
                    SA = x.SA.Split('@')[0].ToString(),
                    Requester = x.Requester.Split('@')[0].ToString(),
                    Priority = x.Priority,
                    ReviewType = x.ReviewType
                }).AsEnumerable();
            }
            catch (Exception exception)
            {
                Log.Error(exception.StackTrace);
                throw exception;

            }

            return result;
        }

        public Reviewer GetDomainUser(String email)
        {
            Reviewer result = requestRepository.GetUser(email);
            return result;
        }

        public IEnumerable<WorkQueueRequest> SearchRequest(SearchModel search)
        {
            IEnumerable<WorkQueueRequest> result = null;
            result = GetRequests(search.User);
            result = result.Where(i =>
         (string.IsNullOrEmpty(search.ProjectID) || i.ProjectID.Contains(search.ProjectID))
         && (string.IsNullOrEmpty(search.Status) || i.Status.Equals(search.Status))
         && (!search.Stage.HasValue || i.StageID == search.Stage));

            return result;
        }

        /// <summary>
        /// Description:Function for retrive all stages.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<KeyValuePair<int, string>> GetAllReviewStages()
        {
            IEnumerable<KeyValuePair<int, string>> result = null;

            try
            {
                var reviewStages = requestRepository.RetrieveReviewStages();
                result = reviewStages.Where(x => x.Active == true).Select(x => new KeyValuePair<int, string>(x.StageId, x.StageName)).AsEnumerable();
            }
            catch (Exception exception)
            {
                Log.Error(exception.StackTrace);
                throw exception;

            }

            return result;
        }

        /// <summary>
        /// Description:Function for get reviewer details based on email address.
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        public Reviewer GetReviewer(string emailAddress)
        {
            Reviewer result = null;

            try
            {
                var reviewers = requestRepository.RetrieveReviewer(emailAddress.ToLower());
                result = reviewers.FirstOrDefault();
            }
            catch (Exception exception)
            {
                Log.Error(exception.StackTrace);
                throw exception;
            }


            return result;
        }

        /// <summary>
        /// Description:Function for retrive all Region.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Region> GetAllRegions()
        {

            IEnumerable<Region> result = null;
            try
            {
                var regions = requestRepository.RetrieveRegions();
                result = regions.AsEnumerable();
            }
            catch (Exception exception)
            {
                Log.Error(exception.StackTrace);
                throw exception;
            }
            return result;
        }

    }


}