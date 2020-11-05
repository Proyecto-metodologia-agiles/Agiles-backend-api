﻿using Domain.Repositories;
using System;

namespace Domain.Contracts
{
    public interface IUnitOfWork : IDisposable
    {

        IEstudianteRepository EstudianteRepository { get; }

        ICommitteeMemberRepository CommitteeMemberRepository { get; }

        IAsesorRepository AsesorRepository { get; }

        IProyectoRepository ProyectoRepository { get; }

        IAdvisoryRepository AdvisoryRepository { get; }


        int Commit();
    }
}
