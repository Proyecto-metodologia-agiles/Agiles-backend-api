using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Base;

namespace Infrastructure.Repositories
{
    public class CommitteeMemberRepository : GenericRepository<CommitteeMember>, ICommitteeMemberRepository
    {
        public CommitteeMemberRepository(IDbContext context) : base(context)
        {
        }
    }
}
