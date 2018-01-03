using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ARBDashboard.Models;

namespace ARBDashboard.Repository
{
    public interface ILoginRepository
    {
        User ValidateCredentials(User user);
    }
}
