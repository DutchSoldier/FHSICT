/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package Interfaces;

import java.rmi.Remote;
import java.rmi.RemoteException;

/**
 *
 * @author Simon
 */
public interface IBank extends Remote {
    public String getNaam() throws RemoteException;
    public boolean HeeftRekeningNummer(int rekeningnummer) throws RemoteException;
    public void WijzigSaldo(int rekeningnummer, double bedrag) throws RemoteException;
}
