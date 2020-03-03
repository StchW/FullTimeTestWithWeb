using FulltimeForceTest.Domain.WordPalindromaAggregate;
using FullTimeForceTest.Api.Infrastructure.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FullTimeForceTest.Api.Application.Commands.CreateWordPalindroma
{
    public class CreateWordPalindromaCommandHandler
        : IRequestHandler<CreateWordPalindromaCommand, bool>
    {
        private IApplicationRepository _applicationRepository;

        public CreateWordPalindromaCommandHandler(
            IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        public async Task<bool> Handle(
            CreateWordPalindromaCommand request, 
            CancellationToken cancellationToken)
        {
            WordPalindroma wordToCreate = new WordPalindroma();
            wordToCreate.Message = request.Message;
            wordToCreate.IsPalindroma = isPalindrome(request.Message);
            _applicationRepository.CreateWordPalindoma(wordToCreate);
            return wordToCreate.IsPalindroma;
        }

        private bool isPalindrome(string text)
        {
            if (text.Length <= 1) return true;
            if (text[0] != text[text.Length - 1]) return false;
            return isPalindrome(text.Substring(1, text.Length - 2));
        }
    }
}
