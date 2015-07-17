package os_bytecodeopgave;

/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author me
 */
public class Rekening {

    private static int sharedNummer;
    private int nummer;
    private int saldo;

    public Rekening(int nummer) {
        this.nummer = nummer;
    }

    public Rekening() {
        this.nummer = (++sharedNummer);
    }

    public void changeSaldo(int bedrag) {
        this.saldo += bedrag;
    }

    public String toString() {
        return "Rekening " + Integer.toString(this.nummer) + "\t Saldo: " + Integer.toString(this.saldo);
    }

    public int getSaldo() {
        return this.saldo;
    }

    public int getNummer() {
        return this.nummer;
    }

    public static Rekening bonusRekening() {
        Rekening localRekening = new Rekening();
        localRekening.changeSaldo(100);
        return localRekening;
    }
}
