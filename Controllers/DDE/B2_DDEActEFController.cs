using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_1721030646.Data;
using WebAPI_1721030646.Models.DDE;
using WebAPI_1721030646.DTO.DDE;

namespace WebAPI_1721030646.Controllers.DDE
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class B2_DDEActEFController : ControllerBase
    {
        private readonly EcommerceAddressContext _context;
        private readonly IMapper _mapper;
        public B2_DDEActEFController(EcommerceAddressContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetAddressByCountryID")]
        public async Task<ActionResult<IEnumerable<AddressDTO>>> GetAddressByCountryID(int CountryID)
        {
            var Address = await _context.Addresses
                .Where(Address => Address.CountryId == CountryID)
                .Select(Address => _mapper.Map<AddressDTO>(Address))
                .ToListAsync();
            return Address;
        }

        [HttpPost]
        public async Task<ActionResult<Address>> AddNewAddress(AddressDTO Address)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var NewAddress = _mapper.Map<Address>(Address);
            _context.Addresses.Add(NewAddress);

            await _context.SaveChangesAsync();

            return NewAddress;
        }

        [HttpPut]
        public async Task<ActionResult<Address>> EditAddress(int AddressId, AddressDTO Address)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var UpdateAddress = _mapper.Map<Address>(Address);
            UpdateAddress.AddressId = AddressId;

            _context.Addresses.Update(UpdateAddress);

            await _context.SaveChangesAsync();

            return UpdateAddress;
        }

        [HttpDelete]
        public async Task<ActionResult<Address>> DeleteAddress(int AddressId)
        {
            var Address = await _context.Addresses.FindAsync(AddressId);
            if (Address is null)
            {
                ModelState.AddModelError("AddressId", "Invalid AddressId");
                return NotFound();
            }

            _context.Addresses.Remove(Address);
            await _context.SaveChangesAsync();

            return Address;
        }
    }
}
