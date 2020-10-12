using Domain.Contracts;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Application.Services.Studens
{
    public class ConsultAsesorService
    {
        readonly IUnitOfWork _unitOfWork;


        public ConsultAsesorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public List<Asesor> GetAll()
        {
            var res = _unitOfWork.AsesorRepository.FindBy();
            _unitOfWork.Dispose();
            return res.ToList();
        }

        public Asesor GetId(int id)
        {
            var ConsultarID = _unitOfWork.AsesorRepository.Find(id);
            _unitOfWork.Dispose();
            return ConsultarID;
        }

    }
}

