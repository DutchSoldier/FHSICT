/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package Bank;

import Interfaces.IBank;
import Interfaces.IBankrekening;
import Interfaces.IDatabaseKoppeling;
import Interfaces.IOverboekCentrale;
import java.net.MalformedURLException;
import java.rmi.Naming;
import java.rmi.RemoteException;
import java.rmi.registry.LocateRegistry;
import java.rmi.server.UnicastRemoteObject;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author Remi_Arts
 */
public class Bank extends UnicastRemoteObject implements IBank{
    private String naam;
    private DatabaseKoppeling dbk;
    private IOverboekCentrale ioc;
    private ArrayList<Klant> klanten = new ArrayList<>();
    
    public Bank(String Naam, int poort, IOverboekCentrale i) throws RemoteException{
        naam = Naam;
        dbk = new DatabaseKoppeling(this);
        ioc = i;

        IDatabaseKoppeling idbk = dbk;
        try {
            LocateRegistry.createRegistry(poort);
            Naming.rebind("rmi://localhost:"+poort+"/DatabaseKoppeling", idbk);
            System.out.println("dbk registered at registry");
        } catch (MalformedURLException ex) {
            Logger.getLogger(Bank.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
    
    @Override
    public String getNaam(){
        return naam;
    }

    public String Overschrijven(double bedrag, int KlantRekening, int OverRekening) throws RemoteException {
        return ioc.BoekOver(bedrag, KlantRekening, OverRekening);
    }
    
    @Override
    public void WijzigSaldo(int rekeningnummer, double bedrag){
     
        for (Klant k : klanten) {
            for (IBankrekening r: k.GetBankRekeningen()) {
                try {
                    if (r.GetNummer() == rekeningnummer) {
                        r.SetSaldo(bedrag);
                        k.InformClient();
                    }
                } catch (RemoteException ex) {
                    Logger.getLogger(Bank.class.getName()).log(Level.SEVERE, null, ex);
                }
            }
        }
        dbk.WijzigSaldo(rekeningnummer, bedrag);
    }

    @Override
    public boolean HeeftRekeningNummer(int rekeningnummer) throws RemoteException {
        return dbk.HeeftRekeningNummer(rekeningnummer);
    }
    
    public void NieuweRekening(String naam) throws SQLException {
        dbk.NieuweRekening(naam);
    }
    
    public void AddKlant(Klant k) {
        klanten.add(k);    
    }
}
