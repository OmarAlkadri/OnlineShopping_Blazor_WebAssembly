using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingCenterproject.Core.Dto.CastomersDto;
using OnlineShoppingCenterproject.Core.Dto.UsersDto;
using OnlineShoppingCenterproject.Core.Entities;
using OnlineShoppingCenterproject.Core.Interfaces;


namespace OnlineShoppingCenterproject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CastomerController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public CastomerController(IRepositoryWrapper repository, IMapper mapper, UserManager<User> userManager)
        {
            _repository = repository;
            _userManager = userManager;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CastomerDto>>> GetAllCastomer()
        {
            var entity = await _repository.Castomer.GetAllCastomer();
            if (entity == null)
            {
                return NotFound();
            }

            var entityResult = _mapper.Map<IEnumerable<CastomerDto>>(entity);

            return Ok(entityResult);
        }
        [HttpGet("{userName}"/*, Name = "CastomerById"*/)]
        public async Task<ActionResult<CastomerDto>> GetCastomerUserName(string userName)
        {
            try
            {
                var entity = await _repository.Castomer.GetCastomerByUserName(userName);
                if (entity == null)
                    return NotFound();
                
                var entityResult = _mapper.Map<CastomerDto>(entity);
                //  entityResult.FullName = entity.User.Name + " " + entity.User.LastName;
                return entityResult;
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error {ex}");
            }
        }
        [HttpGet("{LogIn}")]
        public async Task<User> GetLogInUser(Login LogIn) =>
            await _repository.User.GetLogInUser(LogIn.Email, LogIn.Password, "Castomer");

        [HttpPost]
        public async Task<IActionResult> CreateCastomer([FromBody] CastomerForCreationDto? entity)
        {
            try
            {
                if (entity == null && !ModelState.IsValid)
                    return BadRequest();

                if (!await _repository.User.CheckEmail(entity.User.Email))
                    return BadRequest("Email already exists!");

                entity.User.UserName = entity.User.Email;
                var CastomerEntity = _mapper.Map<Castomer>(entity);
                _repository.Castomer.CreateCastomer(CastomerEntity);
                _repository.Save();
                var createdEntity = _mapper.Map<CastomerDto>(CastomerEntity);
                await _userManager.AddToRoleAsync(CastomerEntity.User, "Castomer");
                await _userManager.AddPasswordAsync(CastomerEntity.User, entity.User.Password);
                return CreatedAtAction("GetCastomerUserName", new { userName = createdEntity.User.Email }, createdEntity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut("{userName}")]
        public async Task<IActionResult> UpdateCastomer(string userName, [FromBody] CastomerForUpdateDto entity)
        {
            try
            {
                if (entity == null)
                    return BadRequest("Castomer object is null");

                if (!ModelState.IsValid)
                    return BadRequest("Invalid model object");
                var user = await _userManager.FindByEmailAsync(userName);

                if (user == null)
                    return NotFound();

                 
                if (entity.Name != null)
                    user.Name = entity.Name;
                if (entity.LastName != null)
                    user.LastName = entity.LastName;            
                if (entity.Password != null)
                    user.Password = entity.Password;
            

                await _userManager.UpdateAsync(user);
              //  _repository.Castomer.UpdateCastomer(CastomerEntity);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error {ex}");
            }
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteCastomer(Guid Id)
        {
            try
            {
                var Castomer = await _repository.User.DeleteCastomerByUser(Id);
                if (Castomer == null)
                {
                    return NotFound();
                }
                _repository.User.DeleteUser(Castomer);
                _repository.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error {ex}");
            }
        }
    }
}
