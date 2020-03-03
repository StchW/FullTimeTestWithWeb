using FullTimeForceTest.Api.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullTimeForceTest.Api.Application.Commands.CreateEmployee
{
    public class CreateEmployeeCommand : IRequest<CalculateSalaryResponse>
    {
        public double PriceHour { get; set; }
        public string Name { get; set; }
        public double TotalHoursWork { get; set; }
        public int Antiquity { get; set; }
    }
}
