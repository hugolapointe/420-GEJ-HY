using ICExample.Models.Role;
using ICExample.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICExample.Controllers {

    [Authorize(Roles = "Admin")]
    public class RoleController : Controller {
        private readonly UserManager<UserModel> userManager;
        private readonly RoleManager<RoleModel> roleManager;

        public RoleController(UserManager<UserModel> userManager,
                              RoleManager<RoleModel> roleManager) {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Index() {
            return View(roleManager.Roles);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id) {
            var role = await roleManager.FindByIdAsync(id);

            var members = new List<UserModel>();
            var nonMembers = new List<UserModel>();

            foreach(UserModel user in userManager.Users) {
                var list = await userManager.IsInRoleAsync(user, role.Name) ? members : nonMembers;
                list.Add(user);
            }

            return View(nameof(Details), new RoleDetailsModel {
                Role = role,
                Members = members,
                NonMembers = nonMembers
            });
        }

        [HttpGet]
        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoleModel model) {
            if(!ModelState.IsValid) {
                return View(model);
            }

            var result = await roleManager.CreateAsync(model);

            if(!result.Succeeded) {
                foreach(IdentityError error in result.Errors) {
                    ModelState.AddModelError("", error.Description);
                }

                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RoleEditModel model) {
            if(!ModelState.IsValid) {
                return await Details(model.Id);
            }

            foreach(string userId in model.UserIdsToAdd ?? new string[] { }) {
                var user = await userManager.FindByIdAsync(userId);

                if(user != null) {
                    var result = await userManager.AddToRoleAsync(user, model.Name);

                    if(!result.Succeeded) {
                        foreach(var error in result.Errors) {
                            ModelState.AddModelError("", error.Description);
                        }

                        return await Details(model.Id);
                    }
                }
            }

            foreach(string userId in model.UserIdsToDelete ?? new string[] { }) {
                var user = await userManager.FindByIdAsync(userId);

                if(user != null) {
                    var result = await userManager.RemoveFromRoleAsync(user, model.Name);

                    if(!result.Succeeded) {
                        foreach(var error in result.Errors) {
                            ModelState.AddModelError("", error.Description);
                        }

                        return await Details(model.Id);
                    }
                }
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id) {
            var role = await roleManager.FindByIdAsync(id);

            if(role == null) {
                ModelState.AddModelError("", "No role found.");

                return View(nameof(Index), roleManager.Roles);
            }

            var result = await roleManager.DeleteAsync(role);

            if(!result.Succeeded) {
                foreach(var error in result.Errors) {
                    ModelState.AddModelError("", error.Description);
                }

                return View(nameof(Index), roleManager.Roles);
            }

            return RedirectToAction(nameof(Index), roleManager.Roles);
        }
    }
}