using System;
using System.Threading.Tasks;
using FullTimeForceTest.Api.Application.Commands.CreateStudentNote;
using FullTimeForceTest.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FullTimeForceTest.Api.Controllers
{
    [ApiController]
    [Route("api/v1/students")]
    public class StudentsController : Controller
    {
        private readonly IMediator _mediator;
        private ApplicationDbContext _context;

        public StudentsController(
            ApplicationDbContext context,
            IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        [HttpPost]
        [Route("calculatefinalnote")]
        public async Task<IActionResult> CalculateFinalNote(CreateStudentCommand studentCommand)
        {
            var response = await _mediator.Send(studentCommand);
            return Ok(response);
        }
    }
}