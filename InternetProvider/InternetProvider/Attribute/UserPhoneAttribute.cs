using Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InternetProvider.Attribute
{
    public class UserPhoneAttribute : ValidationAttribute
    {
        public string GetErrorMessage() => $"This phone is already in use.";
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DbRepository dbRepository = new DbRepository();
            var account = dbRepository.GetAccountByPhoneNumber((string)value);
            if (account == null)
                return ValidationResult.Success;
            return new ValidationResult(GetErrorMessage());
        }
    }
}
