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
    public class DocuTypeController : ControllerBase
    {
        private readonly RentlessDBContext _context;

        public DocuTypeController(RentlessDBContext context)
        {
            _context = context;
        }

        // GET: api/DocuType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DocuType>>> GetDocuType()
        {
            return await _context.DocuType.ToListAsync();
        }

        // GET: api/DocuType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DocuType>> GetDocuType(string id)
        {
            var docuType = await _context.DocuType.FindAsync(id);

            if (docuType == null)
            {
                return NotFound();
            }

            return docuType;
        }

        // PUT: api/DocuType/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDocuType(string id, DocuType docuType)
        {
            if (id != docuType.Code)
            {
                return BadRequest();
            }

            _context.Entry(docuType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocuTypeExists(id))
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

        // POST: api/DocuType
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<DocuType>> PostDocuType(DocuType docuType)
        {
            _context.DocuType.Add(docuType);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DocuTypeExists(docuType.Code))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDocuType", new { id = docuType.Code }, docuType);
        }

        // DELETE: api/DocuType/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DocuType>> DeleteDocuType(string id)
        {
            var docuType = await _context.DocuType.FindAsync(id);
            if (docuType == null)
            {
                return NotFound();
            }

            _context.DocuType.Remove(docuType);
            await _context.SaveChangesAsync();

            return docuType;
        }

        private bool DocuTypeExists(string id)
        {
            return _context.DocuType.Any(e => e.Code == id);
        }
    }
}
