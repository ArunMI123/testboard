using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ARBDashboard.Models;

namespace ARBDashboard.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private ARB_DevelopContext dbcontext;

        public LoginRepository(ARB_DevelopContext _context)
        {
            dbcontext = _context;

        }

        public User ValidateCredentials(User user)
        {
            User _user = dbcontext.Users.Where(x => x.UserName.ToLower() == user.UserName.ToLower()).FirstOrDefault();
                             
            return _user;
        }

    }
}
