using System.ComponentModel.DataAnnotations;

namespace WebProgramlamaVizeOdevi.Web.ViewModels
{
    public class SignInViewModel
    {
        public SignInViewModel()
        {
            
        }
        public SignInViewModel(string email,string password)
        {
            Email= email;
            Password= password; 
        }

        [EmailAddress(ErrorMessage = "Email formatı yanlış !")]
        [Required(ErrorMessage = "Email alanı boş bırakılamaz !")]
        [Display(Name = "Email:")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre alanı boş bırakılamaz !")]
        [DataType(DataType.Password)]//bozamam inş
        [Display(Name = "Şifre:")]
        public string Password { get; set; }

        public bool  RememberMe { get; set; }


        //public  string? PictureUrl { get; set; }//navbara resim eklenmesi için oluşturuldu

    }
}
