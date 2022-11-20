using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Functions.Core
{
    internal class JokeService : IJokeService
    {
        public Task<Joke> GetJokeAsync(CancellationToken cancellationToken)
        {
            // TODO implement
            return Task.FromResult<Joke>(new ());
        }
    }
}
