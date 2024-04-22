using gqlBackend.api.Models;

namespace gqlBackend.api.Queries
{
    public class Query
    {
        public Movie GetMovie() => 
            new Movie("Movie A", "Something happens", 2000, new List<Actor> { new Actor("Actor A", 42), new Actor("Actor B", 43) });
    }
}
