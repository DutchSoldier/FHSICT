/*
 * 
 * @author Remi_Arts
 */

package fontys.time;

import org.junit.After;
import org.junit.AfterClass;
import static org.junit.Assert.*;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;

public class PeriodTest {
    private ITime eindTijd;
    private ITime beginTijd;
    
    public PeriodTest() 
    {
        
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
     * Test of move method, of class Period.
     */
    @Test
    public void testMove() 
    {
        System.out.println("move");
        int minutes = 5;
        Period instance = new Period(10);
        instance.setBeginTime(new Time(1989, 5, 14, 6, 30));
        instance.setEndTime(new Time(1989, 5, 14, 6, 40));
        instance.move(minutes);

        assertEquals(instance.getBeginTime().getMinutes(), 35);
        assertEquals(instance.getEndTime().getMinutes(), 45);
    }
    
    @Test
    public void testMove2() 
    {
        System.out.println("move");
        int minutes = -15;
        Period instance = new Period(10);
        instance.setBeginTime(new Time(1989, 5, 14, 6, 0));
        instance.setEndTime(new Time(1989, 5, 14, 6, 10));
        instance.move(minutes);

        assertEquals(instance.getBeginTime().getMinutes(), 45);
        assertEquals(instance.getEndTime().getMinutes(), 55);
    }
    
    /**
     * Test of changeLengthWith method, of class Period.
     */
    @Test
    public void testChangeLengthWith() {
        System.out.println("changeLengthWith");
        int minutes = 5;
        Period instance = new Period(10);
        instance.setBeginTime(new Time(1989, 5, 14, 6, 30));
        instance.setEndTime(new Time(1989, 5, 14, 6, 40));
        instance.changeLengthWith(minutes);

        assertEquals(instance.getBeginTime().getMinutes(), 30);
        assertEquals(instance.getEndTime().getMinutes(), 45);
    }
    
    @Test
    public void testChangeLengthWith2() {
        System.out.println("changeLengthWith");
        int minutes = -5;
        Period instance = new Period(10);
        instance.setBeginTime(new Time(1989, 5, 14, 6, 30));
        instance.setEndTime(new Time(1989, 5, 14, 6, 40));
        instance.changeLengthWith(minutes);

        assertEquals(instance.getBeginTime().getMinutes(), 30);
        assertEquals(instance.getEndTime().getMinutes(), 40);
    }

    /**
     * Test of isPartOf method, of class Period.
     */
    @Test
    public void testIsPartOf() {
        System.out.println("isPartOf");
        IPeriod period = new Period(15);
        Period instance = new Period(25);
        period.setBeginTime(new Time(1989, 5, 14, 6, 35));
        period.setEndTime(new Time(1989, 5, 14, 6, 50));
        instance.setBeginTime(new Time(1989, 5, 14, 6, 30));
        instance.setEndTime(new Time(1989, 5, 14, 6, 55));
        

        assertEquals(period.isPartOf(instance), true);
    }

    @Test
    public void testIsPartOf2() {
        System.out.println("isPartOf");
        IPeriod period = new Period(5);
        Period instance = new Period(10);
        period.setBeginTime(new Time(1989, 5, 14, 6, 35));
        period.setEndTime(new Time(1989, 5, 14, 6, 40));
        instance.setBeginTime(new Time(1989, 5, 14, 6, 45));
        instance.setEndTime(new Time(1989, 5, 14, 6, 55));
        

        assertEquals(instance.isPartOf(period), false);
    }
    
    @Test
    public void testIsPartO3f() {
        System.out.println("isPartOf");
        IPeriod period = new Period(25);
        Period instance = new Period(25);
        period.setBeginTime(new Time(1989, 5, 14, 6, 35));
        period.setEndTime(new Time(1989, 5, 14, 6, 60));
        instance.setBeginTime(new Time(1989, 5, 14, 6, 30));
        instance.setEndTime(new Time(1989, 5, 14, 6, 55));
        

        assertEquals(period.isPartOf(instance), false);
    }
    
    /**
     * Test of unionWith method, of class Period.
     */
    @Test
    public void testUnionWith() {
        System.out.println("unionWith");
        IPeriod period = new Period(15);
        Period instance = new Period(25);
        IPeriod expResult = period;
        period.setBeginTime(new Time(1989, 5, 14, 6, 35));
        period.setEndTime(new Time(1989, 5, 14, 6, 50));
        instance.setBeginTime(new Time(1989, 5, 14, 6, 30));
        instance.setEndTime(new Time(1989, 5, 14, 6, 55));
        assertEquals(expResult, instance.unionWith(period));
        // TODO review the generated test code and remove the default call to fail.
    }

    @Test
    public void testUnionWith2() {
        System.out.println("unionWith");
        IPeriod period = new Period(15);
        Period instance = new Period(25);
        IPeriod expResult = null;
        period.setBeginTime(new Time(1989, 5, 14, 6, 10));
        period.setEndTime(new Time(1989, 5, 14, 6, 25));
        instance.setBeginTime(new Time(1989, 5, 14, 6, 30));
        instance.setEndTime(new Time(1989, 5, 14, 6, 55));
        assertEquals(expResult, instance.unionWith(period));
        // TODO review the generated test code and remove the default call to fail.
    }
    
    @Test
    public void testUnionWith3() {
        System.out.println("unionWith");
        IPeriod period = new Period(25);
        Period instance = new Period(25);
        IPeriod expResult = instance;
        period.setBeginTime(new Time(1989, 5, 14, 6, 35));
        period.setEndTime(new Time(1989, 5, 14, 6, 60));
        instance.setBeginTime(new Time(1989, 5, 14, 6, 30));
        instance.setEndTime(new Time(1989, 5, 14, 6, 55));
        assertEquals(expResult, instance.unionWith(period));
        // TODO review the generated test code and remove the default call to fail.
    }
    
    /**
     * Test of intersectionWith method, of class Period.
     */
    @Test
    public void testIntersectionWith() {
        System.out.println("intersectionWith");
        IPeriod period = new Period(15);
        Period instance = new Period(25);
        IPeriod expResult = instance;
        period.setBeginTime(new Time(1989, 5, 14, 6, 35));
        period.setEndTime(new Time(1989, 5, 14, 6, 50));
        instance.setBeginTime(new Time(1989, 5, 14, 6, 30));
        instance.setEndTime(new Time(1989, 5, 14, 6, 55));
        assertEquals(expResult, instance.intersectionWith(period));
        // TODO review the generated test code and remove the default call to fail.
    }

    @Test
    public void testIntersectionWith2() {
        System.out.println("intersectionWith");
        IPeriod period = new Period(15);
        Period instance = new Period(25);
        IPeriod expResult = null;
        period.setBeginTime(new Time(1989, 5, 14, 6, 10));
        period.setEndTime(new Time(1989, 5, 14, 6, 25));
        instance.setBeginTime(new Time(1989, 5, 14, 6, 30));
        instance.setEndTime(new Time(1989, 5, 14, 6, 55));
        assertEquals(expResult, instance.intersectionWith(period));
        // TODO review the generated test code and remove the default call to fail.
    }
    
    @Test
    public void testIntersectionWith3() {
        System.out.println("intersectionWith");
        IPeriod period = new Period(25);
        Period instance = new Period(25);
        IPeriod expResult = period;
        period.setBeginTime(new Time(1989, 5, 14, 7, 35));
        period.setEndTime(new Time(1989, 5, 14, 7, 60));
        instance.setBeginTime(new Time(1989, 5, 14, 6, 30));
        instance.setEndTime(new Time(1989, 5, 14, 6, 55));
        assertEquals(expResult, instance.intersectionWith(period));
        // TODO review the generated test code and remove the default call to fail.
    }
}
