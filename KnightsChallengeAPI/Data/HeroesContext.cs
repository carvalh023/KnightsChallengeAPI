using KnightsChallengeAPI.Entities;
using MongoDB.Driver;

namespace KnightsChallengeAPI.Data
{
    public class HeroesContext : IHeroesContext
    {
        public HeroesContext(IConfiguration configuration) 
        {
            var client = new MongoClient(configuration.GetValue<string>
        ("HeroesDataSettings:ConnectionString"));

            var database = client.GetDatabase(configuration.GetValue<string>
            ("HeroesDataSettings:DatabaseName"));

            Heroe = database.GetCollection<Heroes>(configuration.GetValue<string>
                    ("HeroesDataSettings:CollectionName"));
        }

        public IMongoCollection<Heroes> Heroe { get; }
    }
}
