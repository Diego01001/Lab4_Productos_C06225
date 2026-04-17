using DirectorioDeProductos.Models;
using Microsoft.AspNetCore.Mvc;

namespace DirectorioDeProductos.Controllers
{
    public class ProductosController : Controller
    {
        public IActionResult Index()
        {
            List<Producto> productos = ProductoRepositorio.ObtenerTodos();
            return View(productos);
        }

        public IActionResult Detalles(int id)
        {
            Producto? producto = ProductoRepositorio.ObtenerPorId(id);

            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View(new Producto());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Producto producto)
        {
            if (!ModelState.IsValid)
            {
                return View(producto);
            }

            ProductoRepositorio.Agregar(producto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            Producto? producto = ProductoRepositorio.ObtenerPorId(id);

            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Producto producto)
        {
            if (!ModelState.IsValid)
            {
                return View(producto);
            }

            Producto? productoExistente = ProductoRepositorio.ObtenerPorId(producto.Id);

            if (productoExistente == null)
            {
                return NotFound();
            }

            ProductoRepositorio.Actualizar(producto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Eliminar(int id)
        {
            Producto? producto = ProductoRepositorio.ObtenerPorId(id);

            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EliminarConfirmado(int id)
        {
            ProductoRepositorio.Eliminar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}