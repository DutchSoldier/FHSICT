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
public interface IDatabaseKoppeling extends Remote {
    public IKlant Login(String naam, String wachtwoord) throws RemoteException;
    public boolean Registreren(String naam, String wachtwoord)throws RemoteException;
}
