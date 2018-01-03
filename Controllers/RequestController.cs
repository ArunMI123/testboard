using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using ARBDashboard.Models;
using ARBDashboard.Services;


namespace ARBDashboard.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    public class RequestController : Controller
    {
        IRequestService requestService;

        public RequestController(IRequestService _requestService)
        {
            requestService = _requestService;
        }

        /// <summary>
        /// Description:Function for get projects for work queue 
        /// </summary>
        /// <param name="user"></param>
        /// <returns>List of projects</returns>
        [Route("GetRequests")]
        [HttpPost]
        public IActionResult GetRequests([FromBody] User user)
        {
            List<WorkQueueRequest> workQueueRequest = requestService.GetRequests(user).ToList();
            return Json(workQueueRequest);
        }

        [HttpPost]
        [Route("SearchRequest")]
        public IActionResult SearchRequest([FromBody] SearchModel search)
        {
            IEnumerable<WorkQueueRequest> result = requestService.SearchRequest(search);
            return Json(result);
        }

        /// <summary>
        /// Description:Function for get stages. 
        /// </summary>
        /// <returns>stages</returns>
        [Route("Stages")]
        public IActionResult GetStages()
        {
            var result = requestService.GetAllReviewStages();

            //if (!result.Any())
            //{
            //    throw new HttpResponseException(HttpStatusCode.NoContent);
            //}

            return Json(result);
        }


        [Route("PageTest")]
        public string PageTest()
        {
            return "Its working";
        }
    }
}
