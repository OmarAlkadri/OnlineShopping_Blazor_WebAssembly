using OnlineShoppingCenterproject.Core.Dto.UsersDto;

namespace OnlineShoppingCenterproject.Core.Dto.CastomersDto
{
    public class CastomerForCreationDto
    {
        public CastomerForCreationDto()
        {
            User = new UserForCreationDto();
        }
        public string UserName { get; set; }
        public UserForCreationDto User { get; set; }
    }
}
