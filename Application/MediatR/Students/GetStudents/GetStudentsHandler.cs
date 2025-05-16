using Application.MediatR.Students.Shared;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.MediatR.Students.GetStudents
{
    public class GetStudentsHandler : IRequestHandler<GetStudentsQuery,IEnumerable<StudentDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetStudentsHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StudentDto>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            //var students = await _unitOfWork.Repository<Student>().GetAllAsync();

            //var studentsDto = _mapper.Map<IEnumerable<StudentDto>>(students);
            var studentsDto = new List<StudentDto>();
            return studentsDto;
        }
    }
}
