using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Pesel")]
        public string Pesel { get; set; }
        [Required]
        [Display(Name = "Phone")]
        public string Phone { get; set; }
    }
}
