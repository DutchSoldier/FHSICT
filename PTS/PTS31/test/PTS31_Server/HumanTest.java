/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package PTS31_Server;

import PTS31_Server.Human;
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
public class HumanTest {
    
    public HumanTest() {
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
     * Test of getRating method, of class Human.
     */
    @Test
    public void testGetRating() {
        System.out.println("getRating");
        Human instance = new Human(100, "Henk", 1, 5);
        int expResult = 5;
        instance.setRating(5);
        int result = instance.getRating();
        assertEquals(expResult, result);
    }

    /**
     * Test of setRating method, of class Human.
     */
    @Test
    public void testSetRating() {
        System.out.println("setRating");
        int Rating = 5;
        Human instance = new Human(100, "Henk", 1, 5);
        instance.setRating(Rating);
    }
}
