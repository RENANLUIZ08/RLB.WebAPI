using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace App.RLB.WebAPI.Services.Interface
{
    public interface ILoginService
    {
        Task<IdentityUser> FindLogin(string login);
    }
}
