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
    public class ClienteController : ControllerBase
    {
        private readonly AppDBContext _context;

        public ClienteController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/Cliente
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteModelo>>> GetClientes()
        {
            return await _context.Clientes.ToListAsync();
        }

        // GET: api/Cliente/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteModelo>> GetClienteModelo(Guid id)
        {
            var clienteModelo = await _context.Clientes.FindAsync(id);

            if (clienteModelo == null)
            {
                return NotFound();
            }

            return clienteModelo;
        }

        // PUT: api/Cliente/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClienteModelo(Guid id, ClienteModelo clienteModelo)
        {
            if (id != clienteModelo.Id)
            {
                return BadRequest();
            }

            _context.Entry(clienteModelo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteModeloExists(id))
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

        // POST: api/Cliente
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ClienteModelo>> PostClienteModelo(ClienteModelo clienteModelo)
        {
            _context.Clientes.Add(clienteModelo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClienteModelo", new { id = clienteModelo.Id }, clienteModelo);
        }

        // DELETE: api/Cliente/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ClienteModelo>> DeleteClienteModelo(Guid id)
        {
            var clienteModelo = await _context.Clientes.FindAsync(id);
            if (clienteModelo == null)
            {
                return NotFound();
            }

            _context.Clientes.Remove(clienteModelo);
            await _context.SaveChangesAsync();

            return clienteModelo;
        }

        private bool ClienteModeloExists(Guid id)
        {
            return _context.Clientes.Any(e => e.Id == id);
        }
    }
}
