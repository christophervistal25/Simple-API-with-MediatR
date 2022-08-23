using App.Core.StudentModule.Commands;
using App.Core.StudentModule.Queries;
using App.Core.StudentModule.Transports;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(template: nameof(GetStudents), Name = nameof(GetStudents))]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _mediator.Send(new GetAllStudentQuery());
            return Ok(students);
        }


        [HttpGet(template: nameof(GetStudent), Name = nameof(GetStudent))]
        public async Task<IActionResult> GetStudent(int id)
        {
            var student = await _mediator.Send( new GetStudentQuery(id));
            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult<StudentTransport>> AddStudent([FromForm] AddStudentCommand command)
        {
            var student = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetStudent), student);
        }

        [HttpPut]
        public async Task<ActionResult<StudentTransport>> UpdateStudent([FromForm] UpdateStudentCommand command)
        {
            var student = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetStudent), student);
        }

    }
}
