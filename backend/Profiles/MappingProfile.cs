using AutoMapper;
using backend.Models;
using backend.Dtos;
using backend.Dtos.Course;
using backend.Dtos.StudentInfo;
using backend.Dtos.CustomQuestion;
using backend.Dtos.AnswerOption;

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
