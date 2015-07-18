/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package pixel.server;

/**
 *
 * @author Bas
 */
import java.util.Locale;
import javax.mail.Message;
import javax.mail.MessagingException;
import javax.mail.Session;
import javax.mail.Transport;
import javax.mail.internet.InternetAddress;
import javax.mail.internet.MimeMessage;
import java.util.Properties;
import java.util.ResourceBundle;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author Frank
 */
public class Email {

    private String from = "260087@student.fontys.nl";
    private String to;
    private String subject;
    private String text;
    private String password;
    private ResourceBundle resBund;
    private String lang;

    /**
     *
     * @param mailTo
     * @param password
     * @param lang
     */
    public Email(String mailTo, String password, String lang) {
        this.to = mailTo;
        this.password = password;
        this.lang = lang;
        
        switch (lang) {
            case "enUK":
                Locale.setDefault(new Locale("en", "GB"));
                break;
            case "enUS":
                Locale.setDefault(new Locale("en", "US"));
                break;
            case "nl":
                Locale.setDefault(new Locale("nl", "NL"));
                break;
            case "bg":
                Locale.setDefault(new Locale("bg", "BG"));
                break;
        }
        
        resBund = ResourceBundle.getBundle("pixel.resources.language.Language", Locale.getDefault());
    }
    
    /**
     *
     */
    public boolean mail() {
        try {
            subject = resBund.getString("EMAIL_SUBJECT");
            text = resBund.getString("EMAIL_PART1") + to + resBund.getString("EMAIL_PART2") + password + resBund.getString("EMAIL_PART3");

            Properties properties = new Properties();
            properties.put("mail.smtp.host", "smtp1.fontys.nl");
            properties.put("mail.smtp.port", "25");
            Session session = Session.getDefaultInstance(properties, null);

            Message message = new MimeMessage(session);
            message.setFrom(new InternetAddress(from));
            message.setRecipient(Message.RecipientType.TO,
                    new InternetAddress(to));
            message.setSubject(subject);
            message.setText(text);

            Transport.send(message);
            return true;
        } catch (MessagingException ex) {
            Logger.getLogger(Email.class.getName()).log(Level.SEVERE, null, ex);
            return false;
        }
    }
}
