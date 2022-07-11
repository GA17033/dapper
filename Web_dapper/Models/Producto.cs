using System.ComponentModel.DataAnnotations;

namespace Web_dapper.Models
{
    public class Producto
    {
        [Key]
        public int ProductoId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public float Price { get; set; }

        public bool State { get; set; } = true;
    }
}
