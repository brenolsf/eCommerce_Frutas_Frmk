using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eCommerce_Frutas.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace eCommerce_Frutas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]    
    public class FrutasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FrutasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Frutas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Frutas>>> GetFrutas()
        {
            return await _context.Frutas.ToListAsync();
        }

        // GET: api/Frutas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Frutas>> GetFrutas(int id)
        {
            var frutas = await _context.Frutas.FindAsync(id);

            if (frutas == null)
            {
                return NotFound();
            }

            return frutas;
        }

        // PUT: api/Frutas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFrutas(int id, Frutas frutas)
        {
            if (id != frutas.FrutasId)
            {
                return BadRequest();
            }

            _context.Entry(frutas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FrutasExists(id))
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

        // POST: api/Frutas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Frutas>> PostFrutas(Frutas frutas)
        {
            _context.Frutas.Add(frutas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFrutas", new { id = frutas.FrutasId }, frutas);
        }

        // DELETE: api/Frutas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Frutas>> DeleteFrutas(int id)
        {
            var frutas = await _context.Frutas.FindAsync(id);
            if (frutas == null)
            {
                return NotFound();
            }

            _context.Frutas.Remove(frutas);
            await _context.SaveChangesAsync();

            return frutas;
        }

        private bool FrutasExists(int id)
        {
            return _context.Frutas.Any(e => e.FrutasId == id);
        }
    }
}
