using System;
using System.Linq;
using System.Threading.Tasks;
using Consumer.cqrs.Queries;
using Contracts.Models;
using MassTransit;
using MediatR;

namespace Consumer.Consumer
{
    public class StudentBusRequestConsumer : IConsumer<StudentBusRequest>
    {
        private readonly IMediator _mediator;

        public StudentBusRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<StudentBusRequest> context)
        {
            await Console.Out.WriteLineAsync(context.Message.Id.ToString());
            var includes = context.Message.Includes;
            foreach (var include in includes)
            {
                await Console.Out.WriteLineAsync(include);
            }

            var students = _mediator.Send(new GetStudentListQuery()).Result;
            foreach (var student in students)
            {
                await Console.Out.WriteLineAsync($"{student.FirstName} / {student.LastName}");
            }

            await context.RespondAsync<StudentBusResponse>(students.First());
        }
    }
}