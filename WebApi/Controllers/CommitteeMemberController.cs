﻿using Application.Handles.Commite;
using Application.Services.Committee;
using Application.Services.Studens;
using Domain.Contracts;
using Domain.Entities;
using Domain.Entities.Enums;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommitteeMemberController : ControllerBase
    {
        private readonly ProyectoContext _context;
        private readonly IUnitOfWork _unitOfWork;



        public CommitteeMemberController(ProyectoContext context, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _context = context;

        }

        [HttpPost("[action]")]
        public ActionResult<CreateCommitteeMemberResponse> Post(CreateCommitteeMemberRequest request)
        {


            try
            {
                CreateCommitteeMemberService _service = new CreateCommitteeMemberService(_unitOfWork, _unitOfWork.CommitteeMemberRepository);
                CreateCommitteeMemberResponse response = _service.Create(request);


                if (response.RegisterValid == EnumStatusRegisterCommitteMember.Success)
                {
                    return Ok(response);
                }
                return BadRequest(response);
            }
            catch (Exception e)
            {

                CreateCommitteeMemberResponse response = new CreateCommitteeMemberResponse
                {
                    Message = e.Message,
                    RegisterValid = EnumStatusRegisterCommitteMember.Error,
                    Status = false
                };
                return BadRequest(response);
            }


        }

        [HttpGet("[action]")]
        public IEnumerable<CommitteeMember> MiembrosComite()
        {
            ConsultMemberService servicio = new ConsultMemberService(_unitOfWork);
            List<CommitteeMember> Lista = servicio.GetAll();
            return Lista;
        }

    }
}
