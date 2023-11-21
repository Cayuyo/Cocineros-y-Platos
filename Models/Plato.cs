#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using Cocineros_y_Platos.Models;

public class Plato
    {
        [Key]
        public int PlatoId {get;set;}

        [Required]
        public string Nombre {get;set;}

        [Required]
        public int Calorias {get;set;}

        [Required]
        public int Sabor {get;set;}

        [Required]
        public string Descripcion {get;set;}

        public int ChefId {get;set;}
        public Chef Creador {get;set;}
        public DateTime Fecha_Creacion {get;set;} = DateTime.Now;
        public DateTime Fecha_Modificacion {get;set;} = DateTime.Now;
    }