/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package test;

import fontys.time.DayInWeek;
import fontys.time.IPeriod;
import fontys.time.ITime;
import java.util.ArrayList;
import java.util.Iterator;
import opdr.Appointment;
import opdr.Contact;
import opdr.Period;
import opdr.Period2;
import opdr.Time;
import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;
import static org.junit.Assert.*;

/**
 *
 * @author Frank van den Berg - S33
 */
public class FrankUnitTest {
    
    private Time t1;
    
    private Time t2;
    
    private Time t3;
    
    private Time t4;
    
    private IPeriod p1;
     
    private IPeriod p2;
    
    private Appointment a1;
    
    private Appointment a2;
    
    private Contact c1;
    
    private Contact c2;
    
    private Period2 p21;
    
    private Period2 p22;
    
    private Time p2t1;
    
    private long p2t2;
     
    private Time p2t3;
     
    private long p2t4;
   
    public FrankUnitTest() {
    }
    
    @BeforeClass
    public static void setUpClass() {
    }
    
    @AfterClass
    public static void tearDownClass() {
    }
    
    @Before
    public void setUp() {
        t1 = new Time(2050, 11, 5, 8, 50);
        t2 = new Time(2055, 11, 5, 8, 55);
        t3 = new Time(2012, 10, 5, 12, 7);
        t4 = new Time(2012,2,10,12,24);
        p1 = new Period(t1,t2);
        p2 = new Period(t3,t4);
        a1 = new Appointment("Subject 1", new Period(new Time(2012,10,3,11,22),new Time(2012,10,3,11,23)));
        a2 = new Appointment("Subject 2", new Period(new Time(2012,10,3,11,25),new Time(2012,10,3,11,27)));
        c1 = new Contact("Contact 1");
        c2 = new Contact("Contact 2");
        
        p2t1= new Time(2012,2,10,12,21);
        p2t2= 1;
        p2t3= new Time(2012,2,10,12,23);
        p2t4= 1;
        p21 = new Period2(p2t1, p2t2);
        p22 = new Period2(p2t3, p2t4);
    }
    
    @After
    public void tearDown() {
    }
    
    @Test
    public void testTime() {
        assertEquals(-1, t1.compareTo(t2));
        assertEquals(1, t2.compareTo(t1));
        
        assertEquals(-5, t1.difference(t2));
        
        assertEquals(DayInWeek.SUN, t2.getDayInWeek());
        assertEquals(DayInWeek.MON, t3.getDayInWeek());
        
        assertEquals(t2.getMinutes(), t1.getMinutes() + 5);
        assertEquals(t2.getMinutes(), t1.plus(5).getMinutes());
       
    }
    
    @Test
    public void testPeriod() {
        IPeriod p = p1.intersectionWith(p2);
        assertEquals(null, p);
        assertEquals(null, p);

        t1 = new Time(2012,2,10,12,11); t2= new Time(2012,2,10,12,13); t3= new Time(2012,2,10,12,10); t4= new Time(2012,2,10,12,12);
        p1 = new Period(t1, t2);
        p2 = new Period(t3, t4);
        p = p1.intersectionWith(p2);
        assertEquals(11, p.getBeginTime().getMinutes());
        assertEquals(12, p.getEndTime().getMinutes());

        t1= new Time(2012,2,10,12,21); t2= new Time(2012,2,10,12,22); t3= new Time(2012,2,10,12,20); t4= new Time(2012,2,10,12,23);
        p1 = new Period(t1,t2);
        p2 = new Period(t3,t4);
        p = p1.intersectionWith(p2);
        assertEquals(21, p.getBeginTime().getMinutes());
        assertEquals(22, p.getEndTime().getMinutes());

        t1= new Time(2012,2,10,12,15); t2= new Time(2012,2,10,12,17); t3= new Time(2012,2,10,12,16); t4= new Time(2012,2,10,12,18);
        p1 = new Period(t1,t2);
        p2 = new Period(t3,t4);
        p = p1.intersectionWith(p2);
        assertEquals(16, p.getBeginTime().getMinutes());
        assertEquals(17, p.getEndTime().getMinutes());

        t1= new Time(2012,2,10,12,5); t2= new Time(2012,2,10,12,7); t3= new Time(2012,2,10,12,6); t4= new Time(2012,2,10,12,8);
        p1 = new Period(t1,t2);
        p2 = new Period(t3,t4);
        p = p1.intersectionWith(p2);
        assertEquals(6, p.getBeginTime().getMinutes());
        assertEquals(7, p.getEndTime().getMinutes());
        
        t1= new Time(2012,2,10,12,20); t2= new Time(2012,2,10,12,21); t3= new Time(2012,2,10,12,22); t4= new Time(2012,2,10,12,23);
        p1 = new Period(t1,t2);
        p2 = new Period(t3,t4);
        p = p1.unionWith(p2);
        assertEquals(null, p);
        assertEquals(null, p);

        t1= new Time(2012,2,10,12,21); t2= new Time(2012,2,10,12,23); t3= new Time(2012,2,10,12,20); t4= new Time(2012,2,10,12,22);
        p1 = new Period(t1,t2);
        p2 = new Period(t3,t4);
        p = p1.unionWith(p2);
        assertEquals(20, p.getBeginTime().getMinutes());
        assertEquals(23, p.getEndTime().getMinutes());

        t1= new Time(2012,2,10,12,11); t2= new Time(2012,2,10,12,12); t3= new Time(2012,2,10,12,10); t4= new Time(2012,2,10,12,13);
        p1 = new Period(t1,t2);
        p2 = new Period(t3,t4);
        p = p1.unionWith(p2);
        assertEquals(10, p.getBeginTime().getMinutes());
        assertEquals(13, p.getEndTime().getMinutes());

        t1= new Time(2012,2,10,12,15); t2= new Time(2012,2,10,12,17); t3= new Time(2012,2,10,12,16); t4= new Time(2012,2,10,12,18);
        p1 = new Period(t1,t2);
        p2 = new Period(t3,t4);
        p = p1.unionWith(p2);
        assertEquals(15, p.getBeginTime().getMinutes());
        assertEquals(18, p.getEndTime().getMinutes());

        t1= new Time(2012,2,10,12,5); t2= new Time(2012,2,10,12,7); t3= new Time(2012,2,10,12,6); t4= new Time(2012,2,10,12,8);
        p1 = new Period(t1,t2);
        p2 = new Period(t3,t4);
        p = p1.unionWith(p2);
        assertEquals(5, p.getBeginTime().getMinutes());
        assertEquals(8, p.getEndTime().getMinutes());    
    }
    
    @Test
    public void testPeriode2() {
        IPeriod p = p1.intersectionWith(p2);
        assertEquals(null, p);
        assertEquals(null, p);

        p2t1= new Time(2012,2,10,12,11); p2t2= 2; p2t3= new Time(2012,2,10,12,10); p2t4= 2;
        p21 = new Period2(p2t1,p2t2);
        p22 = new Period2(p2t3,p2t4);
        p = p21.intersectionWith(p22);
        assertEquals(11, p.getBeginTime().getMinutes());
        assertEquals(12, p.getEndTime().getMinutes());
        
        p2t1= new Time(2012,2,10,12,21); p2t2= 1; p2t3= new Time(2012,2,10,12,20); p2t4= 3;
        p21 = new Period2(p2t1,p2t2);
        p22 = new Period2(p2t3,p2t4);
        p = p21.intersectionWith(p22);
        assertEquals(21, p.getBeginTime().getMinutes());
        assertEquals(22, p.getEndTime().getMinutes());
        //testen van begintijd1 eerder begintijd2 en eindtijd1 eerder dan eindtijd2
        p2t1= new Time(2012,2,10,12,15); p2t2= 2; p2t3= new Time(2012,2,10,12,16); p2t4= 2;
        p21 = new Period2(p2t1,p2t2);
        p22 = new Period2(p2t3,p2t4);
        p = p21.intersectionWith(p22);
        assertEquals(16, p.getBeginTime().getMinutes());
        assertEquals(17, p.getEndTime().getMinutes());
        //testen van begintijd1 eerder begintijd2 en eindtijd2 eerder dan eindtijd1
        p2t1= new Time(2012,2,10,12,5); p2t2= 2; p2t3= new Time(2012,2,10,12,6); p2t4= 2;
        p21 = new Period2(p2t1,p2t2);
        p22 = new Period2(p2t3,p2t4);
        p = p21.intersectionWith(p22);
        assertEquals(6, p.getBeginTime().getMinutes());
        assertEquals(7, p.getEndTime().getMinutes());
        
        //Union With
        //testen als perioden elkaar niet raken
        p2t1= new Time(2012,2,10,12,20); p2t2= 1; p2t3= new Time(2012,2,10,12,22); p2t4= 1;
        p21 = new Period2(p2t1,p2t2);
        p22 = new Period2(p2t3,p2t4);
        p = p21.unionWith(p22);
        assertEquals(null, p);
        assertEquals(null, p);
        //testen van begintijd2 eerder dan begintijd1 en eindtijd2 eerder dan eindtijd1
        p2t1= new Time(2012,2,10,12,21); p2t2= 2; p2t3= new Time(2012,2,10,12,20); p2t4= 2;
        p21 = new Period2(p2t1,p2t2);
        p22 = new Period2(p2t3,p2t4);
        p = p21.unionWith(p22);
        assertEquals(20, p.getBeginTime().getMinutes());
        assertEquals(23, p.getEndTime().getMinutes());
        //testen van begintijd2 eerder begintijd1 en eindtijd1 eerder dan eindtijd2
        p2t1= new Time(2012,2,10,12,11); p2t2= 1; p2t3= new Time(2012,2,10,12,10); p2t4= 3;
        p21 = new Period2(p2t1,p2t2);
        p22 = new Period2(p2t3,p2t4);
        p = p21.unionWith(p22);
        assertEquals(10, p.getBeginTime().getMinutes());
        assertEquals(13, p.getEndTime().getMinutes());
        //testen van begintijd1 eerder begintijd2 en eindtijd1 eerder dan eindtijd2
        p2t1= new Time(2012,2,10,12,15); p2t2= 2; p2t3= new Time(2012,2,10,12,16); p2t4= 2;
        p21 = new Period2(p2t1,p2t2);
        p22 = new Period2(p2t3,p2t4);
        p = p21.unionWith(p22);
        assertEquals(15, p.getBeginTime().getMinutes());
        assertEquals(18, p.getEndTime().getMinutes());
        //testen van begintijd1 eerder begintijd2 en eindtijd2 eerder dan eindtijd1
        p2t1= new Time(2012,2,10,12,5); p2t2= 2; p2t3= new Time(2012,2,10,12,6); p2t4= 2;
        p21 = new Period2(p2t1,p2t2);
        p22 = new Period2(p2t3,p2t4);
        p = p21.unionWith(p22);
        assertEquals(5, p.getBeginTime().getMinutes());
        assertEquals(8, p.getEndTime().getMinutes());    
    }
    
    @Test
    public void testContact() {
        Iterator<Contact> c;
        ArrayList<Contact> a = new ArrayList<Contact>();

        a1.addContact(c1);
        a.add(c1);
        c = a.iterator();
        assertEquals(c.next(),a1.invitees().next());
        
        a1.addContact(c2);
        a.add(c2);
        c = a.iterator();
        Iterator<Contact> con = a1.invitees();
        while (c.hasNext()){
         assertSame(c.next(),con.next());
        }

        a1.removeContact(c1);
        a.remove(c1);
        c = a.iterator();
        assertSame(c.next(),a1.invitees().next());
        
        assertEquals("Subject 1",a1.getSubject());
        
        IPeriod p = new Period(new Time(2012,10,3,11,22),new Time(2012,10,3,11,23));
        assertSame(p.getBeginTime().getMinutes(),a1.getPeriod().getBeginTime().getMinutes());
        assertEquals(p.getEndTime().getMinutes(),a1.getPeriod().getEndTime().getMinutes());
    }
    
    @Test
    public void testAppointment() {
        Iterator<Appointment> c;
        ArrayList<Appointment> a = new ArrayList<Appointment>();

        c1.addAppointment(a1);
        a.add(a1);
        c = a.iterator();
        assertEquals(c.next(),c1.appointments().next());
        

        c1.addAppointment(a2);
        a.add(a2);
        c = a.iterator();
        Iterator<Appointment> con = c1.appointments();
        while (c.hasNext()){
         assertSame(c.next(),con.next());
        }

        c1.removeAppointment(a1);
        a.remove(a1);
        c = a.iterator();
        assertSame(c.next(),c1.appointments().next());
        
        assertEquals("Contact 1",c1.getName());    
    }
}
