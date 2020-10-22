using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Handles.Commite;
using Application.Services.Advisorys;
using Application.Services.Committee;
using Application.Services.Studens;
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
    public class AdvisoryController : ControllerBase
    {
        readonly ProyectoContext _context;
        readonly IUnitOfWork _unitOfWork;

        public AdvisoryController(ProyectoContext context, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        [HttpPost("[action]")]
        public ActionResult<CreateAdvisoryResponse> Post(CreateAdvisoryRequest request)
        {
            CreateAdvisoryService _service = new CreateAdvisoryService(_unitOfWork);
            CreateAdvisoryResponse response = _service.GuardarAdvisory(request);
            return Ok(response);
        }


        [HttpGet("[action]")]
        public IEnumerable<Advisory> Asesorias()
        {
            ConsultAdvisoryService servicio = new ConsultAdvisoryService(_unitOfWork);
            List<Advisory> Lista = servicio.GetAll();
            return Lista;
        }

    }
}
