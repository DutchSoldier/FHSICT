/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package OverboekCentrale;

import Interfaces.IBank;
import Interfaces.IOverboekCentrale;
import java.net.MalformedURLException;
import java.rmi.Naming;
import java.rmi.RemoteException;
import java.rmi.registry.LocateRegistry;
import java.rmi.server.UnicastRemoteObject;
import java.util.ArrayList;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author Luc
 */
public class OverboekCentrale extends UnicastRemoteObject implements IOverboekCentrale {
    private ArrayList<IBank> banken;
    private IOverboekCentrale ioc = this;
    
    public OverboekCentrale() throws RemoteException {
        banken = new ArrayList<>();
        try {
            LocateRegistry.createRegistry(1099);
            Naming.rebind("rmi://localhost/OverboekCentrale", ioc);
            System.out.println("Overboekcentrale registered at registry");
        } catch (MalformedURLException ex) {
            Logger.getLogger(OverboekCentrale.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
    
    @Override
    public String BoekOver(double bedrag, int EigenRekening, int OverRekening) throws RemoteException {
        IBank bank1 = null;
        IBank bank2 = null;
        for (IBank b : banken) {
            if (b.HeeftRekeningNummer(OverRekening)) {
                bank1 = b;
                break;
            }
        }
        for (IBank b : banken) {
            if (b.HeeftRekeningNummer(EigenRekening)) {
                bank2 = b;
                break;
            }
        }

        if (bank1 != null && bank2 != null) {
            bank1.WijzigSaldo(OverRekening, bedrag);
            bank2.WijzigSaldo(EigenRekening, -bedrag);
            return "Overboeking gelukt";
        }
        else {
            return "Rekening kan niet worden gevonden";
        }
    }

    @Override
    public void AddBank(IBank bank) throws RemoteException {
        banken.add(bank);
        System.out.println(bank.getNaam() +" added");
    }
       
    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) throws RemoteException {
        OverboekCentrale overboekCentrale = new OverboekCentrale();
    }
}
