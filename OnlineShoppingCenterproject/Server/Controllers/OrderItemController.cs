using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingCenterproject.Core.Dto.OrdersDto;
using OnlineShoppingCenterproject.Core.Entities;
using OnlineShoppingCenterproject.Core.Interfaces;

namespace OnlineShoppingCenterproject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public OrderItemController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet("ForCastomer/{CastomerId}")]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrderItemsForCastomer(Guid CastomerId)
        {
            try
            {
                var entity = await _repository.OrderItem.GetOrderItemByCastomer(CastomerId);
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
        [HttpGet("ForOrderId/{OrderId}")]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrderItemsForOrder(Guid OrderId)
        {
            try
            {
                var entity = await _repository.OrderItem.GetOrderItemByOrder(OrderId);
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
        [HttpGet("ForCompany/{CompanyId}")]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrderItemsForCompany(Guid CompanyId)
        {
            try
            {
                var entity = await _repository.OrderItem.GetOrderItemByCompany(CompanyId);
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
        [HttpGet("GetAll/{Status?}")]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetAllOrderItems(string? Status = "all")
        {
            try
            {
                var entity = await _repository.OrderItem.GetAllOrderItem(Status);
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
        [HttpGet("{Status}/{OrderId}")]
        public async Task<ActionResult<OrderItemDto>> GetOrderItemsForStatus(string? Status, Guid OrderId)
        {
            try
            {
                var entity = await _repository.OrderItem.GetOrderItemsByOrderStatus(Status, OrderId);
                if (entity == null)
                {
                    return NotFound();
                }
                else
                {
                    var entityResult = _mapper.Map<IEnumerable<OrderItemDto>>(entity);
                    return Ok(entityResult);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error {ex}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderItemAndOrder([FromBody] OrderItemsList entity)
        {
            try
            {
                if (entity.OrderItem == null)
                    return BadRequest("OrderItem object is null");
                if (!ModelState.IsValid)
                    return BadRequest("Invalid model object");

                var order = new Order();
                var orderAdress = new OrderAddress();
                orderAdress.AddressId = entity.AddressId;
                var castomer = await _repository.Castomer.GetCastomerByUserName(entity.UserName);
                order.CastomerId = castomer.Id;
                order.OrderDate = DateTime.Now;
                //order.Time = DateTime.Now.ToString("h:mm:ss");
                order.Time = DateTime.Now.ToShortTimeString();
                foreach (var item in entity.OrderItem)  
                {
                    var product = await _repository.Product.GetProduct(item.ProductId);
                    product.Quantity -= item.Quantity;
                    if (product.Quantity <= 0 || item.Quantity <= 0)
                    {
                        return BadRequest();
                    }
                    var Price = await _repository.Product.GetProductByPrice(item.ProductId) * item.Quantity;
                    item.Price = Price;
                    item.Order = order;
                    order.total += item.Price;
                    var OrderEntity = _mapper.Map<OrderItem>(item);
                    _repository.Product.Update(product);
                    _repository.OrderItem.CreateOrderItem(OrderEntity);
                }
                orderAdress.Order = order;
                _repository.OrderAddress.CreateOrderAddress(orderAdress);
                _repository.Order.CreateOrder(order);
                _repository.Save();

                return Ok(new { Order = order });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        /*[HttpPut("{Id}")]
        public async Task<IActionResult> UpdateOrder(Guid Id, [FromBody] OrderItemForUpdateDto entity)
        {
            try
            {
                if (entity == null)
                {
                    return BadRequest("Order object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                var Entity = _repository.OrderItem.GetOrderItemById(Id);

                if (Entity == null)
                    return NotFound();

                var createdEntity = _mapper.Map<OrderItem>(Entity);
                _mapper.Map(entity, Entity);
                _repository.OrderItem.UpdateOrderItem(createdEntity);
                _repository.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error {ex}");
            }
        }*/
        /*[HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteOrderItem(Guid Id)
        {
            try
            {
                var entity = await _repository.OrderItem.GetOrderItemById(Id);
                if (entity == null)
                    return NotFound();

                _repository.OrderItem.DeleteOrderItem(entity);
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
