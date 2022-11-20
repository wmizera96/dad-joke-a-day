using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Functions.Core
{
    public class JokeService : IJokeService
    {
        private readonly HttpClient _httpClient;

        public JokeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Joke> GetJokeAsync(CancellationToken cancellationToken)
        {
            var responseMessage = await _httpClient.GetAsync("random/joke", cancellationToken);

            if(responseMessage.IsSuccessStatusCode == false)
            {
                // TODO error handling
                throw new Exception("invalid response");
            }

            var jokeResponse = await responseMessage.Content.ReadAsAsync<JokeResponse>();

            return jokeResponse.Body.First();
        }
    }
}
