package PTS31_Server;

import PTS31_RMI_Objecten.RMI_DrawableWedstrijd;
import PTS31_RMI_Objecten.RMI_JoinableSpel;
import java.util.ArrayList;
import org.junit.After;
import org.junit.AfterClass;
import static org.junit.Assert.*;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;

/**
 *
 * @author Luc
 */
public class Lobby2Test {
    Lobby2 lobby;
    Gebruiker gebruiker;
    
    public Lobby2Test() {
    }
    
    @BeforeClass
    public static void setUpClass() {
    }
    
    @AfterClass
    public static void tearDownClass() {
    }
    
    @Before
    public void setUp() {
        lobby = new Lobby2();
        gebruiker = new Gebruiker("Luc", 100);
        lobby.addJoinableSpel("spel1" , gebruiker);
        lobby.addJoinableSpel("spel2" , gebruiker);
    }
    
    @After
    public void tearDown() {
    }

    /**
     * Test of addBericht method, of class Lobby2.
     */
    @Test
    public void testAddBericht() {
        System.out.println("addBericht");
        Gebruiker verzender = new Gebruiker("Luc", 100);
        lobby.addBericht("test", verzender);

        String expected = "Luc: test";
        String result = lobby.getBerichten().get(0);
        assertEquals(result, expected);
    }

    /**
     * Test of getRMIJoinableSpellen method, of class Lobby2.
     */
    @Test
    public void testGetRMIJoinableSpellen() {
        System.out.println("getRMIJoinableSpellen");
        ArrayList<RMI_JoinableSpel> spellen = lobby.getRMIJoinableSpellen();
        String result1 = spellen.get(0).getWedstrijdNaam();
        int result2 = spellen.get(0).getWedstrijdId();
        String result3 = spellen.get(1).getWedstrijdNaam();
        int result4 = spellen.get(1).getWedstrijdId();
        
        assertEquals("spel1", result1); 
        assertEquals(0, result2); 
        
        assertEquals("spel2", result3); 
        assertEquals(1, result4); 
    }

    /**
     * Test of getRMIDrawableWedstrijdVoorId method, of class Lobby2.
     */
    @Test
    public void testGetRMIDrawableWedstrijdVoorId() {
        System.out.println("getRMIDrawableWedstrijdVoorId");
        int wedstrijdId = 0;
        Lobby2 instance = new Lobby2();
        RMI_DrawableWedstrijd expResult = null;
        RMI_DrawableWedstrijd result = instance.getRMIDrawableWedstrijdVoorId(wedstrijdId);
        assertEquals(expResult, result);
        // TODO review the generated test code and remove the default call to fail.
        fail("The test case is a prototype.");
    }

    /**
     * Test of addSpelerInSpel method, of class Lobby2.
     */
    @Test
    public void testAddSpelerInSpel() {
        System.out.println("addSpelerInSpel");

        boolean result1 = lobby.addSpelerInSpel(gebruiker, 0);
        boolean result2 = lobby.addSpelerInSpel(gebruiker, 0);
        boolean result3 = lobby.addSpelerInSpel(gebruiker, 0);
        boolean result4 = lobby.addSpelerInSpel(gebruiker, 1);
        boolean result5 = lobby.addSpelerInSpel(gebruiker, 2);
                
        assertEquals(true, result1); //true, spel 0 bevatte maar 1 speler
        assertEquals(true, result2); //true, spel 0 bevatte maar 2 spelers
        assertEquals(false, result3); //false, spel 0 bevatte al 3 spelers
        assertEquals(true, result4); //true, spel 1 bevatte maar 1 speler
        assertEquals(false, result5); //false, spel 2 bestaat niet
    }

    /**
     * Test of AddToeschouwerInSpel method, of class Lobby2.
     */
    @Test
    public void testAddToeschouwerInSpel() {
        System.out.println("AddToeschouwerInSpel");
        Gebruiker g = null;
        int wedstrijdId = 0;
        Lobby2 instance = new Lobby2();
        boolean expResult = false;
        boolean result = instance.AddToeschouwerInSpel(g, wedstrijdId);
        assertEquals(expResult, result);
        // TODO review the generated test code and remove the default call to fail.
        fail("The test case is a prototype.");
    }
}
