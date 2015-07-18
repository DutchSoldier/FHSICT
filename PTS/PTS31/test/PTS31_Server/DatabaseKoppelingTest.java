/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package PTS31_Server;

import PTS31_Server.DatabaseKoppeling;
import org.junit.After;
import org.junit.AfterClass;
import static org.junit.Assert.*;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;

/**
 *
 * @author Simon
 */
public class DatabaseKoppelingTest {
    
    public DatabaseKoppelingTest() {
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
     * Test of Login method, of class DatabaseKoppeling.
     */
    @Test
    public void testLoginCorrect() {
        System.out.println("LoginCorrect");
        String username = "Simon";
        String wachtwoord = "test";
        DatabaseKoppeling instance = new DatabaseKoppeling();
        boolean expResult = true;
        boolean result = instance.Login(username, wachtwoord);
        assertEquals(expResult, result);
        // TODO review the generated test code and remove the default call to fail.
    }
    
    @Test
    public void testLoginFout() {
        System.out.println("LoginFout");
        String username = "Simon";
        String wachtwoord = "nietGoed";
        DatabaseKoppeling instance = new DatabaseKoppeling();
        boolean expResult = false;
        boolean result = instance.Login(username, wachtwoord);
        assertEquals(expResult, result);
        // TODO review the generated test code and remove the default call to fail.
    }
    
        @Test
    public void testCheckUsernameCorrect() {
        System.out.println("CheckUsernameCorrect");
        String username = "Simon";
        DatabaseKoppeling instance = new DatabaseKoppeling();
        boolean expResult = true;
        boolean result = instance.CheckUsername(username);
        assertEquals(expResult, result);
        // TODO review the generated test code and remove the default call to fail.
    }
        
    @Test
    public void testCheckUsernameFout() {
        System.out.println("CheckUsernameFout");
        String username = "Luc";
        DatabaseKoppeling instance = new DatabaseKoppeling();
        boolean expResult = false;
        boolean result = instance.CheckUsername(username);
        assertEquals(expResult, result);
        // TODO review the generated test code and remove the default call to fail.
    }
        
    @Test
    public void testGetRating() {
            System.out.println("GetRating");
            String username = "Simon";
            int rating;
            DatabaseKoppeling instance = new DatabaseKoppeling();
            int expResult = 30;
            int result = instance.GetRating(username);
            assertEquals(expResult, result);
    }
}
