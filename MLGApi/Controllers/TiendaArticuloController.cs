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
    public class TiendaArticuloController : ControllerBase
    {
        private readonly AppDBContext _context;

        public TiendaArticuloController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/TiendaArticulo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TiendaArticuloModelo>>> GetTiendaArticulos()
        {
            return await _context.TiendaArticulos.ToListAsync();
        }

        // GET: api/TiendaArticulo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TiendaArticuloModelo>> GetTiendaArticuloModelo(Guid id)
        {
            var tiendaArticuloModelo = await _context.TiendaArticulos.FindAsync(id);

            if (tiendaArticuloModelo == null)
            {
                return NotFound();
            }

            return tiendaArticuloModelo;
        }

        // PUT: api/TiendaArticulo/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTiendaArticuloModelo(Guid id, TiendaArticuloModelo tiendaArticuloModelo)
        {
            if (id != tiendaArticuloModelo.Id)
            {
                return BadRequest();
            }

            _context.Entry(tiendaArticuloModelo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TiendaArticuloModeloExists(id))
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

        // POST: api/TiendaArticulo
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TiendaArticuloModelo>> PostTiendaArticuloModelo(TiendaArticuloModelo tiendaArticuloModelo)
        {
            _context.TiendaArticulos.Add(tiendaArticuloModelo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTiendaArticuloModelo", new { id = tiendaArticuloModelo.Id }, tiendaArticuloModelo);
        }

        // DELETE: api/TiendaArticulo/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TiendaArticuloModelo>> DeleteTiendaArticuloModelo(Guid id)
        {
            var tiendaArticuloModelo = await _context.TiendaArticulos.FindAsync(id);
            if (tiendaArticuloModelo == null)
            {
                return NotFound();
            }

            _context.TiendaArticulos.Remove(tiendaArticuloModelo);
            await _context.SaveChangesAsync();

            return tiendaArticuloModelo;
        }

        private bool TiendaArticuloModeloExists(Guid id)
        {
            return _context.TiendaArticulos.Any(e => e.Id == id);
        }
    }
}
