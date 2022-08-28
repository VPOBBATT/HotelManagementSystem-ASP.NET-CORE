﻿using HMSCore.Validators.Messages;
using System;
using System.ComponentModel.DataAnnotations;

namespace HMSCore.Models.Vouchers
{
    public class AddVoucherFormModel
    {
        [Required]
        [MaxLength(50, ErrorMessage = ValidatorConstants.maxLength)]
        [MinLength(2, ErrorMessage = ValidatorConstants.minLength)]
        public string Name { get; set; }

        [Range(1, 50)]
        public int Discount { get; set; }
    }
}