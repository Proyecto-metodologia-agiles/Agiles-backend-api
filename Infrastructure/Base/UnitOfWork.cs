using Domain.Contracts;
using Domain.Repositories;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure.Base
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private IDbContext _dbContext;

        private  readonly Lazy<ICommitteeMemberRepository> _committeeMemberRepository;




        public UnitOfWork(IDbContext context)
        {
            _dbContext = context;
            //singleton using Lazy
            _committeeMemberRepository = new Lazy<ICommitteeMemberRepository>( ()=>  new CommitteeMemberRepository(_dbContext));
        }
        public ICommitteeMemberRepository CommitteeMemberRepository
        {
            get
            {
                return _committeeMemberRepository.Value;
            }
        }

        public IEstudianteRepository _estudianteRepository;

        public IEstudianteRepository EstudianteRepository
        {
            get
            {
                if (_estudianteRepository == null)
                {
                    _estudianteRepository = new EstudianteRepository(_dbContext);
                }
                return _estudianteRepository;
            }
        }

        public IAsesorRepository _asesorRepository;

        public IAsesorRepository AsesorRepository
        {
            get
            {
                if (_asesorRepository == null)
                {
                    _asesorRepository = new AsesorRepository(_dbContext);
                }
                return _asesorRepository;
            }
        }

        public IProyectoRepository _proyectoRepository;

        public IProyectoRepository ProyectoRepository 
        {
            get 
            {
                if (_proyectoRepository == null) 
                {
                    _proyectoRepository = new ProyectoRepository(_dbContext);
                }
                return _proyectoRepository;
            }
        }


        public int Commit()
        {
            return _dbContext.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
        }
        /// <summary>
        /// Disposes all external resources.
        /// </summary>
        /// <param name="disposing">The dispose indicator.</param>
        private void Dispose(bool disposing)
        {
            if (disposing && _dbContext != null)
            {
                ((DbContext)_dbContext).Dispose();
                _dbContext = null;
            }
        }

       
    }
}
