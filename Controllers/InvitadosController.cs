using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiVigilancia.Data;
using ApiVigilancia.Models;

namespace ApiVigilancia.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvitadosController : ControllerBase
    {
        private readonly SistemaAccesoContext _context;

        public InvitadosController(SistemaAccesoContext context)
        {
            _context = context;
        }

        // GET: api/Invitados/porUsuario/5
        [HttpGet("porUsuario/{id_usuario}")]
        public async Task<ActionResult<IEnumerable<Invitados>>> ObtenerInvitadosPorUsuario(int id_usuario)
        {
            // Buscar al usuario
            var usuario = await _context.UsuariosResidentes.FirstOrDefaultAsync(u => u.id_usuario == id_usuario);
            if (usuario == null)
            {
                return NotFound(new { message = "Usuario no encontrado" });
            }

            // Obtener el id_residente relacionado
            int idResidente = usuario.id_residente;

            // Buscar los invitados con ese id_residente
            var invitados = await _context.Invitados
                .Where(i => i.id_residente == idResidente)
                .ToListAsync();

            return invitados;
        }
    }
}


