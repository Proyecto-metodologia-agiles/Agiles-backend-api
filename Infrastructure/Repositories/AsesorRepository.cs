﻿using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Base;


namespace Infrastructure.Repositories
{
     public class AsesorRepository: GenericRepository<Asesor>, IAsesorRepository
    {
        public AsesorRepository(IDbContext context)
             : base(context)
        {

        }
    }
}
