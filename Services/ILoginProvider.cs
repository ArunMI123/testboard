using System.Security.Claims;
using ARBDashboard.Models;

namespace ARBDashboard.Services
{
    public interface ILoginProvider
    {
        bool ValidateCredentials(ref ARBDashboard.Models.User user, out ClaimsIdentity identity);
        string CreateUserToken(string userName, string password);
    }
}
