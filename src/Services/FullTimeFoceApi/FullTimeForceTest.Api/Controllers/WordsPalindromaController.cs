using System.Threading.Tasks;
using FullTimeForceTest.Api.Application.Commands.CreateWordPalindroma;
using FullTimeForceTest.Api.Application.Queries;
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
        private readonly IWordQueries _wordQueries;

        public WordsPalindromaController(
            IMediator mediator,
            IWordQueries wordQueries)
        {
            _mediator = mediator;
            _wordQueries = wordQueries;
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

        [HttpGet]
        [Route("listWords")]
        public async Task<IActionResult> ListWords()
        {
            var words = await _wordQueries.ListWords();
            return Ok(words);
        }
    }
}