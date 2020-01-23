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
    public class ProductDocumentController : ControllerBase
    {
        private readonly RentlessDBContext _context;

        public ProductDocumentController(RentlessDBContext context)
        {
            _context = context;
        }

        // GET: api/ProductDocument
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDocument>>> GetProductDocument()
        {
            return await _context.ProductDocument.ToListAsync();
        }

        // GET: api/ProductDocument/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDocument>> GetProductDocument(int id)
        {
            var productDocument = await _context.ProductDocument.FindAsync(id);

            if (productDocument == null)
            {
                return NotFound();
            }

            return productDocument;
        }

        // PUT: api/ProductDocument/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductDocument(int id, ProductDocument productDocument)
        {
            if (id != productDocument.ProductCode)
            {
                return BadRequest();
            }

            _context.Entry(productDocument).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductDocumentExists(id))
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

        // POST: api/ProductDocument
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<ProductDocument>> PostProductDocument(ProductDocument productDocument)
        {
            _context.ProductDocument.Add(productDocument);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductDocumentExists(productDocument.ProductCode))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProductDocument", new { id = productDocument.ProductCode }, productDocument);
        }

        // DELETE: api/ProductDocument/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductDocument>> DeleteProductDocument(int id)
        {
            var productDocument = await _context.ProductDocument.FindAsync(id);
            if (productDocument == null)
            {
                return NotFound();
            }

            _context.ProductDocument.Remove(productDocument);
            await _context.SaveChangesAsync();

            return productDocument;
        }

        private bool ProductDocumentExists(int id)
        {
            return _context.ProductDocument.Any(e => e.ProductCode == id);
        }
    }
}
