using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ARBDashboard.Models;

namespace ARBDashboard.Repository
{

    public class ReviewRepository : IReviewRepository
    {
        private ARB_DevelopContext dbcontext;

        public ReviewRepository(ARB_DevelopContext _context)
        {
            dbcontext = _context;

        }

        /// <summary>
        /// Description:function to retrive action type from db
        /// </summary>
        /// <returns></returns>
        public IQueryable<ActionItemType> RetrieveActionTypes()
        {
            IQueryable<ActionItemType> actionTypesQuery = from actionTypes in dbcontext.ActionItemTypes
                                                          select actionTypes;
            return actionTypesQuery;
        }


        /// <summary>
        /// Description:function to retrive Domains from db
        /// </summary>
        /// <returns></returns>
        public IQueryable<Domain> RetrieveDomains()
        {
            IQueryable<Domain> domainQuery = from domains in dbcontext.Domains
                                             select domains;
            return domainQuery;
        }

        public IQueryable<EventType> RetrieveEventType()
        {
            IQueryable<EventType> domainQuery = from eventtype in dbcontext.EventTypes
                                                select eventtype;
            return domainQuery;
        }

        /// <summary>
        /// Description:function to retrive standards from db
        /// </summary>
        /// <returns></returns>
        public IQueryable<Gheastandard> RetrieveGHEAStandards()
        {
            IQueryable<Gheastandard> standardsQuery = from standards in dbcontext.Gheastandards
                                                      select standards;
            return standardsQuery;
        }

        /// <summary>
        /// Description:function to retrive Standard used from db
        /// </summary>
        /// <param name="requestID"></param>
        /// <returns></returns>
        public IQueryable<Object> RetrieveGHEAStandardsUsed(int requestID)
        {

            IQueryable<Object> standardsUsedQuery = from standard in dbcontext.Gheastandards.Where(x => x.IsActive == true)
                                                    join standardUsed in dbcontext.GheastandardsUseds on standard.GheastandardId equals standardUsed.GheastandardId into combined
                                                    from matched in combined.Where(x => x.RequestId == requestID).DefaultIfEmpty()
                                                    select new { RequestID = requestID, standard.GheastandardId, standard.GheastandardName, standard.GheastandardType, selected = matched != null ? true : false };

            return standardsUsedQuery;
        }

        /// <summary>
        /// Description:function to retrive project type from db
        /// </summary>
        /// <returns></returns>
        public IQueryable<ProjectType> RetrieveProjectTypes()
        {
            IQueryable<ProjectType> projectTypesQuery = from projectTypes in dbcontext.ProjectTypes
                                                        select projectTypes;
            return projectTypesQuery;
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

        public IQueryable<Reviewer> RetrieveDMs()
        {
            IQueryable<Reviewer> reviewersQuery = from reviewers in dbcontext.Reviewers
                                                  where (reviewers.Role.Equals("Both") || reviewers.Role.Equals("DM"))
                                                  select reviewers;
            return reviewersQuery;
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

        public IQueryable<ReviewType> RetrieveReviewTypes()
        {
            IQueryable<ReviewType> reviewTypeQuery = from reviewtype in dbcontext.ReviewTypes
                                                     select reviewtype;
            return reviewTypeQuery;
        }

        /// <summary>
        /// Description:function to retrive all reviewers from db
        /// </summary>
        /// <returns></returns>
        public IQueryable<RiskCategory> RetrieveRiskCategories()
        {
            IQueryable<RiskCategory> riskCategoryQuery = from riskCategory in dbcontext.RiskCategories
                                                         select riskCategory;
            return riskCategoryQuery;
        }

        /// <summary>
        /// Description:function to retrive all reviewers from db
        /// </summary>
        /// <returns></returns>
        public IQueryable<RiskCategory> RetrieveRiskCategoryByConditionID(int ConditionID)
        {
            IQueryable<RiskCategory> riskCategoryQuery = from riskCategory in dbcontext.RiskCategories
                                                         join riskCatAssign in dbcontext.RiskCategoryAssignments on riskCategory.RiskCategoryId equals riskCatAssign.RiskCategoryId
                                                         where riskCatAssign.ActionItemId.Equals(ConditionID)
                                                         select riskCategory;
            return riskCategoryQuery;
        }

        /// <summary>
        /// Description:function to retrive action item from db
        /// </summary>
        /// <returns></returns>
        public IQueryable<ActionItem> RetriveActionItem()
        {
            IQueryable<ActionItem> actionItemQuery = from ActionItem in dbcontext.ActionItems.Include("ActionItemType1").Include("ActionItemAttachments").Include("RiskCategoryAssignments").Include("Domain")
                                                     select ActionItem;
            return actionItemQuery;
        }

        /// <summary>
        /// Description:function to retrive all question from db
        /// </summary>
        /// <returns></returns>
        public IQueryable<Question> RetriveQuestion()
        {
            IQueryable<Question> questionQuery = from question in dbcontext.Questions.Include("Domain1.DomainName")
                                                 where question.Active != false
                                                 select question;
            return questionQuery;
        }

        /// <summary>
        /// Description:function to retrive all question for particular request from db
        /// </summary>
        /// <param name="requestId"></param>
        /// <returns></returns>
        public IQueryable<Object> RetriveQuestion(int requestId)
        {

            IQueryable<Object> questionQuery = from question in dbcontext.Questions.Include("Domain1.DomainName")
                                               where question.Active != false
                                               join questionReponse in dbcontext.QuestionResponses on question.QuestionId equals questionReponse.QuestionId into combined
                                               from matched in combined.Where(x => x.RequestId == requestId).DefaultIfEmpty()
                                               select new
                                               {
                                                   QuestionID = question.QuestionId,
                                                   QuestionText = question.QuestionText,
                                                   Ordinal = question.Ordinal,
                                                   DomainName = question.DomainNavigation.DomainName,
                                                   Active = question.Active,
                                                   CommentOption = question.Commentoptions,
                                                   ResponseValue = matched != null ? matched.ResponseValue : null,
                                                   ResposeAnswer = matched != null ? matched.ResposeAnswer : null,
                                                   QuestionResponseID = matched != null ? matched.QuestionResponseId : 0,
                                                   RequestID = requestId
                                               };


            return questionQuery;

        }

        /// <summary>
        /// Description:function to retrive all question from db
        /// </summary>
        /// <returns></returns>
        public IQueryable<ResolutionStrategy> ResolutionTypes()
        {
            IQueryable<ResolutionStrategy> resolutionTypes = from resolutionType in dbcontext.ResolutionStrategies
                                                             select resolutionType;
            return resolutionTypes;
        }

        public IQueryable<ReviewerDomainAssignment> RetrieveReviewers1()
        {
            IQueryable<ReviewerDomainAssignment> reviewersQuery = (from rda in dbcontext.ReviewerDomainAssignments.Include("ReviewerDomainAssignments.Reviewer")
                                                                   join reviewer in dbcontext.Reviewers on
                                                                   rda.ReviewerId equals reviewer.ReviewerId
                                                                   join domain in dbcontext.Domains on
                                                                   rda.DomainId equals domain.DomainId
                                                                   select new ReviewerDomainAssignment
                                                                   {
                                                                       DomainId = rda.DomainId,
                                                                       ReviewerId = rda.ReviewerId,
                                                                       Reviewer = rda.Reviewer,
                                                                       Domain = rda.Domain
                                                                   });

            return reviewersQuery;
        }

        public IQueryable<Reviewer> GetUserList()
        {
            IQueryable<Reviewer> reviewersQuery = from reviewers in dbcontext.Reviewers.Include("ReviewerDomainAssignments.Domain")

                                                  select reviewers;
            return reviewersQuery;
        }
    }
}

