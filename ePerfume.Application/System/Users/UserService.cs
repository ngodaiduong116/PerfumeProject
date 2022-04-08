using ePerfume.Data.EF;
using ePerfume.Data.Entities;
using ePerfume.Utilities.Exceptions;
using ePerfume.ViewModels.Common;
using ePerfume.ViewModels.System.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ePerfume.Application.System.Users
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;
        public readonly IPasswordHasher<User> _passwordHasher;
        private readonly IConfiguration _config;

        public UserService(UserManager<User> userManager, SignInManager<User> signInmanager, RoleManager<Role> roleManager, IConfiguration config, IPasswordHasher<User> passwordHasher)
        {
            _userManager = userManager;
            _signInManager = signInmanager;
            _roleManager = roleManager;
            _config = config;
            _passwordHasher = passwordHasher;
        }

        public async Task<string> Authenticate(LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null)
            {
                return null;
            }
            var result = await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, true);
            if (!result.Succeeded)
            {
                return null;
            }
            var roles = _userManager.GetRolesAsync(user);
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Role, string.Join(";", roles)),
                new Claim(ClaimTypes.Name, request.UserName)
            };
            var checkKey = _config["Tokens:Key"];
            var checkIssuser = _config["Tokens:Issuser"];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Tokens:Issuser"],
                _config["Tokens:Issuser"],
                claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<bool> Register(RegisterRequest request)
        {
            var user = new User()
            {
                Dob = request.D0b,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                PhoneNumber = request.PhoneNumber,
            };
            user.PasswordHash = _passwordHasher.HashPassword(user, request.Password);
            user.SecurityStamp = Guid.NewGuid().ToString();
            var result = await _userManager.CreateAsync(user);
            if (result.Succeeded)
            {
                return true;
            }
            return false;
        }

        public async Task<PageResult<UserVm>> GetUserPaging(GetUserPagingRequest request)
        {
            var query = _userManager.Users;
            if (!string.IsNullOrEmpty(request.KeyWord))
            {
                query = query.Where(x => x.UserName.Contains(request.KeyWord) || x.PhoneNumber.Contains(request.KeyWord));
            }

            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new UserVm()
                {
                    Email = x.Email,
                    UserName = x.UserName,
                    FirstName = x.FirstName,
                    Id = x.Id,
                    PhoneNumber = x.PhoneNumber,
                    LastName = x.LastName,
                }).ToListAsync();

            var pageResult = new PageResult<UserVm>()
            {
                TotalRecord = totalRow,
                Items = data
            };

            return pageResult;
        }
    }
}