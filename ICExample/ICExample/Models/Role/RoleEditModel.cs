using System.ComponentModel.DataAnnotations;

namespace ICExample.Models.Role {
    public class RoleEditModel {
        [Required]
        public string Id { get; set; }

        public string Name { get; set; }

        public string[] UserIdsToAdd { get; set; }

        public string[] UserIdsToDelete { get; set; }
    }
}
