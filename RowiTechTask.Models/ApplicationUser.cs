using Microsoft.AspNetCore.Identity;

namespace RowiTechTask.Models
{
    public class ApplicationUser : IdentityUser
    { 
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }
    }
}
