using MarquesaReplenish.API.Data;
using MarquesaReplenish.API.Helpers;
using MarquesaReplenish.Manager.DTO;
using MarquesaReplenish.Manager.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MarquesaReplenish.API.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("/api/usuarios")]
    public class UsuarioController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public UsuarioController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        
        public async Task<ActionResult> GetUsers([FromQuery] PaginationDTO model)
        {
            string Obtener = ObtenerTokeJwt();
            var users =  _dataContext.TblUsuario.AsQueryable();
            if (!string.IsNullOrWhiteSpace(model.Filter))
            {
                users = users.Where(x => x.Codigo.ToLower().Contains(model.Filter.ToLower()) ||
                                    x.Overol.ToLower().Contains(model.Filter.ToLower()));
            }

            List<tblUsuario> tblUsuarios = await users.Paginate(model).ToListAsync();
            if (tblUsuarios is null)
            {
                return NotFound();
            }

            return Ok(tblUsuarios);
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

        [HttpGet("GetUser")]
        public async Task<ActionResult> GetUser(Guid Id)
        {
            var user = await _dataContext.TblUsuario.FirstOrDefaultAsync(u => u.Codigo == Id.ToString());
            if (user is null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser(tblUsuario model)
        {
            
            try
            {
                _dataContext.Add(model);
                await _dataContext.SaveChangesAsync();
                return Ok(model);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un Usuario con el mismo Nombre de usuario o número de identificación.");
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

        [HttpPost("UpdateUser")]
        public async Task<ActionResult> UpdateUser(UserEditMarquesaDTO user)
        {
            tblUsuario Usuario = new();
            Usuario.Id_Rol = user.Id_Rol;
            Usuario.Id = user.Id;
            Usuario.Codigo = user.Codigo;
            Usuario.Overol = user.Overol;
            Usuario.FechaCreacion = user.FechaCreacion;
            Usuario.Estado = user.Estado;
            //_dataContext.Add(user);
            
            try
            {
                _dataContext.Update(Usuario);
                await _dataContext.SaveChangesAsync();
                return Ok(user);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un Usuario con el mismo UserName.");
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

    }
}
