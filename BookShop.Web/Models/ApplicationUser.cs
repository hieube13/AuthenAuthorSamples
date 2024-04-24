using Microsoft.AspNetCore.Identity;

namespace BookShop.Web.Models
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime? CompanyStartedDate { get; set; }

        public string? Address { get; set;}
    }
}
