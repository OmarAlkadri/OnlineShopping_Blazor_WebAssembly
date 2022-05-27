using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingCenterproject.Core.Dto.PaymentsDto;
using OnlineShoppingCenterproject.Core.Entities;
using OnlineShoppingCenterproject.Core.Interfaces;

namespace OnlineShoppingCenterproject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public PaymentController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentDto>>> GetAllPayment()
        {
            try
            {
                var entity = await _repository.Payment.GetAllPayment();
                // var entity = await _repository.OrderItem.GetAllOrderItem(Status);
                if (entity == null)
                {
                    return NotFound();
                }
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error {ex}");
            }
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<PaymentDto>> GetPaymentById(Guid Id)
        {
            try
            {
                var entity = await _repository.Payment.GetPaymentById(Id);
                // var entity = await _repository.OrderItem.GetAllOrderItem(Status);
                if (entity == null)
                {
                    return NotFound();
                }
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error {ex}");
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreatePayment([FromBody] PaymentForCreationDto entity)
        {
            try
            {
                if (entity == null)
                    return BadRequest("Company object is null");

                if (!ModelState.IsValid)
                    return BadRequest("Invalid model object");

                var Entity = _mapper.Map<Payment>(entity);


                Entity.Date = DateTime.Now.ToString("yyyy-MM-dd");
                //order.Time = DateTime.Now.ToString("h:mm:ss");
                Entity.Time = DateTime.Now.ToShortTimeString();

                var Order = await _repository.Order.GetOrderById(Entity.OrderId);
                Order.status = Status.Sold;

                _repository.Order.Update(Order);

                if (Entity.SpecialOffer > 0.0)
                    Entity.total = Order.total * Entity.SpecialOffer;
                else
                    Entity.total = Order.total;

                _repository.Payment.CreatePayment(Entity);
                _repository.Save();

                var createdEntity = _mapper.Map<PaymentDto>(Entity);
                return CreatedAtAction("GetPaymentById", new { id = createdEntity.Id }, createdEntity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}