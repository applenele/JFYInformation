﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFYInformation.Models.ViewModel
{
    public class vRegister
    {
        [Display(Name = "用户名")]
        [Required]
        public string Username { set; get; }


        [Display(Name = "密码")]
        [Required]
        public string Password { get; set; }

        [Display(Name = "密码重复")]
        [Required]
        [Compare("Password")]
        public string Confirm { get; set; }


        [Display(Name = "角色")]

        public Role Role { set; get; }


    }
}
