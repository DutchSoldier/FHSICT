/**
 *
 * @author Simon_van_Amstel
 */

package fontys.time;

import org.junit.After;
import org.junit.AfterClass;
import static org.junit.Assert.*;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;

public class AppointmentTest {
    
    public AppointmentTest() {
        
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
     * Test of AddContact method, of class Appointment.
     */
    @Test
    public void testAddContact() {
        System.out.println("AddContact");
        Contact c = new Contact("test");
        Appointment instance = new Appointment();
        instance.AddContact(c);
        assertEquals(instance.invitees().next(), c);
    }
}
