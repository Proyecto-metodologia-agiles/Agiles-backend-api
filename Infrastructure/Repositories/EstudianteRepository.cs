using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class EstudianteRepository : GenericRepository<Estudiante>, IEstudianteRepository
    {
        public EstudianteRepository(IDbContext context)
             : base(context)
        {

        }
    }
}
