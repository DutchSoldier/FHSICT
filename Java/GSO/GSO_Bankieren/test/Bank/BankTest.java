/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package Bank;

import Interfaces.IBank;
import Interfaces.IOverboekCentrale;
import java.rmi.RemoteException;
import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;
import static org.junit.Assert.*;

/**
 *
 * @author Simon
 */
public class BankTest {
    private IOverboekCentrale i;
    
    public BankTest() {
    }
    
    @BeforeClass
    public static void setUpClass() {
    }
    
    @AfterClass
    public static void tearDownClass() {
    }
    
    @Before
    public void setUp() {
    }
    
    @After
    public void tearDown() {
    }

    /**
     * Test of WijzigSaldo method, of class Bank.
     */
    @Test
    public void testWijzigSaldoPositief() throws RemoteException {
        System.out.println("WijzigSaldoPositief");
        Bankrekening bankrekening = new Bankrekening(123, 100);
        int rekeningnummer = 123;
        double bedrag = 20;
        Bank instance = new Bank("bank", 1099, i);
        instance.WijzigSaldo(rekeningnummer, bedrag);
       
        assertEquals(120, bankrekening.GetSaldo(), 0);
        
        // TODO review the generated test code and remove the default call to fail.
    }
    
        /**
     * Test of WijzigSaldo method, of class Bank.
     */
    @Test
    public void testWijzigSaldoNegatief() throws RemoteException {
        System.out.println("WijzigSaldoNegatief");
        Bankrekening bankrekening = new Bankrekening(123, 100);
        int rekeningnummer = 123;
        double bedrag = -20;
        Bank instance = new Bank("bank", 1099, i);
        instance.WijzigSaldo(rekeningnummer, bedrag);
       
        assertEquals(80, bankrekening.GetSaldo(), 0);
        
        // TODO review the generated test code and remove the default call to fail.
    }

    /**
     * Test of HeeftRekeningNummer method, of class Bank.
     */
    @Test
    public void testHeeftRekeningNummerWel() throws Exception {
        System.out.println("HeeftRekeningNummerWel");
        Bankrekening bankrekening = new Bankrekening(123, 100);
        int rekeningnummer = 123;
        Bank instance = new Bank("bank", 1099, i);
        boolean expResult = true;
        boolean result = instance.HeeftRekeningNummer(rekeningnummer);
        assertEquals(expResult, result);
    }
    
    @Test
    public void testHeeftRekeningNummerNiet() throws Exception {
        System.out.println("HeeftRekeningNummerNiet");
        Bankrekening bankrekening = new Bankrekening(123, 100);
        int rekeningnummer = 124;
        Bank instance = new Bank("bank", 1099, i);
        boolean expResult = false;
        boolean result = instance.HeeftRekeningNummer(rekeningnummer);
        assertEquals(expResult, result);
    }
}
