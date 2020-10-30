using Application.Requests.Login;
using Application.Response.Login;
using Application.Services.Login;
using Domain.Contracts;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly ProyectoContext _context;
        readonly IUnitOfWork _unitOfWork;

        public UserController(ProyectoContext context, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        [HttpPost("[action]")]
        public ActionResult<LoginResponse> Login(LoginRequest request)
        {
            LoginService _service = new LoginService(_unitOfWork);
            LoginResponse response = _service.Acceder(request);
            if (response.Fail)
            {
                return BadRequest(response);

            }
            return Ok(response);
        }

    }
}
