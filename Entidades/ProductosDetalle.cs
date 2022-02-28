using System;
using System.Collections;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Blazor.Entidades
{
    public class ProductosDetalle
    {
        [Key]

        public int DetallesId { get; set; }
        public int ProductosId { get; set; }
        public string? DescripcionDetalle { get; set; }
        public double Cantidad { get; set; }
        public double Precio { get; set; }

        public ProductosDetalle(int productosId, double cantidad, double precio)
        {
            this.DetallesId = 0;
            this.ProductosId = productosId;
            this.Cantidad = cantidad;
            this.Precio = precio;

        }
    }
}