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
public class Language_bg_BG extends ListResourceBundle{
    
    static final Object[][] contents = {
        //Currency
                                        {"CURRENCY", "Lv"},
        //Email Text
                                        {"EMAIL_SUBJECT","регистрация снимка прилагане"},
                                        {"EMAIL_PART1", "Благодарим Ви за регистрация. Можете да намерите данните си за вход по-долу.\n\nПотребителско име: "},
                                        {"EMAIL_PART2", "\nвременната парола: "},
                                        {"EMAIL_PART3", "\n\nПаролата може да се променя по лични настройки."}
    };
    
    @Override
    protected Object[][] getContents() {
        return contents;
    }
}
