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
    public class GroupsController : ControllerBase
    {
        private readonly AutopickDBContext _context;
        private readonly IMapper _mapper;

        public GroupsController(AutopickDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupModel>>> GetGroups()
        {
            List<Group> groups = await _context.Groups.ToListAsync();
            IEnumerable<GroupModel> response = _mapper.Map<IEnumerable<GroupModel>>(groups);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GroupModel>> GetGroup(Guid id)
        {
            var group = await _context.Groups.FindAsync(id);
            if (group == null) return NotFound();

            var response = _mapper.Map<GroupModel>(group);

            return response;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroup(Guid id, GroupModel group)
        {
            if (id != group.Id) return BadRequest();

            var entity = _mapper.Map<Group>(group);
            _context.Entry(entity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupExists(id)) return NotFound();
                else throw;
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Group>> PostGroup(GroupModel group)
        {
            Group entity = _mapper.Map<Group>(group);
            _context.Groups.Add(entity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGroup", new { id = @group.Id }, @group);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroup(Guid id)
        {
            var group = await _context.Groups.FindAsync(id);
            if (group == null) return NotFound();

            _context.Groups.Remove(group);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GroupExists(Guid id)
        {
            return _context.Groups.Any(e => e.Id == id);
        }
    }
}
