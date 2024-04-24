using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace graphqlbackend.Models
{
    public class Movie
    {
        public Movie(string name, string description, int year, ICollection<Actor>? actors)
        {
            Name = name;
            Description = description;
            Year = year;
            Actors = actors != null ? actors : new List<Actor>();
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        [BsonElement("Release_year")]
        public int Year { get; set; }

        [UseSorting]
        [UseFiltering]
        public ICollection<Actor>? Actors { get; set; }
    }
}
