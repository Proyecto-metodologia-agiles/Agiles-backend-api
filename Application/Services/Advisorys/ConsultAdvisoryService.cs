using Domain.Contracts;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;


namespace Application.Services.Advisorys
{
    public class ConsultAdvisoryService
    {
        readonly IUnitOfWork _unitOfWork;


        public ConsultAdvisoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public List<Advisory> GetAll()
        {
            var res = _unitOfWork.AdvisoryRepository.FindBy(includeProperties: "ThematicAdvisor,MetodologicAdvisor,Proyect");
            _unitOfWork.Dispose();
            return res.ToList();
        }

        public Advisory GetId(int id)
        {
            var ConsultarID = _unitOfWork.AdvisoryRepository.Find(id);
            _unitOfWork.Dispose();
            return ConsultarID;
        }
    }
}
