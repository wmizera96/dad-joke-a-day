using System.Threading;
using System.Threading.Tasks;
using Domain;

namespace Functions.Core
{
    public interface IJokeService
    {
        Task<Joke> GetJokeAsync(CancellationToken cancellationToken);
    }
}
