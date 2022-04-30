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
    public class MatchesController : ControllerBase
    {
        private readonly AutopickDBContext _context;
        private readonly IMapper _mapper;

        public MatchesController(AutopickDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MatchModel>>> GetMatches()
        {
            List<Match> Matches = await _context.Matches.ToListAsync();
            IEnumerable<MatchModel> response = _mapper.Map<IEnumerable<MatchModel>>(Matches);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MatchModel>> GetMatch(Guid id)
        {
            Match Match = await _context.Matches.FindAsync(id);
            if (Match == null) return NotFound();

            var response = _mapper.Map<MatchModel>(Match);

            return response;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutMatch(Guid id, MatchModel match)
        {
            if (id != match.Id) return BadRequest();
            Match entity = _mapper.Map<Match>(match);
            _context.Entry(entity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatchExists(id)) return NotFound();
                else throw;
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<MatchModel>> PostMatch(MatchModel match)
        {
            Match entity = _mapper.Map<Match>(match);
            _context.Matches.Add(entity);
            await _context.SaveChangesAsync();
            match.Id = entity.Id;
            return CreatedAtAction("GetMatch", new { id = match.Id }, match);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMatch(Guid id)
        {
            var Match = await _context.Matches.FindAsync(id);
            if (Match == null) return NotFound();

            _context.Matches.Remove(Match);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MatchExists(Guid id)
        {
            return _context.Matches.Any(e => e.Id == id);
        }
    }
}
