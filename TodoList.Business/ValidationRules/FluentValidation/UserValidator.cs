using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FluentValidation;
using TodoList.Entities.Concrete;

namespace TodoList.Business.ValidationRules.FluentValidation
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.UserName).NotEmpty();
            RuleFor(u => u.UserName).MinimumLength(2);
            RuleFor(u => u.UserEmail).NotEmpty();
            RuleFor(u => u.UserEmail).EmailAddress();
            RuleFor(u => u.UserPassword).NotEmpty();
            RuleFor(u => u.UserPassword).MinimumLength(6).WithMessage("Parolanız en az 6 karakter içermelir.");
            RuleFor(u => u.UserPassword).Must(IsPasswordValid).WithMessage("Parolanızda en az bir küçük harf bir büyük harf ve rakam olmalıdır.");

        }
        private bool IsPasswordValid(string arg)
        {
            try
            {
                var regex = new Regex(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[0-9])[A-Za-z\d]");
                return regex.IsMatch(arg);
            }
            catch
            {
                return false;
            }
        }
    }
}
