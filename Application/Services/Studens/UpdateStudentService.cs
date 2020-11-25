using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Domain.Contracts;
using Domain.Entities;

namespace Application.Services.Studens
{
    public class UpdateStudentService
    {
        readonly IUnitOfWork _unitOfWork;
        public UpdateStudentService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public UpdateEstudianteResponse UpdatePassword(UpdateEstudianteRequest request) 
        {
            Estudiante estudiante = _unitOfWork.EstudianteRepository.FindFirstOrDefault(t => t.Cedula == request.Identification.ToString());
            UpdateEstudianteResponse estudiante_response = new UpdateEstudianteResponse();
            if (estudiante == null)
            {

                estudiante_response.Mensaje = "El estudiante con esta identificacion no existe";
                return estudiante_response;
            }
            else 
            {
                if (request.Password.Length >= 15)
                {
                    estudiante.Password = request.Password;
                    estudiante_response.Mensaje = "La clave del estudiante fue actualizada";
                    return estudiante_response;
                }
                else 
                {
                    estudiante_response.Mensaje = "La contraseña minimo debe ser de 15 caracteres";
                    return estudiante_response;
                }
                
            }

        
        }

    }

    public class UpdateEstudianteRequest
    {
       
        public string Password { get; set; }
        public string Identification { get; set; }
    
       
    }
    public class UpdateEstudianteResponse
    {
        public string Mensaje { get; set; }
    }
}
