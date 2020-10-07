using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IAsesoriaRepository AsesoriaRepository { get; }
        IAsesorRepository AsesorRepository { get; }
        IEstudianteRepository EstudianteRepository { get; }
        IMiembroComiteRepository MiembroComiteRepository { get; }
        IObservacionRepository ObservacionRepository { get; }
        IProyectoRepository ProyectoRepository { get; }
        IValoracionRepository ValoracionRepository { get; }
        int Commit();
    }
}
