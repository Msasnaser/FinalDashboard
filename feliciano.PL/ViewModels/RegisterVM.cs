﻿using System.ComponentModel.DataAnnotations;

namespace feliciano.PL.ViewModels
{
    public class RegisterVM
    {
        public string UserName { get; set; }


        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmedPassword { get; set; }
    }
}
