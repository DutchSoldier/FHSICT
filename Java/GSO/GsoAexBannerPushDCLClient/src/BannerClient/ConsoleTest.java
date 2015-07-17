/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package BannerClient;

import BannerInterfaces.IEffectenbeurs;
import BannerInterfaces.IFonds;
import fontys.observer.RemotePropertyListener;
import java.beans.PropertyChangeEvent;
import java.net.MalformedURLException;
import java.rmi.Naming;
import java.rmi.NotBoundException;
import java.rmi.RemoteException;
import java.util.ArrayList;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author Luc
 */
public class ConsoleTest implements RemotePropertyListener {
    private RemotePropertyListener rpl;
    
    public ConsoleTest  () {           
            try {
            rpl = new RemoteListener(this);
            IEffectenbeurs beurs = (IEffectenbeurs)Naming.lookup("rmi://localhost/Beurs");
            for (IFonds f : beurs.getKoersen(rpl)) {
                System.out.println(f.getNaam() +" "+ f.getKoers()); 
            }
            
        } catch (NotBoundException | MalformedURLException | RemoteException ex) {
            Logger.getLogger(ConsoleTest.class.getName()).log(Level.SEVERE, null, ex);
        }     
    }
    
    @Override
    public void propertyChange(PropertyChangeEvent pce) throws RemoteException {
        if(pce.getPropertyName().equals("Koersen")) {
            for (IFonds f : ((ArrayList<IFonds>)pce.getNewValue())) {
                System.out.println(f.getNaam() +" "+ f.getKoers()); 
            }
        }
    }

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        ConsoleTest test2 = new ConsoleTest();
    }
}
    