
using HMSCore.Areas.Admin.Validators;
using HMSCore.Areas.Admin.Validators.Messages;
using System.ComponentModel.DataAnnotations;

namespace HMSCore.Areas.Admin.Models.Countries
{
    public class EditCountryFormModel
    {
        public string Id { get; set; }

        [Required]
        [CountryNameEdit]
        [MinLength(3, ErrorMessage = ValidatorConstants.minLength)]
        [MaxLength(30, ErrorMessage = ValidatorConstants.maxLength)]
        public string Name { get; set; }
    }
}