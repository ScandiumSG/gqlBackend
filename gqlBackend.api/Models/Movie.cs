namespace gqlBackend.api.Models
{
    public class Movie
    {
        public Movie(string name, string description, int year, ICollection<Actor> actors)
        {
            Name = name;
            Description = description;
            Year = year;
            Actors = actors;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public ICollection<Actor> Actors { get; set; }
    }
}
