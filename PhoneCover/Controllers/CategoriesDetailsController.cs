using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhoneCover.Models;

namespace PhoneCover.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesDetailsController : ControllerBase
    {
        private readonly CategoriesContext _context;

        public CategoriesDetailsController(CategoriesContext context)
        {
            _context = context;
        }

        // GET: api/CategoriesDetails
        [HttpGet]
        public IEnumerable<CategoriesDetails> Getcategories()
        {
            return _context.categories;
        }

        // GET: api/CategoriesDetails/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoriesDetails([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categoriesDetails = await _context.categories.FindAsync(id);

            if (categoriesDetails == null)
            {
                return NotFound();
            }

            return Ok(categoriesDetails);
        }

        // PUT: api/CategoriesDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoriesDetails([FromRoute] int id, [FromBody] CategoriesDetails categoriesDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != categoriesDetails.id)
            {
                return BadRequest();
            }

            _context.Entry(categoriesDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriesDetailsExists(id))
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

        // POST: api/CategoriesDetails
        [HttpPost]
        public async Task<IActionResult> PostCategoriesDetails([FromBody] CategoriesDetails categoriesDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.categories.Add(categoriesDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategoriesDetails", new { id = categoriesDetails.id }, categoriesDetails);
        }

        // DELETE: api/CategoriesDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoriesDetails([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categoriesDetails = await _context.categories.FindAsync(id);
            if (categoriesDetails == null)
            {
                return NotFound();
            }

            _context.categories.Remove(categoriesDetails);
            await _context.SaveChangesAsync();

            return Ok(categoriesDetails);
        }

        private bool CategoriesDetailsExists(int id)
        {
            return _context.categories.Any(e => e.id == id);
        }
    }
}