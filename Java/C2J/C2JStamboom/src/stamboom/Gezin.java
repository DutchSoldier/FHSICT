package stamboom;

import java.util.*;
import java.io.Serializable;

public class Gezin implements java.io.Serializable {

   
    // *********datavelden*************************************
    private int gezinsNr;
    private Persoon ouder1;
    private Persoon ouder2;
    private ArrayList<Persoon> kinderen;
    private static int nextGezinsNr = 1;
    
    /**
     * kan onbekend zijn
     */
    private GregorianCalendar huwelijk;
    
    /**
     * kan onbekend zijn; als start en scheiding beide bekend dan is scheiding
     * later dan start
     */
    private GregorianCalendar scheiding;

    // *********constructoren***********************************
    /**
     * er wordt een (kinderloos) gezin met ouder1 en ouder2 als ouders 
     * geregistreerd; de huwelijks-(en scheidings)datum zijn onbekend (null);
     * het gezin krijgt gezinsNr als nummer;
     * dit gezin wordt ook bij bij de ouders geregistreerd
     * 
     * @param ouder1 mag niet null zijn
     * @param ouder2 ongelijk aan ouder1
     */
    public Gezin(int gezinsNr, Persoon ouder1, Persoon ouder2) {
        if (ouder1 == null) {
            throw new RuntimeException("Eerste ouder mag niet null zijn");
        }
        if (ouder1 == ouder2) {
            throw new RuntimeException("ouders hetzelfde");
        }
        this.gezinsNr = gezinsNr++;
        this.ouder1 = ouder1;
        this.ouder2 = ouder2;
        kinderen = new ArrayList<>();
        ouder1.wordtOuderIn(this);
        if (ouder2 != null) {
            ouder2.wordtOuderIn(this);
        }
    }
    
    // ********methoden*****************************************
    /**
     * @return  alle kinderen uit dit gezin
     */
    public Iterator<Persoon> getKinderen() {
        return kinderen.iterator();
    }

    public int getNr() {
        return gezinsNr;
    }

    /**
     * @return ouder1
     */
    public Persoon getOuder1() {
        return ouder1;
    }

    /**
     * @return ouder2
     */
    public Persoon getOuder2() {
        return ouder2;
    }
    
    /**
     * @return de datum van het huwelijk (kan null zijn)
     */
    public GregorianCalendar getHuwelijk() {
        return huwelijk;
    }
    
    /**
     * @return de datum van scheiding (kan null zijn)
     */
    public GregorianCalendar getScheiding() {
        return scheiding;
    }

    /**
     * als de ouders gehuwd zijn en nog niet gescheiden, en de als parameter 
     * gegeven datum na de huwelijksdatum ligt, wordt dit de scheidngsdatum. 
     * Anders gebeurt er niets.
     */
    public void setScheiding(GregorianCalendar datum) {
        if(this.huwelijk != null && this.scheiding == null && datum.after(this.huwelijk))
        {
            this.scheiding = datum;
        }
    }

    /**
     * registreert het huwelijk, mits de ouders nog niet gehuwd zijn
     * @param datum de huwelijksdatum
     */
    public void setHuwelijk(GregorianCalendar datum) {
        if (huwelijk == null)
        {
            huwelijk = datum;
        }
    }
      
    /**
     * @return het nummer van de relatie, gevolgd door de namen van de twee
     * partners en de voornamen van de kinderen uit deze relatie (zie
     * voorbeeld in opgave)
     */
    public String Beschrijving() {
        String result;
        if (ouder2 != null)
        {
             result = Integer.toString(gezinsNr) + " " + ouder1.getNaam() + " met " + 
                ouder2.getNaam() + ";";
        }
        else
        {
             result = Integer.toString(gezinsNr) + " " + ouder1.getNaam();
        }
        
        
        if (kinderen != null && kinderen.size() > 0)
        {
            result += " kinderen: ";    
            for(Persoon p :kinderen)
            {
                result += "-" + p.getVoornamen() + " ";
            }
        }      
        return result;
    }
    
     /**
     * @return het nummer van de relatie, gevolgd door de namen van de twee
     * partners en de voornamen van de kinderen uit deze relatie (zie
     * voorbeeld in opgave)
     */
    @Override
    public String toString() {
        String result;
        if (ouder2 != null)
        {
             result = Integer.toString(gezinsNr) + " " + ouder1.getNaam() + " met " + 
                ouder2.getNaam() + ";";
        }
        else
        {
             result = Integer.toString(gezinsNr) + " " + ouder1.getNaam();
        }
        return result;
    }

    void breidUitMet(Persoon kind) {
        kinderen.add(kind);
    }
}
