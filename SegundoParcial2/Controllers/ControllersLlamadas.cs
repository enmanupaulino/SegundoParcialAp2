using Microsoft.EntityFrameworkCore;
using SegundoParcial2.Data;
using SegundoParcial2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SegundoParcial2.Controllers
{
    public class ControllersLlamadas
    {
        public bool Guardar(Registros registros)
        {
            bool paso = false;
            Contexto db = new Contexto();
            if (registros.RegistroId == 0)
            {
                Insertar(registros);
            }
            else if (Buscar(registros.RegistroId) == null)
            {
                paso = false;
            }
            else
            {
                Modificar(registros);
            }
            return paso;
        }
        public bool Insertar(Registros registros)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                db.registros.Add(registros);
                paso = db.SaveChanges() > 0;

            }
            catch (Exception) { throw; }

            return paso;
        }
        public Registros Buscar(int Id)
        {
            Contexto db = new Contexto();
            Registros registro = new Registros();
           
            
                registro= db.registros.Where(A => A.RegistroId== Id)
                    .Include(A => A.Detalle).FirstOrDefault();
           
            
            return registro;
        }
        public bool Modificar(Registros registros)
        {
            bool paso = false;
            Contexto db = new Contexto();

            var anterior = Buscar(registros.RegistroId);

            foreach (var item in registros.Detalle)
            {
                if (item.Id == 0)
                {
                    db.Entry(item).State = EntityState.Added;
                }
            }

            foreach (var item in anterior.Detalle)
            {
                if (!registros.Detalle.Any(A => A.Id== item.Id))
                {
                    db.Entry(item).State = EntityState.Deleted;
                }
            }

            db.Entry(registros).State = EntityState.Modified;
            paso = db.SaveChanges() > 0;


            return paso;
        }
        public bool Eliminar(int Id)
        {
            bool paso = false;
            Contexto db = new Contexto();
          


             Registros registro = db.registros.Find(Id);
            if (registro != null)
            {
                db.Entry(registro).State = EntityState.Deleted;
                paso = db.SaveChanges() > 0;
            }

            return paso;
        }
        public List<Registros> GetRegistros(Expression<Func<Registros, bool>> expression)
        {
            List<Registros> lista;
            Contexto db = new Contexto();
            try
            {
                lista = db.registros.Where(expression).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return lista;
        }
    }
}
