using Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InternetProvider.Attribute
{
    public class UserEmailAttribute : ValidationAttribute
    {
        public string GetErrorMessage() => $"This email is already in use.";
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DbRepository dbRepository = new DbRepository();
            var account = dbRepository.GetAccountByEmail((string)value);
            if (account == null)
                return ValidationResult.Success;
            return new ValidationResult(GetErrorMessage());
        }
    }
}
