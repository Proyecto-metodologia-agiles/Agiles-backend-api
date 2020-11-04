using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Base;

namespace Infrastructure.Repositories
{
    public class ValoracionRepository: GenericRepository<Valoracion>, IValorationRepository
    {
        public ValoracionRepository(IDbContext context) : base(context)
        {
        }
    }
}
