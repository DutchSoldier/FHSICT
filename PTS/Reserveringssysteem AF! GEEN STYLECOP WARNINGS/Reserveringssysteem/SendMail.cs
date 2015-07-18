//Send Mail

namespace Reserveringssysteem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Net.Mail;

    /// <summary>
    /// Deze class wordt gebruikt om een bevestigings mail te kunnen sturen naar de bezoeker nadat deze een reservering heeft vastgelegd.
    /// </summary>
    public class SendMail
    {
        /// <summary>
        /// Hiermee kan een mail worden verstuurd.
        /// </summary>
        /// <param name="from">Email van de versturende</param>
        /// <param name="to">Email naar wie de email toe moet</param>
        /// <param name="subject">Het onderwerp van de email</param>
        /// <param name="htmlmessage">De inhoud van het mailtje (opmaak met html)</param>
        /// <param name="smtpserver">De smtp server waarmee de mail moet worden verstuurd</param>
        public void VerzendMail(string from, string to, string subject, string htmlmessage, string smtpserver)
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
        /// Hiermee worden de gegevens van de reservering in een mailbericht in html opmaak gezet. 
        /// De opmaak van de mail wordt door deze functie geregeld, je hoeft alleen de juiste gegevens op te geven.
        /// </summary>
        /// <param name="reserveringsnummer">Het reserveringsnummer van de reservering</param>
        /// <param name="naam">De naam van de reserverende</param>
        /// <param name="aantalpersonen">Het aantal personen waarvoor gereserveerd is</param>
        /// <param name="prijs">De kosten van de reservering</param>
        /// <param name="rekeningnummer">Het rekeningnummer van de betalende</param>
        /// <param name="inloggegevens">De inloggegevens voor de bezoekers</param>
        /// <returns>Geeft een html bericht terug klaar voor verzending</returns>
        public string Mailbody(int reserveringsnummer, string naam, int aantalpersonen, string prijs, string rekeningnummer, List<Persoon> inloggegevens)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<html>");
            sb.AppendLine("<head>");
            sb.AppendLine("<title>Bevestiging Reservering</title>");
            sb.AppendLine("</head>");
            sb.AppendLine("<body>");
            sb.AppendLine("<table width=100%><tr><td colspan='2'>Hartelijk dank voor het reserveren bij ICT4Events. Hieronder vind u uw reserveringsgegevens.</td></tr><tr><td width='100'>Reserveringskenmerk:</td><td>");
            sb.AppendLine(reserveringsnummer.ToString());
            sb.AppendLine("</td></tr><tr><td>Op naam van:</td><td>");
            sb.AppendLine(naam);
            sb.AppendLine("</td></tr><tr><td>Aantal Personen:</td><td>");
            sb.AppendLine(aantalpersonen.ToString());
            sb.AppendLine("</td></tr><tr><td>Te betalen:</td><td>");
            sb.AppendLine(prijs);
            sb.AppendLine("</td></tr><tr><td>Rekeningnummer:</td><td>");
            sb.AppendLine(rekeningnummer);
            sb.AppendLine("</td></tr><tr><td colspan='2'>De inloggegevens die u kunt gebruiken om in te loggen op onze applicaties en computers:</td></tr>");
            for (int i = 0; i < inloggegevens.Count; i++)
            {
                sb.AppendLine("<tr><td colspan='2'><b>");
                sb.AppendLine("Gebruiker " + i);
                sb.AppendLine("</b></td></tr><tr><td>Gebruikersnaam:</td><td>");
                sb.AppendLine(inloggegevens[i].Rfid);
                sb.AppendLine("</td></tr><tr><td>Wachtwoord:</td><td>");
                sb.AppendLine(inloggegevens[i].Wachtwoord);
                sb.AppendLine("</td></tr>");
            }
            sb.AppendLine("</table>");
            sb.AppendLine("</body>");
            sb.AppendLine("</html>");

            return sb.ToString();
        }
    }
}
