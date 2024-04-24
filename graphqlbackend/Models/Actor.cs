using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace graphqlbackend.Models
{
    public class Actor
    {
        public Actor(string name, int age)
        {
            Name = name;
            Age = age;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Full_name")]
        public string Name { get; set; }

        public int Age { get; set; }
    }
}
