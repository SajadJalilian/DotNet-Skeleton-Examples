using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Consumer.cqrs.Queries;
using Consumer.Persistence.Models;
using Consumer.Persistence.Repository.Interfaces;
using MediatR;

namespace Consumer.cqrs.Handlers
{
    public class GetStudentListHandler: IRequestHandler<GetStudentListQuery, List<StudentModel>>
    {
        private readonly IStudentRepo _studentRepo;

        public GetStudentListHandler(IStudentRepo studentRepo)
        {
            _studentRepo = studentRepo;
        }
        public Task<List<StudentModel>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_studentRepo.GetStudents());
        }
    }
}