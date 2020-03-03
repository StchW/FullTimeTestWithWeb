using System.Threading.Tasks;
using FullTimeForceTest.Api.Application.Commands.CreateEmployee;
using FullTimeForceTest.Api.Infrastructure.Repository;
using FullTimeForceTest.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FullTimeForceTest.Api.Controllers
{
    [ApiController]
    [Route("api/v1/employees")]
    public class EmployeesController : Controller
    {
        private readonly IMediator _mediator;

        private ApplicationDbContext _context;
        public EmployeesController(
            ApplicationDbContext context,
            IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        [HttpPost]
        [Route("calculatesalary")]
        public async Task<IActionResult> CalculateSalary(CreateEmployeeCommand employee)
        {
            ApplicationRepository app = new ApplicationRepository(_context);
            var reponse = await _mediator.Send(employee);
            return Ok(reponse);
        }
    }
}