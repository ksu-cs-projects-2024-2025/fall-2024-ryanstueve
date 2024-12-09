using Microsoft.AspNetCore.Identity;

namespace WebApp.Models
{
    /// <summary>
    /// representation of a user
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = "";

        public string LastName { get; set; } = "";

        public string Address { get; set; } = "";

        public DateTime CreatedAt { get; set; }

        public Guid UserId {
            get
            {
                return new Guid(this.Id);
            }
        }
    }
}
