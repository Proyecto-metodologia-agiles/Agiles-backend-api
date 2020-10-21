using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Handles.Commite;
using Application.Services.Pojects;
using Domain.Contracts;
using Domain.Entities;
using Domain.Entities.Enums;
using Infrastructure;
using Infrastructure.Base;
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        readonly ProyectoContext _context;
        readonly IUnitOfWork _unitOfWork;

        public ProjectController(ProyectoContext context, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        [HttpPost("[action]")]
        public ActionResult<CrearProyectoResponse> Post([FromForm] CrearProyectoRequest request)
        {
            RegisterProjectService _service = new RegisterProjectService(_unitOfWork);
            CrearProyectoResponse response = _service.GuardarProyecto(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public IEnumerable<Proyecto> Proyectos()
        {
            ConsulProjectService servicio = new ConsulProjectService(_unitOfWork);
            List<Proyecto> Lista = servicio.GetAll();
            return Lista;

        }
    }
}
