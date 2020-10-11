using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Handles.Commite;
using Application.Services.Committee;
using Domain.Contracts;
using Domain.Entities;
using Domain.Entities.Enums;
using Infrastructure;
using Infrastructure.Base;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        public ActionResult<CreateCommitteeMemberResponse> Post(CreateCommitteeMemberRequest request)
        {

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    CreateCommitteeMemberService _service = new CreateCommitteeMemberService(_unitOfWork, _unitOfWork.CommitteeMemberRepository);
                    CreateCommitteeMemberResponse response = _service.Create(request);

                    transaction.Commit(); //crea la transacion
                    if (response.RegisterValid == EnumStatusRegisterCommitteMember.Success)
                    {
                        return Ok(response);
                    }
                    return BadRequest(response);
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    CreateCommitteeMemberResponse response = new CreateCommitteeMemberResponse
                    {
                        Message = e.Message,
                        RegisterValid = EnumStatusRegisterCommitteMember.Error,
                        Status = false
                    };
                    return BadRequest(response);
                }
            }

        }

    }
}
