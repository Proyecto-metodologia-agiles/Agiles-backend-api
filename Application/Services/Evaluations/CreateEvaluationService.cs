using Application.Requests.Evaluations;
using Application.Response.Evaluations;
using Domain.Contracts;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services.Evaluations
{
    public class CreateEvaluationService
    {

        readonly IUnitOfWork _unitOfWork;


        public CreateEvaluationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public CreateEvaluacionResponse Create(CreateEvaluacionRequest evaluacion)
        {
            try
            {
                Evaluacion evaluacion1 = new Evaluacion()
                {
                    Date = DateTime.Today,
                    //Id = evaluacion.Id,
                    Observation = evaluacion.Observation,
                    ProjectId = evaluacion.ProjectId,
                    Project = _unitOfWork.ProyectoRepository.Find(evaluacion.ProjectId)
                };

                if ("Evaluacion registrada correctamente" == evaluacion1.Verify_Evaluation(evaluacion1))
                {
                    _unitOfWork.EvaluationRepository.Add(evaluacion1);
                    if (_unitOfWork.Commit() > 0)
                    {
                        return new CreateEvaluacionResponse
                        {
                            Evaluacion = evaluacion1,
                            Message = "Creación exitosa",
                            Status = true,
                        };
                    }
                }
                return new CreateEvaluacionResponse
                {
                    Message = "No se pudo crear la evaluación",
                    Status = false,
                    Evaluacion = null,
                };

            }
            catch(Exception e)
            {
                return new CreateEvaluacionResponse
                {
                    Message = e.Message,
                    Status = false,
                    Evaluacion = null,
                };
            }

        }

    }
}
