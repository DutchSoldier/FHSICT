/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package Bank;

import Interfaces.IBankrekening;
import Interfaces.IKlant;
import fontys.observer.BasicPublisher;
import fontys.observer.RemotePropertyListener;
import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author Remi_Arts
 */
public class Klant extends UnicastRemoteObject implements IKlant{
    private String naam;
    private ArrayList<IBankrekening> bankrekeningen;
    private Bank bank;
    private BasicPublisher bp;

    public Klant(String Naam, ArrayList<IBankrekening> brekeningen, Bank b) throws RemoteException{
        naam = Naam;
        bankrekeningen = brekeningen;
        bank = b;
        String[] properties = {"Saldo"};
        bp = new BasicPublisher(properties);
        b.AddKlant(this);
    }

    @Override
    public String Overschrijven(double bedrag, IBankrekening KlantRekening, int OverRekening) throws RemoteException {
        if (KlantRekening.GetSaldo() >= bedrag) {
            return bank.Overschrijven(bedrag, KlantRekening.GetNummer(), OverRekening);
        }
        else {
            return "Onvoldoende saldo";
        }
    }

    @Override
    public ArrayList<IBankrekening> GetBankRekeningen(RemotePropertyListener rpl) throws RemoteException {
        bp.addListener(rpl, "Saldo");
        return bankrekeningen;
    }
    
    public ArrayList<IBankrekening> GetBankRekeningen() {
        return bankrekeningen;
    }

    @Override
    public void OpenBankRekening(String naam) throws RemoteException {
        try {
            bank.NieuweRekening(naam);
        } catch (SQLException ex) {
            Logger.getLogger(Klant.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
    
    public void InformClient() {
        bp.inform(bp, "Saldo", null, bankrekeningen);
    }
}
