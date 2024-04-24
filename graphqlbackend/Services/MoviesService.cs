using MongoDB.Driver;
using graphqlbackend.Models;
using Microsoft.Extensions.Options;

namespace graphqlbackend.Services
{
    public class MoviesService
    {
        private readonly IMongoCollection<Movie> _moviesCollection;

        public MoviesService(IOptions<MovieDataDatabaseSettings> movieDatabaseSettings)
        {
            MongoClient mongoClient = new MongoClient(
                movieDatabaseSettings.Value.ConnectionString);

            IMongoDatabase mongoDatabase = mongoClient.GetDatabase(
                movieDatabaseSettings.Value.DatabaseName);

            _moviesCollection = mongoDatabase.GetCollection<Movie>(
                movieDatabaseSettings.Value.MovieCollectionName);
        }

        public async Task<IEnumerable<Movie>> GetAll()
        {
            return await _moviesCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Movie?> Get(string id) 
        {
            return await _moviesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task Create(Movie newMovie) 
        { 
            await _moviesCollection.InsertOneAsync(newMovie);
        }

        public async Task Update(string id, Movie updatedMovie) 
        {
            await _moviesCollection.ReplaceOneAsync(x => x.Id == id, updatedMovie);
        }

        public async Task Remove(string id) 
        {
            await _moviesCollection.DeleteOneAsync(x => x.Id == id);
        }
    }
}
