using ePerfume.ViewModels.Common;
using ePerfume.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e.Perfume.AdminApp.Services
{
    public interface IUserApi
    {
        Task<string> Authenticate(LoginRequest request);
        Task<PageResult<UserVm>> GetUsersPaging(GetUserPagingRequest request);

        Task<bool> RegisterUser(RegisterRequest request);
    }
}
