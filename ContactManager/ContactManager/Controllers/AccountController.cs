using ContactManager.Models;
using ContactManager.ViewModels.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ContactManager.Controllers {
    public class AccountController : Controller {
        private readonly UserManager<UserModel> userManager;
        private readonly SignInManager<UserModel> signInManager;

        public AccountController(UserManager<UserModel> userManager,
                                 SignInManager<UserModel> signInManager) {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl) {
            ViewBag.returnUrl = returnUrl;

            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(LogInViewModel model, string returnUrl) {
            if (!ModelState.IsValid) {
                return View(model);
            }
            UserModel user = await userManager.FindByEmailAsync(model.UsernameOrEmail) ??
                             await userManager.FindByNameAsync(model.UsernameOrEmail);

            if (user == null) {
                ModelState.AddModelError("", "Invalid username/email or password.");

                return View(model);
            }

            await signInManager.SignOutAsync();
            var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);

            if (!result.Succeeded) {
                ModelState.AddModelError("", "Invalid username/email or password.");

                return View(model);
            }

            return Redirect(returnUrl ?? "/");
        }

        [HttpGet]
        public async Task<IActionResult> LogOut() {
            await signInManager.SignOutAsync();

            return Redirect("/");
        }
    }
}