using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public interface Ipersona
    {

        string NombreCompleto { get; set; }
        string Cedula { get; set; }
        string Correo { get; set; }
        string Password { get; set; }
        string Celular { get; set; }
        int Edad { get; set; }
 

    }
}
