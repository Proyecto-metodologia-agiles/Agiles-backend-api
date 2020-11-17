using Domain.Entities;
using Infrastructure.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class ProyectoContext : DbContextBase
    {


        public DbSet<Estudiante> Estudiantes { get; set; }


        public DbSet<CommitteeMember> CommitteeMembers { set; get; }

        public DbSet<Asesor> Asesors { get; set; }

        public DbSet<Proyecto> Proyectos { get; set; }

        public DbSet<Advisory> Advisorys { get; set; }

        public DbSet<Evaluacion> Evaluation { get; set; }

        public DbSet<Valoracion> Valoration { get; set; }

        public DbSet<Announcement> Announcement { get; set; }

        public ProyectoContext()
        {
        }


        public ProyectoContext(DbContextOptions options) : base(options)
        {

        }
        

        /*
         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {    
            optionsBuilder.UseSqlServer("Server=DESKTOP-FDBCSN1\\SQLEXPRESS;Database=ProyectoBD;Integrated Security=True;");
         } 
        */


    }
}
