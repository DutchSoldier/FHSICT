/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package pixel.resources.language;

import java.util.ListResourceBundle;

/**
 *
 * @author KASPER
 */
public class Language_nl_NL extends ListResourceBundle{
    
    static final Object[][] contents = {
        //Currency
                                        {"CURRENCY", "€"},
        //Email Text
                                        {"EMAIL_SUBJECT","Registratie foto applicatie"},
                                        {"EMAIL_PART1", "Bedankt voor uw registratie. Hieronder staan uw inlog gegevens.\n\nGebruikersnaam: "},
                                        {"EMAIL_PART2", "\nTijdelijk wachtwoord: "},
                                        {"EMAIL_PART3", "\n\nHet wachtwoord kan worden gewijzigd bij persoonlijke instellingen."}
    };
    
    @Override
    protected Object[][] getContents() {
        return contents;
    }
}
