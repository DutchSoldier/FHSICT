/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package pixel.client;

import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;
import java.util.Locale;
import javax.swing.JPanel;
import pixel.client.GUI.HoofdPanel;
import pixel.shared.classes.Foto;
import pixel.shared.interfaces.IClientCommunicator;

/**
 *
 * @author Frank 
 * A class that the server uses to communicate with the client.
 * (push)
 */
public class ClientCommunicator extends UnicastRemoteObject implements IClientCommunicator {

    static final long serialVersionUID = 47L;
    
    /**
     *
     * @throws RemoteException
     */
    public ClientCommunicator() throws RemoteException {
        
    }

    /**
     *
     * @param foto
     * @throws RemoteException
     */
    @Override
    public void refreshPhoto(Foto foto) throws RemoteException {
        JPanel panel = Client.getFrame().getActivePanel();
        if (panel instanceof HoofdPanel) {
            ((HoofdPanel)panel).getMiniatuurWeergaven().addPhoto(foto);
        }
    }
}
