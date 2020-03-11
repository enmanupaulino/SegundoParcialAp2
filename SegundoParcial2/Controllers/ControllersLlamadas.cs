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
                paso = Insertar(registros);
            }
            else
            {
                paso = Modificar(registros);
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
            try
            {
                registro = db.registros.Find(Id);
            }
            catch (Exception)
            {
                throw;
            }
            return registro;
        }
        public bool Modificar(Registros registros)
        {
            bool paso = false;
            Contexto db = new Contexto();

            db.registros.Add(registros);
            db.Entry(registros).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            paso = db.SaveChanges() > 0;

            return paso;
        }
        public bool Eliminar(int Id)
        {
            bool paso = false;
            Contexto db = new Contexto();
            Registros registro = new Registros();


            registro = db.registros.Find(Id);
            db.Entry(registro).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            paso = db.SaveChanges() > 0;

            return paso;
        }
        public List<Registros> GetAsignaturas(Expression<Func<Registros, bool>> expression)
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
