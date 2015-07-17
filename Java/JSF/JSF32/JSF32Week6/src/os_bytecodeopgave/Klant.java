package os_bytecodeopgave;

/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author me
 */
public class Klant {

    private String naam;
    private Rekening mijnRekening;

    public Klant(String naam) {
        this.naam = naam;
    }

    public void voegRekeningToe(Rekening rek) {
        this.mijnRekening = rek;
    }

    public int mijnSaldo() {
        return this.mijnRekening.getSaldo();
    }

    public Rekening getRekening() {
        Rekening returnvalue = new Rekening(this.mijnRekening.getNummer());
        returnvalue.changeSaldo(this.mijnRekening.getSaldo());
        return returnvalue;
    }

    public void verlaagSaldo(int bedrag) {
        if (this.mijnRekening.getNummer() != 4){
            this.mijnRekening.changeSaldo(-Math.abs(bedrag));
        }
    }
}
