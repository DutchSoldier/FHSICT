/**
 *
 * @author Luc_Martens
 */

package fontys.time;

import java.util.ArrayList;
import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;
import static org.junit.Assert.*;

public class ContactTest {
    
    Contact contact;
    
    
    public ContactTest() {
    }
    
    @BeforeClass
    public static void setUpClass() {
    }
    
    @AfterClass
    public static void tearDownClass() {
    }
    
    @Before
    public void setUp() {
        contact = new Contact("Luc");
    }
    
    @After
    public void tearDown() {
    }

    /**
     * Test of getName method, of class Contact.
     */
    @Test
    public void testGetName() {
        System.out.println("getName");
        Contact instance = contact;
        String expResult = "Luc";
        String result = instance.getName();
        assertEquals(expResult, result);
    }

    /**
     * Test of setName method, of class Contact.
     */
    @Test
    public void testSetName() {
        System.out.println("setName");
        String Name = "Luc2";
        Contact instance = contact;
        instance.setName(Name);
        assertEquals(Name, instance.getName());
    }

    /**
     * Test of addAppointment method, of class Contact.
     */
    @Test
    public void testAddAppointment() {
        System.out.println("addAppointment");
        Appointment a = new Appointment();
        Contact instance = contact;
        instance.addAppointment(a);       
        assertEquals(instance.getAppointments().get(0), a);
    }

    /**
     * Test of removeAppointment method, of class Contact.
     */
    @Test
    public void testRemoveAppointment() {
        System.out.println("removeAppointment");
        Appointment a = new Appointment();
        Contact instance = contact;
        instance.addAppointment(a);   
        instance.addAppointment(a);
        instance.removeAppointment(a);
        assertEquals(instance.getAppointments().size(), 1);
    }
}
