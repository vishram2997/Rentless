using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rentless.Models;

namespace Rentless.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymModeController : ControllerBase
    {
        private readonly RentlessDBContext _context;

        public PaymModeController(RentlessDBContext context)
        {
            _context = context;
        }

        // GET: api/PaymMode
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymMode>>> GetPaymMode()
        {
            return await _context.PaymMode.ToListAsync();
        }

        // GET: api/PaymMode/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymMode>> GetPaymMode(string id)
        {
            var paymMode = await _context.PaymMode.FindAsync(id);

            if (paymMode == null)
            {
                return NotFound();
            }

            return paymMode;
        }

        // PUT: api/PaymMode/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymMode(string id, PaymMode paymMode)
        {
            if (id != paymMode.Code)
            {
                return BadRequest();
            }

            _context.Entry(paymMode).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymModeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PaymMode
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<PaymMode>> PostPaymMode(PaymMode paymMode)
        {
            _context.PaymMode.Add(paymMode);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PaymModeExists(paymMode.Code))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPaymMode", new { id = paymMode.Code }, paymMode);
        }

        // DELETE: api/PaymMode/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PaymMode>> DeletePaymMode(string id)
        {
            var paymMode = await _context.PaymMode.FindAsync(id);
            if (paymMode == null)
            {
                return NotFound();
            }

            _context.PaymMode.Remove(paymMode);
            await _context.SaveChangesAsync();

            return paymMode;
        }

        private bool PaymModeExists(string id)
        {
            return _context.PaymMode.Any(e => e.Code == id);
        }
    }
}
