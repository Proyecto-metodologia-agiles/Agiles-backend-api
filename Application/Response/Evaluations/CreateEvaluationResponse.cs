using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Response.Evaluations
{
    public class CreateEvaluacionResponse
    {
        public string Message { set; get; }

        public bool Status { set; get; }
        public Evaluacion Evaluacion { set; get; }
    }
}
