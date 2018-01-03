using ARBDashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARBDashboard.Repository
{
    public interface IRequestRepository
    {
        IEnumerable<WorkQueueRequest> GetAllWorkQueueData();
        Reviewer GetUser(string email);
        IQueryable<ReviewStage> RetrieveReviewStages();
        IQueryable<Reviewer> RetrieveReviewers();
        IQueryable<Region> RetrieveRegions();
        IQueryable<Reviewer> RetrieveReviewer(string emailAddress);
    }
}
