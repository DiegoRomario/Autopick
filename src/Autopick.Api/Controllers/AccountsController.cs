using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Autopick.Api.Data;
using Autopick.Api.Domain;
using Autopick.Api.ViewModels;
using AutoMapper;

namespace Autopick.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly AutopickDBContext _context;
        private readonly IMapper _mapper;

        public AccountsController(AutopickDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountModel>>> GetAccounts()
        {
            List<Account> accounts = await _context.Accounts.ToListAsync();
            IEnumerable<AccountModel> response = _mapper.Map<IEnumerable<AccountModel>>(accounts);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AccountModel>> GetAccount(Guid id)
        {
            Account account = await _context.Accounts.FindAsync(id);
            if (account == null) return NotFound();

            AccountModel response = _mapper.Map<AccountModel>(account);

            return response;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccount(Guid id, AccountModel account)
        {
            if (id != account.Id) return BadRequest();

            Account entity = _mapper.Map<Account>(account);
            _context.Entry(entity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountExists(id)) return NotFound();
                else throw;
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Account>> PostAccount(AccountModel account)
        {
            Account entity = _mapper.Map<Account>(account);
            _context.Accounts.Add(entity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccount", new { id = entity.Id }, entity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(Guid id)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account == null) return NotFound();

            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AccountExists(Guid id)
        {
            return _context.Accounts.Any(e => e.Id == id);
        }
    }
}
