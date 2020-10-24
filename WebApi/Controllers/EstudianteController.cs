using Application.Services;
using Application.Services.Studens;
using Domain.Contracts;
using Domain.Entities;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteController : ControllerBase
    {
        readonly ProyectoContext _context;
        readonly IUnitOfWork _unitOfWork;

        //Se Recomienda solo dejar la Unidad de Trabajo
        public EstudianteController(ProyectoContext context, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        [HttpPost("[action]")]
        public ActionResult<CrearEstudianteResponse> Post(CrearEstudianteRequest request)
        {
            CrearEstudianteServive _service = new CrearEstudianteServive(_unitOfWork);
            CrearEstudianteResponse response = _service.GuardarEstudiante(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public IEnumerable<Estudiante> Estudiantes()
        {
            consultStudentService servicio = new consultStudentService(_unitOfWork);
            List<Estudiante> Lista = servicio.GetAll();
            return Lista;

        }

        [HttpGet("[action]")]
        public IEnumerable<Estudiante> EstudiantesSinProyecto()
        {
            consultStudentService servicio = new consultStudentService(_unitOfWork);
            List<Estudiante> Lista = servicio.GetEstate0();
            return Lista;

        }
    }
}
