using Domain.Contracts;
using Domain.Repositories;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Base
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private IDbContext _dbContext;

       

        public UnitOfWork(IDbContext context)
        {
            _dbContext = context;
        }

        public IEstudianteRepository _estudianteRepository ;

       

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
