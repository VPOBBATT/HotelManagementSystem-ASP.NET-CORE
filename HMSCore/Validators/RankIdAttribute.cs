using HMSCore.Validators.Messages;
using HMSCore.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HMSCore.Validators
{
    public class RankIdAttribute : ValidationAttribute
    {
        public override bool RequiresValidationContext { get { return true; } }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            var guestService = (IGuestsService)validationContext.GetService(typeof(IGuestsService));

            if (!guestService.IsRankExist(value?.ToString().Trim()))
            {
                return new ValidationResult(ValidatorConstants.validateRankId);
            }

            return ValidationResult.Success;
        }
    }
}