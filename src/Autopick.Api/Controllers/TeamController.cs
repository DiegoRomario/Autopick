using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Autopick.Api.Data;
using Autopick.Api.Models;
using AutoMapper;
using Autopick.Api.Domain;

namespace Autopick.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly AutopickDBContext _context;
        private readonly IMapper _mapper;

        public TeamController(AutopickDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamModel>>> GetTeam()
        {
            List<Team> teams = await _context.Teams.Include(x => x.Players).ToListAsync();
            IEnumerable<TeamModel> response = _mapper.Map<IEnumerable<TeamModel>>(teams);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TeamModel>> GetTeam(Guid id)
        {
            Team team = await _context.Teams.FindAsync(id);
            if (team == null) return NotFound();

            var response = _mapper.Map<TeamModel>(team);

            return response;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeam(Guid id, TeamModel team)
        {
            if (id != team.Id) return BadRequest();
            Team entity = _mapper.Map<Team>(team);
            var players = await _context.Players
            .Where(e => team.Players.Select(x => x.Id).Contains(e.Id))
            .ToListAsync();

            _context.PlayersTeams.RemoveRange(_context.PlayersTeams);
            await _context.SaveChangesAsync();
            entity.SetPlayers(players);
            _context.Entry(entity).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamExists(id)) return NotFound();
                else throw;
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<TeamModel>> PostTeam(TeamModel team)
        {

            Team entity = _mapper.Map<Team>(team);
            var players = await _context.Players
            .Where(e => team.Players.Select(x => x.Id).Contains(e.Id))
            .ToListAsync();

            entity.SetPlayers(players);

            _context.Teams.Add(entity);
            await _context.SaveChangesAsync();
            team.Id = entity.Id;
            return CreatedAtAction("GetTeam", new { id = team.Id }, team);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(Guid id)
        {
            var team = await _context.Teams.FindAsync(id);
            if (team == null) return NotFound();

            var teamPlayers = await _context.PlayersTeams
            .Where(e => e.TeamId == id)
            .ToListAsync();

            _context.PlayersTeams.RemoveRange(teamPlayers);
            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TeamExists(Guid id)
        {
            return _context.Teams.Any(e => e.Id == id);
        }
    }
}
