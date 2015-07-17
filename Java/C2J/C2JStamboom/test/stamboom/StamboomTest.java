package stamboom;

import java.util.Calendar;
import java.util.GregorianCalendar;
import org.junit.*;

/**
 *
 * @author 871126
 */
public class StamboomTest {

    public StamboomTest() {
    }

    @Test
    public void testStamboom() {
        Administratie adm = new Administratie();
        adm.addPersoon(Geslacht.MAN, new String[]{"Piet"}, "Swinkels",
                "", new GregorianCalendar(1924, Calendar.APRIL, 23), null);
        Persoon piet = adm.getPersoon(1);
        adm.addPersoon(Geslacht.VROUW, new String[]{"Teuntje"}, "Vries", "de",
                new GregorianCalendar(1927, Calendar.MAY, 5), null);
        Persoon teuntje = adm.getPersoon(2);
        adm.addGezin(piet, teuntje);
        Gezin teuntjeEnPiet = adm.getGezin(1);
        adm.addPersoon(Geslacht.MAN, new String[]{"Gijs", "Jozef"}, "Swinkels",
                "", new GregorianCalendar(1944, Calendar.APRIL, 21), teuntjeEnPiet);
        Persoon gijs = adm.getPersoon(3);
        adm.addPersoon(Geslacht.VROUW, new String[]{"Louise", "Isabel", "Helene"}, "Vuiter", "de",
                new GregorianCalendar(1927, Calendar.JANUARY, 15), null);
        Persoon louise = adm.getPersoon(4);
        adm.addGezin(louise, null);
        Gezin louiseAlleen = adm.getGezin(2);
        adm.addPersoon(Geslacht.VROUW, new String[]{"mary"}, "Vuiter",
                "de", new GregorianCalendar(1943, Calendar.MAY, 25), louiseAlleen);
        Persoon mary = adm.getPersoon(5);
        adm.addGezin(gijs, mary);
        Gezin gijsEnMary = adm.getGezin(3);
        adm.addPersoon(Geslacht.MAN, new String[]{"Jaron"}, "Swinkels",
                "", new GregorianCalendar(1962, Calendar.JULY, 22), gijsEnMary);
        Persoon jaron = adm.getPersoon(6);
        System.out.println(jaron.stamboomGegevensAlsString());
    }
}