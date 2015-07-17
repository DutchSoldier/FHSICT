/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package BannerServer;

import BannerInterfaces.IEffectenbeurs;
import BannerInterfaces.IFonds;
import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;
import java.util.ArrayList;

/**
 *
 * @author Luc
 */
public class MockEffectenbeurs extends UnicastRemoteObject implements IEffectenbeurs {
    private ArrayList<IFonds> koersen;
    
    public MockEffectenbeurs() throws RemoteException {
        koersen = new ArrayList<>();
        koersen.add(new Fonds("test1",Math.random()));
        koersen.add(new Fonds("test2",Math.random()));
        koersen.add(new Fonds("test3",Math.random()));
        koersen.add(new Fonds("test4",Math.random()));
        koersen.add(new Fonds("test5",Math.random()));
    }
    
    @Override
    public ArrayList<IFonds> getKoersen() {
        return koersen;
    }
    
    public void updateKoersen() {
        ArrayList<IFonds> temp = new ArrayList<>();
        for (IFonds f : koersen ) {
            Fonds fonds = (Fonds) f;
            fonds.updateKoers();  
            temp.add(fonds);
        }

        koersen = temp;
    }
}
