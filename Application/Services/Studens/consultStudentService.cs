using Domain.Contracts;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Application.Services.Studens
{
    public class consultStudentService
    {
        readonly IUnitOfWork _unitOfWork;


        public consultStudentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public List<Estudiante> GetAll()
        {
            var res = _unitOfWork.EstudianteRepository.FindBy();
            _unitOfWork.Dispose();
            return res.ToList();
        }

        public Estudiante GetId(int id)
        {
            var ConsultarID = _unitOfWork.EstudianteRepository.Find(id);
            _unitOfWork.Dispose();
            return ConsultarID;
        }

    }
}
