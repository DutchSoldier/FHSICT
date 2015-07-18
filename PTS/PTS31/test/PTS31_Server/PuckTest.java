/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package PTS31_Server;

import PTS31_Server.Edge;
import PTS31_Server.Puck;
import java.awt.Color;
import java.awt.Point;
import java.util.ArrayList;
import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;
import static org.junit.Assert.*;

/**
 *
 * @author Mitch
 */
public class PuckTest {
    
    private Puck puck;
    private static Point point;
    private static ArrayList<Edge> edges = new ArrayList();
    
    public PuckTest() {
    }
    
    @BeforeClass
    public static void setUpClass() {
        point = new Point(0, 0);
        for (int i = 0; i < 6; i++) {
            edges.add(new Edge(point, point, Color.RED));
        }
        for (int i = 0; i < 3; i++) {
            edges.add(new Edge(point, point, Color.WHITE));
        }
    }
    
    @AfterClass
    public static void tearDownClass() {
    }
    
    @Before
    public void setUp() {
        puck = null;
    }
    
    @After
    public void tearDown() {
    }
    
    @Test
    public void TestBewegenEnPositie() {
        assertEquals("check de locatie", 0, (int)puck.GetPositie().distance(point));
        puck.Bewegen();
        assertEquals("check de locatie", 0, (int)puck.GetPositie().distance(new Point(10, 0)));
    }
    
    @Test
    public void TestCheckPuckSpeler() {
        
    }
    
    @Test
    public void TestCheckPuckDoel() {
        
    }
    
    @Test
    public void TestCheckPuckLevel() {
        
    }
    
    @Test
    public void TestConstructor() {
        puck = new Puck(10.53, 0.5, edges);
        assertNotNull("Normale creatie van een puck", puck);
        try {
            puck = new Puck(0.49999, 0.5, edges);
        } catch (Exception exc) {}
        assertNull("Snelheids check", puck);
        try {
            edges.remove(0);
            puck = new Puck(10.53, -1.1, edges);
        } catch (Exception exc) {}
        assertNull("Te laag aantal edges check", puck);
        try {
            edges.add(new Edge(point, point, Color.RED));
            edges.add(new Edge(point, point, Color.RED));
            puck = new Puck(10.53, -1.1, edges);
        } catch (Exception exc) {}
        assertNull("Te hoog aantal edges check", puck);
    }
}
