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

        public List<Valoracion> GetId(int id) 
        {
            var val = _unitOfWork.ValorationRepository.FindBy(t => t.Project.Id == id ,includeProperties: "Project");
            _unitOfWork.Dispose();
            List<Valoracion> valoraciones = new List<Valoracion>();
            foreach (var itemlist in val.ToList())
            {
                if (itemlist.ProjectId == id)
                {
                    valoraciones.Add(itemlist);
                }
            }
            return valoraciones;
        }
    }
}
