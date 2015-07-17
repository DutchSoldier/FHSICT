/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package BannerServer;

import java.net.MalformedURLException;
import java.rmi.Naming;
import java.rmi.RemoteException;
import java.rmi.registry.LocateRegistry;
import java.util.Timer;
import java.util.TimerTask;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author Luc
 */
public class BannerController {
    class update extends TimerTask {
        @Override
        public void run() {
            beurs.updateKoersen();
            System.out.print("update");
        }
    }
    
    private MockEffectenbeurs beurs;
    private Timer timer;
    
    public BannerController() throws RemoteException {
        beurs = new MockEffectenbeurs();
        timer = new Timer();
        timer.scheduleAtFixedRate(new update(), 1000, 1000);
        
        try {
            LocateRegistry.createRegistry(1099);
            Naming.rebind("rmi://localhost/Beurs", beurs);
            System.out.println("Beurs registered at registry");
        } catch (MalformedURLException ex) {
            Logger.getLogger(BannerController.class.getName()).log(Level.SEVERE, null, ex);
        }
        
    }
    
    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) throws RemoteException {
        BannerController bc = new BannerController();
    }
}
