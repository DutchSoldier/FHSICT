/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package pixel.server;

import pixel.shared.classes.Constants;
import pixel.shared.interfaces.IClientCommunicator;
import pixel.shared.interfaces.IServerCommunicator;

import java.net.Inet4Address;
import java.net.UnknownHostException;
import java.rmi.AlreadyBoundException;
import java.rmi.RemoteException;
import java.rmi.registry.LocateRegistry;
import java.rmi.registry.Registry;
import java.util.HashMap;
import java.util.Scanner;
import java.util.logging.Level;
import java.util.logging.Logger;
import pixel.server.core.CoresManager;

/**
 * @author Luc
 */
public class Server {

    private static Registry registry;
    // Integer = client id, deze zal 'generated' worden bij elke client connect. (eerste client die connect is 1, tweede is 2 etc.)
    private static final HashMap<Integer, IClientCommunicator> clients = new HashMap<>();
    private static boolean running = false;
    private static ServerCommunicator serverCommunicator;
    private static SqlDatabaseManager database;

    /**
     *
     * @return
     */
    public static SqlDatabaseManager getDatabase() {
        return database;
    }

    /**
     * @return
     */
    public static HashMap<Integer, IClientCommunicator> getClients() {
        return clients;
    }

    /**
     * @param args the command line arguments
     * @throws RemoteException
     */
    public static void main(String[] args) throws RemoteException {
        initialize();

        Scanner scanner = new Scanner(System.in);
        while (running) {
            if (scanner.hasNextLine()) {
                String command = scanner.nextLine();
                Logger.getLogger(Server.class.getName()).log(Level.INFO, command);
            }
        }
    }

    /**
     *
     */
    public static void initialize() {
        // first create the rmi registry
        Logger.getLogger(Server.class.getName()).log(Level.INFO, "Initializing the server...");

        Thread.setDefaultUncaughtExceptionHandler(new Thread.UncaughtExceptionHandler() {
            @Override
            public void uncaughtException(Thread t, Throwable e) {
                Logger.getLogger(Server.class.getName()).log(Level.SEVERE, "A global error was caught: ", e);
            }
        });

        Logger.getLogger(Server.class.getName()).log(Level.INFO, "Initializing the database manager..");
        database = new SqlDatabaseManager();
        
        Logger.getLogger(Server.class.getName()).log(Level.INFO, "Creating the RMI registry on port: " + Constants.PORT);
        try {
            registry = LocateRegistry.createRegistry(Constants.PORT);
        } catch (RemoteException ex) {
            Logger.getLogger(Server.class.getName()).log(Level.SEVERE, null, ex);
            return;
        }
        Logger.getLogger(Server.class.getName()).log(Level.INFO, "Initialzing the server communicator...");
        // initialize the server communicator to allow clients to communicate with the server
        try {
            serverCommunicator = new ServerCommunicator();
        } catch (RemoteException ex) {
            Logger.getLogger(Server.class.getName()).log(Level.SEVERE, null, ex);
            return;
        }
        Logger.getLogger(Server.class.getName()).log(Level.INFO, "Binding the server communicator with the RMI registry...");
        // bind the server communicator on RMI for the client to actually connect
        try {
            registry.bind(IServerCommunicator.class.getSimpleName(), serverCommunicator);
        } catch (RemoteException | AlreadyBoundException ex) {
            Logger.getLogger(Server.class.getName()).log(Level.SEVERE, null, ex);
            return;
        }
        // intialize thread pools
        Logger.getLogger(Server.class.getName()).log(Level.INFO, "Initializing cores manager...");
        CoresManager.initialize();
        
        // all initialization is done
        try {
            Logger.getLogger(Server.class.getName()).log(Level.INFO, "Server started sucessfully on IPv4: " + Inet4Address.getLocalHost().toString() + ":" + Constants.PORT);
        } catch (UnknownHostException ex) {
            Logger.getLogger(Server.class.getName()).log(Level.SEVERE, null, ex);
            return;
        }

        
        running = true;
    }

    /**
     *
     */
    public static void shutdown() {
        running = false;
    }
    
    private Server() {        
    }
}
