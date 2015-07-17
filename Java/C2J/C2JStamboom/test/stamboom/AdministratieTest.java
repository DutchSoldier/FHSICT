package stamboom;

import java.io.IOException;
import java.util.Iterator;
import java.util.Calendar;
import java.util.ArrayList;
import java.util.GregorianCalendar;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;
import static org.junit.Assert.*;

/**
 *
 * @author 871126
 */
public class AdministratieTest {
    private Administratie adm;
    private Persoon piet, teuntje;
    private Gezin pietEnTeuntje;  
    public AdministratieTest() {
    }

    @BeforeClass
    public static void setUpClass() throws Exception {
    }

    @AfterClass
    public static void tearDownClass() throws Exception {
    }
    
    @Before
    public void setUp() {
        adm = new Administratie();
        adm.addPersoon(Geslacht.MAN, new String[]{"Piet"}, "Swinkels",
                "", new GregorianCalendar(1950, Calendar.APRIL, 23), null);
        piet  = adm.getPersonen("Swinkels").get(0);
        adm.addPersoon(Geslacht.VROUW, new String[]{"Teuntje"}, "Vries", "de", 
                new GregorianCalendar(1949, Calendar.MAY, 5), null);
        teuntje = adm.getPersonen("Vries").get(0);
        adm.addGezin(piet, teuntje);
        Iterator<Gezin> it = piet.getGezinnen();
        pietEnTeuntje = it.next(); 
        pietEnTeuntje.setHuwelijk(new GregorianCalendar(1970, Calendar.MAY, 23));
    }         
    /**
     * Test of addPersoon method, of class Administratie.
     */
    @Test
    public void testPersonenEnRelaties() {
       assertNotNull(pietEnTeuntje);
       assertSame(pietEnTeuntje, adm.getGezin(pietEnTeuntje.getNr()));
       Iterator<Gezin> it = teuntje.getGezinnen();
       Gezin teuntjeEnPiet = it.next();
       assertFalse(it.hasNext());
       assertSame(pietEnTeuntje, teuntjeEnPiet);
       adm.addPersoon(Geslacht.MAN, new String[]{"tom", "JACOBUS"}, "sWinkelS",
                "", new GregorianCalendar(1971, Calendar.APRIL, 13), 
                pietEnTeuntje);
       ArrayList<Persoon> swinkelsen =  adm.getPersonen("Swinkels"); 
       assertEquals(2, swinkelsen.size());
       Persoon tom = swinkelsen.get(0);
       if (!tom.getVoornamen().equals("Tom Jacobus")){
           tom = swinkelsen.get(1);
           assertEquals(tom.getVoornamen(),"Tom Jacobus");
       }
       Iterator<Persoon> itKinderen = pietEnTeuntje.getKinderen();
       assertSame(tom, itKinderen.next());
       assertFalse(itKinderen.hasNext());
       adm.addPersoon(Geslacht.VROUW, new String[]{"Anouk"}, "sWinkelS",
                "", new GregorianCalendar(1972, Calendar.JUNE, 5), null); 
       swinkelsen =  adm.getPersonen("swinkels"); 
       assertEquals(3, swinkelsen.size());
       Persoon anouk = swinkelsen.get(0);
       if (!anouk.getVoornamen().equals("Anouk")){
           anouk = swinkelsen.get(1);
           if (!anouk.getVoornamen().equals("Anouk")){
               anouk = swinkelsen.get(2);
               assertEquals(anouk.getVoornamen(),"Anouk");
           }
       }
       assertNull(anouk.getOuders());
       anouk.setOuders(teuntjeEnPiet);
       assertSame(teuntjeEnPiet,anouk.getOuders());
       itKinderen = pietEnTeuntje.getKinderen();
       Persoon kind1 = itKinderen.next();
       if (kind1 != tom){
           assertSame(anouk,kind1);
           assertSame(tom,itKinderen.next());
       } else {
            assertSame(anouk,itKinderen.next());
       }
       assertFalse(itKinderen.hasNext());
    }
    
    @Test
    public void testScheiding() {
       assertNull(pietEnTeuntje.getScheiding());
       //scheidingsDatum voor voor huwelijksDatum wordt niet geregistreerd
       pietEnTeuntje.setScheiding(new GregorianCalendar(1970, Calendar.APRIL, 23));
       assertNull(pietEnTeuntje.getScheiding());
       //correcte scheidingsdatum
       GregorianCalendar scheiding = new GregorianCalendar(1974, Calendar.JULY, 2);
       pietEnTeuntje.setScheiding(scheiding);
       assertEquals(scheiding,  pietEnTeuntje.getScheiding());
       //andere scheidingsdatum wordt niet meer geaccepteerd
       pietEnTeuntje.setScheiding(new GregorianCalendar(1975, Calendar.JULY, 2));
       assertEquals(scheiding,  pietEnTeuntje.getScheiding());
    }
    
    @Test
    public void testSerialization() throws IOException, ClassNotFoundException {
        adm.save("Test");
        Administratie admLaad = new Administratie("Test.ser");
   
        assertEquals(adm.getPersoon(1).getAchternaam(), admLaad.getPersoon(1).getAchternaam());    
        assertEquals(adm.getPersoon(2).getAchternaam(), admLaad.getPersoon(2).getAchternaam());
    }
}