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
    public class SkillsController : ControllerBase
    {
        private readonly AutopickDBContext _context;
        private readonly IMapper _mapper;

        public SkillsController(AutopickDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SkillModel>>> GetSkills()
        {
            List<Skill> skills = await _context.Skills.ToListAsync();
            IEnumerable<SkillModel> response = _mapper.Map<IEnumerable<SkillModel>>(skills);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SkillModel>> GetSkill(Guid id)
        {
            Skill skill = await _context.Skills.FindAsync(id);
            if (skill == null) return NotFound();

            var response = _mapper.Map<SkillModel>(skill);

            return response;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSkill(Guid id, SkillModel skill)
        {
            if (id != skill.Id) return BadRequest();
            Skill entity = _mapper.Map<Skill>(skill);
            _context.Entry(entity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SkillExists(id)) return NotFound();
                else throw;
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Skill>> PostSkill(SkillModel skill)
        {
            Skill entity = _mapper.Map<Skill>(skill);
            _context.Skills.Add(entity);
            await _context.SaveChangesAsync();
            skill.Id = entity.Id;
            return CreatedAtAction("GetSkill", new { id = skill.Id }, skill);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSkill(Guid id)
        {
            var skill = await _context.Skills.FindAsync(id);
            if (skill == null) return NotFound();

            _context.Skills.Remove(skill);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SkillExists(Guid id)
        {
            return _context.Skills.Any(e => e.Id == id);
        }
    }
}
