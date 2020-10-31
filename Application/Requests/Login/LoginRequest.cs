using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Requests.Login
{
    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public LoginRequest() 
        {
        }

        public LoginRequest(string email, string password) 
        {
            this.Email = email;
            this.Password = password;
        }




    }
}
