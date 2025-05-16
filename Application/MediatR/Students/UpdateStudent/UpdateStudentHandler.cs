using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.MediatR.Students.UpdateStudent
{
    public class UpdateStudentHandler : IRequestHandler<UpdateStudentCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateStudentHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            //var student = _mapper.Map<Student>(request);
            //var data = await _unitOfWork.Repository<Student>().UpdateAsync(student);
        }
    }
} 
