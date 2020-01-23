using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rentless.Models;
using Microsoft.AspNet.OData;
namespace Rentless.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustPaymModeController : ControllerBase
    {
        private readonly RentlessDBContext _context;

        public CustPaymModeController(RentlessDBContext context)
        {
            _context = context;
        }

        // GET: api/CustPaymMode
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustPaymMode>>> GetCustPaymMode()
        {
            return await _context.CustPaymMode.ToListAsync();
        }

        // GET: api/CustPaymMode/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustPaymMode>> GetCustPaymMode(string id)
        {
            var custPaymMode = await _context.CustPaymMode.FindAsync(id);

            if (custPaymMode == null)
            {
                return NotFound();
            }

            return custPaymMode;
        }

        // PUT: api/CustPaymMode/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustPaymMode(string id, CustPaymMode custPaymMode)
        {
            if (id != custPaymMode.CustomerId)
            {
                return BadRequest();
            }

            _context.Entry(custPaymMode).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustPaymModeExists(id))
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

        // POST: api/CustPaymMode
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<CustPaymMode>> PostCustPaymMode(CustPaymMode custPaymMode)
        {
            _context.CustPaymMode.Add(custPaymMode);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CustPaymModeExists(custPaymMode.CustomerId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCustPaymMode", new { id = custPaymMode.CustomerId }, custPaymMode);
        }

        // DELETE: api/CustPaymMode/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CustPaymMode>> DeleteCustPaymMode(string id)
        {
            var custPaymMode = await _context.CustPaymMode.FindAsync(id);
            if (custPaymMode == null)
            {
                return NotFound();
            }

            _context.CustPaymMode.Remove(custPaymMode);
            await _context.SaveChangesAsync();

            return custPaymMode;
        }

        private bool CustPaymModeExists(string id)
        {
            return _context.CustPaymMode.Any(e => e.CustomerId == id);
        }
    }
}
