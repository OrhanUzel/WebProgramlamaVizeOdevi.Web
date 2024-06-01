using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Diagnostics;
using WebProgramlamaVizeOdevi.Web.Extensions;
using WebProgramlamaVizeOdevi.Web.Models;
using WebProgramlamaVizeOdevi.Web.ViewModels;





namespace WebProgramlamaVizeOdevi.Web.Controllers
{
    public class HomeController : Controller
    {
      
        private readonly ILogger<HomeController> _logger;//
        private readonly UserManager<AppUser> _UserManager;//kullanıcı kayıt işlemleri için kullanılıyyor
        private readonly SignInManager<AppUser> _SignInManager;//kullanıcı giriş işlemleri için kullanılıyor

       

        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _logger = logger;
            _UserManager = userManager;
            _SignInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }




        public IActionResult SignUp()
        {

            return View();
        }
        public IActionResult SignIn()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel model, string returnUrl = null!)//sayfa yönlrndirmelerei için yeni bir parametre
        {
            returnUrl = returnUrl ?? Url.Action("Index", "Home")!;//return url null değil ise bir sayfaya yönlendiriyorum
            var hasUser = await _UserManager.FindByEmailAsync(model.Email);
            if (hasUser == null)
            {   //kullanıcı bulunamadıysa direk hata veriyor email yada şifre yanlış diye
                ModelState.AddModelError(string.Empty, "Email veya şifre yanlış");
                return View();
            }





            var SignInResult = await _SignInManager.PasswordSignInAsync(hasUser, model.Password, model.RememberMe, true);//false ya da true veritabanının otomatik kilit mekanizmasının devreyue girmesi için 

            if (SignInResult.Succeeded)
            {//bismillah

                var userViewModel0 = new SignInViewModel
                {

                    Email = hasUser!.Email!,


               
                };
          

                return Redirect(returnUrl!);
            }

            if (SignInResult.IsLockedOut)
            {
                ModelState.AddModelErrorList(new List<string>() { "Hesabınız kitlenmiştir. 3 dakika boyunca giriş yapamazsınız." });
                return View();
            }



            ModelState.AddModelErrorList(new List<string>()
            {//toplam kaç başarısız giriş sayısı olduğunu da beliritiyor
                $"Email Adresi veya Şifre Yanlış !" +
                $" (Başarısız giriş sayısı={await _UserManager.GetAccessFailedCountAsync(hasUser)} )"
            });


            return View();


        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel request)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }


            var identityResult = await _UserManager.CreateAsync(new()
            {
                UserName = request.UserName,
                PhoneNumber = request.Phone,
                Email = request.Email
            }, request.PasswordConfirm);//validasyon yapmasam boşluk girdiğimde ilgili yerlere hata vericek boşluk var diye 



            if (identityResult.Succeeded)
            {
                TempData["SuccessMessage"] = "başarı ile kayıt olundu";
             
                return RedirectToAction(nameof(HomeController.SignUp));
            }
          

            ModelState.AddModelErrorList(identityResult.Errors.Select(x => x.Description).ToList());


        
            return View();

        }







    }
}
