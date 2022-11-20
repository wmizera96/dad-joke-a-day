using Functions.Infrastructure;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Functions.Core
{
    public class JokeService : IJokeService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        private static int Counter = 0;

        public JokeService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public Task<Joke> GetJokeAsync(CancellationToken cancellationToken)
        {
            using var client = this._httpClientFactory.CreateClient();

            // TODO implement
            return Task.FromResult<Joke>(new Joke { Punchline = $"{Counter++} joke"});
        }
    }
}
