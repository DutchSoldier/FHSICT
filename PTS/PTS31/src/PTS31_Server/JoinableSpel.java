/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package PTS31_Server;

import PTS31_Interfaces.IJoinableSpel;
import PTS31_RMI_Objecten.RMI_DrawableWedstrijd;
import fontys.observer.BasicPublisher;
import fontys.observer.RemotePropertyListener;
import java.awt.geom.Point2D;
import java.net.MalformedURLException;
import java.rmi.Naming;
import java.rmi.NotBoundException;
import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;
import java.util.ArrayList;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author Simon
 */
public class JoinableSpel extends UnicastRemoteObject implements IJoinableSpel{
    
    private String gameNaam;
    private ArrayList<Gebruiker> toeschouwers;
    private ArrayList<Gebruiker> spelers;
    private int wedstrijdId;
    private Wedstrijd wedstrijd;
    private Chat chat;
    private BasicPublisher bp;
    private int[] available = {0,1,2};
    private Lobby2 lobby;
    private int peopleReady = 0;
    
    public JoinableSpel(String gameNaam, Gebruiker host, int wedstrijdId, Lobby2 lobby) throws RemoteException{
        this.lobby = lobby;
        chat = new Chat(10);
        toeschouwers = new ArrayList();
        spelers = new ArrayList();
        String[] properties = {"Puck", "Chat", "Speler", "players", "spectators", "ready", "Game Over", "Scored", "Glow"};
        bp = new BasicPublisher(properties);
        this.gameNaam = gameNaam;
        this.wedstrijdId = wedstrijdId;
        
        spelers = new ArrayList<>();
    }
    
    public String getGameNaam() {
        return gameNaam;
    }
    
    public ArrayList<Gebruiker> getToeschouwers() {
        return toeschouwers;
    }
    
    public boolean isVol() {
        return (spelers.size() == 3);
    }
    
    public boolean isGestart() {
        return (wedstrijd != null);
    }
    
    public void addToeschouwer(Gebruiker gebruiker) {
        toeschouwers.add(gebruiker);
        if(!isGestart()) {
            bp.inform(bp, "spectators", toeschouwers, toeschouwers);
        }
    }
    
    public void addSpeler(int index, Gebruiker speler) {
        spelers.add(index, speler);
        bp.inform(bp, "players", spelers, spelers);
    }
    
    public void removeToeschouwer(Gebruiker gebruiker) {
        Gebruiker s = null;
        for (Gebruiker g : toeschouwers) {
            if(g.getNaam().equals(gebruiker.getNaam())) {
                s = g;
            }
        }
        toeschouwers.remove(s);
        if(!isGestart()) {
            bp.inform(bp, "spectators", toeschouwers, toeschouwers);
        }
        if(spelers.isEmpty() && toeschouwers.isEmpty()) {
            try {
                lobby.removeJoinableSpel(this);
                Naming.unbind(gameNaam);
            } catch (    RemoteException | NotBoundException | MalformedURLException ex) {
                Logger.getLogger(JoinableSpel.class.getName()).log(Level.SEVERE, null, ex);
            }
        }
    }
    
    public void removeSpeler(Gebruiker speler, int player) {
        Gebruiker s = null;
        for (Gebruiker g : spelers) {
            if(g.getNaam().equals(speler.getNaam())) {
                s = g;
            }
        }
        if(!isGestart()) {
            spelers.remove(s);
        }
        available[player] = player;
        if(!isGestart()) {
            bp.inform(bp, "players", spelers, spelers);
        }
        if((spelers.isEmpty() && toeschouwers.isEmpty() && !isGestart()) || (wedstrijd != null && wedstrijd.CPUOnly() && toeschouwers.isEmpty())) {
            try {
                lobby.removeJoinableSpel(this);
                Naming.unbind(gameNaam);
            } catch (    RemoteException | NotBoundException | MalformedURLException ex) {
                Logger.getLogger(JoinableSpel.class.getName()).log(Level.SEVERE, null, ex);
            }
        }
    }
    
    public ArrayList<Gebruiker> getSpelers() {
        return spelers;
    }
    
    public int getWedstrijdId() {
        return wedstrijdId;
    }
    
    public void startWedstrijd() {
        wedstrijd = new Wedstrijd(spelers, bp, this);
    } 
    
    public RMI_DrawableWedstrijd getRMIDrawableWedstrijd() {
        if (this.wedstrijd != null) { 
            ArrayList<Point2D.Double> DrawableSpelers = new ArrayList<>();
            for (Speler s : wedstrijd.getSpelers()) {
                DrawableSpelers.add(s.getPositie());
            }
            return new RMI_DrawableWedstrijd(DrawableSpelers, wedstrijd.getPuck().getPositie());  
        }
        return null;     
    }

    @Override
    public Point2D.Double getPuckLocation(RemotePropertyListener rpl) throws RemoteException {
        bp.addListener(rpl, "Puck");
        bp.addListener(rpl, "Glow");
        return wedstrijd.getPuck().getPositie();
    }

    @Override
    public ArrayList<String> getChatText(RemotePropertyListener rpl, boolean midGameSpectator) throws RemoteException {
        if(midGameSpectator) {
            bp.addListener(rpl, "Chat");
            bp.addListener(rpl, "players");
            bp.addListener(rpl, "spectators");
            bp.addListener(rpl, "Game Over");
        } else {
            bp.addListener(rpl, "Scored");
        }
        return chat.getBerichten();
    }

    @Override
    public ArrayList<Point2D.Double> getSpelerLocation(RemotePropertyListener rpl) throws RemoteException {
        bp.addListener(rpl, "Speler");
        ArrayList<Point2D.Double> playerLocations = new ArrayList();
        for(Speler s : wedstrijd.getSpelers()) {
            playerLocations.add(s.getPositie());
        }
        return playerLocations;
    }

    @Override
    public synchronized void MoveSpeler(int s, int dz) throws RemoteException {
        if(wedstrijd != null) {
            wedstrijd.direction[s] = dz;
        }
    }

    @Override
    public synchronized void addChatMessage(String bericht, String username) throws RemoteException {
        Gebruiker verzender = null;
        for(Gebruiker g : toeschouwers) {
            if(g.getNaam().equals(username)) {
                verzender = g;
            }
        }
        for(Gebruiker g : spelers) {
            if(g.getNaam().equals(username)) {
                verzender = g;
            }
        }
        chat.addBericht(bericht, verzender.getNaam());
        bp.inform(bp, "Chat", chat.oldvalue, chat.getBerichten());
    }

    @Override
    public ArrayList<String> getPlayersNames() throws RemoteException {
        ArrayList<String> usernames = new ArrayList();
        for(Gebruiker g : spelers) {
            usernames.add(g.getNaam());
        }
        return usernames;
    }

    @Override
    public ArrayList<String> getUserNames() throws RemoteException {
        ArrayList<String> usernames = new ArrayList();
        for(Gebruiker g : toeschouwers) {
            usernames.add(g.getNaam());
        }
        return usernames;
    }
    
    public int getAvailable() {
        int a = -1;
        for (int i = 0; i < 3 && a == -1; i++) {
            a = available[i];
            available[i] = -1;
        }
        return a;
    }
    
    @Override
    public synchronized void leaveGame(int spelerId, RemotePropertyListener rpl) throws RemoteException {
        bp.removeListener(rpl, "Puck");
        bp.removeListener(rpl, "Glow");
        bp.removeListener(rpl, "Speler");
        bp.removeListener(rpl, "Scored");
        if (spelerId != 3) {
            wedstrijd.swapPlayerWithCPU(spelerId);
        }
    }

    @Override
    public synchronized void changeReadyState(boolean ready) throws RemoteException{
        if(ready) {
            peopleReady++;
            if(peopleReady == 3) {
                startWedstrijd();
                bp.inform(bp, "ready", null, null);
            }
        }
        else {
            peopleReady--;
        }
    }

    @Override
    public boolean isGestart(RemotePropertyListener rpl) throws RemoteException {
        bp.addListener(rpl, "ready");
        return isGestart();
    }

    @Override
    public synchronized void leaveLobby(Gebruiker host, boolean speler, RemotePropertyListener rpl, int player) throws RemoteException {
        bp.removeListener(rpl, "Chat");
        bp.removeListener(rpl, "players");
        bp.removeListener(rpl, "spectators");
        bp.removeListener(rpl, "ready");
        bp.removeListener(rpl, "Game Over");
        if (speler) {
            removeSpeler(host, player);
        }
        else {
            removeToeschouwer(host);
        }
    }
    
    public void EndGame() {
        lobby.removeJoinableSpel(this);
        if (!(wedstrijd.CPUOnly() && toeschouwers.isEmpty())) {
            bp.inform(bp, "Game Over", null, null);
        }
    }
}
