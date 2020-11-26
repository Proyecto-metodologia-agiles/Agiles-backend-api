﻿using Application.Mailers;
using Domain.Contracts;
using Domain.Entities;
using Infrastructure.Mailers.Entities;
using Infrastructure.Mailers.Events;
using System;
using System.Collections.Generic;

namespace Application.Services.Advisorys
{
    public class CreateAdvisoryService
    {
        readonly IUnitOfWork _unitOfWork;

        public CreateAdvisoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CreateAdvisoryResponse GuardarAdvisory(CreateAdvisoryRequest request)
        {
            Proyecto proyecto = _unitOfWork.ProyectoRepository.FindFirstOrDefault(t => t.Title == request.TituloProyecto);

            Asesor asesormetodologico = _unitOfWork.AsesorRepository.FindFirstOrDefault(t => t.Identification == request.IdMetodologicAdvisor);

            Asesor asesormetemaico = _unitOfWork.AsesorRepository.FindFirstOrDefault(t => t.Identification == request.IdThematicAdvisor);

            Advisory Asesoria = _unitOfWork.AdvisoryRepository.FindFirstOrDefault(t => t.Proyect.Title == request.TituloProyecto);


            if (Asesoria == null)
            {
                Advisory AsesoriaNueva = new Advisory();

                AsesoriaNueva.AssignedHours = request.AssignedHours;
                AsesoriaNueva.MetodologicAdvisor = asesormetodologico;
                AsesoriaNueva.Proyect = proyecto;
                AsesoriaNueva.semester = request.semester;
                AsesoriaNueva.ThematicAdvisor = asesormetemaico;
                AsesoriaNueva.Year = DateTime.Today.Year.ToString();

                //modifico el registro proyecto 
                proyecto.Thematic_Advisor = asesormetemaico;
                proyecto.Metodologic_Advisor = asesormetodologico;

               

                proyecto.State = 1;

                if (AsesoriaNueva.Verify_advisory(AsesoriaNueva) == 1)
                {

                    //send thematic

                    ObjectMailer objectMailer = new ObjectMailer()
                    {

                        MailerFroms = new List<MailerFrom>
                    {
                        new MailerFrom
                        {
                            Email = asesormetemaico.Email,
                            Name = asesormetemaico.Name_Complet,
                        }
                    },
                        Subject = "Asignación de asesoria",
                        //TextBody = //"ejemplo",
                        Templante = Theme.Plantilla(new Plantilla
                        {
                            Celular = asesormetemaico.Phone,
                            Correo = asesormetemaico.Email,
                            Horas = AsesoriaNueva.AssignedHours.ToString(),
                            NombreCompleto = asesormetemaico.Name_Complet,
                            TituloProyecto = proyecto.Title
                        }, 1),
                    };
                    SendMailer.Send(objectMailer);


                    //send Metodologic

                    objectMailer = new ObjectMailer()
                    {

                        MailerFroms = new List<MailerFrom>
                    {
                        new MailerFrom
                        {
                            Email = asesormetodologico.Email,
                            Name = asesormetodologico.Name_Complet,
                        }
                    },
                        Subject = "Asignación de asesoria",
                        //TextBody = //"ejemplo",
                        Templante = Theme.Plantilla(new Plantilla
                        {
                            Celular = asesormetodologico.Phone,
                            Correo = asesormetodologico.Email,
                            Horas = AsesoriaNueva.AssignedHours.ToString(),
                            NombreCompleto = asesormetodologico.Name_Complet,
                            TituloProyecto = proyecto.Title
                        }, 1),
                    };
                    SendMailer.Send(objectMailer);

                    _unitOfWork.AdvisoryRepository.Add(AsesoriaNueva);
                    _unitOfWork.Commit();

                    return new CreateAdvisoryResponse() { Mensaje = $"Se registro con exito la asesoria al proyecto: {AsesoriaNueva.Proyect.Title}." };
                }
                else
                {
                    return new CreateAdvisoryResponse() { Mensaje = "Digite los campos primordiales para el registro" };
                }
            }
            else
            {
                return new CreateAdvisoryResponse() { Mensaje = $"Este proyecto cuenta con asesorias registradas" };
            }

        }
    }

    public class CreateAdvisoryRequest
    {
        public string TituloProyecto { get; set; }
        public string IdThematicAdvisor { get; set; }
        public string IdMetodologicAdvisor { get; set; }
        public int AssignedHours { get; set; }
        public string semester { get; set; }
   
    }
    public class CreateAdvisoryResponse
    {
        public string Mensaje { get; set; }
    }
}
