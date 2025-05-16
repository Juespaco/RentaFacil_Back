using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.MediatR.Students.CreateStudent
{
    public class CreateStudentHandler : IRequestHandler<CreateStudentCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateStudentHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            // Mapear el request a la entidad Modulo
            //var student = _mapper.Map<Student>(request);

            //// Agregar el nuevo intancia al hilo actual
            //var data = await _unitOfWork.Repository<Student>().AddAsync(student);
        }
    }
}
