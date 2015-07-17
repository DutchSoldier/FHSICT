/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package Bank;
import Interfaces.IBankrekening;
import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;

/**
 *
 * @author Remi_Arts
 */
public class Bankrekening extends UnicastRemoteObject implements IBankrekening {
    int rekeningnummer;
    double saldo;
    
    public Bankrekening(int Rekeningnummer, double Saldo) throws RemoteException{
        saldo = Saldo;
        rekeningnummer = Rekeningnummer;
    }
    
    public int GetRekeningnummer(){
        return rekeningnummer;
    }
    
    @Override
    public double GetSaldo() throws RemoteException {
        return saldo;
    }
    
    @Override
    public void SetSaldo(double bedrag) {
        saldo += bedrag;
    }

    @Override
    public int GetNummer() throws RemoteException {
        return rekeningnummer;
    }
}
