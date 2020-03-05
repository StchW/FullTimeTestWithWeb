using FullTimeForceTest.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullTimeForceTest.Api.Application.Queries
{
    public interface IWordQueries
    {
        Task<List<EvaluateWordPalindromaResponse>> ListWords();
    }
}
