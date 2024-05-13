using KnightsChallengeAPI.Entities;

namespace KnightsChallengeAPI.Repositories
{
    public interface IKnightsRepository
    {
        Task<IEnumerable<Knights>> GetKnights();
        Task<IEnumerable<Heroes>> GetHeroes();
        Task CreateKnight(Knights knights);
        Task CreateHeroes(Heroes heroes);
        Task<Knights> GetKnightById(string id);
        Task<bool> DeleteKnight(string id);
        Task<bool> UpdateKnightNickname(string id, string nickname);
    }
}
