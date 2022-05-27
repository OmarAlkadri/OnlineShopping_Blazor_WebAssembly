using OnlineShoppingCenterproject.Core.Dto.UsersDto;

namespace OnlineShoppingCenterproject.Core.Dto.CastomersDto
{
    public class CastomerDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public UserDto User { get; set; }
    }
}
