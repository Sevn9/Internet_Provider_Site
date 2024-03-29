﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InternetProvider.Models
{
    public class AuthorizationForm
    {
        [Required(ErrorMessage = "Не указана Почта")]
        public string LoginKey { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
