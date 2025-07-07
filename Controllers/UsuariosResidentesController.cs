
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
        private readonly SistemaAccesoContext _context;

        public UsuariosResidentesController(SistemaAccesoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuariosResidentes>>> GetUsuarios()
        {
            return await _context.UsuariosResidentes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuariosResidentes>> GetUsuario(int id)
        {
            var usuario = await _context.UsuariosResidentes.FindAsync(id);
            if (usuario == null) return NotFound();
            return usuario;
        }

        [HttpPost]
        public async Task<ActionResult<UsuariosResidentes>> PostUsuario(UsuariosResidentes usuario)
        {
            _context.UsuariosResidentes.Add(usuario);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.id_usuario }, usuario);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, UsuariosResidentes usuario)
        {
            if (id != usuario.id_usuario) return BadRequest();
            _context.Entry(usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _context.UsuariosResidentes.FindAsync(id);
            if (usuario == null) return NotFound();
            _context.UsuariosResidentes.Remove(usuario);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // 🔐 LOGIN
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.usuarioNombre) || string.IsNullOrWhiteSpace(request.password))
            {
                return BadRequest(new { message = "Faltan datos" });
            }

            var usuario = await _context.UsuariosResidentes
                .FirstOrDefaultAsync(u =>
                    u.correo == request.usuarioNombre &&
                    u.contraseña == request.password);

            if (usuario == null)
            {
                return Unauthorized(new { message = "Credenciales inválidas" });
            }

            return Ok(new
            {
                message = "Inicio de sesión exitoso",
                id_usuario = usuario.id_usuario,
                nombre = usuario.correo,
                contra = usuario.contraseña
            });
        }
    }
}