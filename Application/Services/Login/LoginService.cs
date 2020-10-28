using Application.Requests.Login;
using Application.Response.Login;
using Domain.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Http.Features;
using System.Collections.Generic;
using System.Linq;
namespace Application.Services.Login
{
    public class LoginService
    {
        readonly IUnitOfWork _unitOfWork;


        public LoginService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
 

        public LoginResponse Acceder(LoginRequest request)
        {
            LoginResponse response = new LoginResponse();
            
            var res = _unitOfWork.EstudianteRepository.FindFirstOrDefault(t => t.Correo == request.Username && t.Password == request.Password);
            if (res != null)
            {
                response.Email = res.Correo;
                response.Idetification = res.Cedula;
                response.Id = res.Id.ToString();
                response.Type = "Estudiante";
                response.Telephone = res.Celular;
                response.Name = res.NombreCompleto;
                response.Message = "Bienvenido: " + res.NombreCompleto;
                return response;
            }
            else
            {
                var res2 = _unitOfWork.AsesorRepository.FindFirstOrDefault(t => t.Email == request.Username && t.Password == request.Password);
                if (res2 != null)
                {
                    response.Email = res2.Email;
                    response.Idetification = res2.Identification;
                    response.Id = res2.Id.ToString();
                    response.Type = "Asesor";
                    response.Telephone = res2.Phone;
                    response.Name = res2.Name_Complet;
                    response.Message = "Bienvenido: " + res2.Name_Complet;
                    return response;
                }
                else
                {
                    var res3 = _unitOfWork.CommitteeMemberRepository.FindFirstOrDefault(t => t.Email == request.Username && t.Password == request.Password);
                    if (res3 != null)
                    {
                        response.Email = res3.Email;
                        response.Idetification = res3.Identification;
                        response.Id = res3.Id.ToString();
                        response.Type = "Miembro Comite";
                        response.Telephone = res3.Phone;
                        response.Name = res3.FullName;
                        response.Message = "Bienvenido: " + res3.FullName;
                        return response;
                    }
                    else
                    {
                        response.Message = "Verifique sus datos de acceso";
                        return response;
                    }
                }
            }        
        }
    }
}
