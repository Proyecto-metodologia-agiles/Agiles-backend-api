using MimeKit;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using MailKit.Net.Smtp;
using System.Reflection;
using MailKit;
using Infrastructure.Mailers.Entities;
using System.Security.Authentication;
using System.IO;
using Infrastructure.Mailers.Events;


namespace Infrastructure.Mailers
{
    public  class Mailer
    {

        private readonly BodyBuilder _bodyBuilder;
        private readonly SmtpClient _client;
        private readonly MimeMessage _message;
        private string _response;
        private bool _state = false;
        private SMTP smtp;



        public Mailer()
        {
            _bodyBuilder = new BodyBuilder();
            _client = new SmtpClient();
            _message = new MimeMessage();

             smtp = new SMTP
            {

                Name = Helper._appSettings.Mailer.SmtName,
                Host = Helper._appSettings.Mailer.SmtpServer,
                UserName = Helper._appSettings.Mailer.SmtpUser,
                Password = Helper._appSettings.Mailer.SmtpPass,
                Port = Helper._appSettings.Mailer.SmtpPort,
                Ssl = Helper._appSettings.Mailer.EnableSsl
            };

        }

       

        public Mailer SetFrom()
        {

            

            _message.From.Add(new MailboxAddress(smtp.Name, smtp.UserName));
            return this;
        }

        

        public Mailer SeTo(List<MailerFrom> MailerFroms)
        {
            MailerFroms.ForEach(x =>
            {
                _message.To.Add(new MailboxAddress (x.Name, x.Email));
            });

            return this;
        }

        public Mailer SetSubject(string subject)
        {
            _message.Subject = subject;
            return this;
        }


        public Mailer SetTextBody(string text) { 
            if(text != "")
            {
                _bodyBuilder.TextBody = text;
            }
            return this;
        }

        public Mailer GetHtml(string? pathToFile = null, Dictionary<string, string>? strReplace = null)
        {

            _bodyBuilder.HtmlBody = pathToFile;
            if (strReplace != null)
            {
                strReplace.ForEach(x =>
                {
                    _bodyBuilder.HtmlBody = _bodyBuilder.HtmlBody.Replace(x.Key, x.Value);
                });

            }

            return this;
        }


        public Mailer FormatFile(Dictionary<string, string> filePaths = null)
        {

            if(filePaths != null)
            {
                filePaths.ForEach(x =>
                {
                    _bodyBuilder.LinkedResources.Add(x.Value).ContentId = x.Key;
                    _bodyBuilder.Attachments.Add(x.Value);
                });
            }
            return this;
        }


        public Mailer SetFile(List<string>? files = null)
        {
            if(files!= null)
            {
                files.ForEach(x =>
                {
                    _bodyBuilder.Attachments.Add(x);
                });
            }

            return this;
        }

        public Mailer CreateBody()
        {
            _message.Body = _bodyBuilder.ToMessageBody();
            
            return this;
        }

        public Mailer Authenticate()
        {
           
            _client.Connect(smtp.Host, smtp.Port, smtp.Ssl);
            _client.Authenticate(smtp.UserName, smtp.Password);
            return this;
        }

        public Mailer Send()
        {
            try
            {
                _client.SslProtocols = SslProtocols.Ssl2
                    | SslProtocols.Ssl3
                    | SslProtocols.Tls
                    | SslProtocols.Tls11
                    | SslProtocols.Tls12;
                    //| SslProtocols.Tls13;
                _client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                _client.Send(_message);
                _client.Disconnect(true);
                _client.Dispose();
                _client.MessageSent += OnMessageSent;
                _state = true;
            }
            catch (Exception)
            {
                _state = false;
            }
            return this;
        }

        public bool SendState()
        {
            return _state;
        } 

        public string SendResponse()
        {
            return _response;
        }

        public void OnMessageSent(object sender, MessageSentEventArgs e)
        {
            _response = e.Response;
        }



    }
}
