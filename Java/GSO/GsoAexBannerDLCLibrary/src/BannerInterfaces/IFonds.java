/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package BannerInterfaces;

import java.rmi.Remote;
import java.rmi.RemoteException;

/**
 *
 * @author Luc
 */
public interface IFonds extends Remote  {
    public String getNaam() throws RemoteException;
    public double getKoers() throws RemoteException;
}
