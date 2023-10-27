using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MarquesaReplenish.API.Data;
using MarquesaReplenish.Manager.Entities;
using Microsoft.EntityFrameworkCore;
using MarquesaReplenish.Manager.DTO;

namespace MarquesaReplenish.API.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("/api/productos")]
    public class ProductosController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public ProductosController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult> GetProductos()
        {
            try
            {
                List<tblCliente> clientes = await _dataContext.tblCliente.ToListAsync();
                if (clientes is null)
                {
                    return NotFound();
                }

                return Ok(clientes);

            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }

        }

        [HttpGet("ProductosCliente")]
        public async Task<ActionResult> GetProductosPorCliente(int cliente)
        {
            try
            {
                List<tblProducto> productos =  _dataContext.tblProducto.Where(p => p.Id_Cliente == cliente).ToList();
                if (productos is null)
                {
                    return NotFound();
                }

                return Ok(productos);

            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }

        }

        [HttpGet("ProductoEspecifico")]
        public async Task<ActionResult> ProductoEspecifico(int producto)
        {
            try
            {
                var productos = await _dataContext.tblProducto.FirstOrDefaultAsync(u => u.Id == producto);
                if (productos is null)
                {
                    return NotFound();
                }

                return Ok(productos);

            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }

        }

        [HttpPost("UpdateProductoEstado")]
        public async Task<ActionResult> UpdateProductoEstado(int idProducto)
        {
            
            try
            {
                var ProductoBD = await _dataContext.tblProducto.FindAsync(idProducto);

                ProductoBD.Estado = !ProductoBD.Estado;
                _dataContext.Update(ProductoBD);
                await _dataContext.SaveChangesAsync();
                return Ok(ProductoBD);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un Producto con el mismo nombre.");
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

        [HttpPost("CrearProducto")]
        public async Task<ActionResult> CrearProducto(tblProducto producto)
        {
            
            try
            {
                
                _dataContext.Add(producto);
                await _dataContext.SaveChangesAsync();
                return Ok(producto);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un producto con el mismo nombre.");
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

        [HttpPost("EditarProducto")]
        public async Task<ActionResult> EditarCliente(tblProducto producto)
        {
            
            try
            {
                _dataContext.Update(producto);
                await _dataContext.SaveChangesAsync();
                return Ok(producto);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un producto con el mismo nombre.");
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

        [HttpGet("TipoGrupo")]
        public async Task<ActionResult> TipoGrupo()
        {
            try
            {
                var TipoGrupo = await _dataContext.tblTipoGrupo.FirstOrDefaultAsync(u => u.Codigo == "01");
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

        [HttpGet("TipoGrupoVariable")]
        public async Task<ActionResult> TipoGrupoVariable(string variable)
        {
            try
            {
                var TipoGrupo = await _dataContext.tblTipoGrupo.FirstOrDefaultAsync(u => u.Codigo == $"{variable}");
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

        [HttpGet("Tipos")]
        public async Task<ActionResult> Tipos(int idTGrupo)
        {
            try
            {
                List<tblTipo> Tipo = _dataContext.tblTipo.Where(p => p.Id_TGrupo == idTGrupo).ToList();
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


    }
}
