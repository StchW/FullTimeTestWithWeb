using System.Threading.Tasks;
using FullTimeForceTest.Api.Application.Commands.CreateEmployee;
using FullTimeForceTest.Api.Application.Queries;
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
        private readonly IEmployeeQueries _employeeQueries;

        private ApplicationDbContext _context;
        public EmployeesController(
            ApplicationDbContext context,
            IMediator mediator,
            IEmployeeQueries employeeQueries)
        {
            _context = context;
            _mediator = mediator;
            _employeeQueries = employeeQueries;
        }

        [HttpPost]
        [Route("calculatesalary")]
        public async Task<IActionResult> CalculateSalary(CreateEmployeeCommand employee)
        {
            ApplicationRepository app = new ApplicationRepository(_context);
            var reponse = await _mediator.Send(employee);
            return Ok(reponse);
        }

        [HttpGet]
        [Route("listsalaries")]
        public async Task<IActionResult> ListSalaries()
        {
            var salaries = await _employeeQueries.ListEmployeeSalaries();
            return Ok(salaries);
        }
    }
}