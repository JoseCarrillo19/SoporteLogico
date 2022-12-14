using Microsoft.AspNetCore.Mvc;
using SoporteLogico.Datos;
using SoporteLogico.Models;

namespace SoporteLogico.Controllers
{
    public class VinculacionController : Controller
    {
        public readonly ApplicationDbContext _db;

        public VinculacionController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Empleado> lista = _db.Empleado;
            return View(lista);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Vinculacion vinculacion)
        {
            Empleado empleado = null;
            foreach (var item in _db.Empleado)
            {
                if (vinculacion.IdEmpleado_Vinculacion == item.IdEmpleado)
                {
                    empleado = item;
                } 
            }
            if(empleado != null)
            {
                _db.Vinculacion.Add(vinculacion);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Crear));

        }

        public IActionResult Vinculaciones(int id)
        {
            IEnumerable<Vinculacion> lista = from Vinculacion in _db.Vinculacion where Vinculacion.IdEmpleado_Vinculacion == id select Vinculacion;
            return View(lista);
        }
    }
}
