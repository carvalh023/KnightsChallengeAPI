using KnightsChallengeAPI.Entities;
using MongoDB.Driver;

namespace KnightsChallengeAPI.Data
{
    public interface IHeroesContext
    {
        IMongoCollection<Heroes> Heroe { get; }
    }
}
