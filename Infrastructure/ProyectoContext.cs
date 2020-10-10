using Domain.Entities;
using Infrastructure.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public class ProyectoContext : DbContextBase
    {

        
        public DbSet<Estudiante> Estudiantes { get; set; }
       

        
        public ProyectoContext(DbContextOptions options) : base(options)
        {

        }
        /*
        
         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-FDBCSN1\SQLEXPRESS;Database=ProyectoBD;Integrated Security=True;");
        }
        */

    }
}
