using FulltimeForceTest.Domain.EmployeeAggregate;
using FullTimeForceTest.Api.Infrastructure.Repository;
using FullTimeForceTest.Api.Infrastructure.Utility.Constants;
using FullTimeForceTest.Api.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FullTimeForceTest.Api.Application.Commands.CreateEmployee
{
    public class CreateEmployeeCommandHandler
        : IRequestHandler<CreateEmployeeCommand, CalculateSalaryResponse>
    {
        private IApplicationRepository _applicationRepository;

        public CreateEmployeeCommandHandler(
            IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        public async Task<CalculateSalaryResponse> Handle(
            CreateEmployeeCommand request, 
            CancellationToken cancellationToken)
        {
            Employee employee = new Employee();
            employee.Name = request.Name;
            employee.PriceHour = request.PriceHour;
            employee.Antiquity = request.Antiquity;
            employee.TotalHoursWork = request.TotalHoursWork;
            employee.TotalGrossCharge = calculateTotalGrossCharge(request.PriceHour, request.TotalHoursWork, request.Antiquity);
            employee.TotalDiscounts = calculateTotalDiscounts(employee.TotalGrossCharge);
            employee.NetoPayment = (employee.TotalGrossCharge - employee.TotalDiscounts);
            _applicationRepository.CreateEmployee(employee);

            CalculateSalaryResponse dataToResponse = new CalculateSalaryResponse();
            dataToResponse.Name = employee.Name;
            dataToResponse.PriceHour = employee.PriceHour;
            dataToResponse.Antiquity = employee.Antiquity;
            dataToResponse.TotalHoursWork = employee.TotalHoursWork;
            dataToResponse.TotalGrossCharge = Math.Round(employee.TotalGrossCharge, 2);
            dataToResponse.TotalDiscounts = Math.Round(employee.TotalDiscounts, 2);
            dataToResponse.NetoPayment = Math.Round(employee.NetoPayment, 2);

            return dataToResponse;
        }

        private double calculateTotalGrossCharge(double PriceHour, double TotalHoursWork, int Antiquity)
        {
            double extra = Antiquity * ValuesPayment.PaymentPerYearOld;
            double payment = (PriceHour * TotalHoursWork + extra);
            return payment;
        }

        private double calculateTotalDiscounts(double mount)
        {
            return (mount * ValuesPayment.DiscountPercentage);
        }


    }
}
