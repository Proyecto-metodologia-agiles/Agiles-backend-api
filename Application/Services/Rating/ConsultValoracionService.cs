using Domain.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Http.Features;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services.Rating
{
    public class ConsultValoracionService
    {
        readonly IUnitOfWork _unitOfWork;

        public ConsultValoracionService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public List<Valoracion> GetId(string id) 
        {
            var val = _unitOfWork.ValorationRepository.FindBy(t => t.Project.Student_1.Cedula == id || t.Project.Student_2.Cedula == id ,includeProperties: "Project");
            _unitOfWork.Dispose();
            List<Valoracion> valoraciones = new List<Valoracion>();
            foreach (var itemlist in val.ToList())
            {          
                    valoraciones.Add(itemlist);   
            }
            return valoraciones;
        }

        public List<Valoracion> GetAll()
        {
            var val = _unitOfWork.ValorationRepository.FindBy(includeProperties: "Project");
            _unitOfWork.Dispose();
            return val.ToList();
        }
    }
}
