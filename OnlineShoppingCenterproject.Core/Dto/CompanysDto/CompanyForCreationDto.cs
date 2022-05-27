using OnlineShoppingCenterproject.Core.Dto.UsersDto;
using OnlineShoppingCenterproject.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace OnlineShoppingCenterproject.Core.Dto.CompanysDto
{
    public class CompanyForCreationDto
    {
        public CompanyForCreationDto()
        {
            activations = false;
            User = new UserForCreationDto();
        }
        [Required]
        public string? startingDate { get; set; }
        [Required]
        public string? CompanyName { get; set; }
        [Required]
        public string? CompanyType { get; set; }
        [Required]
        public string? ShopLicense { get; set; }
        public string? UserName { get; set; }
        public Boolean activations { get; set; }
        [Required]
        public UserForCreationDto User { get; set; }
    }
}
