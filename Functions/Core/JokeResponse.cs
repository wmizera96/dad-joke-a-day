using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Functions.Core
{
    public class JokeResponse
    {
        public bool Success { get; set; }
        public IEnumerable<Joke> Body { get; set; }
    }
}
