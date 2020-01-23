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
    public class ProductAttributeController : ControllerBase
    {
        private readonly RentlessDBContext _context;

        public ProductAttributeController(RentlessDBContext context)
        {
            _context = context;
        }

        // GET: api/ProductAttribute
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductAttribute>>> GetProductAttribute()
        {
            return await _context.ProductAttribute.ToListAsync();
        }

        // GET: api/ProductAttribute/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductAttribute>> GetProductAttribute(int id)
        {
            var productAttribute = await _context.ProductAttribute.FindAsync(id);

            if (productAttribute == null)
            {
                return NotFound();
            }

            return productAttribute;
        }

        // PUT: api/ProductAttribute/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductAttribute(int id, ProductAttribute productAttribute)
        {
            if (id != productAttribute.ProductCoode)
            {
                return BadRequest();
            }

            _context.Entry(productAttribute).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductAttributeExists(id))
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

        // POST: api/ProductAttribute
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<ProductAttribute>> PostProductAttribute(ProductAttribute productAttribute)
        {
            _context.ProductAttribute.Add(productAttribute);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductAttribute", new { id = productAttribute.ProductCoode }, productAttribute);
        }

        // DELETE: api/ProductAttribute/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductAttribute>> DeleteProductAttribute(int id)
        {
            var productAttribute = await _context.ProductAttribute.FindAsync(id);
            if (productAttribute == null)
            {
                return NotFound();
            }

            _context.ProductAttribute.Remove(productAttribute);
            await _context.SaveChangesAsync();

            return productAttribute;
        }

        private bool ProductAttributeExists(int id)
        {
            return _context.ProductAttribute.Any(e => e.ProductCoode == id);
        }
    }
}
