using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ARBDashboard.Models
{
    public class UserModel
    {
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Region { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Nullable<bool> IsAll { get; set; }

    }
}