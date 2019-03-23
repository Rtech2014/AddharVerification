using AddharVerification.Models;
using Microsoft.AspNetCore.Identity;

namespace AddharVerification.Data
{
    public class AppUser : IdentityUser
    {
        public Passport Passport { get; set; }
        public Visa Visa { get; set; }
    }
}
