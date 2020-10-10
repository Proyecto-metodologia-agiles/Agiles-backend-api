using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Domain.Contracts;
using Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        public ActionResult<CrearEstudianteResponse> Post(CrearEstudianteRequest request)
        {
            CrearEstudianteServive _service = new CrearEstudianteServive(_unitOfWork);
            CrearEstudianteResponse response = _service.GuardarEstudiante(request);
            return Ok(response);
        }

    }
}
