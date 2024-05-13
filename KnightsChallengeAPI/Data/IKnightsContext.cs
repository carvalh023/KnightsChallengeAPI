using KnightsChallengeAPI.Entities;
using MongoDB.Driver;

namespace KnightsChallengeAPI.Data
{
    public interface IKnightsContext
    {
        IMongoCollection<Knights> Knight { get; }
        IMongoCollection<Heroes> Heroe { get; }

    }
}
