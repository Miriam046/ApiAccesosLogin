using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiVigilancia.Data;
using ApiVigilancia.Models;

namespace ApiVigilancia.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosResidentesController : ControllerBase
    {
        private readonly SistemaAccesosContext _context;

        public UsuariosResidentesController(SistemaAccesosContext context)
        {
            _context = context;
        }

        // GET: api/UsuariosResidentes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuariosResidentes>>> GetUsuarios()
        {
            return await _context.UsuariosResidentes.ToListAsync();
        }

        // GET: api/UsuariosResidentes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuariosResidentes>> GetUsuario(int id)
        {
            var usuario = await _context.UsuariosResidentes.FindAsync(id);
            if (usuario == null) return NotFound();
            return usuario;
        }

        // POST: api/UsuariosResidentes
        [HttpPost]
        public async Task<ActionResult<UsuariosResidentes>> PostUsuario(UsuariosResidentes usuario)
        {
            _context.UsuariosResidentes.Add(usuario);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.id_usuario }, usuario);
        }

        // PUT: api/UsuariosResidentes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, UsuariosResidentes usuario)
        {
            if (id != usuario.id_usuario) return BadRequest();
            _context.Entry(usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/UsuariosResidentes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _context.UsuariosResidentes.FindAsync(id);
            if (usuario == null) return NotFound();
            _context.UsuariosResidentes.Remove(usuario);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}

