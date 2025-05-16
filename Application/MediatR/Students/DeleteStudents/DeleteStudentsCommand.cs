using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.MediatR.Students.DeleteStudents
{
    public record DeleteStudentCommand(
       [Required] long Id
    ) : IRequest;
}
