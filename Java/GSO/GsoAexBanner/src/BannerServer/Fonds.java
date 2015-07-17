/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package BannerServer;

import BannerInterfaces.IFonds;
import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;

/**
 *
 * @author Luc
 */
public class Fonds extends UnicastRemoteObject implements IFonds{
    private String naam;
    private double koers;
    
    public Fonds(String naam, double koers) throws RemoteException  {
        this.naam = naam;
        this.koers = koers;
    }
    
    @Override
    public String getNaam() {
        return naam;
    }

    @Override
    public double getKoers() {
        return koers;
    }
    
    @Override
    public String toString() {
        return naam + koers;
    }
    
    public void updateKoers() {
        koers = Math.random();
    }
}
