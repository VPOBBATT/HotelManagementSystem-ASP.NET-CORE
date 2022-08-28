using System.ComponentModel.DataAnnotations;
using HMSCore.Validators.Messages;
using HMSCore.Services;

namespace HMSCore.Validators
{
    public class IdentityCardAttribute : ValidationAttribute
    {
        public override bool RequiresValidationContext { get { return true; } }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            var guestService = (IGuestsService)validationContext.GetService(typeof(IGuestsService));

            if (guestService.IsIdentityNumberExist(value?.ToString().Trim()))
            {
                return new ValidationResult(ValidatorConstants.validateIdentityId);
            }

            return ValidationResult.Success;
        }
    }
}