/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package Bank;

import Interfaces.IBank;
import Interfaces.IOverboekCentrale;
import java.net.MalformedURLException;
import java.rmi.Naming;
import java.rmi.NotBoundException;
import java.rmi.RemoteException;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author Remi_Arts
 */
public class ABN {
    Bank bank;
    
    public ABN() throws RemoteException, NotBoundException {
        
        try {
            IOverboekCentrale ioc = (IOverboekCentrale)Naming.lookup("rmi://localhost:1099/OverboekCentrale");
            bank = new Bank("ABN-Amro", 1100, ioc);
            IBank iBank = bank;
            
            ioc.AddBank(iBank);
            
        } catch (MalformedURLException ex) {
            Logger.getLogger(ABN.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
    
    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) throws RemoteException, NotBoundException {
        ABN bank = new ABN();
    }
}
