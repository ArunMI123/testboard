using ARBDashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ARBDashboard.Services
{
    public interface IReviewService
    {
        IEnumerable<Domain> GetAllDomains();
        IEnumerable<ActionItemType> GetAllActionTypes();
        IEnumerable<Gheastandard> GetAllGHEAStandards();
        IEnumerable<Object> GetAllGHEAStandards(int requestID);
        IEnumerable<Region> GetAllRegions();
        Reviewer GetReviewer(string emailAddress);
        IEnumerable<ReviewerDomainAssignment> GetAllReviewers();
        IEnumerable<Reviewer> GetDM();
        //IEnumerable<KeyValuePair> GetAllReviewStages();
        IEnumerable<Object> GetQuestion(int requestId);
        IEnumerable<ReviewType> GetAllReviewTypes();
        IEnumerable<ResolutionStrategy> GetResolutionTypes();
        IList<Reviewer> GetUserList();
        Reviewer GetUser(int userID);
        Reviewer GetDomainUser(string email);
      
    }
}