
using System.ComponentModel.DataAnnotations;

namespace WebProgramlamaVizeOdevi.Web.ViewModels
{                                           
    public class SignUpViewModel
    {

        public SignUpViewModel()
        {
            
        }

        public SignUpViewModel(string userName,string email,string phone,string password)
        {
            UserName = userName;
            Email = email;  
            Phone = phone;  
            Password = password;    

        }

        [Required(ErrorMessage ="Kullanıcı adı alanı boş bırakılamaz !")] 
        [Display(Name ="Kullanıcı Adı:")]
        public string UserName { get; set; }//nullleri gösteriiyor

        [EmailAddress(ErrorMessage ="Email formatı yanlış !")]
        [Required(ErrorMessage = "Email alanı boş bırakılamaz !")]
        [Display(Name = "Email:")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Telefon numarası formatı yanlış !")]
        [Required(ErrorMessage = "Telefon alanı boş bırakılamaz !")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefon:")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Şifre alanı boş bırakılamaz !")]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre:")]
        public string Password { get; set; }

        [Compare(nameof(Password),ErrorMessage ="Girdiğiniz şifreler eşleşmemektedir")]
        [Required(ErrorMessage = "Şifre Tekrarı alanı boş bırakılamaz !")]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre Tekrar:")]
        public string PasswordConfirm { get; set; }


    }
}
