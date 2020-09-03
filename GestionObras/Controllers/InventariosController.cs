using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GestionObras.Controllers
{
    public class InventariosController : Controller
    {
        //private readonly ApplicationDbContext _db;
        //[BindProperty]
        //public Material Material { get; set; }
        public IActionResult Productos()
        {
            return View();
        }
        public IActionResult Upsert(int? id)
        {
            //inicializar material
            if (id == null)
            {
                //create
                //return View(Material); //se debe insertar el objeto
               
            }
            //if (Material == null)
            //{
            //    return NotFound();
            //}
            return View();//se debe insertar el objeto material
        }


        #region API Calls
        #endregion
    }
}
