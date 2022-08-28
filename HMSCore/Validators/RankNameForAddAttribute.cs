using HMSCore.Validators.Messages;
using HMSCore.Services;
using System.ComponentModel.DataAnnotations;

namespace HMSCore.Validators
{
    public class RankNameForAddAttribute : ValidationAttribute
    {
        public override bool RequiresValidationContext { get { return true; } }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            var guestRankService = (IGuestRanksService)validationContext.GetService(typeof(IGuestRanksService));

            if (guestRankService.IsNameExistWhenAdd(value?.ToString().Trim()))
            {
                return new ValidationResult(ValidatorConstants.validateRankNameErrMsg);
            }

            return ValidationResult.Success;
        }
    }
}