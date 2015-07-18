/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package PTS31_Client;

import PTS31_Client.WedstrijdFrame;
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
    private RemotePropertyListener frame;
        
        public RemoteListener(Frame frame) throws RemoteException{
            this.frame = (RemotePropertyListener)frame;
        }
        
        @Override
        public void propertyChange(PropertyChangeEvent pce) throws RemoteException {
            frame.propertyChange(pce);
        }
}
