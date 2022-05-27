using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineShoppingCenterproject.Core.Interfaces;
using OnlineShoppingCenterproject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingCenterproject.Core.Entities
{    public class User : IdentityUser
    {
        [Required]
        [StringLength(10, ErrorMessage = "Name is too long.")]
        [Display(Name = "First Name")]
        public string Name { get; set; }
        [Required]

        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        public Gender Gender { get; set; }
        /*
        [Required]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{8,}$",
            ErrorMessage = "Password should have minimum 8 characters, at least 1 uppercase letter, 1 lowercase letter and 1 number.")]
         */
        [Required]
        public string Password { get; set; }
    }
}