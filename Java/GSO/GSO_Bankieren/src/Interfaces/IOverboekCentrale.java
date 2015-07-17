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
public interface IOverboekCentrale extends Remote {
    String BoekOver(double bedrag, int EigenRekening, int OverRekening) throws RemoteException;
    void AddBank(IBank bank) throws RemoteException;
}
