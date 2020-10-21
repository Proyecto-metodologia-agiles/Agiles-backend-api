using Domain.Contracts;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Services.Pojects
{
    public  class ConsulProjectService
    {
        readonly IUnitOfWork _unitOfWork;


        public ConsulProjectService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public List<Proyecto> GetAll()
        {
            var res = _unitOfWork.ProyectoRepository.FindBy(includeProperties: "Thematic_Advisor,Metodologic_Advisor,Student_1,Student_2");
            _unitOfWork.Dispose();
            return res.ToList();
        }

        public Proyecto GetId(int id)
        {
            var ConsultarID = _unitOfWork.ProyectoRepository.Find(id);
            _unitOfWork.Dispose();
            return ConsultarID;
        }
    }
}
