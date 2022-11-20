using System.Threading;
using System.Threading.Tasks;

namespace Functions.Core
{
    internal interface IJokeService
    {
        Task<Joke> GetJokeAsync(CancellationToken cancellationToken);
    }
}
