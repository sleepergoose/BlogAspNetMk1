using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace Blog.Models.IdentityModels
{
    public class PasswordValidation : IIdentityValidator<string>
    {
        public int RequiredLength { get; set; } // минимальная длина

        public PasswordValidation(int length)
        {
            RequiredLength = length;
        }

        public Task<IdentityResult> ValidateAsync(string item)
        {
            if (String.IsNullOrEmpty(item) || item.Length < RequiredLength)
            {
                return Task.FromResult(IdentityResult.Failed(
                                String.Format("Минимальная длина пароля равна {0}", RequiredLength)));
            }
            string pattern = "^[0-9]+$";

            if (!Regex.IsMatch(item, pattern))
            {
                return Task.FromResult(IdentityResult.Failed("Пароль должен состоять только из цифр"));
            }

            return Task.FromResult(IdentityResult.Success);
        }
    }

    public class UserValidator : UserValidator<AppUser>
    {
        public UserValidator(AppUserManager mgr)
            : base(mgr)
        {
            AllowOnlyAlphanumericUserNames = false;
            RequireUniqueEmail = true;
        }
        public override async Task<IdentityResult> ValidateAsync(AppUser user)
        {
            IdentityResult result = await base.ValidateAsync(user);
            if (user.Email.ToLower().EndsWith("@spam.com"))
            {
                var errors = result.Errors.ToList();
                errors.Add("Данный домен находится в спам-базе. Выберите другой почтовый сервис");
                result = new IdentityResult(errors);
            }
            if (user.UserName.Contains("admin"))
            {
                var errors = result.Errors.ToList();
                errors.Add("Ник пользователя не должен содержать слово 'admin'");
                result = new IdentityResult(errors);
            }
            return result;
        }
    }

}