using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ARBDashboard.Models;


namespace ARBDashboard.Services
{
    public interface IRequestService
    {
        IEnumerable<WorkQueueRequest> GetRequests(User user);
        IEnumerable<WorkQueueRequest> SearchRequest(SearchModel search);
        IEnumerable<KeyValuePair<int, string>> GetAllReviewStages();
        IEnumerable<Region> GetAllRegions();
        Reviewer GetReviewer(string emailAddress);
        
    }
}
