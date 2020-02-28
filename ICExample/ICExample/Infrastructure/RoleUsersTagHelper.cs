using ICExample.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICExample.Infrastructure {

    [HtmlTargetElement("user-list", Attributes = "role-id")]
    public class RoleUsersTagHelper : TagHelper {
        private readonly UserManager<UserModel> userManager;
        private RoleManager<IdentityRole> roleManager;

        [HtmlAttributeName("role-id")]
        public string RoleId { get; set; }

        public RoleUsersTagHelper(UserManager<UserModel> userManager,
                                  RoleManager<IdentityRole> roleManager) {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public override async Task ProcessAsync(TagHelperContext context,
                                                TagHelperOutput output) {

            IdentityRole role = await roleManager.FindByIdAsync(RoleId);

            if(role == null) {
                output.Content.SetContent("No Users");
            }

            List<string> usernames = new List<string>();
            foreach(var user in userManager.Users) {
                if(user != null && await userManager.IsInRoleAsync(user, role.Name)) {
                    usernames.Add(user.UserName);
                }
            }

            output.Content.SetContent(string.Join(", ", usernames));
        }
    }
}
