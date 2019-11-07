using System;
using System.Collections.Generic;
using System.Text;

namespace BancoDeAlimentos.Configuration
{
    public class SmtpConfiguration
    {
        //SMTP Client
        public int Port { get; set; }
        public string ServerUrl { get; set; }
        public string Sender { get; set; }
        public bool Tls { get; set; }
        public string User { get; set; }
        public string Password { get; set; }

    }
}
