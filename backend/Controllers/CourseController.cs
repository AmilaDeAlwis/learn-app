using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using backend.Repository;
using AutoMapper;
using backend.Core.Dtos.Course;
using backend.Core.Interfaces;
using backend.Core.Models;

[ApiController]
[Route("[controller]")]
public class CourseController : ControllerBase
{
    private readonly ICourseRepository _courseRepository;
    private readonly IMapper _mapper;

    public CourseController(ICourseRepository courseRepository, IMapper mapper)
    {
        _courseRepository = courseRepository;
        _mapper = mapper;
    }

    // GET: /Course
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetCourseDto>>> GetAllCourses()
    {
        var courses = await _courseRepository.GetAllAsync();
        var courseDtos = _mapper.Map<IEnumerable<GetCourseDto>>(courses);
        return Ok(courseDtos);
    }

    // GET: /Course/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCourseById(string id)
    {
        var course = await _courseRepository.GetByIdAsync(id);
        if (course == null)
        {
            return NotFound();
        }
        var courseDto = _mapper.Map<GetCourseDto>(course);
        return Ok(courseDto);
    }

    // POST: /Course
    [HttpPost]
    public async Task<IActionResult> CreateCourse([FromBody] CreateCourseDto courseDto)
    {
        Course course = _mapper.Map<Course>(courseDto);
        course.Id = Guid.NewGuid().ToString(); // Generate a new unique identifier
        await _courseRepository.AddAsync(course);
        return CreatedAtAction(nameof(GetCourseById), new { id = course.Id }, _mapper.Map<GetCourseDto>(course));
    }

    // PUT: /Course/{id}
    [HttpPut]
    public async Task<IActionResult> UpdateCourse(string id, [FromBody] CreateCourseDto courseDto)
    {
        var courseToUpdate = await _courseRepository.GetByIdAsync(id);
        if (courseToUpdate == null)
        {
            return NotFound();
        }
        _mapper.Map(courseDto, courseToUpdate);
        await _courseRepository.UpdateAsync(id, courseToUpdate);
        return NoContent();
    }

    // DELETE: /Course/{id}
    [HttpDelete]
    public async Task<IActionResult> DeleteCourse(string id)
    {
        await _courseRepository.DeleteAsync(id);
        return NoContent();
    }
}
