using System.Collections.Generic;
using Consumer.Persistence.Models;
using MediatR;

namespace Consumer.cqrs.Queries
{
    public class GetStudentListQuery : IRequest<List<StudentModel>>
    {
    }
}