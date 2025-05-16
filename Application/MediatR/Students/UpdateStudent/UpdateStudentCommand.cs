using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.MediatR.Students.UpdateStudent
{
    public record UpdateStudentCommand(
       [Required] int Id,
       [Required] string Email,
       [Required] string FirstName,
       [Required] string LastName
    ) : IRequest;
}
