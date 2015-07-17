/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package BannerInterfaces;

import java.rmi.Remote;
import java.rmi.RemoteException;
import java.util.ArrayList;

/**
 *
 * @author Luc
 */
public interface IEffectenbeurs extends Remote {
    public ArrayList<IFonds> getKoersen() throws RemoteException;   
}
