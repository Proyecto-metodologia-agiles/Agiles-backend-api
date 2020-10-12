using System;
using System.Collections.Generic;
using System.Text;
using Domain.Contracts;
using Domain.Entities;



namespace Application.Services.Asesors
{
    public class CrearAsesorService
    {
        readonly IUnitOfWork _unitOfWork;

        public CrearAsesorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CrearAsesorResponse GuardarAsesor(CrearAsesorRequest request) 
        {
            Asesor asesor = _unitOfWork.AsesorRepository.FindFirstOrDefault(t => t.Identification == request.Identification);

            if (asesor == null) 
            {
                Asesor asesorNuevo = new Asesor();
                asesorNuevo.Name_Complet = request.Name_Complet;
                asesorNuevo.Password = request.Password;
                asesorNuevo.Email = request.Email;
                asesorNuevo.Direction = request.Direction;
                asesorNuevo.Type_Asser = request.Type_Asser;
                asesorNuevo.Phone = request.Phone;
                asesorNuevo.Identification = request.Identification;

                if (asesorNuevo.Validar_Asesor(asesorNuevo) == "Asesor registrado correctamente") 
                {
                    _unitOfWork.AsesorRepository.Add(asesorNuevo );
                    _unitOfWork.Commit();
                    return new CrearAsesorResponse() { Mensaje = $"Se registro con exito al asesor {asesorNuevo.Name_Complet}." };
                }
                else
                {
                    return new CrearAsesorResponse() { Mensaje = "Digite los campos primordiales para su registro" };
                }
            }
            else
            {
                return new CrearAsesorResponse() { Mensaje = $"El asesor con ese numero de identificacion ya esta registrado" };
            }

        }



    }

    public class CrearAsesorRequest
    {
        public string Name_Complet { get; set; }   
        public string Password { get; set; }
        public string Email { get; set; }
        public string Identification { get; set; }
        public string Type_Asser { get; set; }
        public string Phone { get; set; }
        public string Direction { get; set; }
    }
    public class CrearAsesorResponse
    {
        public string Mensaje { get; set; }
    }
}
