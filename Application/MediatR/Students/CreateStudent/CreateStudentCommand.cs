using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.MediatR.Students.CreateStudent
{
    public record CreateStudentCommand(
        [Required] string Email,
        [Required] string FirstName,
        [Required] string LastName
     ) : IRequest;
}
