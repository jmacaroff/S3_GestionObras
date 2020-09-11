using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionObras.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionObras.Controllers
{
    public class ProveedoresController : Controller
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public Proveedores proveedor { get; set; }

        public ProveedoresController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Proveedores()
        {
            return View();
        }

        //Muestra la View UpsertProveedores
        public IActionResult UpsertProveedores(int? id)
        {
            proveedor = new Proveedores();
            if (id == null)
            {
                //create
                return View(proveedor);

            }
            //update
            proveedor = _db.Proveedores.FirstOrDefault(u => u.Id == id);
            if (proveedor == null)
            {
                return NotFound();
            }
            return View(proveedor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpsertProveedores()
        {
            if (ModelState.IsValid)
            {
                if (proveedor.Id == 0)
                {
                    //create
                    _db.Proveedores.Add(proveedor);
                }
                else
                {
                    _db.Proveedores.Update(proveedor);
                }
                _db.SaveChanges();
                return RedirectToAction("Proveedores");
            }
            return View(proveedor);
        }

        #region API Calls
        [HttpGet]
        public async Task<IActionResult> GetAllProveedores()
        {
            return Json(new { data = await _db.Proveedores.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete_Proveedores(int id)
        {
            var proveedorFromDb = await _db.Proveedores.FirstOrDefaultAsync(u => u.Id == id);
            if (proveedorFromDb == null)
            {
                return Json(new { success = false, message = "Error al Eliminar" });
            }
            _db.Proveedores.Remove(proveedorFromDb);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Eliminado Correctamente" });
        }

        #endregion

    }
}
