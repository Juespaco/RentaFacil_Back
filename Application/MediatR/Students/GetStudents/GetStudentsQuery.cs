using Application.MediatR.Students.Shared;
using MediatR;

namespace Application.MediatR.Students.GetStudents
{
    public record GetStudentsQuery() : IRequest<IEnumerable<StudentDto>>;
}
