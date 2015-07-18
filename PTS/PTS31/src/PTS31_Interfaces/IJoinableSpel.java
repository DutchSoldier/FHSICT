/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package PTS31_Interfaces;

import PTS31_Server.Gebruiker;
import fontys.observer.RemotePropertyListener;
import java.awt.geom.Point2D;
import java.rmi.Remote;
import java.rmi.RemoteException;
import java.util.ArrayList;

/**
 *
 * @author PIERRE BUTELA
 */
public interface IJoinableSpel extends Remote{
    
    public Point2D.Double getPuckLocation(fontys.observer.RemotePropertyListener rpl) throws RemoteException;
    
    public ArrayList<String> getPlayersNames() throws RemoteException;
    
    public ArrayList<String> getUserNames() throws RemoteException;
    
    public ArrayList<String> getChatText(fontys.observer.RemotePropertyListener rpl, boolean midGameSpectator) throws RemoteException;
    
    public ArrayList<Point2D.Double> getSpelerLocation(fontys.observer.RemotePropertyListener rpl) throws RemoteException;
    
    public void leaveGame(int spelerId, RemotePropertyListener rpl) throws RemoteException;
    
    public void leaveLobby(Gebruiker host, boolean speler, RemotePropertyListener rpl, int player) throws RemoteException;
    
    public void MoveSpeler(int s, int dz) throws RemoteException;
    
    public void addChatMessage(String bericht, String username) throws RemoteException;
    
    public void changeReadyState(boolean ready) throws RemoteException;
    
    public boolean isGestart(RemotePropertyListener rpl) throws RemoteException;
    
}
