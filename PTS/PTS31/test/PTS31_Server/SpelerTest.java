/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package PTS31_Server;

import PTS31_Server.ISpeler;
import PTS31_Server.Speler;
import java.awt.Point;
import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;
import static org.junit.Assert.*;

/**
 *
 * @author Remi_Arts
 */
public class SpelerTest {
    
    public SpelerTest() {
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
     * Test of setScore method, of class Speler.
     */
    @Test
    public void testSetScore() {
        System.out.println("setScore");
        int Score = 0;
        Speler instance = null;
        instance.setScore(Score);
        // TODO review the generated test code and remove the default call to fail.
        fail("The test case is a prototype.");
    }

    /**
     * Test of setSpeler method, of class Speler.
     */
    @Test
    public void testSetSpeler() {
        System.out.println("setSpeler");
        ISpeler Speler = null;
        Speler instance = null;
        instance.setSpeler(Speler);
        // TODO review the generated test code and remove the default call to fail.
        fail("The test case is a prototype.");
    }

    /**
     * Test of setvorigePositie method, of class Speler.
     */
    @Test
    public void testSetvorigePositie() {
        System.out.println("setvorigePositie");
        Point Vorigpunt = null;
        Speler instance = null;
        instance.setvorigePositie(Vorigpunt);
        // TODO review the generated test code and remove the default call to fail.
        fail("The test case is a prototype.");
    }

    /**
     * Test of bewegen method, of class Speler.
     */
    @Test
    public void testBewegen() {
        System.out.println("bewegen");
        int x = 0;
        Speler instance = null;
        int expResult = 0;
        int result = instance.bewegen(x);
        assertEquals(expResult, result);
        // TODO review the generated test code and remove the default call to fail.
        fail("The test case is a prototype.");
    }
}
