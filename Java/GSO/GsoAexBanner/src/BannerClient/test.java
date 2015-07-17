/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package BannerClient;

import BannerInterfaces.IEffectenbeurs;
import BannerInterfaces.IFonds;
import java.net.MalformedURLException;
import java.rmi.Naming;
import java.rmi.NotBoundException;
import java.rmi.RemoteException;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author Luc
 */
public class test {
    public test () {
        try {
            IEffectenbeurs beurs = (IEffectenbeurs)Naming.lookup("rmi://localhost/Beurs");
            for (IFonds f : beurs.getKoersen()) {
                System.out.println(f.getNaam() +" "+ f.getKoers()); 
            }
            
        } catch (NotBoundException | MalformedURLException | RemoteException ex) {
            Logger.getLogger(test.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        test test2 = new test();
    }
}
    