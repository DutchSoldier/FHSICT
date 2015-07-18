/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package pixel.shared.interfaces;

import java.rmi.Remote;
import java.rmi.RemoteException;
import pixel.shared.classes.Foto;

/**
 *
 * @author Frank
 * An interface that the server uses to communicate with the client. (push)
 */
public interface IClientCommunicator extends Remote  {
  
    /**
     *
     * @param foto
     * @throws RemoteException
     */
    public void refreshPhoto(Foto foto) throws RemoteException;
}
