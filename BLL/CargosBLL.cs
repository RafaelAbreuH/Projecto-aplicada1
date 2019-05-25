using Projecto_Aplicada1.DAL;
using Projecto_Aplicada1.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Projecto_Aplicada1.BLL
{
    public class CargosBLL
    {
        //Guardar Usuario
        public static bool Guardar(Cargos cargo)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                if (contexto.Cargo.Add(cargo) != null)
                    paso = contexto.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose(); // cerrar la conexion
            }

            return paso;
        }

        //Modificar Usuario
        public static bool Modificar(Cargos cargo)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(cargo).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        //Eliminar usuario
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var eliminar = contexto.Cargo.Find(id);
                contexto.Entry(eliminar).State = EntityState.Deleted;

                paso = (contexto.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;

        }

        //para Buscar los
        public static Cargos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Cargos cargo = new Cargos();
            try
            {
                cargo = contexto.Cargo.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return cargo;
        }

        //Lista
        public static List<Cargos> Getlist(Expression<Func<Cargos, bool>> expression)
        {
            List<Cargos> lista = new List<Cargos>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Cargo.Where(expression).ToList();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
    }
}
