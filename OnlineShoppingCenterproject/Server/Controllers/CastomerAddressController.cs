using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingCenterproject.Core.Dto.CastomersDto;
using OnlineShoppingCenterproject.Core.Entities;
using OnlineShoppingCenterproject.Core.Interfaces;

namespace OnlineShoppingCenterproject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CastomerAddressController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public CastomerAddressController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet("GetAll/{userName}")]
        public async Task<ActionResult<List<CastomerAddressDto>>> GetAllCastomer_Address(string userName)
        {
            try
            {
                var entity = await _repository.Castomer_Address.GetAllCastomer_Address(userName);
                var entityResult = _mapper.Map<List<CastomerAddressDto>>(entity);
                return Ok(entityResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error {ex}");
            }
        }
        [HttpGet("GetCastomerAddressById/{Id}")]
        public async Task<ActionResult<CastomerAddressDto>> GetCastomer_AddressId(Guid Id)
        {
            try
            {
                var entity = _repository.Castomer_Address.GetCastomer_AddressById(Id);
                if (entity == null)
                {
                    return NotFound();
                }
                else
                {
                    var entityResult = _mapper.Map<CastomerAddressDto>(entity);
                    return Ok(entityResult);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error {ex}");
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateCastomer_Address([FromBody] CastomerAddressForCreationDto entity)
        {
            try
            {
                if (entity == null)
                {
                    return BadRequest("Owner object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                var User_AddressEntity = _mapper.Map<CastomerAddress>(entity);

                var castomer = await _repository.Castomer.GetCastomerByUserName(entity.UserName);

                User_AddressEntity.CastomerId = castomer.Id;

                _repository.Castomer_Address.CreateCastomer_Address(User_AddressEntity);
                _repository.Save();
                var createdEntity = _mapper.Map<CastomerAddressDto>(User_AddressEntity);
                // return CreatedAtRoute("UserById", new { id = createdProduct.id }, createdProduct);
                return CreatedAtAction("GetUser_AddressId", new { Id = createdEntity.Id }, createdEntity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateCastomer_Address(Guid Id, [FromBody] CastomerAddress entity)
        {
            try
            {
                if (entity == null)
                {
                    return BadRequest("Owner object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                var Entity = await _repository.Castomer_Address.GetCastomer_AddressById(Id);
                if (Entity == null)
                {
                    return NotFound();
                }
                _mapper.Map(entity, Entity);
                _repository.Castomer_Address.UpdateCastomer_Address(Entity);
                _repository.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error {ex}");
            }
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteCastomer_Address(Guid Id)
        {
            try
            {
                var entity = await _repository.Castomer_Address.GetCastomer_AddressById(Id);
                if (entity == null)
                {
                    return NotFound();
                }
                /*if (_repository.Castomer.CastomersByUser(id).Any())
                {
                    return BadRequest($"Cannot delete owner with id: {id}. It has related accounts. Delete those accounts first");
                }*/
                _repository.Castomer_Address.DeleteCastomer_Address(entity);
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
