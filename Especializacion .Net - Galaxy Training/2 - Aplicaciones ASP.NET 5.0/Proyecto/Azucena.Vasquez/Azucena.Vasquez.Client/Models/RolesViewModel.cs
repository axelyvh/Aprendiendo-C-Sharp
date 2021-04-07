using System.Collections.Generic;

namespace Azucena.Vasquez.Client.Models
{
    public class RolesViewModel
    {
        public RolesViewModel()
        {
            UserRoles = new HashSet<UserRolesViewModel>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public string ConcurrencyStamp { get; set; }

        public virtual ICollection<UserRolesViewModel> UserRoles { get; set; }
    }
}
