﻿using Microsoft.AspNetCore.Identity;
namespace FinalProject.Models
{
    public class Users : IdentityUser
    {
        public string FullName {  get; set; }
    }
}
