using Application.Services.Advisorys;
using Domain.Contracts;
using Domain.Entities;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvisoryController : ControllerBase
    {
        readonly ProyectoContext _context;
        readonly IUnitOfWork _unitOfWork;
        private readonly AppSettings _appSettings;

        public AdvisoryController(IOptions<AppSettings> appSettings, ProyectoContext context, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _context = context;
            _appSettings = appSettings.Value;
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
