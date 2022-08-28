using HMSCore.Validators.Messages;
using HMSCore.Areas.Admin.Validators;
using System.ComponentModel.DataAnnotations;

namespace HMSCore.Areas.Admin.Models.Cities
{
    public class EditCityFormModel
    {
        [Required]
        [IsCityNameExistWhenEditAttribute1]
        [MinLength(3, ErrorMessage = ValidatorConstants.minLength)]
        [MaxLength(30, ErrorMessage = ValidatorConstants.maxLength)]
        public string Name { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = ValidatorConstants.minLength)]
        [MaxLength(30, ErrorMessage = ValidatorConstants.maxLength)]
        [Display(Name = "Postal code")]
        public string PostalCode { get; set; }

        public string Id { get; set; }
    }
}