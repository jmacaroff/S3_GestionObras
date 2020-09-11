using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionObras.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionObras.Controllers
{
    public class ClientesController : Controller
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public Clientes cliente { get; set; }

        public ClientesController(ApplicationDbContext db)
        {
            _db = db;
        }


        public IActionResult Clientes()
        {
            return View();
        }


        //Muestra la View UpsertClientes
        public IActionResult UpsertClientes(int? id)
        {
            cliente = new Clientes();
            if (id == null)
            {
                //create
                return View(cliente);

            }
            //update
            cliente = _db.Clientes.FirstOrDefault(u => u.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpsertClientes()
        {
            if (ModelState.IsValid)
            {
                if (cliente.Id == 0)
                {
                    //create
                    _db.Clientes.Add(cliente);
                }
                else
                {
                    _db.Clientes.Update(cliente);
                }
                _db.SaveChanges();
                return RedirectToAction("Clientes");
            }
            return View(cliente);
        }

        #region API Calls
        [HttpGet]
        public async Task<IActionResult> GetAllClientes()
        {
            return Json(new { data = await _db.Clientes.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete_Clientes(int id)
        {
            var clienteFromDb = await _db.Clientes.FirstOrDefaultAsync(u => u.Id == id);
            if (clienteFromDb == null)
            {
                return Json(new { success = false, message = "Error al Eliminar" });
            }
            _db.Clientes.Remove(clienteFromDb);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Eliminado Correctamente" });
        }

        #endregion
    }
}
