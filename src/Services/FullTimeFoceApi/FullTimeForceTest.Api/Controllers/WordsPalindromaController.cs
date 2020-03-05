using System.Threading.Tasks;
using FullTimeForceTest.Api.Application.Commands.CreateWordPalindroma;
using FullTimeForceTest.Api.Models;
using FullTimeForceTest.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FullTimeForceTest.Api.Controllers
{
    [ApiController]
    [Route("api/v1/wordspalindroma")]
    public class WordsPalindromaController : Controller
    {
        private readonly IMediator _mediator;
        private ApplicationDbContext _context;

        public WordsPalindromaController(
            ApplicationDbContext context,
            IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        [HttpPost]
        [Route("evaluatewordpalindroma")]
        public async Task<IActionResult> EvaluateWordPalindroma(CreateWordPalindromaCommand word)
        {
            var isPalindroma = await _mediator.Send(word);
            string message = "No es palindroma";
            if (isPalindroma) message = "Es palindroma";
            return Ok(new EvaluateWordPalindromaResponse() { Message = message, IsPalindroma = isPalindroma });
        }

    }
}