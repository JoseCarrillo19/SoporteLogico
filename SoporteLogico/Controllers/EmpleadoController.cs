using Microsoft.AspNetCore.Mvc;
using SoporteLogico.Datos;
using SoporteLogico.Models;

namespace SoporteLogico.Controllers
{
    public class EmpleadoController : Controller
    {

        public readonly ApplicationDbContext _db;

        public EmpleadoController(ApplicationDbContext db)
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
        public IActionResult Crear(Empleado empleado)
        {
            _db.Empleado.Add(empleado);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
