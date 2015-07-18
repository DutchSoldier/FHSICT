/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package nl.fontys.vangeenen.rmi;

import java.rmi.Remote;
import java.rmi.RemoteException;
import java.rmi.registry.LocateRegistry;
import java.rmi.registry.Registry;
import java.rmi.server.UnicastRemoteObject;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author jgeenen
 */
public class ServerImpl extends NodeImpl<Client> implements Server{

    @Override
    public void register(Client other) throws RemoteException{
        super.register(other);
        other.register(this);
    }
    
    
    /**
     * Run this class as follows:<BR/>
     * <code>java -Djava.rmi.server.hostname=PUBLIC_SERVER_IP -cp RMI-project-1.0-SNAPSHOT.jar nl.fontys.vangeenen.rmi.ServerImpl</code><BR/>
     * The value <code>PUBLIC_SERVER_IP</code> must equal the publicly routable IP of the server.
     * @param args none
     */    
    public static void main(String[] args){
        //unwise
        System.setSecurityManager(null);
        try {
            final ServerImpl server = new ServerImpl();
            final Server serverStub = (Server) UnicastRemoteObject.exportObject(server,0);
            final Registry registry = LocateRegistry.createRegistry(RMI_PORT);
            registry.rebind(Server.class.getSimpleName(), serverStub);
            Logger.getLogger(Server.class.getName()).log(Level.INFO, "started {0}", Server.class.getSimpleName());
            server.startPushing();
        } catch (Throwable t) {
            Logger.getLogger(ServerImpl.class.getName()).log(
                Level.SEVERE, 
                "An error ocurred. Ensure that no RMI server is running, then run this class as follows:\n"
                + "java -Djava.rmi.server.hostname=PUBLIC_SERVER_IP -cp RMI-project-1.0-SNAPSHOT.jar nl.fontys.vangeenen.rmi.ServerImpl\n"
                + "The value PUBLIC_SERVER_IP must equal the publicly routable IP of the server", 
                t
            );
            System.exit(1);
        }
    }
}
