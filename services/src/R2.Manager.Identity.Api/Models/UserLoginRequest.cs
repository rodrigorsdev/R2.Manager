using System.ComponentModel.DataAnnotations;

namespace R2.Manager.Identity.Api.Models
{
    public class UserLoginRequest
    {
        [Required(ErrorMessage = "{0} is required")]
        [EmailAddress(ErrorMessage = "{0} is in invalid format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(100, ErrorMessage = "{0} must be betwenn {2} and {1} characters", MinimumLength = 6)]
        public string Password { get; set; }
    }
}
