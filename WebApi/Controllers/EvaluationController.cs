using Application.Requests.Evaluations;
using Application.Requests.Pojects;
using Application.Requests.Rating;
using Application.Response.Evaluations;
using Application.Response.Rating;
using Application.Services.Evaluations;
using Application.Services.Pojects;
using Application.Services.Rating;
using Domain.Contracts;
using Domain.Entities;
using Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EvaluationController : ControllerBase
    {
        readonly ProyectoContext _context;
        readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _appEnvironment;



        public EvaluationController(ProyectoContext context, IUnitOfWork unitOfWork, IWebHostEnvironment appEnvironment)
        {
            _unitOfWork = unitOfWork;
            _context = context;
            _appEnvironment = appEnvironment;
        }

        [HttpGet("[action]")]
        public ActionResult<IEnumerable<Evaluacion>> EvaluationsStudent(string identification)
        {
            ConsultEvaluationService servicio = new ConsultEvaluationService(_unitOfWork);
            List<Evaluacion> Lista = servicio.GetId(identification);
            return Ok(Lista);

        }

        [HttpGet("[action]")]
        public ActionResult<IEnumerable<Evaluacion>> EvaluationsAll()
        {
            ConsultEvaluationService servicio = new ConsultEvaluationService(_unitOfWork);
            List<Evaluacion> Lista = servicio.GetAll();
            return Ok(Lista);

        }
    }
}
