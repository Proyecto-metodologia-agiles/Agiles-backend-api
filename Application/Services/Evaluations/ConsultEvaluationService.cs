using System;
using System.Collections.Generic;
using System.Text;
using Domain.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Http.Features;
using System.Linq;

namespace Application.Services.Evaluations
{
    public class ConsultEvaluationService
    {
        readonly IUnitOfWork _unitOfWork;

        public ConsultEvaluationService (IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public List<Evaluacion> GetId(string id)
        {
            var val = _unitOfWork.EvaluationRepository.FindBy(t => t.Project.Student_1.Cedula == id || t.Project.Student_2.Cedula == id, includeProperties: "Project");
            _unitOfWork.Dispose();
            List<Evaluacion> evaluacions = new List<Evaluacion>();
            foreach (var itemlist in val.ToList())
            {    
                 evaluacions.Add(itemlist);
            }
            return evaluacions;
        }

        public List<Evaluacion> GetAll()
        {
            var val = _unitOfWork.EvaluationRepository.FindBy(includeProperties: "Project");
            _unitOfWork.Dispose();
            return val.ToList();
        }
    }
}
