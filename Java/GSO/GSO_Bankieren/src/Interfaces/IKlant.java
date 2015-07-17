/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package Interfaces;

import fontys.observer.RemotePropertyListener;
import java.rmi.Remote;
import java.rmi.RemoteException;
import java.util.ArrayList;

/**
 *
 * @author Remi_Arts
 */
public interface IKlant extends Remote {
    String Overschrijven(double bedrag, IBankrekening KlantRekening, int OverRekening)throws RemoteException;
    ArrayList<IBankrekening> GetBankRekeningen(RemotePropertyListener rpl)throws RemoteException;
    void OpenBankRekening(String naam)throws RemoteException;
}
