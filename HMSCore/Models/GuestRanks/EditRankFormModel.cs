﻿using System;
using System.ComponentModel.DataAnnotations;
using HMSCore.Validators.Messages;
using HMSCore.Validators;

namespace HMSCore.Models.GuestRanks
{
    public class EditRankFormModel
    {
        public string Id { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = ValidatorConstants.minLength)]
        [MaxLength(30, ErrorMessage = ValidatorConstants.maxLength)]
        [RankNameForEdit]
        public string Name { get; set; }

        [Range(1, 50)]
        public int Discount { get; set; }
    }
}