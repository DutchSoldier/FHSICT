package stamboom;

import java.io.*;
import java.util.*;

public class Admin {

	//************************datavelden************************************* 
	private ArrayList<Persoon> personen;
        private int nextPersNr;
	//***********************constructoren***********************************
	
	/**
	 * er wordt een administratie gecreeerd met 0 personen en dus 0 relaties
	 */
	public Admin() {
		personen = new ArrayList<Persoon>();
	}

	/**
	 * er wordt een administratie gevuld aan de hand van de gegevens in het bestand
	 * met de naam naamBron
	 * @param naamBron een geserialiseerd objectbestand met persoonsgegevens, gevolgd door 
	 * de 2 getallen die resp. betrekking hebben op een eerstvolgend persoonsnummer en 
	 * relatienummer
	 */
	public Admin(String naamBron) {
		try {
			ObjectInputStream in = new ObjectInputStream(new FileInputStream(naamBron));
			personen = (ArrayList<Persoon>)in.readObject();
			Persoon.setNextPersNr((Integer)in.readObject());
			Relatie.setNextRelNr((Integer)in.readObject());
		} catch (FileNotFoundException e) {
			personen = new ArrayList<Persoon>();
			e.printStackTrace();
		} catch (IOException e) {
			personen = new ArrayList<Persoon>();
			e.printStackTrace();
		} catch (ClassNotFoundException e) {
			personen = new ArrayList<Persoon>();
			e.printStackTrace();
		}
	}

        public Persoon initRoot() {
        int persnr = this.nextPersNr;
        this.addPersoon(Geslacht.MAN, new String[]{"Root"}, "root", "", new GregorianCalendar(), null);
        for(Persoon p : this.getAllePersonen()) {
            if(p.getVoornamen().equals("Root")) return p;
        }
        return null;
    }
	//**********************methoden**************************************** 
	
	/**
	 * er wordt afhankelijk van het geslacht een man/vrouw gecreeerd met als
	 * voornamen vnamen, achternaam anaam, tussenvoegsel tvoegsel, geboortedatum
	 * gebdat en ouderlijke relatie ouders; 
	 * de creatie van deze persoon is voortaan ook bij ouders bekend
	 */
	public void addPersoon(Geslacht geslacht, String[] vnamen, String anaam,
			String tvoegsel, GregorianCalendar gebdat, Relatie ouders) {
		if (geslacht == Geslacht.MAN)
			personen.add(new Man(vnamen, anaam, tvoegsel, gebdat, ouders));
		else
			personen.add(new Vrouw(vnamen, anaam, tvoegsel, gebdat, ouders));
	}


	/**
	 * er wordt een (kinderloze) relatie tussen m1 en m2 gecreeerd; de start-
	 * (en scheidings)datum is onbekend
	 */
	public void addRelatie(Persoon m1, Persoon m2) {
		new Relatie(m1, m2);
	}

	/**
	 * @return alle personen met een achternaam gelijk aan de meegegeven achternaam 
	 */
	public ArrayList<Persoon> getPersonen(String achternaam) {
		ArrayList<Persoon> selected = new ArrayList<Persoon>();
		for (Persoon m : personen) {
			if (m.getAchternaam().equalsIgnoreCase(achternaam))
				selected.add(m);
		}
		return selected;
	}

	/**
	 * 
	 * @param nr
	 * @return de persoon met nummer nr, als die niet bekend is wordt er null
	 * geretourneerd
	 */
	public Persoon getPersoon(int nr) {
		for (Persoon p : personen) {
			if (p.getNr() == nr)
				return p;
		}
		return null;
	}


	/**
	 * 
	 * @param relNr
	 * @return de relatie met nummer nr, als die niet bekend is wordt er null 
	 * geretourneerd
	 */
	public Relatie getRelatie(int relNr) {
		// inefficiente oplossing
		for (Persoon p : personen) {
			Iterator<Relatie> it = p.getRelaties();
			while (it.hasNext()) {
				Relatie r = it.next();
				if (r.getNr() == relNr)
					return r;
			}
		}
		return null;
	}

	/**
	 * de persoonsgegevens worden weggeschreven in een geserialiseerd bestand met de
	 * naam naamBestemming, eerst worden de persoonsgegevens weggeschreven en vervolgens
	 * het eerstvolgende nieuwe persoonsnummer gevolgd door het nieuwe relatienummer
	 * @param naamBestemming
	 */
	public void save(String naamBestemming) {
		try {
			ObjectOutputStream out = new ObjectOutputStream(new FileOutputStream(naamBestemming));
			out.writeObject(personen);
			out.writeObject(Persoon.getNextPersNr());
			out.writeObject(Relatie.getNextRelNr());
		} catch (FileNotFoundException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}
        
        public ArrayList<Persoon> getAllePersonen() {
        return this.personen;
    }
}
