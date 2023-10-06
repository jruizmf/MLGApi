using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MLGBussinesLogic;
using MLGBussinesLogic.models.dto;
using MLGBussinessLogic.interfaces;
using MLGBussinessLogic.services;
using MLGDataAccessLayer;
using MLGDataAccessLayer.models;

namespace MLGApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteArticuloController : ControllerBase
    {
        private readonly AppDBContext _context;
        private readonly IClienteArticuloRepository _clienteArticuloRepository;

        public ClienteArticuloController(AppDBContext context, IClienteArticuloRepository clienteArticuloRepository)
        {
            _context = context;
            _clienteArticuloRepository = clienteArticuloRepository;
        }

        // GET: api/ClienteArticuloModelos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MLGDataAccessLayer.models.ClienteArticuloModelo>>> GetClienteArticulos()
        {
            try {
                var result = await _clienteArticuloRepository.GetAll();

                return result;
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("Usuario/{id}")]
        [HttpGet]
        public async Task<ActionResult> GetClienteArticuloByUser(Guid id)
        {

            try
            {
                var clienteArticulo = await _clienteArticuloRepository.GetByUser(id);

                if (clienteArticulo == null)
                {
                    return NotFound();
                }

                return Ok(clienteArticulo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/ClienteArticuloModelos/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetClienteArticuloModelo(Guid id)
        {
            
            try
            {
                var clienteArticulo = await _clienteArticuloRepository.GetOne(id);

                if (clienteArticulo == null)
                {
                    return NotFound();
                }

                return Ok(clienteArticulo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/ClienteArticuloModelos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClienteArticuloModelo(Guid id, MLGDataAccessLayer.models.ClienteArticuloModelo clienteArticulo)
        {
            try
            {
                await _clienteArticuloRepository.Update(id, clienteArticulo);

                return Ok("Articulo modificado exitosamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/ClienteArticuloModelos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ClienteArticuloDto>> PostClienteArticuloModelo(ClienteArticuloDto clienteArticuloModelo)
        {
            try
            {
                await  _clienteArticuloRepository.Add(clienteArticuloModelo);

                return CreatedAtAction("GetClienteArticuloModelo", new { id = clienteArticuloModelo.Id }, clienteArticuloModelo);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/ClienteArticuloModelos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ClienteArticuloModelo>> DeleteClienteArticuloModelo(Guid id)
        {
            try
            {
                await _clienteArticuloRepository.Delete(id);

                return Ok("Articulo Eliminado exitosamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
