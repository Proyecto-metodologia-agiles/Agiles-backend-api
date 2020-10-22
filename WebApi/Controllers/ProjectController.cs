using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Handles.Commite;
using Application.Requests.Pojects;
using Application.Services.Pojects;
using Domain.Contracts;
using Domain.Entities;
using Domain.Entities.Enums;
using Infrastructure;
using Infrastructure.Base;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        readonly ProyectoContext _context;
        readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _appEnvironment;


        public ProjectController(ProyectoContext context, IUnitOfWork unitOfWork, IWebHostEnvironment appEnvironment)
        {
            _unitOfWork = unitOfWork;
            _context = context;
            _appEnvironment = appEnvironment;
        }

        [HttpPost("[action]")]
        public ActionResult<CrearProyectoResponse> Post([FromForm] CrearProyectoRequest request)
        {
            RegisterProjectService _service = new RegisterProjectService(_unitOfWork);
            CrearProyectoResponse response = _service.GuardarProyecto(request, _appEnvironment.ContentRootPath);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public ActionResult<IEnumerable<Proyecto>> Proyectos()
        {
            ConsulProjectService servicio = new ConsulProjectService(_unitOfWork);
            List<Proyecto> Lista = servicio.GetAll();
            Lista.ForEach(x =>
            {
                x.Url_Archive = Request.Host + "/" + x.Url_Archive;
            });

            return Ok(Lista);

        }


        [HttpPut("[action]")]
        public ActionResult<CrearProyectoResponse> Pust([FromForm] UpdateProjectServiceRequest request)
        {
            UpdateProjectService _service = new UpdateProjectService(_unitOfWork);
            UpdateProjectServiceResponse response = _service.UpdateFile(request, _appEnvironment.ContentRootPath);
            return Ok(response);
        }


    }
}
