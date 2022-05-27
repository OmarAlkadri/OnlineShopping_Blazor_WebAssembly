using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingCenterproject.Core.Dto.ProductCompanysDto;
using OnlineShoppingCenterproject.Core.Interfaces;

namespace OnlineShoppingCenterproject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        public ProductController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet("AllProductForCompany/{UserName}")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProduct(string UserName)
        {
            var entity = await _repository.ProductCompany.GetAllProductCompany(UserName);
            if (entity == null)
            {
                return NotFound();
            }
            var entityResult = _mapper.Map<IEnumerable<ProductDto>>(entity);
            return Ok(entityResult);
        }        
        [HttpGet("ProductItem/{Id}")]
        public async Task<ActionResult<ProductDto>> GetProductItem(Guid Id)
        {
            var entity = await _repository.Product.GetProduct(Id);
            if (entity == null)
            {
                return NotFound();
            }
            var entityResult = _mapper.Map<ProductDto>(entity);
            return Ok(entityResult);
        }
        [HttpGet("SearchInLine/{line}")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> SearchInLine(string line)
        {
            try
            {
                var entity = await _repository.Product.SearchForProduct(line);
                if (entity == null)
                {
                    return NotFound();
                }
                else
                {
                    var entityResult = _mapper.Map<IEnumerable<ProductDto>>(entity);
                    return Ok(entityResult);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error {ex}");
            }
        }
        [HttpGet("GetProduct/{Id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(Guid Id)
        {
            try
            {
                var entity = await _repository.Product.GetProduct(Id);
                if (entity == null)
                {
                    return NotFound();
                }
                else
                {
                    var entityResult = _mapper.Map<ProductDto>(entity);
                    return Ok(entityResult);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error {ex}");
            }
        }
        [HttpGet("GetPageSize")]
        public async Task<ActionResult<int>> GetPageSize()
        {
            try
            {
                var entity = await _repository.Product.GetPageSize();
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error {ex}");
            }
        }
        [Route("PageForCompany")]
        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> Page(int page = 1)
        {
            try
            {
                var entity = await _repository.Product.PageForCompany(page);
                if (entity == null)
                {
                    return NotFound();
                }
                else
                {
                    var entityResult = _mapper.Map<List<ProductDto>>(entity);
                    return Ok(entityResult);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error {ex}");
            }
        }      
        [Route("Page")]
        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> Page(string? sortOrder = null,
            string? currentFilter = null, string? searchString = null, int page = 1)
        {
            try
            {
                if (searchString == null && currentFilter != null)
                {
                    searchString = currentFilter;
                }
                var entity = await _repository.Product.Page(sortOrder, searchString, page);
                if (entity == null)
                {
                    return NotFound();
                }
                else
                {
                    var entityResult = _mapper.Map<List<ProductDto>>(entity);
                    return Ok(entityResult);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error {ex}");
            }
        }
        [HttpDelete("DeleteProduct/{Id}")]
        public async Task<IActionResult> DeleteProduct(Guid Id)
        {
            try
            {
                var entity = await _repository.Product.DeleteProductByCompany(Id);
                if (entity == null)
                {
                    return NotFound();
                }
                _repository.Product.DeleteProduct(entity);
                _repository.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error {ex}");
            }
        }

        [HttpPut("UpdateProduct/{Id}")]
        public async Task<IActionResult> UpdateProduct(Guid Id, [FromBody] ProductForUpdateDto entity)
        {
            try
            {
                if (entity == null)
                    return BadRequest("Product object is null");
                if (!ModelState.IsValid)
                    return BadRequest("Invalid model object");

                var Entity = await _repository.Product.GetProductById(Id);
                if (Entity == null)
                    return NotFound();


                if (entity.Name != null)
                    Entity.Name = entity.Name;
                if (entity.Type != null)
                    Entity.Type = entity.Type;
                if (entity.WarrantyCompany != null)
                    Entity.WarrantyCompany = entity.WarrantyCompany;
                if (entity.CompanyName != null)
                    Entity.CompanyName = entity.CompanyName;

                if (entity.ModelNumber != null)
                    Entity.ModelNumber = entity.ModelNumber;
                if (entity.Foto != null)
                    Entity.Foto = entity.Foto;
                if (entity.Quantity != null && entity.Quantity > 0)
                    Entity.Quantity = entity.Quantity;

                if (entity.Title != null)
                    Entity.Title = entity.Title;
                if (entity.UnitPrice != null && entity.UnitPrice > 0)
                    Entity.UnitPrice = entity.UnitPrice;

                _repository.Product.UpdateProduct(Entity);
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
