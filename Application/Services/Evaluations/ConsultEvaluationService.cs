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

        public List<Evaluacion> GetId(int id)
        {
            var val = _unitOfWork.EvaluationRepository.FindBy(t => t.Project.Id == id,includeProperties: "Project");
            _unitOfWork.Dispose();
            List<Evaluacion> evaluacions = new List<Evaluacion>();
            foreach (var itemlist in val.ToList())
            {
                if (itemlist.ProjectId == id)
                {
                    evaluacions.Add(itemlist);
                }
            }
            return evaluacions;
        }
    }
}
