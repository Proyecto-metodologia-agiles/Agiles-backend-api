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
    public class ValorationController : ControllerBase
    {
        readonly ProyectoContext _context;
        readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _appEnvironment;



        public ValorationController(ProyectoContext context, IUnitOfWork unitOfWork, IWebHostEnvironment appEnvironment)
        {
            _unitOfWork = unitOfWork;
            _context = context;
            _appEnvironment = appEnvironment;
        }

        [HttpGet("[action]")]
        public ActionResult<IEnumerable<Valoracion>> ValorationsStudent(string identification)
        {
            ConsultValoracionService servicio = new ConsultValoracionService(_unitOfWork);
            List<Valoracion> Lista = servicio.GetId(identification);
            return Ok(Lista);

        }

        [HttpGet("[action]")]
        public ActionResult<IEnumerable<Valoracion>> ValorationsAll()
        {
            ConsultValoracionService servicio = new ConsultValoracionService(_unitOfWork);
            List<Valoracion> Lista = servicio.GetAll();
            return Ok(Lista);

        }
    }
}
