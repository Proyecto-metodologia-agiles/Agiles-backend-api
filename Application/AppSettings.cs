
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class AppSettings
{
    public string Secret { get; set; }
    public string VirusTotalKey { set; get; }

    public string Url { set; get; }
    public Mailer Mailer { set; get; }

    public string ApiKeySms { set; get; }

    public string ApiSecretSms { set; get; }

    public string FromSms { set; get; }
}

public class Mailer
{
    public string SmtpServer { set; get; }
    public bool EnableSsl { set; get; }

    public int SmtpPort { set; get; }

    public string SmtName { set; get; }

    public string SmtpUser { set; get; }

    public string SmtpPass { set; get; }

}

