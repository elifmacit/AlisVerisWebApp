using AlisVerisWebApp.Data;
using AlisVerisWebApp.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AlisVerisWebApp.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(AppUserRegisterDto appUserRegisterDto)
        {
            Random random = new Random();
            int code = 0;
            code = random.Next(10000, 1000000);
            AppUser appuser = new AppUser()
            {
                FirstName = appUserRegisterDto.FirstName,
                LastName = appUserRegisterDto.LastName,
                UserName = appUserRegisterDto.UserName,
                City = appUserRegisterDto.City,
                Email = appUserRegisterDto.Email,
                ConfirmCode = code
            };
            var result = await userManager.CreateAsync(appuser, appUserRegisterDto.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Home", "Index");
            }
            return View();
        }
    }
}
