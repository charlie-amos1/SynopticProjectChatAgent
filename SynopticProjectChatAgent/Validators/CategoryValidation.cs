using SynopticProjectChatAgent.Helper;
using System.ComponentModel.DataAnnotations;

namespace SynopticProjectChatAgent.Validators
{
    public class CategoryValidation : ValidationAttribute
    {
        FilterOptions filter  =new FilterOptions();

        protected override ValidationResult IsValid(object value, ValidationContext validationContext) 
        {
            string input = value.ToString();

            if (value != null) 
            {
                if (filter.CategoryList.Contains(input)) 
                {
                    return ValidationResult.Success;
                }
               
            }
            return new ValidationResult("Not A Valid Continent");
        }

    }
}
