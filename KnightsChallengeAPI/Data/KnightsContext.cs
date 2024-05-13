using KnightsChallengeAPI.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace KnightsChallengeAPI.Data
{
    public class KnightsContext : IKnightsContext
    {
        public KnightsContext(IConfiguration configuration) 
        {
            var client = new MongoClient(configuration.GetValue<string>
        ("KnightsDataSettings:ConnectionString"));

            var database = client.GetDatabase(configuration.GetValue<string>
                ("KnightsDataSettings:DatabaseName"));

            Knight = database.GetCollection<Knights>(configuration.GetValue<string>
                    ("KnightsDataSettings:CollectionName"));

            Heroe = database.GetCollection<Heroes>(configuration.GetValue<string>
                    ("HeroesDataSettings:CollectionName"));
        }
        
        public IMongoCollection<Knights> Knight { get; }

        public IMongoCollection<Heroes> Heroe { get; }

    }
}
