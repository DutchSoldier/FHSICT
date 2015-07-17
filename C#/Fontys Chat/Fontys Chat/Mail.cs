// Mail classe, stuurt een email naar de klant door wanneer hij/zij zich online registreert.

namespace WebApplication1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Text;
    using System.Net.Mail;

    /// <summary>
    /// Hiermee kan een mail worden verstuurd.
    /// </summary>

    public static class Mail
    {
        /// <summary>
        /// Hiermee kan een mail worden verstuurd.
        /// </summary>
        /// <param name="from">Email van de versturende</param>
        /// <param name="to">Email naar wie de email toe moet</param>
        /// <param name="subject">Het onderwerp van de email</param>
        /// <param name="htmlmessage">De inhoud van het mailtje (opmaak met html)</param>
        /// <param name="smtpserver">De smtp server waarmee de mail moet worden verstuurd</param>
        public static void VerzendMail(string from, string to, string subject, string htmlmessage, string smtpserver)
        {
            MailMessage mail = new MailMessage();
            SmtpClient client = new SmtpClient(smtpserver);
            mail.From = new MailAddress(from);
            mail.IsBodyHtml = true;
            mail.To.Add(to);
            mail.Subject = subject;
            mail.SubjectEncoding = System.Text.Encoding.Unicode;
            mail.Body = htmlmessage;
            mail.BodyEncoding = System.Text.Encoding.Unicode;

            try
            {
                client.Send(mail);
            }
            catch (SmtpFailedRecipientsException)
            {
                throw new ArgumentException("Uw bevestigingsmail is niet aangekomen!");
            }
            catch (SmtpException)
            {
                throw new ArgumentException("Uw bevestigingsmail kan niet verzonden worden!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Hiermee worden de gegevens van de registratie in een mailbericht in html opmaak gezet. 
        /// De opmaak van de mail wordt door deze functie geregeld, je hoeft alleen de juiste gegevens op te geven.
        /// </summary>
        /// <param name="User_ID">Het id nummer van de persoon</param>
        /// <param name="Username">De gebruiker zijn online naam</param>
        /// <param name="password">Het wachtwoord van de gebruiker</param>
        /// <returns>Geeft een html bericht terug klaar voor verzending</returns>
        public static string Mailbody(string username, string password)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<html>");
            sb.AppendLine("<head>");
            sb.AppendLine("<title>Bevestiging Reservering</title>");
            sb.AppendLine("</head>");
            sb.AppendLine("<body>");
            sb.AppendLine("<table width=100%><tr><td colspan='2'>Hartelijk dank voor het registreren bij FontysChat. Hieronder vind u uw registratie gegevens.</td></tr><tr><td width='100'>Reserveringskenmerk:</td><td>");
            sb.AppendLine("</td></tr><tr><td>Op naam van:</td><td>");
            sb.AppendLine(username);
            sb.AppendLine("</td></tr><tr><td>Password:</td><td>");
            sb.AppendLine(password);
            sb.AppendLine("</table>");
            sb.AppendLine("</body>");
            sb.AppendLine("</html>");

            return sb.ToString();
        }

        /// <summary>
        /// The mail body for friend request.
        /// </summary>
        /// <param name="yourname">The yourname.</param>
        /// <returns></returns>
        public static string FriendMailBody(string yourname)
        {
            StringBuilder fmb = new StringBuilder();
            fmb.AppendLine("<html>");
            fmb.AppendLine("<head>");
            fmb.AppendLine("<title>Je bent als vriend toegevoegd</title>");
            fmb.AppendLine("</head>");
            fmb.AppendLine("<body>");
            fmb.AppendLine("<table width=100%><tr><td colspan='2'>De volgende user heeft je als vriend toegevoegd op FontysChat:</td></tr><tr><td width='100'>Reserveringskenmerk:</td><td>");
            fmb.AppendLine("</td></tr><tr><td>Op naam van:</td><td>");
            fmb.AppendLine(yourname);
            fmb.AppendLine("</table>");
            fmb.AppendLine("</body>");
            fmb.AppendLine("</html>");

            return fmb.ToString();
        }
    }
}