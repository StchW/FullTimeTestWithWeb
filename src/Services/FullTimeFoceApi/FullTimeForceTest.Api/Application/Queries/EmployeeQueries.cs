using FulltimeForceTest.Domain.EmployeeAggregate;
using FullTimeForceTest.Api.Models;
using FullTimeForceTest.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullTimeForceTest.Api.Application.Queries
{
    public class EmployeeQueries : IEmployeeQueries
    {
        private IDatabaseService<Employee> _dbEmployee;

        public EmployeeQueries(
            ApplicationDbContext _context)
        {
            _dbEmployee = new DatabaseService<Employee>(_context);
        }

        public async Task<List<CalculateSalaryResponse>> ListEmployeeSalaries()
        {
            List<CalculateSalaryResponse> employees = new List<CalculateSalaryResponse>();
            CalculateSalaryResponse employeeToResponse = null;
            var employeesDB = _dbEmployee.GetList().OrderByDescending(x => x.Id).ToList();

            if (employeesDB == null || employeesDB.Count == 0) return employees;

            foreach (var item in employeesDB)
            {
                employeeToResponse = new CalculateSalaryResponse();
                employeeToResponse.Id = item.Id;
                employeeToResponse.Name = item.Name;
                employeeToResponse.PriceHour = item.PriceHour;
                employeeToResponse.TotalHoursWork = item.TotalHoursWork;
                employeeToResponse.Antiquity = item.Antiquity;
                employeeToResponse.TotalDiscounts = Math.Round(item.TotalDiscounts, 2);
                employeeToResponse.TotalGrossCharge = Math.Round(item.TotalGrossCharge, 2);
                employeeToResponse.NetoPayment = Math.Round(item.NetoPayment, 2);
                employees.Add(employeeToResponse);
            }

            return employees;
        }
    }
}
