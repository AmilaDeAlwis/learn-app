using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using AutoMapper;
using backend.Repository;
using backend.Core.Dtos.StudentInfo;
using backend.Core.Interfaces;
using backend.Core.Models;

[ApiController]
[Route("[controller]")]
public class StudentInfoController : ControllerBase
{
    private readonly IStudentInfoRepository _studentInfoRepository;
    private readonly IMapper _mapper;

    public StudentInfoController(IStudentInfoRepository studentInfoRepository, IMapper mapper)
    {
        _studentInfoRepository = studentInfoRepository;
        _mapper = mapper;
    }

    // GET: /StudentInfo
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetStudentInfoDto>>> GetAllStudentsInfo()
    {
        var studentInfo = await _studentInfoRepository.GetAllAsync();
        var studentInfoDtos = _mapper.Map<IEnumerable<GetStudentInfoDto>>(studentInfo);
        return Ok(studentInfoDtos);
    }

    // GET: /StudentInfo/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetStudentInfoById(string id)
    {
        var course = await _studentInfoRepository.GetByIdAsync(id);
        if (course == null)
        {
            return NotFound();
        }
        var studentInfoDto = _mapper.Map<GetStudentInfoDto>(course);
        return Ok(studentInfoDto);
    }

    // POST: /StudentInfo
    [HttpPost]
    public async Task<IActionResult> CreateStudentInfo([FromBody] CreateStudentInfoDto studentInfoDto)
    {
        var studentInfo = _mapper.Map<StudentInfo>(studentInfoDto);
        studentInfo.Id = Guid.NewGuid().ToString(); // Generate a new unique identifier
        await _studentInfoRepository.AddAsync(studentInfo);
        return CreatedAtAction(nameof(GetStudentInfoById), new { id = studentInfo.Id }, _mapper.Map<GetStudentInfoDto>(studentInfo));
    }

    // PUT: /StudentInfo/{id}
    [HttpPut]
    public async Task<IActionResult> UpdateStudentInfo(string id, [FromBody] CreateStudentInfoDto studentInfoDto)
    {
        var studentInfoToUpdate = await _studentInfoRepository.GetByIdAsync(id);
        if (studentInfoToUpdate == null)
        {
            return NotFound();
        }
        _mapper.Map(studentInfoDto, studentInfoToUpdate);
        await _studentInfoRepository.UpdateAsync(id, studentInfoToUpdate);
        return NoContent();
    }

    // DELETE: /StudentInfo/{id}
    [HttpDelete]
    public async Task<IActionResult> DeleteStudentInfo(string id)
    {
        await _studentInfoRepository.DeleteAsync(id);
        return NoContent();
    }
}
