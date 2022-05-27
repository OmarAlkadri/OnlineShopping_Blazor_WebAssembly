using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingCenterproject.Core.Dto;
using OnlineShoppingCenterproject.Core.Interfaces;

namespace OnlineShoppingCenterproject.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ERPController : ControllerBase
	{
        private IRepositoryWrapper _repository;

        public ERPController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }
        [HttpGet("GetCompanyForERP/{Id}")]
        public async Task<ActionResult<CompanyForERP>> GetCompanyForERP(Guid Id)
        {
            var entity = await _repository.Erp.GetCompanyForERP(Id);
            return Ok(entity);
        }
        [HttpGet("QuantityForAllProduct")]
        public async Task<ActionResult<long>> QuantityForAllProduct()
        {
            var entity = await _repository.Erp.QuantityForAllProduct();
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }       
        [HttpGet("QuantityForCompany/{UserName}")]
        public async Task<ActionResult<long>> QuantityForCompany(string UserName)
        {
            var entity = await _repository.Erp.QuantityForAllProductForCompany(UserName);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }
        [HttpGet("BestSellerForCompany/{UserName}")]
        public async Task<ActionResult<long>> BestSellerForCompany(string UserName)
        {
            var entity = await _repository.Erp.QuantityOfProductSold(UserName);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }    
        [HttpGet("BestSellerYearForCompany/{UserName}/{Year}")]
        public async Task<ActionResult<long>> BestSellerYearForCompany(string UserName, string Year)
        {
            var entity = await _repository.Erp.BestSellerForYearForCompany(UserName, Year);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }
        [HttpGet("BestSellerForYear/{Year}")]
        public async Task<ActionResult<long>> BestSellerForYear(string Year)
        {
            var entity = await _repository.Erp.BestSellerForYear(Year);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }
    }
}
