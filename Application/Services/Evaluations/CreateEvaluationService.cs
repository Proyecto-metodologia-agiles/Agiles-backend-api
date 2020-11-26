using Application.Mailers;
using Application.Requests.Evaluations;
using Application.Response.Evaluations;
using Domain.Contracts;
using Domain.Entities;
using Infrastructure.Mailers.Entities;
using Infrastructure.Mailers.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Services.Evaluations
{
    public class CreateEvaluationService
    {

        readonly IUnitOfWork _unitOfWork;


        public CreateEvaluationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public CreateEvaluacionResponse Create(CreateEvaluacionRequest evaluacion)
        {
            try
            {
                Evaluacion evaluacion1 = new Evaluacion()
                {
                    Date = DateTime.Today,
                    //Id = evaluacion.Id,
                    Observation = evaluacion.Observation,
                    ProjectId = evaluacion.ProjectId,
                    Project = _unitOfWork.ProyectoRepository.FindBy(x => x.Id == evaluacion.ProjectId, includeProperties: "Thematic_Advisor,Metodologic_Advisor,Student_1,Student_2").FirstOrDefault(),
            };

                 

                if ("Evaluacion registrada correctamente" == evaluacion1.Verify_Evaluation(evaluacion1))
                {
                    _unitOfWork.EvaluationRepository.Add(evaluacion1);
                    if (_unitOfWork.Commit() > 0)
                    {

                        //estudiante 1
                        

                        ObjectMailer objectMailer = new ObjectMailer()
                        {

                            MailerFroms = new List<MailerFrom>
                        {
                            new MailerFrom
                            {
                                Email = evaluacion1.Project.Student_1.Correo,
                                Name = evaluacion1.Project.Student_1.NombreCompleto,
                            }
                        },
                            Subject = "Evaluacion de proyecto por el comite",
                            //TextBody = //"ejemplo",
                            Templante = Theme.Plantilla(new Plantilla
                            {
                                Celular = evaluacion1.Project.Student_1.Celular,
                                Correo = evaluacion1.Project.Student_1.Correo,
                                //Horas = AsesoriaNueva.AssignedHours.ToString(),
                                NombreCompleto = evaluacion1.Project.Student_1.NombreCompleto,
                                TituloProyecto = evaluacion1.Project.Title
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
                                Email = evaluacion1.Project.Student_2.Correo,
                                Name = evaluacion1.Project.Student_2.NombreCompleto,
                            }
                        },
                            Subject = "Evaluacion de proyecto por el comite",
                            //TextBody = //"ejemplo",
                            Templante = Theme.Plantilla(new Plantilla
                            {
                                Celular = evaluacion1.Project.Student_2.Celular,
                                Correo = evaluacion1.Project.Student_2.Correo,
                                //Horas = AsesoriaNueva.AssignedHours.ToString(),
                                NombreCompleto = evaluacion1.Project.Student_2.NombreCompleto,
                                TituloProyecto = evaluacion1.Project.Title
                            }, 2),
                        };

                        SendMailer.Send(objectMailer);

                        return new CreateEvaluacionResponse
                        {
                            Evaluacion = evaluacion1,
                            Message = "Creación exitosa",
                            Status = true,
                        };
                    }
                }
                return new CreateEvaluacionResponse
                {
                    Message = "No se pudo crear la evaluación",
                    Status = false,
                    Evaluacion = null,
                };

            }
            catch(Exception e)
            {
                return new CreateEvaluacionResponse
                {
                    Message = e.Message,
                    Status = false,
                    Evaluacion = null,
                };
            }

        }

    }
}
