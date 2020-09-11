using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionObras.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionObras.Controllers
{
    public class InventariosController : Controller
    {
        private readonly ApplicationDbContext _db;

        //Se tiene un objeto productos de la clase Productos del modelo
        //Productos hace referencia a la vista => es como el Index del video

        [BindProperty]
        public Productos productos { get; set; }

        public InventariosController(ApplicationDbContext db)
        {
            _db = db;
        }

        //Muestra la View de Productos
        public IActionResult Productos()
        {
            return View();
        }

        //Muestra la View UpsertProductos
        public IActionResult UpsertProductos(int? id)
        {
            productos = new Productos();
            if (id == null)
            {
                //create
                return View(productos); 
               
            }
            //update
            productos = _db.Productos.FirstOrDefault(u => u.Id == id);
            if (productos == null)
            {
                return NotFound();
            }
            return View(productos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpsertProductos()
        {
            if(ModelState.IsValid)
            {
                if(productos.Id == 0)
                {
                    //create
                    _db.Productos.Add(productos);
                }
                else
                {
                    _db.Productos.Update(productos);
                }
                _db.SaveChanges();
                return RedirectToAction("Productos");
            }
            return View(productos);
        }

        #region API Calls
        [HttpGet]
        public async Task<IActionResult> GetAllProductos()
        {
            return Json(new { data = await _db.Productos.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete_Productos(int id)
        {
            var productFromDb = await _db.Productos.FirstOrDefaultAsync(u => u.Id == id);
            if (productFromDb == null)
            {
                return Json(new { success = false, message = "Error al Eliminar" });
            }
            _db.Productos.Remove(productFromDb);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Eliminado Correctamente" });
        }

        #endregion
    }
}
