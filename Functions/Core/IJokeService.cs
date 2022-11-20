using System.Threading;
using System.Threading.Tasks;

namespace Functions.Core
{
    public interface IJokeService
    {
        Task<Joke> GetJokeAsync(CancellationToken cancellationToken);
    }
}
