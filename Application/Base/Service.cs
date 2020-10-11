using Application.Interface;
using Domain.Base;
using Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Base
{
    public class Service<T> : IService<T> where T : BaseEntity
    {
        private  readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<T> _genericRepository;
        public Service(IUnitOfWork unitOfWork, IGenericRepository<T> genericRepository)
        {
            _unitOfWork = unitOfWork;
            _genericRepository = genericRepository;

        }


        public T Create(T entity)
        {
            _genericRepository.Add(entity);
            if(_unitOfWork.Commit() > 0)
            {
                return entity;
            }
            return null;
        }

        public bool Delete(T entity)
        {
            _genericRepository.Delete(entity);
            if (_unitOfWork.Commit() > 0)
            {
                return true;
            }
            return false;
        }

        public bool Delete(object id)
        {
            _genericRepository.Delete(id);
            if (_unitOfWork.Commit() > 0)
            {
                return true;
            }
            return false;
        }

        public T Find(object id)
        {
            return _genericRepository.Find(id);
        }

        public T Update(T entity)
        {
            _genericRepository.Edit(entity);
            if (_unitOfWork.Commit() > 0)
            {
                return entity;
            }
            return null;
        }
    }
}
