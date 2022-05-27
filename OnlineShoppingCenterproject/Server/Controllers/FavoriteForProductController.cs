using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingCenterproject.Core.Dto.FavoriteForProductsDto;
using OnlineShoppingCenterproject.Core.Dto.ProductCompanysDto;
using OnlineShoppingCenterproject.Core.Entities;
using OnlineShoppingCenterproject.Core.Interfaces;

namespace OnlineShoppingCenterproject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteForProductController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public FavoriteForProductController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet("GetAllFavorite/{UserName}")]
        public async Task<ActionResult<List<FavoriteForProduct>>> GetAllFavorite(string UserName)
        {
            var entity = await _repository.FavoriteForProduct.GetAllFavoriteForProduct(UserName);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }       
        [HttpGet("GetBool/{productId}")]
        public async Task<ActionResult<Boolean>> GetBool(Guid productId)
        {
            try
            {
                var entity = await _repository.FavoriteForProduct.GetFavoriteForProductByProductId(productId);
                if (entity == null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("AddFavorite/{productId}/{userName}")]
        public async Task<ActionResult<Boolean>> CreateFavorite(Guid productId, string userName)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                FavoriteForProductForCreationDto entity = new FavoriteForProductForCreationDto();
                entity.ProductId = productId;
                var Castomer = await _repository.Castomer.GetCastomerByUserName(userName);
				if (Castomer==null)
				{
                    return false;
				}
                entity.CastomerId = Castomer.Id;

                var FavoriteForProductEntity = _mapper.Map<FavoriteForProduct>(entity);
                _repository.FavoriteForProduct.CreateFavoriteForProduct(FavoriteForProductEntity);
                _repository.Save();

                return true;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("{ProductId}")]
        public async Task<IActionResult> DeleteFavorite(Guid ProductId)
        {
            try
            {
                var Castomer = await _repository.FavoriteForProduct.GetFavoriteForProductByProductId(ProductId);
                if (Castomer == null)
                {
                    return NotFound();
                }
                _repository.FavoriteForProduct.DeleteFavoriteForProduct(Castomer);
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
