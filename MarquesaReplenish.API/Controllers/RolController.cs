using MarquesaReplenish.API.Data;
using MarquesaReplenish.API.Helpers;
using MarquesaReplenish.Manager.DTO;
using MarquesaReplenish.Manager.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarquesaReplenish.API.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("/api/roles")]
    public class RolController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public RolController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet("GetRoles")]
        public async Task<ActionResult> GetRoles([FromQuery] PaginationDTO model)
        {
            string Obtener = ObtenerTokeJwt();
            var Roless = _dataContext.TblRol.AsQueryable();
            //var roles = await _dataContext.TblRol.ToListAsync();
            var roles = await Roless.Paginate(model).ToListAsync();
            if (roles is null)
            {
                return NotFound();
            }

            return Ok(roles);
        }

        private string ObtenerTokeJwt()
        {
            try
            {
                string token = HttpContext.Request.Headers["Authorization"]!;



                if (!string.IsNullOrEmpty(token) && token.StartsWith("Bearer "))
                {
                    token = token.Substring("Bearer ".Length).Trim();
                }



                return token!;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        [HttpGet("GetRol")]
        public async Task<ActionResult> GetRol(int Id)
        {
            tblRol rol = await _dataContext.TblRol.FirstOrDefaultAsync(u => u.Id == Id);
            if (rol is null)
            {
                return NotFound();
            }

            return Ok(rol);
        }

        [HttpGet("GetRolCodigo")]
        public async Task<ActionResult> GetRol(string Id)
        {
            tblRol rol = await _dataContext.TblRol.FirstOrDefaultAsync(u => u.Id == Convert.ToInt32(Id));
            if (rol is null)
            {
                return NotFound();
            }

            return Ok(rol);
        }

        [HttpGet("GetUserUserName")]
        public async Task<ActionResult> GetUserUserName(string UserName)
        {
            tblUsuario Usuario = await _dataContext.TblUsuario.FirstOrDefaultAsync(u => u.Codigo == UserName);
            if (Usuario is null)
            {
                return NotFound();
            }

            return Ok(Usuario);
        }

        [HttpGet("GetRolNombre")]
        public async Task<ActionResult> GetRolNombre(string nombre)
        {
            var rol = await _dataContext.TblRol.FirstOrDefaultAsync(u => u.Nombre == nombre);
            if (rol is null)
            {
                return NotFound();
            }

            return Ok(rol);
        }



        [HttpPost("CrearRol")]
        public async Task<ActionResult> CreateRol(tblRol rol)
        {

            try
            {
                rol.Sincronizar = true;
                _dataContext.Add(rol);
                await _dataContext.SaveChangesAsync();
                return Ok(rol);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un rol con el mismo nombre.");
                }
                else
                {
                    return BadRequest(dbUpdateException.InnerException.Message);
                }
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPost("UpdateRol")]
        public async Task<ActionResult> UpdateRol(tblRol rol)
        {

            try
            {
                _dataContext.Update(rol);
                await _dataContext.SaveChangesAsync();
                return Ok(rol);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un rol con el mismo nombre.");
                }
                else
                {
                    return BadRequest(dbUpdateException.InnerException.Message);
                }
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPost("UpdateRolEstado")]
        public async Task<ActionResult> UpdateRolEstado(int idRol)
        {
            var RolBD = await _dataContext.TblRol.FindAsync(idRol);

            RolBD.Estado = !RolBD.Estado;
            try
            {
                _dataContext.Update(RolBD);
                await _dataContext.SaveChangesAsync();
                return Ok(RolBD);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un rol con el mismo nombre.");
                }
                else
                {
                    return BadRequest(dbUpdateException.InnerException.Message);
                }
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPost("CrearRolPermiso")]
        public async Task<ActionResult> CrearRolPermiso(tblDetalleRolPermisos RolPermiso)
        {

            try
            {
                _dataContext.Add(RolPermiso);
                await _dataContext.SaveChangesAsync();
                return Ok(RolPermiso);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un Detalle Permiso-rol con este usuario.");
                }
                else
                {
                    return BadRequest(dbUpdateException.InnerException.Message);
                }
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpGet("GetRolPermiso")]
        public async Task<ActionResult> GetRolPermiso(int id_permiso, int id_rol)
        {
            var resultado = await _dataContext.tblDetalleRolPermisos
                            .Where(u => u.Id_Permisos == id_permiso && u.Id_Rol == id_rol)
                            .FirstOrDefaultAsync();
            if (resultado is null)
            {
                return NotFound();
            }

            return Ok(resultado);
        }
        [HttpPost("EliminarRolPermiso")]
        public async Task<ActionResult> EliminarRolPermiso(tblDetalleRolPermisos RolPermiso)
        {

            try
            {
                _dataContext.Remove(RolPermiso);
                await _dataContext.SaveChangesAsync();
                return Ok(RolPermiso);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un Detalle Permiso-rol con este usuario.");
                }
                else
                {
                    return BadRequest(dbUpdateException.InnerException.Message);
                }
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }


        [HttpPost("CrearRolCliente")]
        public async Task<ActionResult> CrearRolCliente(tblDetalleRolCliente RolCliente)
        {
            _dataContext.Add(RolCliente);
            try
            {
                await _dataContext.SaveChangesAsync();
                return Ok(RolCliente);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un Detalle Cliente-rol con este usuario.");
                }
                else
                {
                    return BadRequest(dbUpdateException.InnerException.Message);
                }
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpGet("GetRolCliente")]
        public async Task<ActionResult> GetRolCliente(int id_Cliente, int id_rol)
        {
            var resultado = await _dataContext.tblDetalleRolCliente
                            .Where(u => u.Id_Cliente == id_Cliente && u.Id_Rol == id_rol)
                            .FirstOrDefaultAsync();
            if (resultado is null)
            {
                return NotFound();
            }

            return Ok(resultado);
        }

        [HttpPost("EliminarRolCliente")]
        public async Task<ActionResult> EliminarRolCliente(tblDetalleRolCliente RolCliente)
        {

            try
            {
                _dataContext.Remove(RolCliente);
                await _dataContext.SaveChangesAsync();
                return Ok(RolCliente);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un Detalle Cliente-rol con este usuario.");
                }
                else
                {
                    return BadRequest(dbUpdateException.InnerException.Message);
                }
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpGet("GetPermisosRol")]
        public async Task<ActionResult> GetPermisosRol(int idRol)
        {
            var rolPermiso = await _dataContext.tblDetalleRolPermisos
                .Where(r => r.Id_Rol == idRol)
                .ToListAsync();
            if (rolPermiso is null)
            {
                return NotFound();
            }

            return Ok(rolPermiso);
        }

        [HttpGet("GetClientesRol")]
        public async Task<ActionResult> GetClientesRol(int idRol)
        {
            var rolCliente = await _dataContext.tblDetalleRolCliente
                .Where(r => r.Id_Rol == idRol)
                .ToListAsync();
            if (rolCliente is null)
            {
                return NotFound();
            }

            return Ok(rolCliente);
        }
    }
}
