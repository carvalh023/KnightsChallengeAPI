using KnightsChallengeAPI.Data;
using KnightsChallengeAPI.Entities;
using MongoDB.Driver;

namespace KnightsChallengeAPI.Repositories
{
    public class KnightsRepository : IKnightsRepository
    {
        private readonly IKnightsContext _context;

        private readonly IHeroesContext _contextHero;
        public KnightsRepository(IKnightsContext context)
        {
            _context = context;
        }

        public async Task CreateKnight(Knights knights)
        {
            await _context.Knight.InsertOneAsync(knights);
        }
        public async Task CreateHeroes(Heroes heroes)
        {
            await _context.Heroe.InsertOneAsync(heroes);
        }

        public async Task<bool> DeleteKnight(string id)
        {
            var newHeroe = _context.Knight.Find(p => p.Id == id).FirstOrDefaultAsync();

            var heroes = new Heroes()
            {
                Id = newHeroe.Result.Id,
                Name = newHeroe.Result.Name,
                Nickname = newHeroe.Result.Nickname,
                Birthday = newHeroe.Result.Birthday,
                weapons = newHeroe.Result.weapons,
                attributes = newHeroe.Result.attributes,
                KeyAttribute = newHeroe.Result.KeyAttribute
            };
            
            await _contextHero.Heroe.InsertOneAsync(heroes);

            FilterDefinition<Knights> filter = Builders<Knights>.Filter.Eq(p => p.Id, id);

            DeleteResult deleteResult = await _context.Knight.DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }

        public async Task<IEnumerable<Heroes>> GetHeroes()
        {
            return await _contextHero.Heroe.Find(p => true).ToListAsync();
        }

        public async Task<Knights> GetKnightById(string id)
        {
            return await _context.Knight.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Knights>> GetKnights()
        {
            return await _context.Knight.Find(p => true).ToListAsync();
        }

        public async Task<bool> UpdateKnightNickname(string id, string nickname)
        {
            var newnick = _context.Knight.Find(p => p.Id == id).FirstOrDefaultAsync();

            newnick.Result.Nickname = nickname;

            var updateResult = await _context.Knight.ReplaceOneAsync(
                filter: g => g.Id == newnick.Result.Id, replacement: newnick.Result);

            return updateResult.IsAcknowledged
                && updateResult.ModifiedCount > 0;
        }
    }
}
