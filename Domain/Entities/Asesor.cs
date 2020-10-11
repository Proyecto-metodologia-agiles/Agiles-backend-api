using System;
using System.Collections.Generic;
using System.Text;
using Domain.Base;

namespace Domain.Entities
{

    public class Asesor: Entity<int>
    {
        public string Name { get; set; }
        public string Last_Name { get; set; }
        public string Password { get; set; }

        public string Email { get; set; }
        public string Identification { get; set; }
        public string Type_Asser { get; set; }
        public string Phone { get; set; }
        public string Direction { get; set; }
        public Asesor()
        {

        }

        public Asesor(string Nombre, string Apellido, string Password, string Email, string Identificacion, string Tipo_Asesor, string Telefono, string Direccion)
        {
            this.Name = Nombre;
            this.Last_Name = Apellido;
            this.Identification = Identificacion;
            this.Type_Asser = Tipo_Asesor;
            this.Phone = Telefono;
            this.Direction = Direccion;
            this.Email = Email;
            this.Password = Password;
        }

        public string Validar_Asesor(Asesor asesor)
        {
            if (asesor.Name == null || asesor.Last_Name == null || asesor.Identification == null || asesor.Type_Asser == null || asesor.Phone == null || asesor.Direction == null || asesor.Password == null || asesor.Email == null)
            {
                return "Digite los campos primordiales para el registro";
            }
            else
            {
                return "Asesor registrado correctamente";
            }
        }
    }
}
