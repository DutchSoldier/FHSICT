package stamboom;

import java.io.*;
import java.util.*;

public class Administratie {

    //************************datavelden*************************************
    private ArrayList<Persoon> personen;
    private int nextGezinsNr;
    private int nextPersNr;

    //***********************constructoren***********************************
    /**
     * er wordt een administratie gecreeerd met 0 personen en dus 0 gezinnen
     * personen en gezinnen die in de toekomst zullen worden gecreeerd, 
     * worden elk opvolgend genummerd vanaf 1
     */
    public Administratie() {
        nextGezinsNr = 1;
        nextPersNr = 1;
        personen = new ArrayList();
    }
    
    /**
     * er wordt een Administratie gecreëerd en gevuld aan de hand van de
     * gegevens in het bestand met de naam naamBron
     * @param naamBron een geserialiseerd objectbestand met 
     * persoonsgegevens, gevolgd door de 2 getallen die resp. betrekking 
     * hebben op een eerstvolgend persoonsnummer en gezinsnummer
     */
    public Administratie(String naamBron) throws ClassNotFoundException, IOException 
    {
        try
        {
            ObjectInputStream in = new ObjectInputStream(new FileInputStream(naamBron));
            personen = (ArrayList<Persoon>)in.readObject();
            nextPersNr = (int)in.readInt();
            nextGezinsNr = (int)in.readInt();
            in.close();
        }
        
        catch(IOException | ClassNotFoundException e)
        {
            throw e; 
        }
    }


    //**********************methoden****************************************
     /**
     * er wordt een persoon met een gegeven geslacht, met als
     * voornamen vnamen, achternaam anaam, tussenvoegsel tvoegsel, geboortedatum
     * gebdat en een gegeven ouderlijk gezin; de persoon krijgt een uniek nummer
     * toegewezen de creatie van deze persoon is voortaan ook bij het ouderlijk
     * gezin bekend. Alleen de parameter ouderlijkGezin mag de waarde null 
     * hebben. 
     */
    public void addPersoon(Geslacht geslacht, String[] vnamen, String anaam,
            String tvoegsel, GregorianCalendar gebdat, Gezin ouderlijkGezin) {
        
        personen.add(new Persoon(nextPersNr,vnamen, anaam, tvoegsel, gebdat,
                     geslacht, ouderlijkGezin));
        
        nextPersNr++;
    }

    /**
     * er wordt een (kinderloos) gezin met m1 en m2 als ouders gcreeerd;
     * de huwelijks- en scheidingsdatum zijn onbekend (null); het gezin
     * krijgt een uniek nummer toegewezen
     */
    public void addGezin(Persoon m1, Persoon m2) {
        // gecreeerd object wordt niet aan variabele gekoppeld; zie code
        // constructor van de klasse Gezin:
        new Gezin(nextGezinsNr, m1, m2);
        nextGezinsNr++;
    }

    /**
     *
     * @param nr
     * @return de persoon met nummer nr, als die niet bekend is wordt er null
     * geretourneerd
     */
    public Persoon getPersoon(int nr) {
        for(Persoon p: personen)
        {
            if(p.getNr() == nr)
            {
                return p; 
            }
        }
        return null;
    }

    /**
     * @return alle personen met een achternaam gelijk aan de meegegeven achternaam
     */
    public ArrayList<Persoon> getPersonen(String achternaam) {
        ArrayList<Persoon> juistePersonen = new ArrayList();
        for(Persoon p : personen)
        {
            if(p.getAchternaam().equalsIgnoreCase(achternaam)){
                juistePersonen.add(p);
            }
        }
        return juistePersonen;
    }
    
    public ArrayList<Persoon> getPersonen() {
        return personen;
    }

    /**
     *
     * @param gezinsNr
     * @return het gezin met nummer nr. Als dat niet bekend is wordt er null
     * geretourneerd
     */
    public Gezin getGezin(int gezinsNr) {
        // inefficiente oplossing
        for (Persoon p : personen) {
            Iterator<Gezin> it = p.getGezinnen();
            while (it.hasNext()) {
                Gezin r = it.next();
                if (r.getNr() == gezinsNr) {
                    return r;
                }
            }
        }
        return null;
    }
    
    /**
    * de persoonsgegevens worden weggeschreven in een geserialiseerd 
    * bestand met de naam naamBestemming, eerst worden de 
    * persoonsgegevens weggeschreven en vervolgens het eerstvolgende 
    * nieuwe persoonsnummer gevolgd door het nieuwe relatienummer
    * @param naamBestemming
    */
    public void save(String naamBestemming) throws IOException{
        try
        {
            ObjectOutputStream out = new ObjectOutputStream(new FileOutputStream(naamBestemming + ".ser"));
            out.writeObject(this.personen);
            out.writeInt(this.nextPersNr);
            out.writeInt(this.nextGezinsNr); 
            out.close();
        }
        
        catch(IOException e)
        {
            throw e;
        }
    }
}