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
    public class ProductDetailsController : ControllerBase
    {
        private readonly ProductContext _context;

        public ProductDetailsController(ProductContext context)
        {
            _context = context;
        }

        // GET: api/ProductDetails
        [HttpGet]
        public IEnumerable<ProductDetails> Getusers()
        {
            return _context.product;
        }

        // GET: api/ProductDetails/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetails([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productDetails = await _context.product.FindAsync(id);

            if (productDetails == null)
            {
                return NotFound();
            }

            return Ok(productDetails);
        }

        // PUT: api/ProductDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductDetails([FromRoute] int id, [FromBody] ProductDetails productDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productDetails.id)
            {
                return BadRequest();
            }

            _context.Entry(productDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductDetailsExists(id))
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

        // POST: api/ProductDetails
        [HttpPost]
        public async Task<IActionResult> PostProductDetails([FromBody] ProductDetails productDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.product.Add(productDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductDetails", new { id = productDetails.id }, productDetails);
        }

        // DELETE: api/ProductDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductDetails([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productDetails = await _context.product.FindAsync(id);
            if (productDetails == null)
            {
                return NotFound();
            }

            _context.product.Remove(productDetails);
            await _context.SaveChangesAsync();

            return Ok(productDetails);
        }

        private bool ProductDetailsExists(int id)
        {
            return _context.product.Any(e => e.id == id);
        }
    }
}