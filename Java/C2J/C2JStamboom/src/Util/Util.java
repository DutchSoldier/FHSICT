/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package Util;

import java.awt.Component;
import java.util.GregorianCalendar;
import javax.swing.JOptionPane;

/**
 *
 * @author Luc
 */
public class Util {
    public static GregorianCalendar datum (Component parent, String datumaanduiding){
        try {
            String[] datumSplit = datumaanduiding.split("-");
            if (datumSplit.length != 3) {
                JOptionPane.showMessageDialog(parent, "Ongeldige datum", "",
                    JOptionPane.ERROR_MESSAGE);
                return null;
            }
            int dag = Integer.parseInt(datumSplit[0]);
            if (dag <= 0 || dag > 31) {
                JOptionPane.showMessageDialog(parent,
                        "Ongeldige dag", "",
                        JOptionPane.ERROR_MESSAGE);
                return null;
            }

            int maand = Integer.parseInt(datumSplit[1]);
            if (maand <= 0 || maand > 12) {
                JOptionPane.showMessageDialog(parent,
                        "Ongeldige maand", "",
                        JOptionPane.ERROR_MESSAGE);
                return null;
            }

            int jaar = Integer.parseInt(datumSplit[2]);

            // maanden zijn binnen GregorianCalendar van 0 t/m 11 gecodeerd:
            return new GregorianCalendar(jaar, maand - 1, dag);
        } catch (NumberFormatException e) {
            JOptionPane.showMessageDialog(parent, "Ongeldige datum", "",
                    JOptionPane.ERROR_MESSAGE);
            return null;
        }
    } 

}
