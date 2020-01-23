using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rentless.Models;
using NetTopologySuite.Geometries;
using Microsoft.AspNet.OData;
namespace Rentless.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustListingController : ControllerBase
    {
        private readonly RentlessDBContext _context;

        public CustListingController(RentlessDBContext context)
        {
            _context = context;
        }

        // GET: api/CustListing
        [EnableQuery]
        [HttpGet]
        public  ActionResult<IEnumerable<CustListing>> GetCustListing()
        {
             var listing =  _context  
                .CustListing 
                .Select(t => new {t.CustomerId, t.ProductCode, t.Latitude, t.Longtude })  
                .ToList(); 

            return Ok(listing);
        }



        // GET: api/CustListing/5
        [HttpGet("{id}")]
        public  ActionResult<CustListing> GetCustListing(string custId, int prod)
        {
            var custListing =  _context.CustListing.Select(t => new {t.CustomerId, t.ProductCode, t.Latitude, t.Longtude })
                            .Where(x=> x.CustomerId == custId && x.ProductCode == prod).First();

          
            return Ok(custListing);
        }

        // PUT: api/CustListing/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustListing(string id, CustListing custListing)
        {
            if (id != custListing.CustomerId)
            {
                return BadRequest();
            }

            _context.Entry(custListing).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (CustListingExists(custListing.CustomerId, custListing.ProductCode))
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

        // POST: api/CustListing
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<CustListing>> PostCustListing(CustListing custListing)
        {
            
            var geometryFactory = NetTopologySuite.NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326); 

            Point point = geometryFactory.CreatePoint(new Coordinate(custListing.Latitude, custListing.Longtude));
            
            custListing.Location = point;

            _context.CustListing.Add(custListing);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CustListingExists(custListing.CustomerId, custListing.ProductCode))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCustListing", new { custId = custListing.CustomerId, prod = custListing.ProductCode  }, custListing);
        }

        // DELETE: api/CustListing/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CustListing>> DeleteCustListing(string id)
        {
            var custListing = await _context.CustListing.FindAsync(id);
            if (custListing == null)
            {
                return NotFound();
            }

            _context.CustListing.Remove(custListing);
            await _context.SaveChangesAsync();

            return custListing;
        }

        private bool CustListingExists(string cust, int prod)
        {
            return _context.CustListing.Any(e => e.CustomerId == cust && e.ProductCode== prod);
        }
    }
}
