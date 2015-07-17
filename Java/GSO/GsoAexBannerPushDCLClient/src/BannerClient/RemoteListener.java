/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package BannerClient;

import fontys.observer.RemotePropertyListener;
import java.beans.PropertyChangeEvent;
import java.io.Serializable;
import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;

/**
 *
 * @author Luc
 */
public class RemoteListener extends UnicastRemoteObject implements RemotePropertyListener, Serializable {
     private RemotePropertyListener rpl;
        
        public RemoteListener(ConsoleTest klasse) throws RemoteException{
            this.rpl = (RemotePropertyListener)klasse;
        }
        
        @Override
        public void propertyChange(PropertyChangeEvent pce) throws RemoteException {
            rpl.propertyChange(pce);
        }
    
}
