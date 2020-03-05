using FulltimeForceTest.Domain.WordPalindromaAggregate;
using FullTimeForceTest.Api.Models;
using FullTimeForceTest.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullTimeForceTest.Api.Application.Queries
{
    public class WordQueries : IWordQueries
    {
        private IDatabaseService<WordPalindroma> _dbWordPalindroma;

        public WordQueries(
            ApplicationDbContext _context)
        {
            _dbWordPalindroma = new DatabaseService<WordPalindroma>(_context);
        }


        public async Task<List<EvaluateWordPalindromaResponse>> ListWords()
        {
            List<EvaluateWordPalindromaResponse> words = new List<EvaluateWordPalindromaResponse>();
            EvaluateWordPalindromaResponse word = null;

            var wordsDB = _dbWordPalindroma.GetList().OrderByDescending(x => x.Id).ToList();
            if (wordsDB == null || wordsDB.Count == 0) return words;

            foreach (var item in wordsDB)
            {
                word = new EvaluateWordPalindromaResponse();
                word.Id = item.Id;
                word.Message = item.Message;
                word.IsPalindroma = item.IsPalindroma;
                words.Add(word);
            }

            return words;
        }


    }
}
