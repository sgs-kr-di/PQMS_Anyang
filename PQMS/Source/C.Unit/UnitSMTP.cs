using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace PQMS
{
    public class UnitSMTP
    {

        public string sFROM { get; set; }
        public string sTO { get; set; }
        public string sSUBJECT { get; set; }
        public string sBODY { get; set; }       

        
        public void Email_Send()
        {
            MailMessage mail = new MailMessage();
            SmtpClient smtpServer = new SmtpClient("smtp-apac.sgs.net");

            mail.From = new MailAddress(sFROM); // 발신

            mail.To.Add(sTO); //수신

            mail.Subject = sSUBJECT; // 제목

            mail.Body = sBODY; //내용

            smtpServer.Port = 25;
            //smtpServer.Send(mail);

        }

    }
}

