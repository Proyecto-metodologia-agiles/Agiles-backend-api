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
       

        public DbSet<CommitteeMember> CommitteeMembers { set; get; }

        public DbSet<Asesor> Asesors { get; set; }

        public DbSet<Proyecto> Proyectos { get; set; }

        public DbSet<Advisory> Advisorys { get; set; }

        public ProyectoContext()
        {
        }

        
        
        public ProyectoContext(DbContextOptions options) : base(options)
        {

        }
        
        
        
         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {    
            optionsBuilder.UseSqlServer(@"data source=.\SQLEXPRESS;initial catalog=ProyectoBD;user id=sa;password=4015594wae");
         } 
        
        

    }
}
