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
    public class ModalitiesController : ControllerBase
    {
        private readonly AutopickDBContext _context;
        private readonly IMapper _mapper;
        public ModalitiesController(AutopickDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModalityModel>>> GetModalities()
        {
            List<Modality> modalities = await _context.Modalities.ToListAsync();
            IEnumerable<ModalityModel> response = _mapper.Map<IEnumerable<ModalityModel>>(modalities);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ModalityModel>> GetModality(Guid id)
        {
            Modality modality = await _context.Modalities.FindAsync(id);
            if (modality == null) return NotFound();

            var response = _mapper.Map<ModalityModel>(modality);

            return response;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutModality(Guid id, ModalityModel modality)
        {
            if (id != modality.Id) return BadRequest();
            Modality entity = _mapper.Map<Modality>(modality);
            _context.Entry(entity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModalityExists(id)) return NotFound();
                else throw;
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<ModalityModel>> PostModality(ModalityModel modality)
        {
            Modality entity = _mapper.Map<Modality>(modality);
            _context.Modalities.Add(entity);
            await _context.SaveChangesAsync();
            modality.Id = entity.Id;
            return CreatedAtAction("GetModality", new { id = modality.Id }, modality);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModality(Guid id)
        {
            var modality = await _context.Modalities.FindAsync(id);
            if (modality == null) return NotFound();

            _context.Modalities.Remove(modality);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ModalityExists(Guid id)
        {
            return _context.Modalities.Any(e => e.Id == id);
        }
    }
}
