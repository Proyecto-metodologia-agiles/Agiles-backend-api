using Application.Mailers;
using Application.Requests.Rating;
using Application.Response.Rating;
using Domain.Contracts;
using Domain.Entities;
using Infrastructure.Mailers.Entities;
using Infrastructure.Mailers.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Services.Rating
{
    public class CreateValoracionService
    {
        readonly IUnitOfWork _unitOfWork;


        public CreateValoracionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public CreateValoracionResponse Create(CreateValoracionRequest valoracion)
        {
            try
            {
                Valoracion valoracion1 = new Valoracion()
                {
                    Date = DateTime.Today,
                    Observation = valoracion.Observation,
                    ProjectId = valoracion.ProjectId,
                    Project = _unitOfWork.ProyectoRepository.FindBy(x => x.Id == valoracion.ProjectId, includeProperties: "Thematic_Advisor,Metodologic_Advisor,Student_1,Student_2").FirstOrDefault(),
                    Valoration = valoracion.Valoration
                    
                };

                if ("Valoracion registrada correctamente" == valoracion1.Verify_Valoration(valoracion1))
                {

                    ObjectMailer objectMailer = new ObjectMailer()
                    {

                        MailerFroms = new List<MailerFrom>
                        {
                            new MailerFrom
                            {
                                Email = valoracion1.Project.Student_1.Correo,
                                Name = valoracion1.Project.Student_1.NombreCompleto,
                            }
                        },
                        Subject = "Valoracion de proyecto por parte de asesor",
                        //TextBody = //"ejemplo",
                        Templante = Theme.Plantilla(new Plantilla
                        {
                            Celular = valoracion1.Project.Student_1.Celular,
                            Correo = valoracion1.Project.Student_1.Correo,
                            //Horas = AsesoriaNueva.AssignedHours.ToString(),
                            NombreCompleto = valoracion1.Project.Student_1.NombreCompleto,
                            TituloProyecto = valoracion1.Project.Title
                        }, 2),
                    };
                    SendMailer.Send(objectMailer);

                    //estudiante 2

                    objectMailer = new ObjectMailer()
                    {

                        MailerFroms = new List<MailerFrom>
                        {
                            new MailerFrom
                            {
                                Email = valoracion1.Project.Student_2.Correo,
                                Name = valoracion1.Project.Student_2.NombreCompleto,
                            }
                        },
                        Subject = "Valoracion de proyecto por parte de asesor",
                        //TextBody = //"ejemplo",
                        Templante = Theme.Plantilla(new Plantilla
                        {
                            Celular = valoracion1.Project.Student_2.Celular,
                            Correo = valoracion1.Project.Student_2.Correo,
                            //Horas = AsesoriaNueva.AssignedHours.ToString(),
                            NombreCompleto = valoracion1.Project.Student_2.NombreCompleto,
                            TituloProyecto = valoracion1.Project.Title
                        }, 2),
                    };

                    SendMailer.Send(objectMailer);

                    _unitOfWork.ValorationRepository.Add(valoracion1);
                    if (_unitOfWork.Commit() > 0)
                    {
                        return new CreateValoracionResponse
                        {
                            Valoracion = valoracion1,
                            Message = "Creación exitosa",
                            Status = true,
                        };
                    }
                }
                return new CreateValoracionResponse
                {
                    Message = "No se pudo crear la evaluación",
                    Status = false,
                    Valoracion = null,
                };

            }
            catch (Exception e)
            {
                return new CreateValoracionResponse
                {
                    Message = e.Message,
                    Status = false,
                    Valoracion = null,
                };
            }

        }

    }
}
