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
    public class NewsLetterDetailsController : ControllerBase
    {
        private readonly NewsLetterContext _context;

        public NewsLetterDetailsController(NewsLetterContext context)
        {
            _context = context;
        }

        // GET: api/NewsLetterDetails
        [HttpGet]
        public IEnumerable<NewsLetterDetails> GetnewsLetter()
        {
            return _context.newsLetter;
        }

        // GET: api/NewsLetterDetails/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNewsLetterDetails([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newsLetterDetails = await _context.newsLetter.FindAsync(id);

            if (newsLetterDetails == null)
            {
                return NotFound();
            }

            return Ok(newsLetterDetails);
        }

        // PUT: api/NewsLetterDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNewsLetterDetails([FromRoute] int id, [FromBody] NewsLetterDetails newsLetterDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != newsLetterDetails.id)
            {
                return BadRequest();
            }

            _context.Entry(newsLetterDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewsLetterDetailsExists(id))
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

        // POST: api/NewsLetterDetails
        [HttpPost]
        public async Task<IActionResult> PostNewsLetterDetails([FromBody] NewsLetterDetails newsLetterDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.newsLetter.Add(newsLetterDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNewsLetterDetails", new { id = newsLetterDetails.id }, newsLetterDetails);
        }

        // DELETE: api/NewsLetterDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNewsLetterDetails([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newsLetterDetails = await _context.newsLetter.FindAsync(id);
            if (newsLetterDetails == null)
            {
                return NotFound();
            }

            _context.newsLetter.Remove(newsLetterDetails);
            await _context.SaveChangesAsync();

            return Ok(newsLetterDetails);
        }

        private bool NewsLetterDetailsExists(int id)
        {
            return _context.newsLetter.Any(e => e.id == id);
        }
    }
}