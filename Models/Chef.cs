#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using Cocineros_y_Platos.Models;

public class Chef
{
    [Key]
    public int ChefId { get; set; }

    [Required]
    public string Nombre { get; set; }

    [Required]
    public string Apellido { get; set; }

    [Required]
    [CheckChefAge]
    public DateTime Cumpleanos { get; set; }

    public List<Plato> PlatosCreados { get; set; } = new List<Plato>();
    public DateTime Fecha_Creacion { get; set; } = DateTime.Now;
    public DateTime Fecha_Modificacion { get; set; } = DateTime.Now;

    public class CheckChefAge : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is DateTime fechaNacimiento)
            {
                int edad = CalcularEdad(fechaNacimiento);
                return edad >= 18;
            }
            return true;
        }
    }
    public static int CalcularEdad(DateTime fechaNacimiento)
    {
        DateTime ahora = DateTime.Today;
        int edad = ahora.Year - fechaNacimiento.Year;

        if (ahora.Month < fechaNacimiento.Month || (ahora.Month == fechaNacimiento.Month && ahora.Day < fechaNacimiento.Day))
        {
            edad--;
        }

        return edad;
    }
}