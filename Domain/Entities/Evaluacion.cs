using Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Evaluacion: Entity<int>
    {
        public string Observation { get; set; }
        public Proyecto Project { get; set; }
        public DateTime Date { get; set; }

        public Evaluacion() 
        {
        }

        public Evaluacion(string observation, Proyecto project, DateTime date) 
        {

            this.Observation = observation;
            this.Project = project;
            this.Date = date;
        }

        public string Verify_Evaluation(Evaluacion evaluation)
        {
            if (evaluation.Date == null || evaluation.Observation == null || evaluation.Project == null)
            {
                return "Digite los campos primordiales para el registro";
            }
            else
            {
                return "Evaluacion registrada correctamente";
            }
        }

    }
}
