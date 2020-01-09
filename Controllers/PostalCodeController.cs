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
    public class PostalCodeController : ControllerBase
    {
        private readonly RentlessDBContext _context;

        public PostalCodeController(RentlessDBContext context)
        {
            _context = context;
        }

        // GET: api/PostalCode
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostalCode>>> GetPostalCode()
        {
            return await _context.PostalCode.ToListAsync();
        }

        // GET: api/PostalCode/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PostalCode>> GetPostalCode(string id)
        {
            var postalCode = await _context.PostalCode.FindAsync(id);

            if (postalCode == null)
            {
                return NotFound();
            }

            return postalCode;
        }

        // PUT: api/PostalCode/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPostalCode(string id, PostalCode postalCode)
        {
            if (id != postalCode.Code)
            {
                return BadRequest();
            }

            _context.Entry(postalCode).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostalCodeExists(id))
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

        // POST: api/PostalCode
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<PostalCode>> PostPostalCode(PostalCode postalCode)
        {
            _context.PostalCode.Add(postalCode);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PostalCodeExists(postalCode.Code))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPostalCode", new { id = postalCode.Code }, postalCode);
        }

        // DELETE: api/PostalCode/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PostalCode>> DeletePostalCode(string id)
        {
            var postalCode = await _context.PostalCode.FindAsync(id);
            if (postalCode == null)
            {
                return NotFound();
            }

            _context.PostalCode.Remove(postalCode);
            await _context.SaveChangesAsync();

            return postalCode;
        }

        private bool PostalCodeExists(string id)
        {
            return _context.PostalCode.Any(e => e.Code == id);
        }
    }
}
