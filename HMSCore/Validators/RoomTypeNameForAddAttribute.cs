using HMSCore.Validators.Messages;
using HMSCore.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HMSCore.Validators
{
    public class RoomTypeNameForAddAttribute : ValidationAttribute
    {
        public override bool RequiresValidationContext { get { return true; } }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            var roomTypeService = (IRoomsTypeSercvice)validationContext.GetService(typeof(IRoomsTypeSercvice));

            if (roomTypeService.IsRoomNameExistForAdd(value?.ToString().Trim()))
            {
                return new ValidationResult(ValidatorConstants.roomType);
            }

            return ValidationResult.Success;
        }
    }
}