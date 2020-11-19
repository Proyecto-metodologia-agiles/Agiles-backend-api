using Domain;
using Infrastructure.Mailers.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Mailers.Events
{

    public class ObjectMailer
    {
        public SMTP? Smtp { set; get; }
        public List<MailerFrom>? MailerFroms { set; get; }
        public string? Subject { set; get; }
        public string? Templante { set; get; }
        public Dictionary<string, string> StrReplacesTemplante { set; get; } = null;
        public Dictionary<string, string> FileHtmlPath  { set; get; } = null;
        public List<string>? FilesPath { set; get; } = null;

        public string? TextBody { set; get; }
    }

    public static class SendMailer
    {
        public static bool Send(ObjectMailer mailer)
        {
            return new Mailer()
                    .SetFrom(mailer.Smtp)
                    .SeTo(mailer.MailerFroms)
                    .SetSubject(mailer.Subject)
                    .GetHtml(mailer.Templante, mailer.StrReplacesTemplante)
                    .FormatFile(mailer.FileHtmlPath)
                    .SetFile(mailer.FilesPath)
                    .SetTextBody(mailer.TextBody)
                    .CreateBody()
                    .Authenticate(mailer.Smtp)
                    .Send()
                    .SendState();
        }


        

    }
}
