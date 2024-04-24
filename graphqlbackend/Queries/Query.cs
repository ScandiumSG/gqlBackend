using graphqlbackend.Models;
using graphqlbackend.Services;

namespace graphqlbackend.Queries
{
    public class Query
    {
        private readonly MoviesService _service;
        public Query(MoviesService service) 
        {
            _service = service;
        }

        [UseSorting]
        [UseFiltering]
        public async Task<IEnumerable<Movie>> GetMovie(int year = 0, [GraphQLName("movie_name")] string name = "")
        {
            var movies = await _service.GetAll();

            if (year != 0 && name != "")
            {
                return movies.Where(mov => mov.Year == year && mov.Name == name);
            }
            if (name != "")
            {
                return movies.Where(mov => mov.Name == name);
            }
            if (year != 0)
            {
                return movies.Where(mov => mov.Year == year);
            }
            return movies;
        }
    }
}
