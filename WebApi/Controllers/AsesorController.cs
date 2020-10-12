using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Handles.Commite;
using Application.Services.Asesors;
using Application.Services.Committee;
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
    public class AsesorController : ControllerBase
    {
        readonly ProyectoContext _context;
        readonly IUnitOfWork _unitOfWork;

        public AsesorController(ProyectoContext context, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }
        [HttpPost("[action]")]
        public ActionResult<CrearAsesorResponse> Post(CrearAsesorRequest request)
        {
            CrearAsesorService _service = new CrearAsesorService(_unitOfWork);
            CrearAsesorResponse response = _service.GuardarAsesor(request);
            return Ok(response);
        }
    }
}
