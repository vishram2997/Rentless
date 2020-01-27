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
    public class AttributeTypeController : ControllerBase
    {
        private readonly RentlessDBContext _context;

        public AttributeTypeController(RentlessDBContext context)
        {
            _context = context;
        }

        // GET: api/AttributeType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AttributeType>>> GetAttributeType()
        {
            return await _context.AttributeType
                        .Include(t => t.values)
                        
                        .ToListAsync();
        }

        // GET: api/AttributeType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AttributeType>> GetAttributeType(string id)
        {
            var attributeType = await _context.AttributeType.FindAsync(id);

            if (attributeType == null)
            {
                return NotFound();
            }

            return attributeType;
        }

        // PUT: api/AttributeType/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAttributeType(string id, AttributeType attributeType)
        {
            if (id != attributeType.Code)
            {
                return BadRequest();
            }

            _context.Entry(attributeType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttributeTypeExists(id))
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

        // POST: api/AttributeType
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<AttributeType>> PostAttributeType(AttributeType attributeType)
        {
            _context.AttributeType.Add(attributeType);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AttributeTypeExists(attributeType.Code))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAttributeType", new { id = attributeType.Code }, attributeType);
        }


        //Bulk update 

        [Route("api/[controller]/[action]")]
        [HttpPost]
        public async Task<ActionResult<AttributeType>> Bulk(List <AttributeType> attributeTypes)
        {

            foreach(AttributeType attributeType in attributeTypes)
            {
                _context.AttributeType.Add(attributeType);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    if (AttributeTypeExists(attributeType.Code))
                    {
                        return Conflict();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return Ok("Inserted All")
        }

        // DELETE: api/AttributeType/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AttributeType>> DeleteAttributeType(string id)
        {
            var attributeType = await _context.AttributeType.FindAsync(id);
            if (attributeType == null)
            {
                return NotFound();
            }

            _context.AttributeType.Remove(attributeType);
            await _context.SaveChangesAsync();

            return attributeType;
        }

        private bool AttributeTypeExists(string id)
        {
            return _context.AttributeType.Any(e => e.Code == id);
        }
    }
}
