using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Blazor.DAL;
using Blazor.Entidades;

namespace Blazor.BLL
{
    public class ProductosBLL
    {
        public static bool Guardar(Productos producto)
        {
            if(!Existe(producto.ProductoId))
                return Insertar(producto);
            else
                return Modificar(producto);
        }

        private static bool Modificar(Productos productos)
        {
            bool confirmar = false;
            
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(productos).State = EntityState.Modified;
                confirmar = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally { contexto.Dispose(); }

            return confirmar;
        }

        private static bool Insertar(Productos productos)
        {
            bool confirmar = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Productos.Add(productos);
                confirmar = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally { contexto.Dispose(); }

            return confirmar;
        }

        public static bool Eliminar(int id)
        {
            bool confirmar = false;
            Contexto contexto = new Contexto();

            try
            {
                var productos = contexto.Productos.Find(id);
                if(productos != null)
                {
                    contexto.Productos.Remove(productos);
                    confirmar = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally { contexto.Dispose(); }

            return confirmar;
        }

        public static Productos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Productos productos;

            try
            {
                productos = contexto.Productos.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally { contexto.Dispose(); }

            return productos!;
        }

        private static bool Existe(int id)
        {
            bool confirmar = false;
            Contexto contexto = new Contexto();

            try
            {
                confirmar = contexto.Productos.Any(e => e.ProductoId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally { contexto.Dispose(); }

            return confirmar;
        }

        public static List<Productos> GetProductos()
        {
            List<Productos>? lista = new List<Productos>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Productos.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally { contexto.Dispose(); }

            return lista;
        }

        public static List<Productos> GetList(Expression<Func<Productos, bool>> criterio)
        {
            List<Productos>? lista = new List<Productos>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Productos?.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally { contexto.Dispose(); }

            return lista!;
        }
    }
}