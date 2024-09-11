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
    public class C2_CMSActEFController : ControllerBase
    {
        private readonly CMSContext _context;
        private readonly IMapper _mapper;
        public C2_CMSActEFController(CMSContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetWardByDistrictID")]
        public async Task<ActionResult<IEnumerable<WardDTO>>> GetWardByDistrictID(int DistrictID)
        {
            var Ward = await _context.Wards
                .Where(Ward => Ward.DistrictId == DistrictID)
                .Select(Ward => _mapper.Map<WardDTO>(Ward))
                .ToListAsync();
            return Ward;
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
