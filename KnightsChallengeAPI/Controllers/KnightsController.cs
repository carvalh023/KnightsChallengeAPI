using KnightsChallengeAPI.Entities;
using KnightsChallengeAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KnightsChallengeAPI.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class KnightsController : ControllerBase
    {
        private readonly IKnightsRepository _repository;

        public KnightsController(IKnightsRepository repository)
        {
            _repository = repository;
        }

        [HttpGet(Name = "GetKnights")]
        [ProducesResponseType(typeof(IEnumerable<Knights>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Knights>>> GetKnights()
        {
            var knights = await _repository.GetKnights();

            return Ok(knights);
        }

        [HttpGet(Name = "GetHeroes")]
        [ProducesResponseType(typeof(IEnumerable<Heroes>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Heroes>>> GetHeroes()
        {
            var heroes = await _repository.GetHeroes();

            return Ok(heroes);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Knights), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Knights>> CreateKnight([FromBody] Knights knights)
        {
            if (knights is null)
                return BadRequest("Invalid Product");

            await _repository.CreateKnight(knights);

            return CreatedAtRoute("CreateKnight", new { id = knights.Id }, knights);
        }

        [HttpGet("{id:length(24)}", Name = "GetKnightById")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Knights), StatusCodes.Status200OK)]
        public async Task<ActionResult<Knights>> GetKnightById(string id)
        {
            var knight = await _repository.GetKnightById(id);

            if (knight is null)
            {
                return NotFound();
            }

            return Ok(knight);
        }

        [HttpDelete("{id:length(24)}", Name = "DeleteKnight")]
        [ProducesResponseType(typeof(Knights), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteKnight(string id)
        {
            var oldKnight = await _repository.GetKnightById(id);

            var heroes = new Heroes()
            {
                Id = oldKnight.Id,
                Name = oldKnight.Name,
                Nickname = oldKnight.Nickname,
                Birthday = oldKnight.Birthday,
                weapons = oldKnight.weapons,
                attributes = oldKnight.attributes,
                KeyAttribute = oldKnight.KeyAttribute
            };

            await _repository.CreateHeroes(heroes);

            return Ok(await _repository.DeleteKnight(id));
        }

        [HttpPut]
        [ProducesResponseType(typeof(Knights), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateKnightNickname(string id, string nickname)
        {
            if (id is null && nickname is null)
            {
                return BadRequest("Invalid Product");
            }
            else
            {
                
                return Ok(await _repository.UpdateKnightNickname(id, nickname));
            }
                            
        }
    }
}
