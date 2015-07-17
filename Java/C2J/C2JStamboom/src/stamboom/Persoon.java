package stamboom;

import java.util.*;

public class Persoon implements java.io.Serializable {

    // ********datavelden**************************************
    private int persNr;
    private String[] voornamen;
    private String achternaam;
    private String tussenvoegsel;
    private GregorianCalendar gebdat;
    private Gezin ouders;
    private ArrayList<Gezin> gezinnen;
    private Geslacht geslacht;  
  

   // ********constructoren***********************************
    /**
     * er wordt een persoon gecreeerd met persoonsnummer persNr en met als
     * voornamen vnamen, achternaam anaam, tussenvoegsel tvoegsel, geboortedatum
     * gebdat, gelsacht geslacht en een gegeven ouderlijk gezin (mag null
     * (=onbekend) zijn); de creatie van deze persoon is voortaan ook bij het
     * ouderlijk gezin bekend, mits dit bekend is; NB. de eerste letter van een
     * voornaam en achternaam wordt naar een hoofdletter omgezet, alle andere
     * letters zijn kleine letters
     *
     */
    public Persoon(int persNr, String[] vnamen, String anaam, String tvoegsel,
            GregorianCalendar gebdat, Geslacht geslacht, Gezin ouderlijkGezin) {
       
        this.persNr = persNr;
        this.achternaam = anaam;
        this.tussenvoegsel = tvoegsel;
        this.gebdat = gebdat;
        this.geslacht = geslacht;
        this.ouders = ouderlijkGezin;
        if(this.ouders != null){
            this.ouders.breidUitMet(this);
        }
        this.gezinnen = new ArrayList();
        
        this.achternaam = Character.toUpperCase(anaam.charAt(0)) + 
                          anaam.substring(1).toLowerCase();
        
        /*
        String temp[] = new String[vnamen.length];
        this.voornamen = new String[vnamen.length];
        for(int i = 0; i < vnamen.length -1; i++)
        {
            temp[i] = Character.toUpperCase(vnamen[i].charAt(0)) + 
                                vnamen[i].substring(1).toLowerCase();
        }
        this.voornamen = temp;
        * */
        
        for (int x = 0; x < vnamen.length; x++) {
            String vletter = vnamen[x].substring(0, 1);
            vletter = vletter.toUpperCase();
            String tempnaam = vnamen[x].substring(1, vnamen[x].length());
            tempnaam = tempnaam.toLowerCase();
            vnamen[x] = vletter + tempnaam;
        }
        String aletter = anaam.substring(0, 1);
        aletter = aletter.toUpperCase();
        anaam = anaam.substring(1, anaam.length());
        anaam = anaam.toLowerCase();
        anaam = aletter + anaam;
        
        this.voornamen = vnamen;
    }

    // ********methoden****************************************
    /**
     * @return de achternaam van deze persoon
     */
    public String getAchternaam() {
        return achternaam;
    }

    /**
     * @return de geboortedatum van deze persoon in de stringvorm
     *         dagnummer-maandnummer-jaartal
     */
    public String getGebdat() {
        return gebdat.get(Calendar.DAY_OF_MONTH) + "-" +
                (gebdat.get(Calendar.MONTH)+1) + "-" + gebdat.get(Calendar.YEAR);
    }

    /**
     *
     * @return het geslacht van deze persoon
     */
    public Geslacht getGeslacht(){
        return geslacht;
    };

    /**
     *
     * @return de voorletters van de voornamen; elke voorletter wordt gevolgd door
     *         een punt
     */
    public String getInitialen() {
        String result = "";
        for(int i = 0; i < voornamen.length; i++)
        {
            result += voornamen[i];
            if (i != voornamen.length - 1) {
                result += " ";
            }  
        }
        return result;
    }

    /**
     *
     * @return de initialen gevolgd door een eventueel tussenvoegsel en afgesloten
     *         door de achternaam
     */
    public String getNaam() {
        if (this.tussenvoegsel != null && !this.tussenvoegsel.isEmpty()) {
        return getInitialen() + " " + this.tussenvoegsel + " " + this.achternaam;
        }
        else {
            return getInitialen() + " " + this.achternaam;
        }
            
    }

    /**
     * @return het nummer van deze persoon
     */
    public int getNr() {
        return persNr;
    }

   /**
     * @return een iterator over de gezinnen waar deze persoon bij betrokken is
     */
    public Iterator<Gezin> getGezinnen() {
        return gezinnen.iterator();
    }

     /**
     * @return het tussenvoegsel van de naam van deze persoon (kan een lege string
     *         zijn)
     */
    public String getTussenvoegsel() {
        return tussenvoegsel;
    }

    /**
     * @return alle voornamen onderling gescheiden door een spatie
     */
    public String getVoornamen() {
        StringBuilder init = new StringBuilder();
        for (String s : voornamen) {
            init.append(s + " ");
        }
        // de laatste spatie verwijderen:
        if (init.length() > 0) {
            init.deleteCharAt(init.length() - 1);
        }
        return init.toString();
    }

    /**
     * @return de standaard gegevens van deze mens (naam, geslacht en
     *         geboortedatum)
     */
    public String standaardGegevens() {
        return getNaam() + " (" + getGeslacht() + ") " + getGebdat();
    }

     /**
     * @return het ouderlijk gezin van deze persoon, indien bekend, anders null
     */
    public Gezin getOuders() {
        return ouders;
    }
    
        
     /**
     * Als het ouderlijk gezin ('ouders') van deze persoon (this) nog onbekend is krijgt deze
     * het gegeven ouderlijk gezin toegewezen en tevens wordt deze persoon (this)
     * als kind in dat gegeven ouderlijk gezin geregistreerd.
     * Als de ouders bij aanroep al bekend zijn, verandert er niets.
     */
    public void setOuders(Gezin ouders) {
        if (this.ouders == null)
        {   
            this.ouders = ouders;
            this.ouders.breidUitMet(this);
        }
    }

    /**
     * @return voornamen, eventueel tussenvoegsel en achternaam, geslacht,
     *         geboortedatum, namen van de ouders, mits bekend, en nummers van de
     *         gezinnen waarbij deze persoon betrokken is (geweest)
     */
    public String Beschrijving() {
        StringBuilder s = new StringBuilder();

        s.append(standaardGegevens());

        if (ouders != null) {
            s.append("; 1e ouder: " + ouders.getOuder1().getNaam());
            
            if (ouders.getOuder2() != null)
            {
                s.append("; 2e ouder: " + ouders.getOuder2().getNaam());
            }
        }
        if (!gezinnen.isEmpty()) {
            s.append("; is ouder in gezin ");

            for (Gezin g : gezinnen) {
                s.append(g.getNr() + " ");
            }
        }

        return s.toString();
    }
    
    @Override
    public String toString() {
        return this.standaardGegevens();
    }
    
    /**
     * als g nog niet bij deze persoon staat geregistreerd wordt g bij deze
     * persoon geregistreerd en anders verandert er niets
     *
     * @param g
     *          een nieuw gezin waarin deze persoon een ouder is
     *
     */
    void wordtOuderIn(Gezin g) {
        if (!gezinnen.contains(g)) {
            gezinnen.add(g);
        }
    }
    
    /**
* Voegt de stamboomgegevens van deze persoon toe aan een lijst 
* @param generatie de generatie van deze persoon in de lijst
* @param lijst (niet null) 
*/
    public void voegStamboomgegevensToeAan(ArrayList<PersoonMetGeneratie> lijst, int generatie) {
        generatie++;
        try{
            lijst.add(new PersoonMetGeneratie(ouders.getOuder1().toString(), generatie));
            ouders.getOuder1().voegStamboomgegevensToeAan(lijst, generatie);
            lijst.add(new PersoonMetGeneratie(ouders.getOuder2().toString(), generatie));
            ouders.getOuder2().voegStamboomgegevensToeAan(lijst, generatie);
        }
        catch(Exception ex) {}
    }

    
    /**
    * @return de stamboomgegevens van deze persoon in de vorm van een 
    * String, waarbij iedere persoon op een aparte regel staat en iedere * voorgaande generatie twee posities inspringt. 
    */
    public String stamboomGegevensAlsString() {
        ArrayList<PersoonMetGeneratie> a = new ArrayList<>();
        a.add(new PersoonMetGeneratie(getNaam(), 0));
        voegStamboomgegevensToeAan(a, 0);
        String result = "";
        for (PersoonMetGeneratie p : a) {
            for (int i = 0; i < p.getGeneratie(); i++) {
                result += "     ";
            }
            result += p.getTekst() + "\n";
        }
        return result;  
    }
}
