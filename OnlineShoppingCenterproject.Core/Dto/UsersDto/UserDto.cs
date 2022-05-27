using OnlineShoppingCenterproject.Core.Dto.CastomersDto;
using OnlineShoppingCenterproject.Core.Dto.CompanysDto;
using OnlineShoppingCenterproject.Models;

namespace OnlineShoppingCenterproject.Core.Dto.UsersDto
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public string Password { get; set; }
    }
}