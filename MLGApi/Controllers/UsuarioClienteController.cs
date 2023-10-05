using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MLGBussinesLogic.models.dto;
using MLGBussinessLogic.interfaces;
using MLGDataAccessLayer;
using MLGDataAccessLayer.models;

namespace MLGApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioClienteController : ControllerBase
    {
        private readonly IUsuarioClienteRepository _usuarioClienteRepository;

        public UsuarioClienteController(AppDBContext context, IUsuarioClienteRepository usuarioClienteRepository)
        {
            _usuarioClienteRepository = usuarioClienteRepository;
        }

        // GET: api/UsuarioCliente
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioClienteModelo>>> GetUsuarioClientes()
        {
            return await _usuarioClienteRepository.GetAll();
        }

        // GET: api/UsuarioCliente/5
        [Route("{id:Guid}")]
        [HttpGet]
        public async Task<ActionResult<UsuarioClienteModelo>> GetUsuarioClienteModelo(Guid id)
        {
            try
            {
                var usuarioCliente = await _usuarioClienteRepository.GetOne(id);

                return Ok(usuarioCliente);
            } catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // PUT: api/UsuarioCliente/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<object>> PutUsuarioClienteModelo(Guid id, UsuarioDto usuarioClienteModelo)
        {
            try
            {
                var result = await _usuarioClienteRepository.Update(id, usuarioClienteModelo) ;
                return Ok(new {message = result }) ;
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        // POST: api/UsuarioCliente
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UsuarioClienteModelo>> PostUsuarioClienteModelo(UsuarioDto usuarioClienteModelo)
        {
            try
            {
                await _usuarioClienteRepository.Add(usuarioClienteModelo);
                return CreatedAtAction("GetUsuarioClienteModelo", new { id = usuarioClienteModelo.Id }, usuarioClienteModelo);
            } catch(Exception ex)
            {
                return BadRequest(ex);
            }
            
        }

        // DELETE: api/UsuarioCliente/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteUsuarioClienteModelo(Guid id)
        {
            try
            {
                var result = await _usuarioClienteRepository.Delete(id);
                return Ok(new { message = result });
            } 
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            
        }
    }
}
