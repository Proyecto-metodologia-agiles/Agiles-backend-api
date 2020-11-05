using Application.Requests.Rating;
using Application.Response.Rating;
using Domain.Contracts;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services.Rating
{
    public class CreateValoracionService
    {
        readonly IUnitOfWork _unitOfWork;


        public CreateValoracionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public CreateValoracionResponse Create(CreateValoracionRequest valoracion)
        {
            try
            {
                Valoracion valoracion1 = new Valoracion()
                {
                    Date = valoracion.Date,
                    //Id = evaluacion.Id,
                    Observation = valoracion.Observation,
                    ProjectId = valoracion.ProjectId,
                    Project = _unitOfWork.ProyectoRepository.Find(valoracion.ProjectId),
                    Valoration = valoracion.Valoration
                    
                };

                if ("Valoracion registrada correctamente" == valoracion1.Verify_Valoration(valoracion1))
                {
                    _unitOfWork.ValorationRepository.Add(valoracion1);
                    if (_unitOfWork.Commit() > 0)
                    {
                        return new CreateValoracionResponse
                        {
                            Valoracion = valoracion1,
                            Message = "Creación exitosa",
                            Status = true,
                        };
                    }
                }
                return new CreateValoracionResponse
                {
                    Message = "No se pudo crear la evaluación",
                    Status = false,
                    Valoracion = null,
                };

            }
            catch (Exception e)
            {
                return new CreateValoracionResponse
                {
                    Message = e.Message,
                    Status = false,
                    Valoracion = null,
                };
            }

        }

    }
}
