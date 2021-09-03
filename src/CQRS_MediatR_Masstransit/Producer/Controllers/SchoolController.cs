using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.Models;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace Producer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly IRequestClient<StudentBusRequest> _requestClient;

        public SchoolController(IRequestClient<StudentBusRequest> requestClient)
        {
            _requestClient = requestClient;
        }

        // GET: api/School
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/School/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/School
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StudentBusRequest studentBusRequest)
        {
            var student = await _requestClient.GetResponse<StudentBusResponse>(studentBusRequest);
            await Console.Out.WriteLineAsync($"{student.Message.FirstName} / {student.Message.LastName} / {student.Message.StudentId}");
            return Ok();
        }

        // PUT: api/School/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}