namespace Azucena.Vasquez.Client.Models
{
    public class UserRolesViewModel
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }

        public virtual RolesViewModel Role { get; set; }
        public virtual UserViewModel User { get; set; }
    }
}
