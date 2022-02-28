using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Blazor.Entidades;

namespace Blazor.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Productos>? Productos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"DefaultConnection");
        }
    }
}