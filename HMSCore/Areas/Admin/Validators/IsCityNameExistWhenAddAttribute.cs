using HMSCore.Areas.Admin.Services;
using HMSCore.Areas.Admin.Validators.Messages;
using System.ComponentModel.DataAnnotations;

namespace HMSCore.Areas.Admin.Validators
{
    public class IsCityNameExistWhenAddAttribute : ValidationAttribute
    {
        public override bool RequiresValidationContext { get { return true; } }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            var countryService = (IAdminCitiesService)validationContext.GetService(typeof(IAdminCitiesService));


            if (countryService.IsCityExistForAdd(value?.ToString().Trim()))
            {
                return new ValidationResult(ValidatorConstants.validateCountryNameErrMsg);
            }

            return ValidationResult.Success;
        }
    }
}