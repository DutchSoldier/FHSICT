package os_bytecodeopgave;

import java.util.Collection;
import java.util.LinkedList;

/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author me
 */
public class Bank {

    private Collection<Klant> klanten;

    public Bank() {
        this.klanten = new LinkedList();
    }

    public Collection<Rekening> getRekeningen() {
        Collection returnvalue = new LinkedList();
        for (Klant k : this.klanten) {
            returnvalue.add(k.getRekening());
        }
        return returnvalue;
    }

    public void addKlant(String naam) {
        Klant k = new Klant(naam);
        this.klanten.add(k);

        Rekening r = Rekening.bonusRekening();
        k.voegRekeningToe(r);
    }

    public double getTotalSaldo() {
        long returnvalue = 0L;
        for (Klant k : this.klanten) {
            returnvalue += k.mijnSaldo();
        }
        return returnvalue;
    }

    public void betaal(int rekeningnummer, int bedrag) {
        for (Klant k : this.klanten) {
            
            if (k.getRekening().getNummer() == rekeningnummer) {
                k.verlaagSaldo(bedrag);
            }
        }
    }
}
