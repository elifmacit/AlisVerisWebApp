using Microsoft.AspNetCore.Identity;

namespace AlisVerisWebApp.Data
{
    public class AppUser : IdentityUser
    {
        public string? FirstName { get; internal set; }
        public string? LastName { get; internal set; }
        public string? City { get; internal set; }
        public int ConfirmCode { get; internal set; }
    }
}