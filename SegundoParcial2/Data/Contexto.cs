

using Microsoft.EntityFrameworkCore;
using SegundoParcial2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SegundoParcial2.Data
{
    public class Contexto:DbContext
        
    {
        public DbSet<Registros> registros { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@" Data Source =Database/Llamadas");

        }
    }
}
