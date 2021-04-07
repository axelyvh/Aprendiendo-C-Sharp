using Microsoft.AspNetCore.Identity;

namespace Azucena.Vasquez.Client.Areas.Identity.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
