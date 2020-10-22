using Application.Requests.Pojects;
using Domain.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace Application.Services.Pojects
{
    public class UpdateProjectService
    {
        readonly IUnitOfWork _unitOfWork;

        public UpdateProjectService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public UpdateProjectServiceResponse UpdateFile(UpdateProjectServiceRequest request, string path)
        {
            UpdateProjectServiceResponse response = new UpdateProjectServiceResponse();

            try
            {
               
                Proyecto proyectoNuevo = new Proyecto
                {
                    Id = request.Id
                };

                FileInfo fi = new FileInfo(request.Archive.FileName);
                string nameFile = "Archivos/" + DateTime.Now.Ticks.ToString() + fi.Extension;

                string filepatch = Path.Combine(path, nameFile);
                proyectoNuevo.Url_Archive = nameFile;
                Proyecto proyecto = _unitOfWork.ProyectoRepository.Find(proyectoNuevo.Id);
                proyecto.Url_Archive = proyectoNuevo.Url_Archive;
                if (_unitOfWork.Commit() > 0)
                {
                    using (var stream = File.Create(filepatch))
                    {
                        request.Archive.CopyTo(stream);
                        response.Proyecto = proyecto;
                        response.Status = true;
                        response.Message = $"Se registro con exito al proyecto: {proyectoNuevo.Title}.";
                        return response;
                    }
                }

                response.Proyecto = proyecto;
                response.Status = true;
                response.Message = $"Se actulizo con exito al proyecto: {proyectoNuevo.Title}.";
                return response;
            }catch(Exception e)
            {
                response.Proyecto = null;
                response.Status = true;
                response.Message = e.Message;
                return response;
            }
        }

    }


   
}
