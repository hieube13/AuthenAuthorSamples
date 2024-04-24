using Microsoft.AspNetCore.Identity;

namespace BookShop.Identity.Data
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime? CompanyStartedDate { get; set; }

        [PersonalData]
        public string? Address { get; set; }
    }
}
