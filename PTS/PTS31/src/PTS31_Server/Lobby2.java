package PTS31_Server;

import PTS31_Interfaces.ILobby;
import PTS31_RMI_Objecten.RMI_DrawableWedstrijd;
import PTS31_RMI_Objecten.RMI_JoinableSpel;
import fontys.observer.BasicPublisher;
import fontys.observer.RemotePropertyListener;
import java.net.MalformedURLException;
import java.rmi.Naming;
import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;
import java.util.ArrayList;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author Luc
 */
//alternatieve implementatie van de lobby klasse
public class Lobby2  extends UnicastRemoteObject implements ILobby{
    protected ArrayList<JoinableSpel> spellen;
    private ArrayList<Gebruiker> gebruikers; 
    private int volgendeWedstrijdId;
    private Chat chat;
    private BasicPublisher bp;

    public Lobby2() throws RemoteException{
        String[] properties = {"Chat", "GameNames", "UserNames"};
        bp = new BasicPublisher(properties);
        spellen = new ArrayList();
        gebruikers = new ArrayList();
        chat = new Chat(30);
        volgendeWedstrijdId = 0;
    }
    
    public void addBericht(String bericht, Gebruiker verzender) {
        this.chat.addBericht(bericht, verzender.getNaam()); 
    }
    
    public ArrayList<String> getBerichten() {
        return chat.getBerichten();
    }
     
    @Override
    public synchronized int addJoinableSpel(String gameNaam, Gebruiker host) throws RemoteException {
        try {
            if(!getGameNames().contains(gameNaam) && !gameNaam.equals("Lobby") && !gameNaam.equals("Database")) {
                JoinableSpel j = new JoinableSpel(gameNaam, host, volgendeWedstrijdId, this);
                spellen.add(j);
                try {
                    Naming.rebind("rmi://localhost/" + gameNaam, j);
                } catch (MalformedURLException ex) {
                    Logger.getLogger(Lobby2.class.getName()).log(Level.SEVERE, null, ex);
                }
                volgendeWedstrijdId++;
                bp.inform(bp, "GameNames", null, getGameNames());
                return joinGame(gameNaam, host);
            }
        } catch (RemoteException ex) {
            Logger.getLogger(Lobby2.class.getName()).log(Level.SEVERE, null, ex);
        }
        return -1;
    }
    
    public void removeJoinableSpel(JoinableSpel joinableSpel) {
        try {
            spellen.remove(joinableSpel);
            bp.inform(bp, "GameNames", null, getGameNames());
        } catch (RemoteException ex) {
            Logger.getLogger(Lobby2.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
    
    public void addGebruiker(Gebruiker gebruiker) {
        gebruikers.add(gebruiker);
        bp.inform(bp, "UserNames", null, getUsernames());
    }
    
    public void removeGebruiker(Gebruiker gebruiker) {
        gebruikers.remove(gebruiker);
        bp.inform(bp, "UserNames", null, getUsernames());
    }
    
    
    //haalt de objecten op die via RMI verstuurd moeten worden naar de client die ze aanvraagd
    public ArrayList<RMI_JoinableSpel> getRMIJoinableSpellen() {
        ArrayList<RMI_JoinableSpel> result = new ArrayList<>();
        for (JoinableSpel j : spellen) {
            result.add(new RMI_JoinableSpel(j.getWedstrijdId(), j.getGameNaam(), j.isVol()));
        }
        return result;
    }
    
    //haalt drawableWedstrijd object op van wedstrijd met id wedstrijdId
    public RMI_DrawableWedstrijd getRMIDrawableWedstrijdVoorId(int wedstrijdId) {
        for (JoinableSpel j : spellen) {
            if (j.getWedstrijdId() == wedstrijdId) {
                return j.getRMIDrawableWedstrijd();
            }
        }
        return null; 
    }
    
    //voegt gebruiker g toe als toeschouwer aan wedstrijd met bijbehorende wedstrijdId
    //return true als het gelukt it
    //return false als spel niet gevonden kan worden
    public boolean AddToeschouwerInSpel(Gebruiker g, int wedstrijdId) {
        for (JoinableSpel j : spellen) {
            if (j.getWedstrijdId() == wedstrijdId) {
                j.addToeschouwer(g);
                return true;
            }
        }
        return false;       
    }

    public ArrayList<String> getUsernames() {
        ArrayList<String> usernames = new ArrayList();
        for(Gebruiker g : gebruikers) {
            usernames.add(g.getNaam());
        }
        return usernames;
    }

    @Override
    public ArrayList<String> getChatText(RemotePropertyListener rpl) throws RemoteException {
        bp.addListener(rpl, "Chat");
        return chat.getBerichten();
    }

    @Override
    public ArrayList<String> getGameNames(RemotePropertyListener rpl) throws RemoteException {
        bp.addListener(rpl, "GameNames");
        return getGameNames();
    }
    
    public ArrayList<String> getGameNames() throws RemoteException {
        ArrayList<String> gamenames = new ArrayList();
        for(JoinableSpel j : spellen) {
            gamenames.add(j.getGameNaam());
        }
        return gamenames;
    }

    @Override
    public synchronized void addChatMessage(String bericht, String username) throws RemoteException {
        /*Gebruiker verzender = null;
        for(Gebruiker g : gebruikers) {
            if(g.getNaam().equals(username)) {
                verzender = g;
            }
        }*/
        chat.addBericht(bericht, username);
        bp.inform(bp, "Chat", chat.oldvalue, chat.getBerichten());
    }

    @Override
    public synchronized int joinGame(String gameNaam, Gebruiker host) throws RemoteException {
        for(JoinableSpel spel : spellen) {
            if (spel.getGameNaam().equals(gameNaam)) {
                int result = spel.getAvailable();
                if(result != -1 && !spel.isGestart()) {
                    spel.addSpeler(result, host);
                    return result;
                }
            }
        }
        return -1;
    }

    @Override
    public synchronized void spectateGame(String gameNaam, Gebruiker host) throws RemoteException {
        for(JoinableSpel spel : spellen) {
            if (spel.getGameNaam().equals(gameNaam)) {
                spel.addToeschouwer(host);
            }
        }
    }

    @Override
    public synchronized void leaveLobby(RemotePropertyListener rpl, String gebruiker) throws RemoteException {
        Gebruiker geb = null;
        for(Gebruiker g : gebruikers) {
            if(g.naam.equals(gebruiker)) {
                geb = g;
            }
        }
        removeGebruiker(geb);
        bp.removeListener(rpl, "Chat");
        bp.removeListener(rpl, "GameNames");
        bp.removeListener(rpl, "UserNames");
    }
    
    @Override
    public synchronized void getUsernames(RemotePropertyListener rpl, Gebruiker gebruiker) throws RemoteException {
        bp.addListener(rpl, "UserNames");
        addGebruiker(gebruiker);
    }
}
