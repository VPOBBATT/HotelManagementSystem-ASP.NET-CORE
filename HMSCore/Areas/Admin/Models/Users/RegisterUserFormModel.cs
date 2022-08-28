//using HMSCore.Validators.Messages;
using HMSCore.Areas.Admin.Validators.Messages;
using System.ComponentModel.DataAnnotations;

namespace HMSCore.Areas.Admin.Models.Users
{
    public class RegisterUserFormModel
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Display(Name = "Full Name")]
        [Required]
        [MinLength(3, ErrorMessage = ValidatorConstants.minLength)]
        [MaxLength(30, ErrorMessage = ValidatorConstants.maxLength)]
        public string FullName { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = ValidatorConstants.minLength)]
        [MaxLength(30, ErrorMessage = ValidatorConstants.maxLength)]
        public string Password { get; set; }
    }
}