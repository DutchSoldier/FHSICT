/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package PTS31_Interfaces;

import PTS31_Server.Gebruiker;
import java.rmi.Remote;
import java.rmi.RemoteException;
import java.util.ArrayList;

/**
 *
 * @author Mitch
 */
public interface IDatabase extends Remote {
    
    boolean checkUsername(String gebruikersnaam) throws RemoteException;
    
    void register(String gebruikersnaam, String wachtwoord) throws RemoteException;
    
    Gebruiker login(String username, String wachtwoord) throws RemoteException;
    
    ArrayList<Gebruiker> searchGebruiker(String zoekopdracht) throws RemoteException;
    
    ArrayList<String> getTopRating() throws RemoteException;
    
}
