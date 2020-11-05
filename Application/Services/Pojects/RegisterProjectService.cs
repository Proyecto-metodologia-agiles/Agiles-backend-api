using Domain.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;


namespace Application.Services.Pojects
{
    public class RegisterProjectService
    {
        readonly IUnitOfWork _unitOfWork;

        public RegisterProjectService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CrearProyectoResponse GuardarProyecto(CrearProyectoRequest request, string path)
        {
            Proyecto proyecto = _unitOfWork.ProyectoRepository.FindFirstOrDefault(t => t.Title == request.Title.ToString());
            if (proyecto == null)
            {

                Proyecto proyectoNuevo = new Proyecto();
                proyectoNuevo.Title = request.Title;

                FileInfo fi = new FileInfo(request.Archive.FileName);



                string nameFile = "Archivos/" + DateTime.Now.Ticks.ToString() + fi.Extension;

                string filepatch = Path.Combine(path, nameFile);

                //var filepatch = "C:\\DDDCore3\\Agiles-backend-api\\WebApi\\Archivos\\" + request.Archive.FileName;
                proyectoNuevo.Url_Archive = nameFile;
                proyectoNuevo.Focus = request.Focus;
                proyectoNuevo.Cut = Convert.ToInt32(request.Cut);
                proyectoNuevo.Date = DateTime.Today;
                proyectoNuevo.Line = request.Line;
                //busco el asesor metodologico
                Asesor asesormetodologico = _unitOfWork.AsesorRepository.FindFirstOrDefault(t => t.Identification == request.Metodologic_Advisor);
                proyectoNuevo.Metodologic_Advisor = asesormetodologico;
                //busco el asesor tematico
                Asesor asesormetemaico = _unitOfWork.AsesorRepository.FindFirstOrDefault(t => t.Identification == request.Thematic_Advisor);
                proyectoNuevo.Thematic_Advisor = asesormetemaico;
                //busco estudiante1 
                Estudiante estudiante1 = _unitOfWork.EstudianteRepository.FindFirstOrDefault(t => t.Cedula == request.Student_1);
                //busco estudiante2 si existe o no
                Estudiante estudiante2;
                if (request.Student_2 == null)
                {
                    estudiante2 = null;
                    
                }
                else
                {
                    estudiante2 = _unitOfWork.EstudianteRepository.FindFirstOrDefault(t => t.Cedula == request.Student_2);
                    estudiante2.Estado = 1;
                }

                proyectoNuevo.Student_1 = estudiante1;
                proyectoNuevo.Student_2 = estudiante2;
                proyectoNuevo.State = 0;


                if (proyectoNuevo.Verify_proyecto(proyectoNuevo) == "Proyecto registrado correctamente")
                {
                    estudiante1.Estado = 1;
                
                    _unitOfWork.ProyectoRepository.Add(proyectoNuevo);
                    _unitOfWork.Commit();


                    //muevo el archivo
                    using (var stream = System.IO.File.Create(filepatch))
                    {
                        request.Archive.CopyTo(stream);
                    }
                    //retorno mensaje
                    return new CrearProyectoResponse() { Mensaje = $"Se registro con exito al proyecto: {proyectoNuevo.Title}." };
                }
                else
                {
                    return new CrearProyectoResponse() { Mensaje = "Digite los campos primordiales para el registro" };
                }
            }
            else
            {
                return new CrearProyectoResponse() { Mensaje = $"Un proyecto con ese titulo ya se encuentra registrado" };
            }

        }
    }
    public class CrearProyectoRequest
    {
        public string Title { get; set; }
        public IFormFile Archive { get; set; }
        public string Focus { get; set; }
        public string Cut { get; set; }
        public string Line { get; set; }
        public string Thematic_Advisor { get; set; }
        public string Metodologic_Advisor { get; set; }
        public string Student_1 { get; set; }
        public string Student_2 { get; set; }
    }
    public class CrearProyectoResponse
    {
        public string Mensaje { get; set; }
    }
}
