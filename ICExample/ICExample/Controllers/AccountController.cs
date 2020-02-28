using ICExample.Models.Account;
using ICExample.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ICExample.Controllers {
    [Authorize]
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
        public async Task<IActionResult> Login(LoginModel model, string returnUrl) {
            if(!ModelState.IsValid) {
                return View(model);
            }
            UserModel user = await userManager.FindByEmailAsync(model.UsernameOrEmail) ??
                             await userManager.FindByNameAsync(model.UsernameOrEmail);

            if(user == null) {
                ModelState.AddModelError("", "Invalid username/email or password.");

                return View(model);
            }

            await signInManager.SignOutAsync();
            var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);

            if(!result.Succeeded) {
                ModelState.AddModelError("", "Invalid username/email or password.");

                return View(model);
            }

            return Redirect(returnUrl ?? "/");
        }

        [HttpGet]
        public async Task<IActionResult> Logout() {
            await signInManager.SignOutAsync();

            return Redirect("/");
        }
    }
}