using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
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
    public class ArticuloController : ControllerBase
    {
        private readonly AppDBContext _context;
        private readonly IArticuloRepository _articuloRepository;
        public ArticuloController(AppDBContext context, IArticuloRepository articuloRepository)
        {
            _context = context;
            _articuloRepository = articuloRepository;
        }

        // GET: api/ArticuloModelos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArticuloModelo>>> GetArticulos()
        {
            try
            {
                var result = await _articuloRepository.GetAll();
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/ArticuloModelos/5
        [Route("{id:Guid}")]
        [HttpGet]
        public async Task<ActionResult<ArticuloModelo>> GetArticuloModelo(Guid id)
        {
            var articulo = await _articuloRepository.GetOne(id);

            if (articulo == null)
            {
                return NotFound();
            }

            return articulo;
        }

        // PUT: api/ArticuloModelos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
       
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArticuloModelo(Guid id, ArticuloModelo articuloModelo)
        {
            if (id != articuloModelo.Id)
            {
                return BadRequest();
            }

            _context.Entry(articuloModelo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticuloModeloExists(id))
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

        // POST: api/ArticuloModelos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ArticuloModelo>> PostArticuloModelo(ArticuloModelo articulo)
        {
            await _articuloRepository.Add(articulo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArticuloModelo", new { id = articulo.Id }, articulo);
        }

        // DELETE: api/ArticuloModelos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<object>> DeleteArticuloModelo(Guid id)
        {
            var result = await _articuloRepository.Delete(id);
            await _context.SaveChangesAsync();

            return Ok(new { mensaje = result });
        }

        private bool ArticuloModeloExists(Guid id)
        {
            return _context.Articulos.Any(e => e.Id == id);
        }
    }
}
