﻿using System.ComponentModel.DataAnnotations;

namespace FinalProject.ViewModels
{
    public class LoginViewModel
    {

        [Required(ErrorMessage ="Required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage ="Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
