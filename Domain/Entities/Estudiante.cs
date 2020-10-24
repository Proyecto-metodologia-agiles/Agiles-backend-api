using Domain.Base;

namespace Domain.Entities
{
    public class Estudiante : Entity<int>, Ipersona
    {
        public string NombreCompleto { get; set; }
        public string Cedula { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
        public string Celular { get; set; }
        public int Edad { get; set; }
        public string Semestre { get; set; }
        public int Estado { get; set; }

        public Estudiante()
        {
            Edad = 0;
        }


        public string ValidarEstudiante(Estudiante estudiante)
        {
            if (estudiante.Cedula == null || estudiante.Celular == null || estudiante.Correo == null || estudiante.Edad == 0 || estudiante.Semestre == null || estudiante.NombreCompleto == null || estudiante.Password == null)
            {
                return "Digite los campos primordiales para su registro";
            }
            else
            {
                return "Registrado correctamente";
            }
        }
    }


}

