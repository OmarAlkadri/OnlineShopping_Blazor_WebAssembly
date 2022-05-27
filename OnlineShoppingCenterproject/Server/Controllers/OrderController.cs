using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingCenterproject.Core.Dto.OrdersDto;
using OnlineShoppingCenterproject.Core.Entities;
using OnlineShoppingCenterproject.Core.Interfaces;

namespace OnlineShoppingCenterproject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public OrderController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("all/{userName}")]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetAllOrderItem(string userName)
        {
            try
            {
                var entity = await _repository.Order.GetAllOrder(userName);
                if (entity == null)
                {
                    return NotFound();
                }
                var entityResult = _mapper.Map<IEnumerable<OrderDto>>(entity);
                return Ok(entityResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error {ex}");
            }
        }

    }
}