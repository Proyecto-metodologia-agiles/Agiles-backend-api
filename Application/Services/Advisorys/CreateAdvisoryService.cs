using Domain.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;


namespace Application.Services.Advisorys
{
    public class CreateAdvisoryService
    {
        readonly IUnitOfWork _unitOfWork;

        public CreateAdvisoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CreateAdvisoryResponse GuardarAdvisory(CreateAdvisoryRequest request)
        {
            Proyecto proyecto = _unitOfWork.ProyectoRepository.FindFirstOrDefault(t => t.Id == request.IdProyecto);

            Asesor asesormetodologico = _unitOfWork.AsesorRepository.FindFirstOrDefault(t => t.Id == request.IdMetodologicAdvisor);
           
            Asesor asesormetemaico = _unitOfWork.AsesorRepository.FindFirstOrDefault(t => t.Id == request.IdThematicAdvisor);

            Advisory Asesoria = _unitOfWork.AdvisoryRepository.FindFirstOrDefault(t => t.Proyect.Id == request.IdProyecto);


            if (Asesoria == null)
            {
                Advisory AsesoriaNueva = new Advisory();

                AsesoriaNueva.AssignedHours = request.AssignedHours;
                AsesoriaNueva.MetodologicAdvisor = asesormetodologico;
                AsesoriaNueva.Proyect = proyecto;
                AsesoriaNueva.semester = request.semester;
                AsesoriaNueva.ThematicAdvisor = asesormetemaico;
                AsesoriaNueva.Year = request.Year;

                if ( AsesoriaNueva.Verify_advisory(AsesoriaNueva) == 1)
                {
                    _unitOfWork.AdvisoryRepository.Add(AsesoriaNueva);
                    _unitOfWork.Commit();
                  
                    return new CreateAdvisoryResponse() { Mensaje = $"Se registro con exito la asesoria al proyecto: {AsesoriaNueva.Proyect.Title}." };
                }
                else
                {
                    return new CreateAdvisoryResponse() { Mensaje = "Digite los campos primordiales para el registro" };
                }
            }
            else
            {
                return new CreateAdvisoryResponse() { Mensaje = $"Este proyecto cuenta con asesorias registradas" };
            }

        }
    }

    public class CreateAdvisoryRequest
    {
        public int  IdProyecto  { get; set; }
        public int IdThematicAdvisor  { get; set; }
        public int  IdMetodologicAdvisor  { get; set; }
        public int AssignedHours { get; set; }
        public String semester { get; set; }
        public String Year { get; set; }
    }
    public class CreateAdvisoryResponse
    {
        public string Mensaje { get; set; }
    }
}
