using gqlBackend.api.Models;

namespace gqlBackend.api.Queries
{
    public class Query
    {
        private static Actor actor1 = new Actor("Actor A", 42);
        private static Actor actor2 = new Actor("Actor B", 62);
        private static Actor actor3 = new Actor("Actor C", 22);

        private ICollection<Movie> _movies = new List<Movie>
        {
            new Movie("Movie A", "Something happens!", 1980, new List<Actor> { actor1, actor2 }),
            new Movie("Movie B", "Something happens?", 2000, new List<Actor> { actor2, actor3 }),
            new Movie("Movie C", "Something happens.", 2020, new List<Actor> { actor1, actor3 }),
        };

        [UseFiltering]
        public IEnumerable<Movie> GetMovie(int year = 0, [GraphQLName("movie_name")] string name = "")
        {
            if (year != 0 && name != "")
            {
                return _movies.Where(mov => mov.Year == year && mov.Name == name);
            }
            if (name != "")
            {
                return _movies.Where(mov => mov.Name == name);
            }
            if (year != 0)
            {
                return _movies.Where(mov => mov.Year == year);
            }
            return _movies;
        }
    }
}
