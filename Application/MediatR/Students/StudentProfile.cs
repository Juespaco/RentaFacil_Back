using Application.MediatR.Students.CreateStudent;
using Application.MediatR.Students.DeleteStudents;
using Application.MediatR.Students.Shared;
using Application.MediatR.Students.UpdateStudent;
using AutoMapper;
using Domain.Entities;

namespace Application.MediatR.Students
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            //CreateMap<Student, StudentDto>();
            //CreateMap<CreateStudentCommand, Student>();
            //CreateMap<UpdateStudentCommand, Student>();
            //CreateMap<DeleteStudentCommand, Student>();
        }
    }
}
