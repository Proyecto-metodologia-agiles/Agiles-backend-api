using Application.Requests.Announcement;
using Application.Response.Announcement;
using Application.Services.Advisorys;
using Application.Services.Announcements;
using Domain.Contracts;
using Domain.Entities;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementController : ControllerBase
    {
        readonly ProyectoContext _context;
        readonly IUnitOfWork _unitOfWork;

        public AnnouncementController(ProyectoContext context, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        [HttpPost("[action]")]
        public ActionResult<AnnouncementResponse> Post(AnnouncementRequest request)
        {
            AnnouncementSaveService _service = new AnnouncementSaveService(_unitOfWork);
            AnnouncementResponse response = _service.GuardarAnnouncement(request);
            return Ok(response);
        }
    }
}
