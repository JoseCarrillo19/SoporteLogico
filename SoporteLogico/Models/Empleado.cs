using System.ComponentModel.DataAnnotations;

namespace SoporteLogico.Models
{
    public class Empleado
    {
        [Key]
        public int IdEmpleado { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Direccion { get; set; }
        public string? Email { get; set; }

        public int IdGenero { get; set; }

        public int IdCiudad { get; set; }


        public List<Vinculacion> Vinculacions { get; set; }


    }
}
