using MarquesaReplenish.API.Data;
using MarquesaReplenish.Manager.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarquesaReplenish.API.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("/api/poblacion")]
    public class PoblacionController : ControllerBase
    {

        private readonly DataContext _dataContext;

        public PoblacionController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet("GetPoblacion")]
        public async Task<ActionResult> GetPoblacion(int Id)
        {
            var poblacion = await _dataContext.tblPoblacion.FirstOrDefaultAsync(u => u.Id == Id);
            if (poblacion is null)
            {
                return NotFound();
            }

            return Ok(poblacion);
        }

        [HttpGet("GetPoblacionPorProducto")]
        public async Task<ActionResult> GetClientesPorRol(int idProducto)
        {
            try
            {
                List<tblPoblacion> poblacion = _dataContext.tblPoblacion.Where(p => p.Id_producto == idProducto).ToList();
                if (poblacion is null)
                {
                    return NotFound();
                }

                return Ok(poblacion);

            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }

        }

        [HttpPost("UpdatePoblaciones")]
        public async Task<ActionResult> UpdatePoblaciones(tblPoblacion poblacion)
        {
            tblPoblacion PoblacionUpdate = new();

            PoblacionUpdate = await _dataContext.tblPoblacion.FirstOrDefaultAsync(u => u.Id == poblacion.Id);         
            PoblacionUpdate.Nombre = poblacion.Nombre;
            PoblacionUpdate.Adicional = poblacion.Adicional;
            PoblacionUpdate.Interprete = poblacion.Interprete;
            try
            {
                _dataContext.Update(PoblacionUpdate);
                await _dataContext.SaveChangesAsync();
                return Ok(PoblacionUpdate);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe una población con el mismo Nombre.");
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

    

    [HttpPost("CrearPoblacion")]
        public async Task<ActionResult> CrearPoblacion(tblPoblacion poblacion)
        {
            
            try
            {
                _dataContext.Add(poblacion);
                await _dataContext.SaveChangesAsync();
                return Ok(poblacion);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe una poblacion con el mismo Nombre.");
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
