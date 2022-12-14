using System;
using System.Threading;
using System.Threading.Tasks;
using Functions.Core;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Functions
{
    public class JokeFunctions
    {
        private readonly IJokeService _jokeService;

        public JokeFunctions(IJokeService jokeService)
        {
            _jokeService = jokeService;
        }


        [FunctionName("get-random-joke")]
        public async Task GetRandomJokeAsync([TimerTrigger("*/5 * * * * *")]TimerInfo myTimer, ILogger log, CancellationToken cancellationToken)
        {
            var joke = await _jokeService.GetJokeAsync(cancellationToken);
            log.LogInformation(joke.ToString());
        }
    }
}
