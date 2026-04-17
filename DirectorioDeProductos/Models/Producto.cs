using System.ComponentModel.DataAnnotations;

namespace DirectorioDeProductos.Models
{
    public class Producto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; } = string.Empty;

        [Range(0.01, 999999, ErrorMessage = "El precio debe estar entre 0.01 y 999999.")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "La categoría es obligatoria.")]
        public string Categoria { get; set; } = string.Empty;
    }
}