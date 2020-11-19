using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Mailers.Entities
{
    public class SMTP
    {
        public string Name { set; get; }
        public string UserName { set; get; }
        public string Password { set; get; }
        public string Host { set; get; }
        public int Port { set; get; }
        public bool Ssl { set; get; }


    }


}
