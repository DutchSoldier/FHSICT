/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package Bank;

import fontys.observer.RemotePropertyListener;
import java.awt.Frame;
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
        
        public RemoteListener(Frame klasse) throws RemoteException{
            this.rpl = (RemotePropertyListener)klasse;
        }
        
        @Override
        public void propertyChange(PropertyChangeEvent pce) throws RemoteException {
            rpl.propertyChange(pce);
        }
    
}
