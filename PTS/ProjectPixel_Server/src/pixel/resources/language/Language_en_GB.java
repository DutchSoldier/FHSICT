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
public class Language_en_GB extends ListResourceBundle{
    
    static final Object[][] contents = {
        //Currency
                                        {"CURRENCY", "£"},
        //Email Text
                                        {"EMAIL_SUBJECT","Registration photo application"},
                                        {"EMAIL_PART1", "Thank you for your registration. You can find your login information below.\n\nUsername: "},
                                        {"EMAIL_PART2", "\nTemporary password: "},
                                        {"EMAIL_PART3", "\n\nThe password can be changed at personal settings."}
    };
    
    @Override
    protected Object[][] getContents() {
        return contents;
    }
}
