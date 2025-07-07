using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiVigilancia.Data;
using ApiVigilancia.Models;

namespace ApiVigilancia.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResidentesController : ControllerBase
    {
        private readonly SistemaAccesoContext _context;

        public ResidentesController(SistemaAccesoContext context)
        {
            _context = context;
        }

        // GET: api/Residentes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Residentes>>> ObtenerTodos()
        {
            return await _context.Residentes.ToListAsync();
        }

        // GET: api/Residentes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Residentes>> ObtenerPorId(int id)
        {
            var residente = await _context.Residentes.FindAsync(id);

            if (residente == null)
                return NotFound(new { message = "Residente no encontrado" });

            return residente;
        }

        // POST: api/Residentes
        [HttpPost]
        public async Task<ActionResult<Residentes>> Crear(Residentes residente)
        {
            _context.Residentes.Add(residente);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(ObtenerPorId), new { id = residente.id_residente }, residente);
        }

        // PUT: api/Residentes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, Residentes residente)
        {
            if (id != residente.id_residente)
                return BadRequest();

            _context.Entry(residente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Residentes.Any(r => r.id_residente == id))
                    return NotFound(new { message = "Residente no encontrado" });
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/Residentes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var residente = await _context.Residentes.FindAsync(id);
            if (residente == null)
                return NotFound(new { message = "Residente no encontrado" });

            _context.Residentes.Remove(residente);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
