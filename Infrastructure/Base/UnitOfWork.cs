﻿using Domain.Contracts;
using Domain.Repositories;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure.Base
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private IDbContext _dbContext;

        private readonly Lazy<ICommitteeMemberRepository> _committeeMemberRepository;




        public UnitOfWork(IDbContext context)
        {
            _dbContext = context;
            //singleton using Lazy
            _committeeMemberRepository = new Lazy<ICommitteeMemberRepository>(() => new CommitteeMemberRepository(_dbContext));
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

        public IAdvisoryRepository _advisoryRepository;

        public IAdvisoryRepository AdvisoryRepository
        {
            get
            {
                if (_advisoryRepository == null)
                {
                    _advisoryRepository = new AdvisoryRepository(_dbContext);
                }
                return _advisoryRepository;
            }
        }

        public IEvaluationRepository _evaluationRepository;

        public IEvaluationRepository EvaluationRepository 
        {
            get 
            {
                if (_evaluationRepository == null) 
                {
                    _evaluationRepository = new EvaluacionRepository(_dbContext);
                }
                return _evaluationRepository;
            }
        }

        public IValorationRepository _valorationRepository;
        
        public IValorationRepository ValorationRepository 
        {
            get 
            {
                if (_valorationRepository == null) 
                {
                    _valorationRepository = new ValoracionRepository(_dbContext);
                }
                return _valorationRepository;
            }
        }

        public IAnnouncementRepository _announcementRepository;
       
        public IAnnouncementRepository AnnouncementRepository 
        {
            get
            {
                if (_announcementRepository == null)
                {
                    _announcementRepository = new AnnouncementRepository(_dbContext);
                }
                return _announcementRepository;
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
