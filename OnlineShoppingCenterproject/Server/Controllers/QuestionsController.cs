using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingCenterproject.Core.Dto.QuestionssDto;
using OnlineShoppingCenterproject.Core.Entities;
using OnlineShoppingCenterproject.Core.Interfaces;

namespace OnlineShoppingCenterproject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        public QuestionsController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet("GetAllQuestionsByCompanyId/{CompanyId}")]
        public async Task<ActionResult<IEnumerable<QuestionsDto>>> GetAllQuestions(Guid CompanyId)
        {
            try
            {
                var entity = await _repository.Questions.GetAllQuestionsForCompany(CompanyId);
                var entityResult = _mapper.Map<IEnumerable<QuestionsDto>>(entity);
                return Ok(entityResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error {ex}");
            }
        }
        [HttpGet("GetAllQuestionsByProductId/{ProductId}")]
        public async Task<ActionResult<IEnumerable<QuestionsDto>>> GetAllQuestionsForProduct(Guid ProductId)
        {
            try
            {
                var entity = await _repository.Questions.GetAllQuestionsForProduct(ProductId);
                var entityResult = _mapper.Map<IEnumerable<QuestionsDto>>(entity);
                return Ok(entityResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error {ex}");
            }
        }
        [HttpGet("GetQuestionsById/{Id}")]
        public async Task<ActionResult<QuestionsDto>> GetQuestionsId(Guid Id)
        {
            try
            {
                var entity = await _repository.Questions.GetQuestionsById(Id);
                if (entity == null)
                {
                    return NotFound();
                }
                else
                {
                    var entityResult = _mapper.Map<QuestionsDto>(entity);
                    return Ok(entityResult);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error {ex}");
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateQuestions([FromBody] QuestionsForCreationDto entity)
        {
            try
            {
                if (entity == null)
                {
                    return BadRequest("Company object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var CompanyEntity = _mapper.Map<Questions>(entity);
                _repository.Questions.CreateQuestions(CompanyEntity);
                _repository.Save();
                var createdEntity = _mapper.Map<QuestionsDto>(CompanyEntity);
                return CreatedAtAction("GetQuestionsId", new { Id = createdEntity.Id }, createdEntity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}
