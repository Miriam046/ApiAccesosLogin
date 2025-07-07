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

        // ================================
        // GET: api/Invitados/porUsuario/5
        // Devuelve los invitados del residente asociado a un usuario
        // ================================
        [HttpGet("porUsuario/{id_usuario}")]
        public async Task<ActionResult<IEnumerable<Invitados>>> ObtenerInvitadosPorUsuario(int id_usuario)
        {
            // Buscar al usuario por su ID
            var usuario = await _context.UsuariosResidentes.FirstOrDefaultAsync(u => u.id_usuario == id_usuario);
            if (usuario == null)
            {
                return NotFound(new { message = "Usuario no encontrado" });
            }

            // Obtener el id_residente relacionado con ese usuario
            int idResidente = usuario.id_residente;

            // Buscar los invitados que pertenecen a ese residente
            var invitados = await _context.Invitados
                .Where(i => i.id_residente == idResidente)
                .ToListAsync();

            return invitados;
        }

        // ================================
        // POST: api/Invitados
        // Agrega un nuevo invitado (desde app Android, por ejemplo con código QR)
        // ================================
        [HttpPost]
        public async Task<ActionResult<Invitados>> AgregarInvitado([FromBody] Invitados invitado)
        {
            if (invitado == null)
            {
                return BadRequest(new { message = "Datos inválidos" });
            }

            // Validar que el residente exista
            var residente = await _context.Residentes.FindAsync(invitado.id_residente);
            if (residente == null)
            {
                return NotFound(new { message = "Residente no encontrado" });
            }

            // Estado inicial del invitado
            invitado.estado = "Activo";

            // Guardar en base de datos
            _context.Invitados.Add(invitado);
            await _context.SaveChangesAsync();

            // Retornar el nuevo invitado creado con su ID
            return CreatedAtAction(nameof(ObtenerInvitadoPorId), new { id = invitado.id_invitado }, invitado);
        }

        // ================================
        // GET: api/Invitados/5
        // Devuelve los datos de un invitado por su ID
        // ================================
        [HttpGet("{id}")]
        public async Task<ActionResult<Invitados>> ObtenerInvitadoPorId(int id)
        {
            var invitado = await _context.Invitados.FindAsync(id);
            if (invitado == null)
            {
                return NotFound(new { message = "Invitado no encontrado" });
            }
            return invitado;
        }

        // ================================
        // GET: api/Invitados/porCodigo/QR123456
        // Devuelve el invitado cuyo código coincida (por ejemplo, escaneado de QR)
        // ================================
        [HttpGet("porCodigo/{codigo}")]
        public async Task<ActionResult<Invitados>> ObtenerInvitadoPorCodigo(string codigo)
        {
            var invitado = await _context.Invitados
                .FirstOrDefaultAsync(i => i.codigo == codigo && i.estado == "Activo");

            if (invitado == null)
            {
                return NotFound(new { message = "Invitado no encontrado o no activo" });
            }

            return invitado;
        }
    }
}
