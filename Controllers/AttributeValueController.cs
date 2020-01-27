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
    public class AttributeValueController : ControllerBase
    {
        private readonly RentlessDBContext _context;

        public AttributeValueController(RentlessDBContext context)
        {
            _context = context;
        }

        // GET: api/AttributeValue
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AttributeValue>>> GetAttributeValue()
        {
            return await _context.AttributeValue
                        .ToListAsync();
        }

        // GET: api/AttributeValue/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AttributeValue>> GetAttributeValue(string id)
        {
            var attributeValue = await _context.AttributeValue.FindAsync(id);

            if (attributeValue == null)
            {
                return NotFound();
            }

            return attributeValue;
        }

        // PUT: api/AttributeValue/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAttributeValue(string id, AttributeValue attributeValue)
        {
            if (id != attributeValue.AttributeTypeCode)
            {
                return BadRequest();
            }

            _context.Entry(attributeValue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttributeValueExists(id))
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

        // POST: api/AttributeValue
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<AttributeValue>> PostAttributeValue(AttributeValue attributeValue)
        {
            _context.AttributeValue.Add(attributeValue);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AttributeValueExists(attributeValue.AttributeTypeCode))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAttributeValue", new { id = attributeValue.AttributeTypeCode }, attributeValue);
        }



        //BULK UPDATE
        [Route("api/[controller]/[action]")]
        [HttpPost]
        public async Task<ActionResult<AttributeValue>> Bulk(List<AttributeValue> attributeValues)
        {
            foreach(AttributeValue attributeValue in attributeValues )
            {
                _context.AttributeValue.Add(attributeValue);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    if (AttributeValueExists(attributeValue.AttributeTypeCode))
                    {
                        return Conflict();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return Ok("Inserted");
        }

        // DELETE: api/AttributeValue/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AttributeValue>> DeleteAttributeValue(string id)
        {
            var attributeValue = await _context.AttributeValue.FindAsync(id);
            if (attributeValue == null)
            {
                return NotFound();
            }

            _context.AttributeValue.Remove(attributeValue);
            await _context.SaveChangesAsync();

            return attributeValue;
        }

        private bool AttributeValueExists(string id)
        {
            return _context.AttributeValue.Any(e => e.AttributeTypeCode == id);
        }
    }
}
