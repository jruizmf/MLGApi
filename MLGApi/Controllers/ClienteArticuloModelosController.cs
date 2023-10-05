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
    public class ClienteArticuloController : ControllerBase
    {
        private readonly AppDBContext _context;

        public ClienteArticuloController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/ClienteArticuloModelos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteArticuloModelo>>> GetClienteArticulos()
        {
            return await _context.ClienteArticulos.ToListAsync();
        }

        // GET: api/ClienteArticuloModelos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteArticuloModelo>> GetClienteArticuloModelo(Guid id)
        {
            var clienteArticuloModelo = await _context.ClienteArticulos.FindAsync(id);

            if (clienteArticuloModelo == null)
            {
                return NotFound();
            }

            return clienteArticuloModelo;
        }

        // PUT: api/ClienteArticuloModelos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClienteArticuloModelo(Guid id, ClienteArticuloModelo clienteArticuloModelo)
        {
            if (id != clienteArticuloModelo.Id)
            {
                return BadRequest();
            }

            _context.Entry(clienteArticuloModelo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteArticuloModeloExists(id))
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

        // POST: api/ClienteArticuloModelos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ClienteArticuloModelo>> PostClienteArticuloModelo(ClienteArticuloModelo clienteArticuloModelo)
        {
            _context.ClienteArticulos.Add(clienteArticuloModelo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClienteArticuloModelo", new { id = clienteArticuloModelo.Id }, clienteArticuloModelo);
        }

        // DELETE: api/ClienteArticuloModelos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ClienteArticuloModelo>> DeleteClienteArticuloModelo(Guid id)
        {
            var clienteArticuloModelo = await _context.ClienteArticulos.FindAsync(id);
            if (clienteArticuloModelo == null)
            {
                return NotFound();
            }

            _context.ClienteArticulos.Remove(clienteArticuloModelo);
            await _context.SaveChangesAsync();

            return clienteArticuloModelo;
        }

        private bool ClienteArticuloModeloExists(Guid id)
        {
            return _context.ClienteArticulos.Any(e => e.Id == id);
        }
    }
}
