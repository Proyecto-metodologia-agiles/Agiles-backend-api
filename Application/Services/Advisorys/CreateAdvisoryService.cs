using Domain.Contracts;
using Domain.Entities;
using System;


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
            Proyecto proyecto = _unitOfWork.ProyectoRepository.FindFirstOrDefault(t => t.Title == request.TituloProyecto);

            Asesor asesormetodologico = _unitOfWork.AsesorRepository.FindFirstOrDefault(t => t.Identification == request.IdMetodologicAdvisor);

            Asesor asesormetemaico = _unitOfWork.AsesorRepository.FindFirstOrDefault(t => t.Identification == request.IdThematicAdvisor);

            Advisory Asesoria = _unitOfWork.AdvisoryRepository.FindFirstOrDefault(t => t.Proyect.Title == request.TituloProyecto);


            if (Asesoria == null)
            {
                Advisory AsesoriaNueva = new Advisory();

                AsesoriaNueva.AssignedHours = request.AssignedHours;
                AsesoriaNueva.MetodologicAdvisor = asesormetodologico;
                AsesoriaNueva.Proyect = proyecto;
                AsesoriaNueva.semester = request.semester;
                AsesoriaNueva.ThematicAdvisor = asesormetemaico;
                AsesoriaNueva.Year = DateTime.Today.Year.ToString();

                proyecto.Thematic_Advisor = asesormetemaico;
                proyecto.Metodologic_Advisor = asesormetodologico;

                if (AsesoriaNueva.Verify_advisory(AsesoriaNueva) == 1)
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
        public string TituloProyecto { get; set; }
        public string IdThematicAdvisor { get; set; }
        public string IdMetodologicAdvisor { get; set; }
        public int AssignedHours { get; set; }
        public string semester { get; set; }
   
    }
    public class CreateAdvisoryResponse
    {
        public string Mensaje { get; set; }
    }
}
