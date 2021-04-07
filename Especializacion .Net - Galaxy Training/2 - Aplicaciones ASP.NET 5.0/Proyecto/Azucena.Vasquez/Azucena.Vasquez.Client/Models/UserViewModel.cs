using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Azucena.Vasquez.Client.Models
{
    public class UserViewModel
    {

        public UserViewModel()
        {
            UserRoles = new List<UserRolesViewModel>();
        }

        public string Id { get; set; }

        [Required(ErrorMessage = "Usuario es requerido")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Contraseña es requerido")]
        public string Clave { get; set; }

        [Required(ErrorMessage = "Nombres es requerido")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Apellidos es requerido")]
        public string LastName { get; set; }
        
        public string FullName { get; set; }
        
        [EmailAddress]
        [Required(ErrorMessage = "Email es requerido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Rol es requerido")]
        public string RoleId { get; set; }

        public List<UserRolesViewModel> UserRoles { get; set; }

    }
}
