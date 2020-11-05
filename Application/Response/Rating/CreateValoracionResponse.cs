using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Response.Rating
{
    public class CreateValoracionResponse
    {
        public string Message { set; get; }

        public bool Status { set; get; }
        public Valoracion Valoracion { set; get; }
    }
}
