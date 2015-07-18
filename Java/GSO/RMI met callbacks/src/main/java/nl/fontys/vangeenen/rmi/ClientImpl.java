/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package nl.fontys.vangeenen.rmi;

import java.rmi.registry.LocateRegistry;
import java.rmi.registry.Registry;
import java.rmi.server.UnicastRemoteObject;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author jgeenen
 */
public class ClientImpl extends NodeImpl<Server> implements Client{

    /**
     * @param args the RMI registry server's ip address
     */
    public static void main(String[] args){
        //unwise
        System.setSecurityManager(null);
        String serverAddress = (args.length < 1) ? "localhost" : args[0];
        try {
            //create RMI-stub for a ClientImpl
            final ClientImpl clientImpl = new ClientImpl();
            final Client clientStub = (Client) UnicastRemoteObject.exportObject(clientImpl,0);
            
            //register clientStub at remote server
            Registry remoteRegistry = LocateRegistry.getRegistry(serverAddress,RMI_PORT);
            Server server = (Server) remoteRegistry.lookup(Server.class.getSimpleName());
            server.register(clientStub);
            
            //start pushing messages to the server
            clientImpl.startPushing();
            
        } catch (Throwable t) {
            Logger.getLogger(ServerImpl.class.getName()).log(
                Level.SEVERE, 
                "An error ocurred. Ensure that no RMI server is running, then run this class as follows:\n"
                + "java -Djava.rmi.server.hostname=PUBLIC_CLIENT_IP -cp RMI-project-1.0-SNAPSHOT.jar nl.fontys.vangeenen.rmi.ClientImpl PUBLIC_SERVER_IP\n"
                + "* The value PUBLIC_SERVER_IP must equal the publicly routable IP of the server.\n"
                + "* The value PUBLIC_CLIENT_IP must equal YOUR routable IP.", 
                t
            );
            System.exit(1);
       }
    }
    
}
