using System.Collections.Generic;
using System.Linq;

namespace DirectorioDeProductos.Models
{
    public static class ProductoRepositorio
    {
        private static readonly List<Producto> productos = new List<Producto>();
        private static int ultimoId = 0;

        public static List<Producto> ObtenerTodos()
        {
            return productos
                .OrderBy(p => p.Id)
                .ToList();
        }

        public static Producto? ObtenerPorId(int id)
        {
            return productos.FirstOrDefault(p => p.Id == id);
        }

        public static void Agregar(Producto producto)
        {
            if (producto == null)
            {
                return;
            }

            ultimoId++;
            producto.Id = ultimoId;
            productos.Add(producto);
        }

        public static void Actualizar(Producto productoActualizado)
        {
            if (productoActualizado == null)
            {
                return;
            }

            Producto? productoExistente = ObtenerPorId(productoActualizado.Id);

            if (productoExistente == null)
            {
                return;
            }

            productoExistente.Nombre = productoActualizado.Nombre;
            productoExistente.Precio = productoActualizado.Precio;
            productoExistente.Categoria = productoActualizado.Categoria;
        }

        public static void Eliminar(int id)
        {
            Producto? producto = ObtenerPorId(id);

            if (producto != null)
            {
                productos.Remove(producto);
            }
        }
    }
}