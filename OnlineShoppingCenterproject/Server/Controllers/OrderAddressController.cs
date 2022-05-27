using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingCenterproject.Core.Dto.OrdersDto;
using OnlineShoppingCenterproject.Core.Entities;
using OnlineShoppingCenterproject.Core.Interfaces;

namespace OnlineShoppingCenterproject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderAddressController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        public OrderAddressController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderAddressDto>>> GetAllOrderAddress()
        {
            var entity = await _repository.OrderAddress.GetAllOrderAddress();
            if (entity == null)
            {
                return NotFound();
            }
            var entityResult = _mapper.Map<IEnumerable<OrderAddressDto>>(entity);
            return Ok(entityResult);
        }
        [HttpGet("{Id}", Name = "CastomerById")]
        public async Task<ActionResult<OrderAddressDto>> GetOrderAddressId(Guid Id)
        {
            try
            {
                var entity = await _repository.OrderAddress.GetOrderAddressId(Id);
                if (entity == null)
                {
                    return NotFound();
                }
                var entityResult = _mapper.Map<OrderAddressDto>(entity);
                return entityResult;
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error {ex}");
            }
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateOrderAddress(Guid Id, [FromBody] OrderAddressForUpdateDto entity)
        {
            try
            {
                if (entity == null)
                {
                    return BadRequest("Castomer object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                var Entity = await _repository.OrderAddress.GetOrderAddressId(Id);
                if (Entity == null)
                {
                    return NotFound();
                }
                var UpdateEntity = _mapper.Map<OrderAddress>(Entity);
                _mapper.Map(entity, UpdateEntity);
                _repository.OrderAddress.UpdateOrderAddress(UpdateEntity);
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
