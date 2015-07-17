/**
 *
 * @author Remi_Arts
 */

package fontys.time;

import static org.junit.Assert.*;

public class TimeTest {
    
    public TimeTest() {
    }

    @org.junit.BeforeClass
    public static void setUpClass() throws Exception {
    }

    @org.junit.AfterClass
    public static void tearDownClass() throws Exception {
    }

    @org.junit.Before
    public void setUp() throws Exception {
    }

    @org.junit.After
    public void tearDown() throws Exception {
    }
    
   /** @BeforeClass
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
    }*/

    /**
     * Test of getDayInWeek method, of class Time.
     */
    @org.junit.Test
    public void testGetDayInWeek() {
        System.out.println("getDayInWeek");
        Time instance = new Time(2012, 10, 18, 12, 30);
        DayInWeek expResult = DayInWeek.MON;
        DayInWeek result = instance.getDayInWeek();
        assertEquals(expResult, result);
    }
    
    @org.junit.Test
    public void testGetDayInWeek2() {
        System.out.println("getDayInWeek");
        Time instance = new Time(2012, 10, 19, 12, 30);
        DayInWeek expResult = DayInWeek.TUE;
        DayInWeek result = instance.getDayInWeek();
        assertEquals(expResult, result);
    }

    /**
     * Test of plus method, of class Time.
     */
    @org.junit.Test
    public void testPlus() {
        System.out.println("plus");
        int minutes = 5;
        ITime instance = new Time(1992, 10, 3, 12, 30);
        ITime expResult = new Time(1992, 10, 3, 12, 35);
        ITime result = instance.plus(minutes);
        
        assertEquals(expResult.getYear(), result.getYear());
        assertEquals(expResult.getMonth(), result.getMonth());
        assertEquals(expResult.getDay(), result.getDay());
        assertEquals(expResult.getHours(), result.getHours());
        assertEquals(expResult.getMinutes(), result.getMinutes());
    }

    @org.junit.Test
    public void testPlus2() {
        System.out.println("plus");
        int minutes = -5;
        ITime instance = new Time(1992, 10, 3, 12, 30);
        ITime expResult = new Time(1992, 10, 3, 12, 25);
        ITime result = instance.plus(minutes);
        
        assertEquals(expResult.getYear(), result.getYear());
        assertEquals(expResult.getMonth(), result.getMonth());
        assertEquals(expResult.getDay(), result.getDay());
        assertEquals(expResult.getHours(), result.getHours());
        assertEquals(expResult.getMinutes(), result.getMinutes());
    }
    
    /**
     * Test of difference method, of class Time.
     */
    @org.junit.Test
    public void testDifference() {
        System.out.println("difference");
        ITime time = new Time(1992, 10, 3, 12, 30);
        Time instance = new Time(1992, 10, 3, 12, 20);
        int expResult = -10;
        int result = instance.difference(time);
        assertEquals(expResult, result);
    }
    
    @org.junit.Test
    public void testDifference2() {
        System.out.println("difference");
        ITime time = new Time(1992, 10, 3, 12, 30);
        Time instance = new Time(1992, 10, 3, 12, 40);
        int expResult = 10;
        int result = instance.difference(time);
        assertEquals(expResult, result);
    }

    @org.junit.Test
    public void testDifference3() {
        System.out.println("difference");
        ITime time = new Time(1992, 10, 3, 12, 30);
        Time instance = new Time(1992, 10, 3, 12, 30);
        int expResult = 0;
        int result = instance.difference(time);
        assertEquals(expResult, result);
    }
    
    /**
     * Test of compareTo method, of class Time.
     */
    @org.junit.Test
    public void testCompareTo() {
        System.out.println("compareTo");
        ITime o = new Time(1992, 10, 3, 12, 30);
        Time instance = new Time(1992, 10, 3, 12, 30);
        int expResult = 0;
        int result = instance.compareTo(o);
        assertEquals(expResult, result);
    }
    
    @org.junit.Test
    public void testCompareTo2() {
        System.out.println("compareTo");
        ITime o = new Time(1992, 10, 3, 12, 30);
        Time instance = new Time(1992, 10, 3, 12, 40);
        int expResult = 1;
        int result = instance.compareTo(o);
        assertEquals(expResult, result);
    }
    
    @org.junit.Test
    public void testCompareTo3() {
        System.out.println("compareTo");
        ITime o = new Time(1992, 10, 3, 12, 30);
        Time instance = new Time(1992, 10, 3, 12, 20);
        int expResult = -1;
        int result = instance.compareTo(o);
        assertEquals(expResult, result);
    }
}
