using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Base;

namespace Infrastructure.Repositories
{
    public class ProyectoRepository: GenericRepository<Proyecto>, IProyectoRepository
    {
        public ProyectoRepository(IDbContext context)
            : base(context) 
        {
        
        }
        
    }
}
