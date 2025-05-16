using Application.MediatR.Students.CreateStudent;
using Application.MediatR.Students.DeleteStudents;
using Application.MediatR.Students.GetStudents;
using Application.MediatR.Students.Shared;
using Application.MediatR.Students.UpdateStudent;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StudentsController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        [EnableCors("MyPolicy")]
        [ProducesResponseType(typeof(IEnumerable<StudentDto>), 200)]
        public async Task<IEnumerable<StudentDto>> GetAllAsync()
        {
            return await _mediator.Send(new GetStudentsQuery());
        }

        [HttpPost]
        [EnableCors("MyPolicy")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<bool> CreateAsync(CreateStudentCommand student)
        {
            await _mediator.Send(student);
            return true;
        }

        [HttpPut]
        [EnableCors("MyPolicy")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<bool> UpdateAsync(UpdateStudentCommand student)
        {
            await _mediator.Send(student);
            return true;
        }

        [HttpDelete("DeleteById/{studentId}")]
        [EnableCors("MyPolicy")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<bool> DeleteAsync(int studentId)
        {
            DeleteStudentCommand student = new DeleteStudentCommand(studentId);
            await _mediator.Send(student);
            return true;
        }

    }
}
