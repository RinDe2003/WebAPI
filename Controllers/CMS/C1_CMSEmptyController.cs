using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_1721030646.Data;
using WebAPI_1721030646.Models.CMS;
using WebAPI_1721030646.DTO.CMS;

namespace WebAPI_1721030646.Controllers.CMS
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class C1_CMSEmptyController : ControllerBase
    {
        private readonly CMSContext _context;
        private readonly IMapper _mapper;
        public C1_CMSEmptyController(CMSContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetAllAccounts")]
        public async Task<ActionResult<IEnumerable<AccountDTO>>> GetAllAccounts()
        {
            var Account = await _context.Accounts
                .Select(Account => _mapper.Map<AccountDTO>(Account))
                .ToListAsync();
            return Account;
        }

        [HttpGet(Name = "GetAccountById")]
        public async Task<ActionResult<IEnumerable<AccountDTO>>> GetAccountById(int AccountID)
        {
            var Account = await _context.Accounts
                .Where(Account => Account.Id == AccountID)
                .Select(Account => _mapper.Map<AccountDTO>(Account))
                .ToListAsync();
            return Account;
        }

         [HttpPost]
        public async Task<ActionResult<Account>> AddNewAccount(AccountDTO Account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var NewAccount = _mapper.Map<Account>(Account);
            _context.Accounts.Add(NewAccount);

            await _context.SaveChangesAsync();

            return NewAccount;
        }

        [HttpPut]
        public async Task<ActionResult<Account>> EditAccount(int AccountId, AccountDTO Account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var UpdateAccount = _mapper.Map<Account>(Account);
            UpdateAccount.AccountId = AccountId;

            _context.Accounts.Update(UpdateAccount);

            await _context.SaveChangesAsync();

            return UpdateAccount;
        }

        [HttpDelete]
        public async Task<ActionResult<Account>> DeleteAccount(int AccountId)
        {
            var Account = await _context.Accounts.FindAsync(AccountId);
            if (Account is null)
            {
                ModelState.AddModelError("AccountId", "Invalid AccountId");
                return NotFound();
            }

            _context.Accounts.Remove(Account);
            await _context.SaveChangesAsync();

            return Account;
        }
    }
}
