using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Response.Login
{
    public class LoginResponse
    {

        public string Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Idetification { get; set; }
        public string Telephone { get; set; }
        public string Message { get; set; }
        public LoginResponse() 
        {
        }

        public LoginResponse(string id, string type, string name, string email, string identification, string telephone, string message) 
        {
            this.Id = id;
            this.Type = type;
            this.Name = name;
            this.Email = email;
            this.Idetification = identification;
            this.Telephone = telephone;
            this.Message = message;
            
        }
    }
}
