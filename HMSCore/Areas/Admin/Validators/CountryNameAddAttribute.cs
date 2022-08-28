using HMSCore.Areas.Admin.Services;
using HMSCore.Areas.Admin.Validators.Messages;
using System.ComponentModel.DataAnnotations;

namespace HMSCore.Areas.Admin.Validators
{
    public class CountryNameAddAttribute : ValidationAttribute
    {
        public override bool RequiresValidationContext { get { return true; } }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            var countryService = (ICountriesService)validationContext.GetService(typeof(ICountriesService));


            if (countryService.IsCountryExistForAdd(value?.ToString().Trim()))
            {
                return new ValidationResult(ValidatorConstants.validateCountryNameErrMsg);
            }

            return ValidationResult.Success;
        }
    }
}