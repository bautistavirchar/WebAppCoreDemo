using Microsoft.AspNetCore.Identity;

namespace WebAppCoreDemo
{
    public class ApplicationUser : IdentityUser
    {
        public string Fullname { get; set; }
        public string OldPassword { get; set; }
    }

    public class ApplicationRole : IdentityRole
    {
        public string Description { get; set; }
    }
}