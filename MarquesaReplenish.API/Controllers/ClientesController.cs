using MarquesaReplenish.API.Data;
using MarquesaReplenish.Manager.DTO;
using MarquesaReplenish.Manager.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;


namespace MarquesaReplenish.API.Controllers
{
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("/api/clientes")]
    public class ClientesController : ControllerBase
    {

        private readonly DataContext _dataContext;

        public ClientesController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult> GetClientes()
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

        [HttpGet("GetClientesPorRol")]
        public async Task<ActionResult> GetClientesPorRol(int idRol)
        {
            try
            {
                List<tblDetalleRolCliente> clientes = _dataContext.tblDetalleRolCliente.Where(p => p.Id_Rol == idRol).ToList();
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

        [HttpPost("UpdateClienteEstado")]
        public async Task<ActionResult> UpdateClienteEstado(int idCliente)
        {       
            try
            {
                var ClienteBD = await _dataContext.tblCliente.FindAsync(idCliente);

                ClienteBD.Estado = !ClienteBD.Estado;
                _dataContext.Update(ClienteBD);
                await _dataContext.SaveChangesAsync();
                return Ok(ClienteBD);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un Cliente con el mismo nombre.");
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



        [HttpPost("CrearCliente")]
        public async Task<ActionResult> CrearCliente(tblCliente cliente)
        {
            
            try
            {
                _dataContext.Add(cliente);
                await _dataContext.SaveChangesAsync();
                return Ok(cliente);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un cliente con el mismo NIT.");
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

        [HttpPost("EditarCliente")]
        public async Task<ActionResult> EditarCliente(tblCliente cliente)
        {
            _dataContext.Add(cliente);
            try
            {
                await _dataContext.SaveChangesAsync();
                return Ok(cliente);
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


        [HttpGet("GetCliente")]
        public async Task<ActionResult> GetUser(string Id)
        {
            var cliente = await _dataContext.tblCliente.FirstOrDefaultAsync(u => u.Id.ToString() == Id);
            if (cliente is null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        [HttpPost("UpdateCliente")]
        public async Task<ActionResult> UpdateCliente(tblCliente cliente)
        {
            tblCliente ClienteUpdate = new();

            ClienteUpdate = await _dataContext.tblCliente.FirstOrDefaultAsync(u => u.Id == cliente.Id);

            ClienteUpdate.Nit = cliente.Nit;
            ClienteUpdate.Nombre = cliente.Nombre;
            if (cliente.Img != null)
            {
                ClienteUpdate.Img = cliente.Img;
            }

            //_dataContext.Add(user);

            try
            {
                _dataContext.Update(ClienteUpdate);
                await _dataContext.SaveChangesAsync();
                return Ok(ClienteUpdate);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un Cliente con el mismo Nit.");
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
