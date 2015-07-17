/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package Interfaces;

import java.rmi.Remote;
import java.rmi.RemoteException;

/**
 *
 * @author Remi_Arts
 */
public interface IBankrekening extends Remote {
    double GetSaldo()throws RemoteException;
    int GetNummer() throws RemoteException;
    void SetSaldo(double bedrag) throws RemoteException;
}
