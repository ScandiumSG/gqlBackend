using graphqlbackend.Models;
using graphqlbackend.Services;

namespace graphqlbackend.Queries
{
    public class Mutation
    {
        private readonly MoviesService _service;
        public Mutation(MoviesService service)
        {
            _service = service;
        }

        [UseMutationConvention]
        public async Task<Movie?> CreateMovie(Movie movie) 
        { 
            Movie? inserted = await _service.Create(movie);
            if (inserted == null)
            {
                return null;
            }
            else 
            { 
                return inserted;
            }
        }
    }
}
