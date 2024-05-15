using backend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using backend.Interfaces;
using AutoMapper;
using backend.Repository;
using backend.Dtos.CustomQuestion;

[ApiController]
[Route("[controller]")]
public class CustomQuestionController : ControllerBase
{
    private readonly ICustomQuestionRepository _customQuestionRepository;
    private readonly IMapper _mapper;

    public CustomQuestionController(ICustomQuestionRepository customQuestionRepository, IMapper mapper)
    {
        _customQuestionRepository = customQuestionRepository;
        _mapper = mapper;
    }

    // GET: /CustomQuestion
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetCustomQuestionDto>>> GetAllCourses()
    {
        var customQuestions = await _customQuestionRepository.GetAllAsync();
        var customQuestionDtos = _mapper.Map<IEnumerable<GetCustomQuestionDto>>(customQuestions);
        return Ok(customQuestionDtos);
    }

    // GET: /CustomQuestion/{id}
    [HttpGet]
    public async Task<IActionResult> GetCustomQuestionById(string id)
    {
        var customQuestion = await _customQuestionRepository.GetByIdAsync(id);
        if (customQuestion == null)
        {
            return NotFound();
        }
        var customQuestionDto = _mapper.Map<GetCustomQuestionDto>(customQuestion);
        return Ok(customQuestionDto);
    }

    // POST: /CustomQuestion
    [HttpPost]
    public async Task<IActionResult> CreateCustomQuestion([FromBody] CreateCustomQuestionDto customQuestionDto)
    {
        var customQuestion = _mapper.Map<CustomQuestion>(customQuestionDto);
        customQuestion.Id = Guid.NewGuid().ToString(); // Generate a new unique identifier
        await _customQuestionRepository.AddAsync(customQuestion);
        return CreatedAtAction(nameof(GetCustomQuestionById), new { id = customQuestion.Id }, _mapper.Map<CreateCustomQuestionDto>(customQuestion));
    }

    // PUT: /CouCustomQuestionrse/{id}
    [HttpPut]
    public async Task<IActionResult> UpdateCustomQuestion(string id, [FromBody] CreateCustomQuestionDto customQuestionDto)
    {
        var customQuestionToUpdate = await _customQuestionRepository.GetByIdAsync(id);
        if (customQuestionToUpdate == null)
        {
            return NotFound();
        }
        _mapper.Map(customQuestionDto, customQuestionToUpdate);
        await _customQuestionRepository.UpdateAsync(id, customQuestionToUpdate);
        return NoContent();
    }

    // DELETE: /CustomQuestion/{id}
    [HttpDelete]
    public async Task<IActionResult> DeleteCustomQuestion(string id)
    {
        await _customQuestionRepository.DeleteAsync(id);
        return NoContent();
    }
}
