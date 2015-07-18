package PTS31_Server;

import PTS31_Interfaces.IDatabase;
import PTS31_Interfaces.ISpeler;
import java.net.Inet4Address;
import java.rmi.Naming;
import java.rmi.NoSuchObjectException;
import java.rmi.RemoteException;
import java.rmi.registry.LocateRegistry;
import java.rmi.server.UnicastRemoteObject;

/**
 *
 * @author PIERRE BUTELA
 */
public class PTS31_RunServer {
    private static final int PORT = 1099;
    private static ISpeler speler;
    //private static IWedstrijd wedstrijd;
    private Lobby2 lobby;
    private IDatabase database;
    
    
    public PTS31_RunServer() throws RemoteException{
        
        try
            {	
                System.out.println("Starting new server...");
                this.lobby = new Lobby2();
                this.database = new DatabaseKoppeling(lobby);
                System.out.println("stub created");
                System.out.println("registry started at port " + PORT);
                Naming.rebind("rmi://localhost/Lobby", lobby);
                System.out.println("Lobby stub registered at registry");
                Naming.rebind("rmi://localhost/Database", database);
                System.out.println("Database stub registered at registry");			
                System.out.println("Server ready...");
                
                
                System.out.println("IP4 addres to connect : " + Inet4Address.getLocalHost().toString());
                
                
                //WedstrijdFrame gui = new WedstrijdFrame(lobbyPublisher,  speler, this);
                //gui.setVisible(true);
                //gui.setTitle("PTS31: Airhockey Server");
            }catch (Exception ex){           
        try 
            {
                UnicastRemoteObject.unexportObject(this.lobby, true);
                System.out.println("Server err: " + ex.getMessage()+ex);
            }catch (NoSuchObjectException ex1) {

            }finally {
                System.out.println("Something went wrong, restarting server...");
            }
        }    
    }

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {

        try{
            LocateRegistry.createRegistry(PORT);
            PTS31_RunServer server = new PTS31_RunServer();
        }catch (Exception ex){
            ex.printStackTrace();
        }

        //Lobby2 lobby = new Lobby2();

    }
}
