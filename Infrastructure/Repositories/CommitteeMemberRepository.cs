﻿using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class CommitteeMemberRepository : GenericRepository<CommitteeMember>, ICommitteeMemberRepository
    {
        public CommitteeMemberRepository(IDbContext context) : base(context)
        {
        }
    }
}