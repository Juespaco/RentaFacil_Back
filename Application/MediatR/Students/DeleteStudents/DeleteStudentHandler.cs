using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.MediatR.Students.DeleteStudents
{
    public class DeleteStudentHandler : IRequestHandler<DeleteStudentCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteStudentHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            //var student = await _unitOfWork.Repository<Student>().GetByIdAsync(request.Id);
            //await _unitOfWork.Repository<Student>().DeleteAsync(student);
        }
    }
}
