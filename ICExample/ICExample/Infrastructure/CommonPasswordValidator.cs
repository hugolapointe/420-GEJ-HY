using ICExample.Resources;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICExample.Infrastructure {
    public class CommonPasswordValidator<TUser> : IPasswordValidator<TUser>
        where TUser : IdentityUser {
        public HashSet<string> PasswordsForbidden { get; private set; }

        public CommonPasswordValidator(CommonPasswordLists lists) {
            PasswordsForbidden = lists.Top10kPasswords.Value;
        }

        public Task<IdentityResult> ValidateAsync(UserManager<TUser> manager,
                                                  TUser user,
                                                  string password) {
            if(PasswordsForbidden.Contains(password)) {
                var result = IdentityResult.Failed(new IdentityError {
                    Code = "CommonPassword",
                    Description = "The password you chose is too common."
                });

                return Task.FromResult(result);
            }
            return Task.FromResult(IdentityResult.Success);
        }
    }
}
