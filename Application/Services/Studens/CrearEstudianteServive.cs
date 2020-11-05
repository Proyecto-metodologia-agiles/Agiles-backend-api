using Domain.Contracts;
using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Application.Services
{
    public class CrearEstudianteServive
    {
        readonly IUnitOfWork _unitOfWork;

        public CrearEstudianteServive(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CrearEstudianteResponse GuardarEstudiante(CrearEstudianteRequest request)
        {
            Estudiante estudiante = _unitOfWork.EstudianteRepository.FindFirstOrDefault(t => t.Cedula == request.Cedula.ToString());
            if (estudiante == null)
            {
                Estudiante estudianteNuevo = new Estudiante();
                estudianteNuevo.Cedula = request.Cedula;
                estudianteNuevo.Celular = request.Celular;
                estudianteNuevo.Correo = request.Correo;
                estudianteNuevo.Edad = request.Edad;
                estudianteNuevo.Semestre = request.Semestre;
                estudianteNuevo.NombreCompleto = request.NombreCompleto;
                estudianteNuevo.Password = request.Password;
                estudianteNuevo.Estado = 0;

                if (estudianteNuevo.ValidarEstudiante(estudianteNuevo) == "Registrado correctamente")
                {
                    _unitOfWork.EstudianteRepository.Add(estudianteNuevo);
                    _unitOfWork.Commit();
                    return new CrearEstudianteResponse() { Mensaje = $"Se registro con exito al estudiante {estudianteNuevo.NombreCompleto}." };
                }
                else
                {
                    return new CrearEstudianteResponse() { Mensaje = "Digite los campos primordiales para su registro" };
                }
            }
            else
            {
                return new CrearEstudianteResponse() { Mensaje = $"El estudiante con ese numero de cedula ya esta registrado" };
            }
        }

    }


    public class CrearEstudianteRequest
    {
        public string NombreCompleto { get; set; }
        [MaxLength(10)]
        [RegularExpression("([0-9]+)")]
        public string Cedula { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
        [MaxLength(10)]
        [RegularExpression("([0-9]+)")]
        public string Celular { get; set; }
        public int Edad { get; set; }
        public string Semestre { get; set; }
    }
    public class CrearEstudianteResponse
    {
        public string Mensaje { get; set; }
    }
}
