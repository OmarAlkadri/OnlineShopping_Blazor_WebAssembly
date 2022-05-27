using AutoMapper;
using OnlineShoppingCenterproject.Core.Entities;
using OnlineShoppingCenterproject.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingCenterproject.Core.Dto.ProductCompanysDto;
using Microsoft.AspNetCore.Authorization;
using OnlineShoppingCenterproject.Core.Dto.CompanysDto;
using System.Net.Http.Headers;

namespace OnlineShoppingCenterproject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCompanyController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public ProductCompanyController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /*[HttpGet("{Id}")]
        public async Task<IActionResult> GetProductId(Guid Id)
        {
            try
            {
                var entity = await _repository.ProductCompany.GetProductById(Id);
                if (entity == null)
                    return NotFound();

                var entityResult = _mapper.Map<ProductCompanyDto>(entity);
                return Ok(entityResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error {ex}");
            }
        }*/

        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct([FromBody] ProductCompanyForCreationDto entity)
        {
            try
            {
                if (entity.activations)
                {
                    if (entity == null)
                        return BadRequest("Company object is null");

                    if (!ModelState.IsValid)
                        return BadRequest("Invalid model object");

                    var Entity = _mapper.Map<ProductCompany>(entity);
                    _repository.ProductCompany.CreateProduct(Entity);
                    _repository.Save();
                    var createdEntity = _mapper.Map<ProductCompanyDto>(Entity);
                    return Ok();
                }
                else
                {
                    return BadRequest("Company is not Activation");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("Upload")]
        public IActionResult Upload()
        {
            try
            {
                var file = Request.Form.Files[0];

                var folderName = Path.Combine(@"..\Client\wwwroot", "images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    return Ok(dbPath);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}
