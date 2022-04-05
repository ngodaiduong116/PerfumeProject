using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePerfume.ViewModels.System.Users
{
    public class LoginRequestValidate : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidate()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("User name is required");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required").MinimumLength(6).WithMessage("Password is at lease 6 character");
        }
    }
}