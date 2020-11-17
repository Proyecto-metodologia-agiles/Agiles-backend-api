using Application.Requests.Announcement;
using Application.Response.Announcement;
using Domain.Contracts;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services.Announcements
{
    public class AnnouncementSaveService
    {
        readonly IUnitOfWork _unitOfWork;


        public AnnouncementSaveService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public AnnouncementResponse GuardarAnnouncement(AnnouncementRequest request)
        {
            Announcement announcement = _unitOfWork.AnnouncementRepository.FindFirstOrDefault(t => t.DateOne == request.DateOne || t.DateTwo == request.DateTwo);

            if (announcement == null)
            {
                Announcement announcementNuevo  = new Announcement();
                announcementNuevo.DateOne = request.DateOne;
                announcementNuevo.DateTwo = request.DateTwo;

                if (announcementNuevo.Verify_dates(announcementNuevo) == 1 )
                {
                    _unitOfWork.AnnouncementRepository.Add(announcementNuevo);
                    _unitOfWork.Commit();
                    return new AnnouncementResponse()
                    {
                        Message = $"Se establecio con exito la fecha que va desde {announcementNuevo.DateOne} hasta {announcementNuevo.DateTwo}.",
                        Status = true
                    };
                }
                else
                {
                    return new AnnouncementResponse() {
                        Message = "Elija la fecha de inicio y la fecha de finalizacion",
                        Status = false
                    };
                }
            }
            else
            {
                return new AnnouncementResponse() {
                    Message = $"El intervalo de tiempo con esas dos fechas ya se encuentra registrado",
                    Status = false
                };
            }

        }
    }
}
