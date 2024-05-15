using backend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using backend.Interfaces;
using AutoMapper;
using backend.Repository;
using backend.Dtos.AnswerOption;

[ApiController]
[Route("[controller]")]
public class AnswerOptionController : ControllerBase
{
    private readonly IAnswerOptionRepository _answerOptionRepository;
    private readonly IMapper _mapper;

    public AnswerOptionController(IAnswerOptionRepository answerOptionRepository, IMapper mapper)
    {
        _answerOptionRepository = answerOptionRepository;
        _mapper = mapper;
    }

    // GET: /AnswerOptions
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetAnswerOptionDto>>> GetAllAnswerOptions()
    {
        var answerOption = await _answerOptionRepository.GetAllAsync();
        var answerOptionDtos = _mapper.Map<IEnumerable<GetAnswerOptionDto>>(answerOption);
        return Ok(answerOptionDtos);
    }

    // GET: /AnswerOption/{id}
    [HttpGet]
    public async Task<IActionResult> GetAnswerOptionById(string id)
    {
        var answerOption = await _answerOptionRepository.GetByIdAsync(id);
        if (answerOption == null)
        {
            return NotFound();
        }
        var answerOptionDto = _mapper.Map<GetAnswerOptionDto>(answerOption);
        return Ok(answerOptionDto);
    }

    // POST: /AnswerOption
    [HttpPost]
    public async Task<IActionResult> CreateAnswerOption([FromBody] CreateAnswerOptionDto answerOptionDto)
    {
        var answerOption = _mapper.Map<AnswerOption>(answerOptionDto);
        answerOption.Id = Guid.NewGuid().ToString(); // Generate a new unique identifier
        await _answerOptionRepository.AddAsync(answerOption);
        return CreatedAtAction(nameof(GetAnswerOptionById), new { id = answerOption.Id }, answerOption);
    }

    // PUT: /AnswerOption/{id}
    [HttpPut]
    public async Task<IActionResult> UpdateAnswerOption(string id, [FromBody] CreateAnswerOptionDto answerOptionDto)
    {
        var answerOptionToUpdate = await _answerOptionRepository.GetByIdAsync(id);
        if (answerOptionToUpdate == null)
        {
            return NotFound();
        }
        _mapper.Map(answerOptionDto, answerOptionToUpdate);
        await _answerOptionRepository.UpdateAsync(id, answerOptionToUpdate);
        return NoContent();
    }

    // DELETE: /AnswerOption/{id}
    [HttpDelete]
    public async Task<IActionResult> DeleteAnswerOption(string id)
    {
        await _answerOptionRepository.DeleteAsync(id);
        return NoContent();
    }
}
