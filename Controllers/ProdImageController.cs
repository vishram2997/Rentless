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
    public class ProdImageController : ControllerBase
    {
        private readonly RentlessDBContext _context;

        public ProdImageController(RentlessDBContext context)
        {
            _context = context;
        }

        // GET: api/ProdImage
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdImage>>> GetProdImage()
        {
            return await _context.ProdImage.ToListAsync();
        }

        // GET: api/ProdImage/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProdImage>> GetProdImage(int id)
        {
            var prodImage = await _context.ProdImage.FindAsync(id);

            if (prodImage == null)
            {
                return NotFound();
            }

            return prodImage;
        }

        // PUT: api/ProdImage/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProdImage(int id, ProdImage prodImage)
        {
            if (id != prodImage.Id)
            {
                return BadRequest();
            }

            _context.Entry(prodImage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdImageExists(id))
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


        [Route("[action]")]
        [HttpPost]
        public async Task<ActionResult<ProdImage>> Bulk(List <ProdImage> prodImages)
        {

            foreach(ProdImage prodImage in prodImages)
            {
                _context.ProdImage.Add(prodImage);
                await _context.SaveChangesAsync();
            }
            return Ok("Created");
        }

        // POST: api/ProdImage
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<ProdImage>> PostProdImage(ProdImage prodImage)
        {
            _context.ProdImage.Add(prodImage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProdImage", new { id = prodImage.Id }, prodImage);
        }

        // DELETE: api/ProdImage/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProdImage>> DeleteProdImage(int id)
        {
            var prodImage = await _context.ProdImage.FindAsync(id);
            if (prodImage == null)
            {
                return NotFound();
            }

            _context.ProdImage.Remove(prodImage);
            await _context.SaveChangesAsync();

            return prodImage;
        }

        private bool ProdImageExists(int id)
        {
            return _context.ProdImage.Any(e => e.Id == id);
        }
    }
}
