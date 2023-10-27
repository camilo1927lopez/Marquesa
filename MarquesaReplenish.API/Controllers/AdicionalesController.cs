using MarquesaReplenish.API.Data;
using MarquesaReplenish.Manager.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarquesaReplenish.API.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("/api/adicionales")]
    public class AdicionalesController : Controller
    {
        private readonly DataContext _dataContext;

        public AdicionalesController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet("GetAdicionalPorProducto")]
        public async Task<ActionResult> GetAdicionalPorProducto(int idProducto)
        {
            try
            {
                List<tblAdicionales> adicionales = _dataContext.tblAdicionales.Where(p => p.Id_producto == idProducto).ToList();
                if (adicionales is null)
                {
                    return NotFound();
                }

                return Ok(adicionales);

            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }

        }

        [HttpGet("TipoGrupo")]
        public async Task<ActionResult> TipoGrupo()
        {
            try
            {
                var TipoGrupo = await _dataContext.tblTipoGrupo.FirstOrDefaultAsync(u => u.Codigo == "03");
                if (TipoGrupo is null)
                {
                    return NotFound();
                }

                return Ok(TipoGrupo);

            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }

        }

        [HttpGet("Tipo")]
        public async Task<ActionResult> Tipo(int id)
        {
            try
            {
                List<tblTipo> Tipo = _dataContext.tblTipo.Where(p => p.Id_TGrupo == id).ToList();
                if (Tipo is null)
                {
                    return NotFound();
                }

                return Ok(Tipo);

            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }

        }

        [HttpPost("CrearAdicional")]
        public async Task<ActionResult> CrearAdicional(tblAdicionales Adicional)
        {

            try
            {

                _dataContext.Add(Adicional);
                await _dataContext.SaveChangesAsync();
                return Ok(Adicional);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un Adicional con el mismo nombre.");
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

        [HttpPost("UpdateAdicionales")]
        public async Task<ActionResult> UpdateAdicionales(tblAdicionales adicional)
        {
            try
            {
                _dataContext.Update(adicional);
                await _dataContext.SaveChangesAsync();
                return Ok(adicional);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un adicional con el mismo Nombre.");
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

        [HttpGet("GetAdicional")]
        public async Task<ActionResult> GetAdicional(int Id)
        {
            var adicional = await _dataContext.tblAdicionales.FirstOrDefaultAsync(u => u.Id == Id);
            if (adicional is null)
            {
                return NotFound();
            }

            return Ok(adicional);
        }

    }
}
