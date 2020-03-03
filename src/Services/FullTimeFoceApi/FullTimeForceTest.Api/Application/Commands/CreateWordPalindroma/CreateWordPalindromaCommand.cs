using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullTimeForceTest.Api.Application.Commands.CreateWordPalindroma
{
    public class CreateWordPalindromaCommand : IRequest<bool>
    {
        public string Message { get; set; }
    }
}
