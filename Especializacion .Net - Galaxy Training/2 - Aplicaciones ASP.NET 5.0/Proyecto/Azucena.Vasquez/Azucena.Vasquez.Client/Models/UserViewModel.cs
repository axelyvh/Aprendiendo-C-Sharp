using System.Collections.Generic;

namespace Azucena.Vasquez.Client.Models
{
    public class UserViewModel
    {

        public UserViewModel()
        {
            UserRoles = new List<UserRolesViewModel>();
        }

        public string Id { get; set; }
        public string UserName { get; set; }
        public string Clave { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string RoleId { get; set; }
        public List<UserRolesViewModel> UserRoles { get; set; }
    }
}
