namespace graphqlbackend.Models
{
    public class MovieDataDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string MovieCollectionName { get; set; } = null!;

    }
}
