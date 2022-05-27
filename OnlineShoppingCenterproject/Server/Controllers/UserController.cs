using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingCenterproject.Core.Entities;
using OnlineShoppingCenterproject.Core.Interfaces;
using OnlineShoppingCenterproject.Core.Dto.UsersDto;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using OnlineShoppingCenterproject.Core.Dto;

namespace OnlineShoppingCenterproject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private readonly UserManager<User> _userManager;
        private readonly IConfigurationSection _jwtSettings;
        private readonly IConfiguration _configuration;
        private IMapper _mapper;
        public UserController(IRepositoryWrapper repository, IMapper mapper,
            UserManager<User> userManager, IConfiguration configuration)
        {
            _repository = repository;
            _userManager = userManager;
            _configuration = configuration;
            _jwtSettings = _configuration.GetSection("JwtSettings"); ;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUser()
        {
            try
            {
                var entity = await _repository.User.GetAllUser();
                if (entity == null)
                {
                    return NotFound();
                }
                var entityResult = _mapper.Map<IEnumerable<UserDto>>(entity);
                return Ok(entityResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error {ex}");
            }
        }
        [HttpPost("Registration")]
        public async Task<IActionResult> RegisterUser([FromBody] UserForCreationDto? userForRegistration)
        {

            if (userForRegistration == null || !ModelState.IsValid)
                return BadRequest();

            /*
             User user = new User
            {
                Name = userForRegistration.Name,
                LastName = userForRegistration.LastName,
                Gender = (Models.Gender)userForRegistration.Gender,
                Password = userForRegistration.Password,
                UserName = userForRegistration.Email,
                Email = userForRegistration.Email
            };
            */
            userForRegistration.UserName = userForRegistration.Email;
            var UserEntity = _mapper.Map<User>(userForRegistration);
            var result = await _userManager.CreateAsync(UserEntity, userForRegistration.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                return BadRequest(new RegistrationResponseDto { Errors = errors });
            }
            await _userManager.AddToRoleAsync(UserEntity, "Admin");
            return StatusCode(201);
        }
        [HttpPost("LogIn")]
        public async Task<IActionResult> GetLogInUser(Login LogIn)
        {
            var user = await _userManager.FindByEmailAsync(LogIn.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, LogIn.Password))
                return Unauthorized(new AuthResponseDto { ErrorMessage = "Invalid Authentication" });
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims(user);
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return Ok(new AuthResponseDto { IsAuthSuccessful = true, Token = token });
        }
        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(_jwtSettings.GetSection("securityKey").Value);
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private async Task<List<Claim>> GetClaims(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email),
               // new Claim(ClaimTypes.Role, user.Name),
            };
            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var tokenOptions = new JwtSecurityToken(
                issuer: _jwtSettings.GetSection("validIssuer").Value,
                audience: _jwtSettings.GetSection("validAudience").Value,
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_jwtSettings.GetSection("expiryInMinutes").Value)),
                signingCredentials: signingCredentials);

            return tokenOptions;
        }






        [HttpGet("{Id}", Name = "UserById")]
        public async Task<IActionResult> GetUserId(Guid Id)
        {
            try
            {
                var user = await _repository.User.GetUserById(Id);
                if (user == null)
                {
                    return NotFound();
                }
                else
                {
                    var userResult = _mapper.Map<UserDto>(user);
                    return Ok(userResult);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error {ex}");
            }
        }
        /*[HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid Id)
        {
            try
            {
                var user = await _repository.User.GetUserById(id);
                if (user == null)
                {
                    return NotFound();
                }
                _repository.User.DeleteUser(user);
                _repository.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error {ex}");
            }
        }*/
    }
}
