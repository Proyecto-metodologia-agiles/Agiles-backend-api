using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Base;

namespace Infrastructure.Repositories
{
    public class EvaluacionRepository: GenericRepository <Evaluacion>, IEvaluationRepository
    {
        public EvaluacionRepository(IDbContext context) : base(context)
        {
        }

    }
}
