using Microsoft.AspNetCore.Identity;

namespace WebProgramlamaVizeOdevi.Web.Localization
{
    public class LocalizationIdentityErrorDescriber:IdentityErrorDescriber
    {


       

        public override IdentityError DuplicateEmail(string email)
        {
            return new IdentityError
            {
                Code = "DublicateEmail",
                Description = $"{email} daha önce " +
              $"başka bir kullanıcı tarafından alınmıştır"
            };

        }
        public override IdentityError DuplicateUserName(string userName)
        {
            return new IdentityError
            {
                Code = "DublicateUserName",
                Description = $"{userName} daha önce " +
               $"başka bir kullanıcı tarafından alınmıştır"
            };
        }
        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError
            {
                Code = "PasswordRequiresLower",
                Description = $"Şifre en az 1 küçük karakter içermelidir  !"
            };
        }
       
      
        public override IdentityError PasswordRequiresUpper()
       
        {
            return new IdentityError
            {
                Code = "PasswordRequiresUpper",
                Description = $"Şifre en az 1 Büyük karakter içermelidir  !"
            };
        }
        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError
            {
                Code = "PasswordTooShort",
                Description = $"Şifre en az 6 karakterli olmalıdır !"
            };
        }



    }
}
