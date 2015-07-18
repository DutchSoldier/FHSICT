/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package test;

import fontys.time.IPeriod;
import opdr.Period;
import opdr.Time;
import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;
import static org.junit.Assert.*;
/**
 *
 * @author Kasper Vos - S33
 */
public class KasperUnitTest {
    
    private Time t1;
    
    private Time t2;
    
    private Time t3;
    
    private Time t4;
    
    private Period p1;
    
    private Period p2;
    
    public KasperUnitTest() {
    }
    
    @BeforeClass
    public static void setUpClass() {
    }
    
    @AfterClass
    public static void tearDownClass() {
    }
    
    @Before
    public void setUp() {
        t1 = new Time(2012,2,10,12,21);
        t2 = new Time(2012,2,10,12,22);
        t3 = new Time(2012,2,10,12,23);
        t4 = new Time(2012,2,10,12,24);
        p1 = new Period(t1,t2);
        p2 = new Period(t3,t4);
    }
    
    @After
    public void tearDown() {
    }
    // TODO add test methods here.
    // The methods must be annotated with annotation @Test. For example:
    //
    // @Test
    // public void hello() {}
    @Test
    public void TestPeriod()
    {        
        //IntersectionWith tests
        //Geen intersectie
        IPeriod p = p1.intersectionWith(p2);
        assertEquals(null, p);
        assertEquals(null, p);
        //testen van begintijd2 eerder dan begintijd1 en eindtijd2 eerder dan eindtijd1
        t1= new Time(2012,2,10,12,11); t2= new Time(2012,2,10,12,13); t3= new Time(2012,2,10,12,10); t4= new Time(2012,2,10,12,12);
        p1 = new Period(t1,t2);
        p2 = new Period(t3,t4);
        p = p1.intersectionWith(p2);
        assertEquals(11, p.getBeginTime().getMinutes());
        assertEquals(12, p.getEndTime().getMinutes());
        //testen van begintijd2 eerder begintijd1 en eindtijd1 eerder dan eindtijd2
        t1= new Time(2012,2,10,12,21); t2= new Time(2012,2,10,12,22); t3= new Time(2012,2,10,12,20); t4= new Time(2012,2,10,12,23);
        p1 = new Period(t1,t2);
        p2 = new Period(t3,t4);
        p = p1.intersectionWith(p2);
        assertEquals(21, p.getBeginTime().getMinutes());
        assertEquals(22, p.getEndTime().getMinutes());
        //testen van begintijd1 eerder begintijd2 en eindtijd1 eerder dan eindtijd2
        t1= new Time(2012,2,10,12,15); t2= new Time(2012,2,10,12,17); t3= new Time(2012,2,10,12,16); t4= new Time(2012,2,10,12,18);
        p1 = new Period(t1,t2);
        p2 = new Period(t3,t4);
        p = p1.intersectionWith(p2);
        assertEquals(16, p.getBeginTime().getMinutes());
        assertEquals(17, p.getEndTime().getMinutes());
        //testen van begintijd1 eerder begintijd2 en eindtijd2 eerder dan eindtijd1
        t1= new Time(2012,2,10,12,5); t2= new Time(2012,2,10,12,7); t3= new Time(2012,2,10,12,6); t4= new Time(2012,2,10,12,8);
        p1 = new Period(t1,t2);
        p2 = new Period(t3,t4);
        p = p1.intersectionWith(p2);
        assertEquals(6, p.getBeginTime().getMinutes());
        assertEquals(7, p.getEndTime().getMinutes());
        
        //Union With
        //testen als perioden elkaar niet raken
        t1= new Time(2012,2,10,12,20); t2= new Time(2012,2,10,12,21); t3= new Time(2012,2,10,12,22); t4= new Time(2012,2,10,12,23);
        p1 = new Period(t1,t2);
        p2 = new Period(t3,t4);
        p = p1.unionWith(p2);
        assertEquals(null, p);
        assertEquals(null, p);
        //testen van begintijd2 eerder dan begintijd1 en eindtijd2 eerder dan eindtijd1
        t1= new Time(2012,2,10,12,21); t2= new Time(2012,2,10,12,23); t3= new Time(2012,2,10,12,20); t4= new Time(2012,2,10,12,22);
        p1 = new Period(t1,t2);
        p2 = new Period(t3,t4);
        p = p1.unionWith(p2);
        assertEquals(20, p.getBeginTime().getMinutes());
        assertEquals(23, p.getEndTime().getMinutes());
        //testen van begintijd2 eerder begintijd1 en eindtijd1 eerder dan eindtijd2
        t1= new Time(2012,2,10,12,11); t2= new Time(2012,2,10,12,12); t3= new Time(2012,2,10,12,10); t4= new Time(2012,2,10,12,13);
        p1 = new Period(t1,t2);
        p2 = new Period(t3,t4);
        p = p1.unionWith(p2);
        assertEquals(10, p.getBeginTime().getMinutes());
        assertEquals(13, p.getEndTime().getMinutes());
        //testen van begintijd1 eerder begintijd2 en eindtijd1 eerder dan eindtijd2
        t1= new Time(2012,2,10,12,15); t2= new Time(2012,2,10,12,17); t3= new Time(2012,2,10,12,16); t4= new Time(2012,2,10,12,18);
        p1 = new Period(t1,t2);
        p2 = new Period(t3,t4);
        p = p1.unionWith(p2);
        assertEquals(15, p.getBeginTime().getMinutes());
        assertEquals(18, p.getEndTime().getMinutes());
        //testen van begintijd1 eerder begintijd2 en eindtijd2 eerder dan eindtijd1
        t1= new Time(2012,2,10,12,5); t2= new Time(2012,2,10,12,7); t3= new Time(2012,2,10,12,6); t4= new Time(2012,2,10,12,8);
        p1 = new Period(t1,t2);
        p2 = new Period(t3,t4);
        p = p1.unionWith(p2);
        assertEquals(5, p.getBeginTime().getMinutes());
        assertEquals(8, p.getEndTime().getMinutes());
    }
}
