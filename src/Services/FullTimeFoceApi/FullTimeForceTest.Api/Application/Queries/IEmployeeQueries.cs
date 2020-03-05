using FullTimeForceTest.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullTimeForceTest.Api.Application.Queries
{
    public interface IEmployeeQueries
    {
        Task<List<CalculateSalaryResponse>> ListEmployeeSalaries();
    }
}
