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

       
        public ProyectoContext(DbContextOptions options) : base(options)
        {

        }

        public ProyectoContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source=.\SQLEXPRESS;initial catalog=ProyectoBD;user id=sa;password=4015594wae");
        }
       
       

    }
}
