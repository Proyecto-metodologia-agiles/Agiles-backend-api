using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Requests.Login
{
    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public LoginRequest() 
        {
        }

        public LoginRequest(string username, string password) 
        {
            this.Username = username;
            this.Password = password;
        }




    }
}
