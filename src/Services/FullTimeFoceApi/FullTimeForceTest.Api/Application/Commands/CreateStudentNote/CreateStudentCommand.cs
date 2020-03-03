using FullTimeForceTest.Api.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullTimeForceTest.Api.Application.Commands.CreateStudentNote
{
    public class CreateStudentCommand : IRequest<CalculateFinalNoteResponse>
    {
        public string Notes { get; set; }
    }
}
