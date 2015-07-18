/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package PTS31_Interfaces;

import PTS31_Server.Gebruiker;
import fontys.observer.RemotePropertyListener;
import java.rmi.Remote;
import java.rmi.RemoteException;
import java.util.ArrayList;

/**
 *
 * @author PIERRE BUTELA
 */
public interface ILobby extends Remote{
    
    public void getUsernames(RemotePropertyListener rpl, Gebruiker gebruiker) throws RemoteException;
    
    public ArrayList<String> getChatText(RemotePropertyListener rpl) throws RemoteException;
    
    public ArrayList<String> getGameNames(RemotePropertyListener rpl) throws RemoteException;
    
    public int addJoinableSpel(String gameNaam, Gebruiker host) throws RemoteException;
    
    public int joinGame(String gameNaam, Gebruiker host) throws RemoteException;
    
    public void spectateGame(String gameNaam, Gebruiker host) throws RemoteException;
    
    public void leaveLobby(RemotePropertyListener rpl, String gebruiker) throws RemoteException;
    
    public void addChatMessage(String bericht, String username) throws RemoteException;
    
}
