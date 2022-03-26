using MailKit.Net.Smtp;
using MailKit;
using MimeKit;


namespace Backend.Models
{
    public class Email
    {        
        string Servidor = "smtp.gmail.com";
        int Puerto = 587;
        String GmailUser = "prub3508@gmail.com";
        String GmailPass = "pruebaCorreo";
        public string GmailReceptor = "";
        public string SendMessage = "";


        public async Task sendEmail()
        {
            MimeMessage mensaje = new();
            mensaje.From.Add(new MailboxAddress("Correo Prueba", GmailUser));
            mensaje.To.Add(new MailboxAddress("Destino", GmailReceptor));
            mensaje.Subject = "Notificación";

            BodyBuilder CuerpoMensaje = new();
            CuerpoMensaje.TextBody = SendMessage;


            mensaje.Body = CuerpoMensaje.ToMessageBody();

            SmtpClient ClientSmtp = new();
            ClientSmtp.CheckCertificateRevocation = false;
            ClientSmtp.Connect(Servidor, Puerto, MailKit.Security.SecureSocketOptions.StartTls);
            ClientSmtp.Authenticate(GmailUser, GmailPass);
            ClientSmtp.Send(mensaje);
            ClientSmtp.Disconnect(true);

        }

    }
}
