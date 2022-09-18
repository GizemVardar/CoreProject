using Demo.Core.MvcUI.Entities;
using Demo.Core.MvcUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Core.MvcUI.Controllers
{
    public class AccountController : Controller
    {
        public UserManager<IdentityUser> _userManager; // kullanıcı bazlı isimler isim soyisim vs
        public RoleManager<IdentityRole> _roleManager;// rol bazlı işlemler admin user
        public SignInManager<IdentityUser> _singInManager; // giriş cıkıs singin rememberme gibi işlemlerin oldugu classlardır. bu classlar Identity İçerisindedir. 
        public AccountController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager; 
            _singInManager = signInManager;
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // Giriş yaparken dogrulama ve token olusturur. 
        public IActionResult Register(RegisterViewModel registerViewModel)
        {

            if (ModelState.IsValid)
            {
                CustomIdentityUser user = new CustomIdentityUser
                {
                    UserName = registerViewModel.UserName,
                    Email = registerViewModel.Email,
                };
                IdentityResult result = _userManager.CreateAsync(user, registerViewModel.Password).Result;
                if (result.Succeeded)
                {
                    if (!_roleManager.RoleExistsAsync("Admin").Result)
                    {
                        CustomIdentityRole role = new CustomIdentityRole
                        {
                            Name = "Admin"
                        };
                        IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
                        if (!roleResult.Succeeded)
                        {
                            ModelState.AddModelError("", "We are unable to add the role");
                            return View(registerViewModel);
                        }
                    }
                }
                _userManager.AddToRoleAsync(user, "Admin").Wait();
                return RedirectToAction("Login", "Account");
            }
            
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = _singInManager.PasswordSignInAsync(loginViewModel.UserName, loginViewModel.Password, loginViewModel.RememberMe, false).Result;
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Admin");

                }
                ModelState.AddModelError("", "Invalid Login!");
            }
            return View(loginViewModel);

        }
        public IActionResult Logoff()
        {
            _singInManager.SignOutAsync().Wait();//Sistemden çıkış yap bekle.
            return RedirectToAction("Login"); //Çıkış yaptıktan sonra Login sayfasına geri döner.
        }

    }
}
