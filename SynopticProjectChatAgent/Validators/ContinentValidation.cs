﻿using SynopticProjectChatAgent.Helper;
using System.ComponentModel.DataAnnotations;

namespace SynopticProjectChatAgent.Validators
{
    public class ContinentValidation : ValidationAttribute
    {
        FilterOptions filter  =new FilterOptions();

        protected override ValidationResult IsValid(object value, ValidationContext validationContext) 
        {
            string input= value.ToString();

            if (value != null) 
            {
                if (filter.ContinentsList.Contains(input)) 
                {
                    return ValidationResult.Success;
                }
               
            }
            return new ValidationResult("Not A Valid Continent");
        }

    }
}