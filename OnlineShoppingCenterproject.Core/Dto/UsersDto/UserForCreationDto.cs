using OnlineShoppingCenterproject.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace OnlineShoppingCenterproject.Core.Dto.UsersDto
{
    // [Index(nameof(Email), IsUnique = true)]
    public class UserForCreationDto
    {
        public UserForCreationDto()
        {
            IsClick = false;
        }
        public Boolean IsClick { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "Name is too long.")]
        [Display(Name = "First Name")]
        public string? Name { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "Name is too long.")]
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }
        public Gender? Gender { get; set; }
        [Required(ErrorMessage = "Email already exists!")]
        // [EmailAddress] 
        public string? Email { get; set; }
        public string? UserName { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
