using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MLGBussinesLogic.interfaces;
using MLGDataAccessLayer;
using MLGDataAccessLayer.models;

namespace MLGApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiendaController : ControllerBase
    {
        private readonly AppDBContext _context;
        private readonly ITiendaRepository _tiendaRepository;

        public TiendaController(AppDBContext context, ITiendaRepository tiendaRepository)
        {
            _context = context;
            _tiendaRepository = tiendaRepository;
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
            try
            {
                await _tiendaRepository.Update(id, tiendaModelo);

                return Ok(new { mensaje = "Tienda modificada exitosamente" });
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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
