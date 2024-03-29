using Castle.Core.Resource;
using EntityLayer.Entity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validations
{
    public class LoginValidations: AbstractValidator<Users>
    {
        public LoginValidations()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("User Boş olamaz!");
          
        }
    }
}
