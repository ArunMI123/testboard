using System;
using System.Security.Claims;
using ARBDashboard.Models;
using ARBDashboard.Services;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;

namespace ARBDashboard.Controllers
{

    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private const string LocalLoginProvider = "Local";
        private ILoginProvider _loginProvider;
        private IRequestService _requestService;


        public AccountController(ILoginProvider loginProvider, IRequestService requestService)
        {
            _loginProvider = loginProvider;
            _requestService = requestService;

        }
        /// <summary>
        /// Description:Fuction for Login authentication
        /// </summary>
        /// <param name="user">Login Information(UserName & Password)</param>
        /// <returns>User details & token </returns>

        [HttpPost]
        [Route("Token")]
        public IActionResult Token([FromBody] ARBDashboard.Models.User user)
        {

            ClaimsIdentity identity;
            if (!_loginProvider.ValidateCredentials(ref user, out identity))
            {
                return BadRequest("Incorrect UserName or Password");

            }

            Reviewer reviewer = _requestService.GetReviewer(user.Email);
            Region region = _requestService.GetAllRegions().Where(x => x.RegionName == user.Region).FirstOrDefault();
            // String authString = "Administrator:Welcome@321";
            String authString = user.UserName + ":" + user.Password;
            var authStringBytes = System.Text.Encoding.UTF8.GetBytes(authString);
            String authBaseString = System.Convert.ToBase64String(authStringBytes);
            //identity.AddClaim(new Claim("Ticket", authBaseString));

            //var ticket = new AuthenticationTicket(identity, new AuthenticationProperties());
            //var currentUtc = new SystemClock().UtcNow;
            //ticket.Properties.IssuedUtc = currentUtc;
            //ticket.Properties.ExpiresUtc = currentUtc.Add(TimeSpan.FromMinutes(45));

            return Ok(new
            {
                Name = user.Name,
                FirsName = user.FirstName,
                LastName = user.LastName,
                Region = user.Region,
                RegionID = region != null ? region.RegionId.ToString() : "",
                Role = (reviewer == null ? "Requester" : (reviewer.Role == "Both" ? "DM" : reviewer.Role)),
                IsDMalsoAReviewer = ((reviewer != null && reviewer.Role == "Both") ? true : false),
                Email = user.Email.ToLower(),
                // AccessToken = Startup.OAuthOptions.AccessTokenFormat.Protect(ticket)
            });
        }


    }
}
