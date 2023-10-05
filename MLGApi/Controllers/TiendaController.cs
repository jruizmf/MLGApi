using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MLGDataAccessLayer;
using MLGDataAccessLayer.models;

namespace MLGApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiendaController : ControllerBase
    {
        private readonly AppDBContext _context;

        public TiendaController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/Tienda
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TiendaModelo>>> GetTiendas()
        {
            return await _context.Tiendas.ToListAsync();
        }

        // GET: api/Tienda/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TiendaModelo>> GetTiendaModelo(Guid id)
        {
            var tiendaModelo = await _context.Tiendas.FindAsync(id);

            if (tiendaModelo == null)
            {
                return NotFound();
            }

            return tiendaModelo;
        }

        // PUT: api/Tienda/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTiendaModelo(Guid id, TiendaModelo tiendaModelo)
        {
            if (id != tiendaModelo.Id)
            {
                return BadRequest();
            }

            _context.Entry(tiendaModelo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TiendaModeloExists(id))
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

        // POST: api/Tienda
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TiendaModelo>> PostTiendaModelo(TiendaModelo tiendaModelo)
        {
            _context.Tiendas.Add(tiendaModelo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTiendaModelo", new { id = tiendaModelo.Id }, tiendaModelo);
        }

        // DELETE: api/Tienda/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TiendaModelo>> DeleteTiendaModelo(Guid id)
        {
            var tiendaModelo = await _context.Tiendas.FindAsync(id);
            if (tiendaModelo == null)
            {
                return NotFound();
            }

            _context.Tiendas.Remove(tiendaModelo);
            await _context.SaveChangesAsync();

            return tiendaModelo;
        }

        private bool TiendaModeloExists(Guid id)
        {
            return _context.Tiendas.Any(e => e.Id == id);
        }
    }
}
