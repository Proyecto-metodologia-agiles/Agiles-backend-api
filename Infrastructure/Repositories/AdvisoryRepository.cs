using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Base;

namespace Infrastructure.Repositories
{
    public class AdvisoryRepository : GenericRepository<Advisory>, IAdvisoryRepository
    {
        public AdvisoryRepository(IDbContext context): base(context)
        {

        }
    }
}
