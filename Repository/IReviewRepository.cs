using ARBDashboard.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ARBDashboard.Repository
{
    public interface IReviewRepository
    {
        IQueryable<Domain> RetrieveDomains();
        IQueryable<ActionItemType> RetrieveActionTypes();
        IQueryable<Gheastandard> RetrieveGHEAStandards();
        IQueryable<Object> RetrieveGHEAStandardsUsed(int requestID);
        IQueryable<ProjectType> RetrieveProjectTypes();
        IQueryable<Region> RetrieveRegions();
        IQueryable<Reviewer> RetrieveReviewer(string emailAddress);
        IQueryable<Reviewer> RetrieveReviewers();
        IQueryable<Reviewer> RetrieveDMs();
        IQueryable<ReviewStage> RetrieveReviewStages();
        IQueryable<RiskCategory> RetrieveRiskCategories();
        IQueryable<RiskCategory> RetrieveRiskCategoryByConditionID(int ConditionID);

        IQueryable<Question> RetriveQuestion();
        IQueryable<Object> RetriveQuestion(int requestId);
        IQueryable<EventType> RetrieveEventType();
        IQueryable<ReviewType> RetrieveReviewTypes();
        IQueryable<ResolutionStrategy> ResolutionTypes();
        IQueryable<ReviewerDomainAssignment> RetrieveReviewers1();
        IQueryable<Reviewer> GetUserList();

    }
}