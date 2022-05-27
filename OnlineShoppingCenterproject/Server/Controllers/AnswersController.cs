using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingCenterproject.Core.Dto.AnswerssDto;
using OnlineShoppingCenterproject.Core.Entities;
using OnlineShoppingCenterproject.Core.Interfaces;

namespace OnlineShoppingCenterproject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswersController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        public AnswersController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet("GetAllAnswersByQuestionsId/{QuestionsId}")]
        public async Task<ActionResult<IEnumerable<AnswersDto>>> GetAllAnswers(Guid QuestionsId)
        {
            try
            {
                var entity = await _repository.Answers.GetAllAnswers(QuestionsId);
                if (entity == null)
                {
                    return NotFound();
                }
                var entityResult = _mapper.Map<IEnumerable<AnswersDto>>(entity);
                return Ok(entityResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error {ex}");
            }
        }
        [HttpGet("GetAnswersById/{Id}")]
        public async Task<ActionResult<AnswersDto>> GetAnswersId(Guid Id)
        {
            try
            {
                var entity = await _repository.Answers.GetAnswersById(Id);
                if (entity == null)
                {
                    return NotFound();
                }
                else
                {
                    var entityResult = _mapper.Map<AnswersDto>(entity);
                    return Ok(entityResult);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error {ex}");
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateAnswers([FromBody] AnswersForCreationDto entity)
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

                var CompanyEntity = _mapper.Map<Answers>(entity);
                _repository.Answers.CreateAnswers(CompanyEntity);
                _repository.Save();
                var createdEntity = _mapper.Map<AnswersDto>(CompanyEntity);
                return CreatedAtAction("GetAnswersId", new { Id = createdEntity.Id }, createdEntity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}
