using HMSCore.Validators.Messages;
using HMSCore.Services;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace HMSCore.Validators
{
    public class RankNameForEditAttribute : ValidationAttribute
    {
        public override bool RequiresValidationContext { get { return true; } }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            var guestRankService = (IGuestRanksService)validationContext.GetService(typeof(IGuestRanksService));

            var httpAccesor = (IHttpContextAccessor)validationContext.GetService(typeof(IHttpContextAccessor));

            string rankId = httpAccesor.HttpContext.Request.RouteValues.Values.Last().ToString();

            if (guestRankService.IsNameExistWhenEdit(value?.ToString().Trim(), rankId))
            {
                return new ValidationResult(ValidatorConstants.validateRankNameErrMsg);
            }

            return ValidationResult.Success;
        }
    }
}