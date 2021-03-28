using App.RLB.WebAPI.Services.Interface;
using EF.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace App.RLB.WebAPI.Services
{
    public class LoginService : ILoginService
    {
        protected readonly IRepositoryBase<IdentityUser> loginRepository;

        public Task<IdentityUser> InsertDb(IdentityUser userApp)
        {
            var IUser = loginRepository.InsertDb(userApp);
            loginRepository.CommitWork();
            return Task.FromResult(IUser);
        }
        public Task<IdentityUser> FindLogin(string Login)
            => Task.FromResult(loginRepository.GetFirst((l) => l.Email == Login));
    }

}
