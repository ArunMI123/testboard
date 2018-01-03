using System;
using System.Collections.Generic;
using System.Linq;
using ARBDashboard.Models;
using ARBDashboard.Repository;


namespace ARBDashboard.Services
{
    public class ReviewService : IReviewService
    {
        private IReviewRepository reviewRepository;
      
        public ReviewService(IReviewRepository _reviewRepository)
        {
            reviewRepository = _reviewRepository;
        }

        /// <summary>
        /// Description:Function for retrive all actiontype.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ActionItemType> GetAllActionTypes()
        {
            
            IEnumerable<ActionItemType> result = null;
            try
            {
                var actionTypes = reviewRepository.RetrieveActionTypes();
                result = actionTypes;
                //.Select(x => new KeyValuePair { Key = x.ActionItemTypeID, Value = x.ActionItemType1 }).AsEnumerable();
            }
            catch (Exception exception)
            {
                throw exception;

            }
            return result;
        }

        /// <summary>
        /// Description:Function for retrive all domain .
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Domain> GetAllDomains()
        {
            IEnumerable<Domain> result = null;
            try
            {
                var domains = reviewRepository.RetrieveDomains();

                result = domains.AsEnumerable();

            }
            catch (Exception exception)
            {
                throw exception;
            }

            return result;

        }

        /// <summary>
        /// Description:Function for retrive all Standards .
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Gheastandard> GetAllGHEAStandards()
        {
            IEnumerable<Gheastandard> result = null;
            try
            {
                var standards = reviewRepository.RetrieveGHEAStandards();

                result = standards.AsEnumerable();
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return result;
        }

        /// <summary>
        /// Description:Function for retrive all standard for request .
        /// </summary>
        /// <param name="requestID"></param>
        /// <returns></returns>
        public IEnumerable<Object> GetAllGHEAStandards(int requestID)
        {
            IEnumerable<Object> result = null;
            try
            {
                var standardsUsed = reviewRepository.RetrieveGHEAStandardsUsed(requestID);

                result = standardsUsed.AsEnumerable();
            }
            catch (Exception exception)
            {
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
                var regions = reviewRepository.RetrieveRegions();
                result = regions.AsEnumerable();
            }
            catch (Exception exception)
            {
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
                var reviewers = reviewRepository.RetrieveReviewer(emailAddress.ToLower());
                result = reviewers.FirstOrDefault();
            }
            catch (Exception exception)
            {
                throw exception;
            }


            return result;
        }

        /// <summary>
        /// Description:Function for retrive all reviewers.
        /// </summary>
        /// <returns></returns>
        //public IEnumerable<Reviewer> GetAllReviewers()
        //{
        //    IEnumerable<Reviewer> result = null;
            
        //    try
        //    {
        //        var reviewers = reviewRepository.RetrieveReviewers().Where(x=>x.Role.ToLower().Equals("both") || x.Role.ToLower().Equals("reviewer")) ;
        //        result = reviewers.AsEnumerable();

        //    }
        //    catch (Exception exception)
        //    {
        //        throw exception;
        //    }
        //    return result;

        //}


        public IEnumerable<ReviewerDomainAssignment> GetAllReviewers()
        {
            IEnumerable<ReviewerDomainAssignment> result = null;

            try
            {
                var reviewers = reviewRepository.RetrieveReviewers1().Where(x => (x.Reviewer.Role.ToLower().Equals("both") || x.Reviewer.Role.ToLower().Equals("reviewer")) && x.Reviewer.Active==true);
                result = reviewers.AsEnumerable();

            }
            catch (Exception exception)
            {
                throw exception;
            }
            return result;

        }

        public IEnumerable<Reviewer> GetDM()
        {
            IEnumerable<Reviewer> result = null;

            try
            {
                var reviewers = reviewRepository.RetrieveDMs();
                result = reviewers.AsEnumerable();

            }
            catch (Exception exception)
            {
                throw exception;
            }
            return result;

        }

        /// <summary>
        /// Description:Function for retrive all stages.
        /// </summary>
        /// <returns></returns>
        //public IEnumerable<KeyValuePair> GetAllReviewStages()
        //{
        //    IEnumerable<KeyValuePair> result = null;
         
        //    try
        //    {
        //        var reviewStages = reviewRepository.RetrieveReviewStages();
        //        result = reviewStages.Where(x => x.Active == true).Select(x => new KeyValuePair { Key = x.StageID, Value = x.StageName }).AsEnumerable();
        //    }
        //    catch (Exception exception)
        //    {
        //        throw exception;
                
        //    }

        //    return result;
        //}

      

        /// <summary>
        /// Description:Function for retrive question for particular request.
        /// </summary>
        /// <param name="requestId"></param>
        /// <returns></returns>
        public IEnumerable<Object> GetQuestion(int requestId)
        {
            IEnumerable<Object> result = null;
           
            try
            {
                result = reviewRepository.RetriveQuestion(requestId).AsEnumerable();
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return result;
        }

     

        public IEnumerable<ReviewType> GetAllReviewTypes()
        {
            IEnumerable<ReviewType> ReviewTypes = reviewRepository.RetrieveReviewTypes();

            return ReviewTypes;
        }

        public IEnumerable<ResolutionStrategy> GetResolutionTypes()
        {
            IEnumerable<ResolutionStrategy> resolutionTypes = reviewRepository.ResolutionTypes();

            return resolutionTypes;
        }

        public IList<Reviewer> GetUserList()
        {
            List<Reviewer> userList = reviewRepository.GetUserList().ToList();
            userList = userList.Select(x => new Reviewer
            {
                ReviewerId = x.ReviewerId,
                ReviewerName = x.ReviewerName,
                ReviewerEmail = x.ReviewerEmail,
                Role = x.Role,
                Active = x.Active,
                CreatedBy = x.CreatedBy,
                ModifiedBy = x.ModifiedBy,
                ModifiedDate = x.ModifiedDate,
                ReviewerDomainAssignments = x.ReviewerDomainAssignments.Select(y => new ReviewerDomainAssignment { DomainId = y.DomainId, Domain = new Domain { DomainName = y.Domain.DomainName } }).ToList()
            }).ToList();
            return userList;
        }

        public Reviewer GetUser(int userID)
        {
           Reviewer result = reviewRepository.GetUserList().Where(x => x.ReviewerId == userID).FirstOrDefault();
            return result;
        }

        public Reviewer GetDomainUser(String email)
        {
            Reviewer result = reviewRepository.GetUserList().Where(x => x.ReviewerEmail == email).FirstOrDefault();
            return result;
        }

      
    }
}