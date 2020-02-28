using ICExample.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ICExample.Controllers {

    [Authorize(Roles = "Admin")]
    public class UserController : Controller {
        private UserManager<UserModel> userManager;

        public UserController(UserManager<UserModel> userManager) {
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index() {
            return View(userManager.Users);
        }

        [HttpGet]
        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserCreateModel model) {
            if(!ModelState.IsValid) {
                return View(model);
            }

            UserModel user = new UserModel {
                UserName = model.Username,
                FirstName = model.Firstname,
                LastName = model.Lastname,
                Email = model.Email
            };

            IdentityResult result = await userManager.CreateAsync(user, model.Password);

            if(!result.Succeeded) {
                foreach(IdentityError error in result.Errors) {
                    ModelState.AddModelError("", error.Description);
                }

                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id) {
            UserModel user = await userManager.FindByIdAsync(id);

            if(user == null) {
                return RedirectToAction(nameof(Index));
            }

            return View(new UserEditModel {
                Id = user.Id,
                Username = user.UserName,
                Firstname = user.FirstName,
                Lastname = user.LastName,
                Email = user.Email
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserEditModel model) {
            if(!ModelState.IsValid) {
                return View(model);
            }

            UserModel user = await userManager.FindByIdAsync(model.Id);

            if(user == null) {
                ModelState.AddModelError("", "User Not Found.");

                return View(model);
            }

            bool isCorrect = await userManager.CheckPasswordAsync(user, model.CurrentPassword);

            if(!isCorrect) {
                ModelState.AddModelError("", "The current password wasn't correct.");

                return View(model);
            }

            if(model.Firstname != null && !user.FirstName.Equals(model.Firstname)) {
                user.FirstName = model.Firstname;
                var result = await userManager.UpdateAsync(user);

                if(!result.Succeeded) {
                    ModelState.AddModelError("", "Unable to change the firstname.");

                    return View(model);
                }
            }

            if(model.Lastname != null && !user.Email.Equals(model.Lastname)) {
                user.LastName = model.Lastname;
                var result = await userManager.UpdateAsync(user);

                if(!result.Succeeded) {
                    ModelState.AddModelError("", "Unable to change the lastname.");

                    return View(model);
                }
            }

            if(model.Email != null && !user.Email.Equals(model.Email)) {
                var token = await userManager.GenerateChangeEmailTokenAsync(user, model.Email);
                var result = await userManager.ChangeEmailAsync(user, model.Email, token);

                if(!result.Succeeded) {
                    ModelState.AddModelError("", "Unable to change the email address.");

                    return View(model);
                }
            }

            if(model.NewPassword != null) {
                var token = await userManager.GeneratePasswordResetTokenAsync(user);
                var result = await userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);

                if(!result.Succeeded) {
                    ModelState.AddModelError("", "Unable to change the password.");

                    return View(model);
                }
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id) {
            UserModel user = await userManager.FindByIdAsync(id);

            if(user == null) {
                ModelState.AddModelError("", "User Not Found.");

                return View(nameof(Index), userManager.Users);
            }

            IdentityResult result = await userManager.DeleteAsync(user);

            if(!result.Succeeded) {
                foreach(IdentityError error in result.Errors) {
                    ModelState.AddModelError("", error.Description);
                }

                return View(nameof(Index), userManager.Users);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}