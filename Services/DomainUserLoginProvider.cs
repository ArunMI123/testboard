using System.Security.Claims;
using ARBDashboard.Models;
using System;
using ARBDashboard.Repository;
using System.Collections.Generic;
using Serilog;

namespace ARBDashboard.Services
{
    public class DomainUserLoginProvider : ILoginProvider
    {
        ILoginRepository _loginRepository;

        public DomainUserLoginProvider(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        /// <summary>
        /// Description:Function to validate credential in active service.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="identity"></param>
        /// <returns></returns>
        public bool ValidateCredentials(ref User user, out ClaimsIdentity identity)
        {
            bool isValid = false;
            User _user = null;
            try
            {
                if (!String.IsNullOrEmpty(user.UserName) && !String.IsNullOrEmpty(user.Password))
                {
                    _user = _loginRepository.ValidateCredentials(user);
                    if (_user != null && (user.Password == _user.Password))
                    {
                        isValid = true;

                    }
                }

                if (isValid)
                {

                    user.Name = _user.Name;
                    user.FirstName = _user.FirstName;
                    user.LastName = _user.LastName;
                    user.Email = _user.Email;
                    user.Region = _user.Region;

                    //JDS: 6/8/2017 - Added this fix to get the region out of the attributes section.
                    //
                    //user.Region = AccountManagementExtensions.GetProperty(searchResult, "physicalDeliveryOfficeName");

                    //identity = new ClaimsIdentity(Startup.OAuthOptions.AuthenticationType);
                    //identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));

                    identity = null;
                }
                else
                {
                    identity = null;

                }
            }
            catch (Exception exception)
            {
                Log.Error(exception.StackTrace);
                throw exception;
            }

            return isValid;
        }

        public string CreateUserToken(string userName, string password)
        {
            string strToken = string.Empty;
            strToken = userName + ":" + password;
            var AuthString = System.Text.Encoding.UTF8.GetBytes($"{userName}:{password}");
            return System.Convert.ToBase64String(AuthString);

        }

        /// <summary>
        /// Description:Function to return domain.
        /// </summary>
        /// <param name="domain"></param>
        public DomainUserLoginProvider()
        {
            
        }

        private readonly string _domain;
    }


}