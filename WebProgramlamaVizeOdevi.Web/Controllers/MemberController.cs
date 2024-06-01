using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebProgramlamaVizeOdevi.Web.Models;

namespace WebProgramlamaVizeOdevi.Web.Controllers
{
    public class MemberController : Controller
    {

        private readonly SignInManager<AppUser> _signInManager;

        public MemberController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task LogOut()//eski yöntemde IAction result dönüyor idi 
        {

            await _signInManager.SignOutAsync();
           

        }





    }
}
