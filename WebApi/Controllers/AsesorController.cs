﻿using Application.Services.Asesors;
using Application.Services.Studens;
using Domain.Contracts;
using Domain.Entities;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;


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


        [HttpGet("[action]")]
        public IEnumerable<Asesor> Asesores()
        {
            ConsultAsesorService servicio = new ConsultAsesorService(_unitOfWork);
            List<Asesor> Lista = servicio.GetAll();
            return Lista;
        }

        [HttpGet("[action]")]
        public IEnumerable<Asesor> AsesoresTematicos()
        {
            ConsultAsesorService servicio = new ConsultAsesorService(_unitOfWork);
            List<Asesor> Lista = servicio.GetThematic();
            return Lista;
        }

        [HttpGet("[action]")]
        public IEnumerable<Asesor> AsesoresMetodologicos()
        {
            ConsultAsesorService servicio = new ConsultAsesorService(_unitOfWork);
            List<Asesor> Lista = servicio.GetMetodologic();
            return Lista;
        }


        [HttpGet("[action]")]
        public IEnumerable<Asesor> AsesoresProject()
        {
            ConsultAsesorService servicio = new ConsultAsesorService(_unitOfWork);
            List<Asesor> Lista = servicio.GetMetodologic();
            return Lista;
        }

        [HttpGet("[action]")]
        public ActionResult<Asesor> GetAsesor(uint id)
        {

            if(id == 0)
            {
                return BadRequest(new
                {
                    Status = false,
                    Message = "Id requerido", 
                });;
            }

            ConsultAsesorService servicio = new ConsultAsesorService(_unitOfWork);
            Asesor Lista = servicio.GetProyectos(Convert.ToInt32(id));
            if(Lista == null)
            {
                return BadRequest(new
                {
                    Status = false,
                    Message = "no hay datos que mostrar",
                }); ;
            }
            return Ok(Lista);
        }
    }
}
