using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
       
        IEstudianteRepository EstudianteRepository { get; }

        ICommitteeMemberRepository CommitteeMemberRepository {  get; }

        IAsesorRepository AsesorRepository { get; }

        int Commit();
    }
}
