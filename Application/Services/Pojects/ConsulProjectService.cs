using Domain.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Http.Features;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services.Pojects
{
    public class ConsulProjectService
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

        public List<Proyecto> GetComplet()
        {
            var res = _unitOfWork.ProyectoRepository.FindBy(includeProperties: "Thematic_Advisor,Metodologic_Advisor,Student_1,Student_2");
            _unitOfWork.Dispose();
            List<Proyecto> asesorados = new List<Proyecto>();
            foreach (var itemlist in res.ToList())
            {
                if (itemlist.Student_1.Estado==1 || itemlist.Student_2.Estado==1)
                {
                    asesorados.Add(itemlist);
                }
            }
            return asesorados;
        }

        public List<Proyecto> GetInomplet()
        {
            var res = _unitOfWork.ProyectoRepository.FindBy(includeProperties: "Thematic_Advisor,Metodologic_Advisor,Student_1,Student_2");
            _unitOfWork.Dispose();
            List<Proyecto> noasesorados = new List<Proyecto>();
            foreach (var itemlist in res.ToList())
            {
                if (itemlist.Student_1.Estado == 0 && itemlist.Student_2.Estado == 0)
                {
                    noasesorados.Add(itemlist);
                }
            }
            return noasesorados;
        }
    }
}
