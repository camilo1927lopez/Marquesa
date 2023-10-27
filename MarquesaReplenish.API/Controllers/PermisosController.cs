using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MarquesaReplenish.API.Data;
using MarquesaReplenish.Manager.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace MarquesaReplenish.API.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("/api/permisos")]
    public class PermisosController : Controller
    {
        private readonly DataContext _dataContext;

        public PermisosController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet("GetPermisos")]
        public async Task<ActionResult> GetPermisos()
        {
            try
            {
                var permisos = await _dataContext.tblPermisos.ToListAsync();
                if (permisos is null)
                {
                    return NotFound();
                }

                return Ok(permisos);

            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }

        }
        //// GET: PermisosController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: PermisosController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: PermisosController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: PermisosController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: PermisosController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: PermisosController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: PermisosController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        [HttpGet("TipoGrupo")]
        public async Task<ActionResult> TipoGrupo()
        {
            try
            {
                var TipoGrupo = await _dataContext.tblTipoGrupo.FirstOrDefaultAsync(u => u.Codigo == "05");
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
    }
}
