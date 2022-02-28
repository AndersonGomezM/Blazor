using System;
using System.Collections;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blazor.Entidades
{
    public class Productos
    {
        [Key]
        
        public int ProductoId { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir la descripción")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir la existencia")]
        [Range(1, int.MaxValue, ErrorMessage = "La Id esta fuera del rango permitido")]
        public int Existencia { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el costo")]
        [Range(1.00, double.MaxValue, ErrorMessage = "El costo se sale del rango permitido")]
        public double Costo { get; set; }

        public double ValorInventario { get; set; }

        [ForeignKey("DetalleId")]
        public virtual ProductosDetalle? DescripcionDetalle { get; set; }
    }
}