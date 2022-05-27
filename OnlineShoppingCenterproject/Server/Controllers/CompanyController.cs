using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingCenterproject.Core.Dto.CompanysDto;
using OnlineShoppingCenterproject.Core.Dto.UsersDto;
using OnlineShoppingCenterproject.Core.Entities;
using OnlineShoppingCenterproject.Core.Interfaces;
using OnlineShoppingCenterproject.Models;

namespace OnlineShoppingCenterproject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public CompanyController(IRepositoryWrapper repository, IMapper mapper, UserManager<User> userManager)
        {
            _repository = repository;
            _userManager = userManager;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IList<CompanyDto>>> GetAllCompany()
        {
            var entity = await _repository.Company.GetAllCompany();
            if (entity == null)
            {
                return NotFound();
            }

            var entityResult = _mapper.Map<IList<CompanyDto>>(entity);

            return Ok(entityResult);
        }
        [HttpGet("{userName}"/*, Name = "CastomerById"*/)]
        public async Task<ActionResult<CompanyDto>> GetCompanyId(string userName)
        {
            try
            {

                var entity = await _repository.Company.GetCompanyByUserName(userName);
                if (entity == null)
                    return NotFound();

                var entityResult = _mapper.Map<CompanyDto>(entity);
                //  entityResult.FullName = entity.User.Name + " " + entity.User.LastName;
                return entityResult;
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error {ex}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany(CompanyForCreationDto? entity)
        {
            try
            {
                if (entity == null&& !ModelState.IsValid)
                    return BadRequest();
                
                var a = await _repository.User.CheckEmail(entity.User.Email);

                if (!a)
                {
                    return BadRequest("Email already exists!");
                }
                entity.User.UserName = entity.User.Email;
                entity.UserName = entity.User.Email;
                var CastomerEntity = _mapper.Map<Company>(entity);
                _repository.Company.CreateCompany(CastomerEntity);
                _repository.Save();
                var createdEntity = _mapper.Map<CompanyDto>(CastomerEntity);
                await _userManager.AddToRoleAsync(CastomerEntity.User, "Company");
                await _userManager.AddPasswordAsync(CastomerEntity.User, entity.User.Password);
                return CreatedAtAction("GetCompanyId", new { UserName = createdEntity.User.Email }, createdEntity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("Change/{UserName}")]
        public async Task<IActionResult> UpdateCompany(string UserName)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid model object");
                var CompanyEntity = await _repository.Company.GetCompanyByUserName(UserName);
                if (CompanyEntity == null)
                    return NotFound();
                CompanyEntity.activations = !CompanyEntity.activations;
                _repository.Company.UpdateCompany(CompanyEntity);
                _repository.Save();
                return Ok(CompanyEntity.activations);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error {ex}");
            }
        }
        [HttpPut("UpdateCompany/{userName}")]
        public async Task<IActionResult> UpdateCompany(string userName, CompanyForUpdateDto entity)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(userName);

                if (!ModelState.IsValid)
                    return BadRequest("Invalid model object");
                var CompanyEntity = await _repository.Company.GetCompanyByUserName(userName);
                if (CompanyEntity == null)
                    return NotFound();


                if (entity.CompanyName != null)
                    CompanyEntity.CompanyName = entity.CompanyName;
                if (entity.CompanyType != null)
                    CompanyEntity.CompanyType = entity.CompanyType;
                if (entity.startingDate != null)
                    CompanyEntity.startingDate = entity.startingDate;


               /* if (entity.Name != null)
                    CompanyEntity.User.Name = entity.Name;
                if (entity.LastName != null)
                    CompanyEntity.User.LastName = entity.LastName;
                if (entity.Password != null)
                    CompanyEntity.User.Password = entity.Password;*/


                _repository.Company.UpdateCompany(CompanyEntity);
                _repository.Save();
                return Ok(CompanyEntity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error {ex}");
            }
        }
        [HttpDelete("{UserName}")]
        public async Task<IActionResult> DeleteCastomer(string UserName)
        {
            try
            {
                var company = await _repository.Company.GetCompanyByUserName(UserName);
                if (company == null)    
                {
                    return NotFound();
                }
                _repository.Company.DeleteCompany(company);
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
