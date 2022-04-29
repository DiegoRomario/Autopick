using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Autopick.Api.Data;
using Autopick.Api.Domain;
using AutoMapper;
using Autopick.Api.Models;

namespace Autopick.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly AutopickDBContext _context;
        private readonly IMapper _mapper;

        public PlayersController(AutopickDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerModel>>> GetPlayers()
        {
            List<Player> player = await _context.Players.ToListAsync();
            IEnumerable<PlayerModel> response = _mapper.Map<IEnumerable<PlayerModel>>(player);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PlayerModel>> GetPlayer(Guid id)
        {
            Player player = await _context.Players.FindAsync(id);
            if (player == null) return NotFound();

            var response = _mapper.Map<PlayerModel>(player);

            return response;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayer(Guid id, PlayerModel player)
        {
            if (id != player.Id) return BadRequest();
            Player entity = _mapper.Map<Player>(player);
            _context.Entry(entity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerExists(id)) return NotFound();
                else throw;
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<PlayerModel>> PostPlayer(PlayerModel player)
        {
            Player entity = _mapper.Map<Player>(player);
            _context.Players.Add(entity);
            await _context.SaveChangesAsync();
            player.Id = entity.Id;
            return CreatedAtAction("GetPlayer", new { id = player.Id }, player);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer(Guid id)
        {
            var player = await _context.Players.FindAsync(id);
            if (player == null) return NotFound();

            _context.Players.Remove(player);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlayerExists(Guid id)
        {
            return _context.Players.Any(e => e.Id == id);
        }
    }
}
