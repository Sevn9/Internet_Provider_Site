using InternetProvider.Attribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InternetProvider.Models
{
    public class RegistrationForm
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Patronymic { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        [UserPhone]
        public string PhoneNumber { get; set; }
        [Required]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Введите корректную почту")]
        [UserEmail]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^(?=.{8,16}$)(?=.*?[a-z])(?=.*?[A-Z])(?=.*?[0-9]).*$", ErrorMessage = "минимальная длина 8 карактеров и максимальная 16 по крайней мере одна цифра, нижний регистр и один верхний регистр")]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}
