using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MLGBussinesLogic.interfaces;
using MLGBussinesLogic.models.dto;
using MLGBussinesLogic.services;
using MLGBussinessLogic.interfaces;
using MLGBussinessLogic.services;
using MLGDataAccessLayer;
using MLGDataAccessLayer.models;

namespace MLGApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly AppDBContext _context;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IClienteRepository _clienteRepository;

        public UsuarioController(AppDBContext context, IUsuarioRepository userRepository, IClienteRepository clienteRepository)
        {
            _context = context;
            _usuarioRepository = userRepository ??
                throw new ArgumentNullException(nameof(userRepository)); ;
            _clienteRepository = clienteRepository;
        }

        // GET: api/Usuario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioModelo>>> GetUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        // GET: api/Usuario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModelo>> GetUsuarioModelo(Guid id)
        {
            var usuarioModelo = await _context.Usuarios.FindAsync(id);

            if (usuarioModelo == null)
            {
                return NotFound();
            }

            return usuarioModelo;
        }

        // PUT: api/Usuario/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuarioModelo(Guid id, MLGBussinesLogic.models.UsuarioModelo usuarioModelo)
        {
            
            if (id != usuarioModelo.Id)
            {
                return BadRequest();
            }

            try
            {
                var result = await _usuarioRepository.Update(id, usuarioModelo);
                return Ok(new { message = result });
            }
            catch (DbUpdateConcurrencyException)
            {
                return NoContent();
            }
        }

        // POST: api/Usuario
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UsuarioModelo>> PostUsuarioModelo(MLGBussinesLogic.models.UsuarioModelo usuario)
        {
            try
            {
                var usuarioId = await _usuarioRepository.Add(usuario);

                return CreatedAtAction("GetUsuarioModelo", new { id = usuarioId }, usuario);
            } 
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // DELETE: api/Usuario/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteUsuarioModelo(Guid id)
        {
            try
            {
                var result = await _usuarioRepository.Delete(id);
                return Ok(new { message = result });
            } catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
