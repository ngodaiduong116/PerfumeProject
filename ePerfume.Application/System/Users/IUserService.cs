using ePerfume.ViewModels.Common;
using ePerfume.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePerfume.Application.System.Users
{
    public interface IUserService
    {
        Task<string> Authenticate(LoginRequest request);

        Task<bool> Register(RegisterRequest request);

        Task<PageResult<UserVm>> GetUserPaging(GetUserPagingRequest request);
    }
}