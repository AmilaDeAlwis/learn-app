using AutoMapper;
using backend.Dtos;
using backend.Core.Dtos.AnswerOption;
using backend.Core.Dtos.Course;
using backend.Core.Dtos.CustomQuestion;
using backend.Core.Dtos.StudentInfo;
using backend.Core.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Course mappings
        CreateMap<Course, CreateCourseDto>(); 
        CreateMap<CreateCourseDto, Course>(); 

        // StudentInfo mappings
        CreateMap<StudentInfo, CreateStudentInfoDto>(); 
        CreateMap<CreateStudentInfoDto, StudentInfo>(); 

        // CustomQuestion mappings
        CreateMap<CustomQuestion, CreateCustomQuestionDto>(); 
        CreateMap<CreateCustomQuestionDto, CustomQuestion>(); 

        // AnswerOption mappings
        CreateMap<AnswerOption, CreateAnswerOptionDto>(); 
        CreateMap<CreateAnswerOptionDto, AnswerOption>(); 
    }
}
