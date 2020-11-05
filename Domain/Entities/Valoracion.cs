using Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Valoracion : Entity<int>
    {
        public string Observation { get; set; }
        public DateTime Date { get; set; }
        public string Valoration { get; set; }
        public Proyecto Project { get; set; }
        public Valoracion()
        {
        }

        public Valoracion(string observation, Proyecto project, DateTime date, string valoration) 
        {
            this.Observation = observation;
            this.Project = project;
            this.Date = date;
            this.Valoration = valoration;

        }

        public string Verify_Valoration(Valoracion valoration)
        {
            if (valoration.Date == null || valoration.Observation == null || valoration.Project == null || valoration.Valoration == null)
            {
                return "Digite los campos primordiales para el registro";
            }
            else
            {
                return "Valoracion registrada correctamente";
            }
        }
    }
}
