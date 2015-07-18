/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package nl.fontys.vangeenen.rmi;

import java.rmi.Remote;
import java.rmi.RemoteException;

/**
 * Base interface for e.g. {@link Client} and {@link Server}
 * @author jgeenen
 * @param <T> the interface to which instances register itself for callbacks
 */
public interface Node<T extends Node> extends Remote{

    /** the (default) RMI registry port*/
    public static final int RMI_PORT=1099;

   
    /**
     * Register for callbacks from this {@link Node}
     * @param other the remote node
     * @throws RemoteException 
     */
    public void register(T other) throws RemoteException;
    
    /**
     * Receive a callback from a remote node
     * @param message 
     */
    public void onMessage(String message) throws RemoteException;
    
}
