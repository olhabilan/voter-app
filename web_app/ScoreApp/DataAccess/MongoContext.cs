using MongoDB.Driver;
using ScoreApp.Models.DataModels;
using System;

namespace ScoreApp.DataAccess
{
    public interface IMongoContext
    {
        IMongoCollection<ScoreItem> ScoreItems { get; }
    }

    public class MongoContext : IMongoContext
    {
        private readonly IMongoDatabase _database = null;

        public MongoContext(string connectionString, string database)
        {
            if (string.IsNullOrWhiteSpace(connectionString) || string.IsNullOrWhiteSpace(database))
            {
                throw new ArgumentException("empty connection string to mongo");
            }

            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(database);
        }

        public IMongoCollection<ScoreItem> ScoreItems
        {
            get
            {
                return _database.GetCollection<ScoreItem>("scoreCollection");
            }
        }
    }
}
