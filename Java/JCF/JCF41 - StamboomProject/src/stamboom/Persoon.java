package stamboom;

import java.io.Serializable;
import java.util.*;

/**
 * @author 871059
 */
public abstract class Persoon implements Serializable {

	private static int	nextPersNr	= 0;

	/**
	 * @return the nextPersNr
	 */
	static int getNextPersNr() {
		return nextPersNr;
	}

	/**
	 * @param nextPersNr
	 *          the nextPersNr to set
	 */
	static void setNextPersNr(int nr) {
		nextPersNr = nr;
	}

	// ********datavelden**************************************

	private int									persNr;

	private String[]						voornamen;

	private String							achternaam;

	private String							tussenvoegsel;

	private GregorianCalendar		gebdat;

	private Relatie							ouders;

	private ArrayList<Relatie>	relaties;

	// ********constructoren***********************************

	/**
	 * er wordt een mens gecreeerd met een uniek personsnummer en met als
	 * voornamen vnamen, achternaam anaam, tussenvoegsel tvoegsel, geboortedatum
	 * gebdat (mag null (=onbekend) zijn en ouderlijke relatie ouders (mag null
	 * (=onbekend) zijn); de creatie van deze mens is voortaan ook bij ouders
	 * bekend, mits ouders ongelijk aan null; NB. de eerste letter van een
	 * voornaam en achternaam wordt naar een hoofdletter omgezet, alle andere
	 * letters zijn kleine letters
	 * 
	 * @param ouders
	 *          , mag null (=onbekend) zijn
	 */
	public Persoon(String[] vnamen, String anaam, String tvoegsel,
			GregorianCalendar gebdat, Relatie ouders) {
		persNr = nextPersNr;
		nextPersNr++;

		for (int i = 0; i < vnamen.length; i++) {
			vnamen[i] = vnamen[i].toUpperCase().charAt(0)
					+ vnamen[i].substring(1).toLowerCase();
		}
		voornamen = vnamen;

		achternaam = anaam.toUpperCase().charAt(0)
				+ anaam.substring(1).toLowerCase();
		tussenvoegsel = tvoegsel.toLowerCase();
		this.gebdat = gebdat;
		this.ouders = ouders;
		if (ouders != null)
			ouders.krijgtKind(this);
		relaties = new ArrayList<Relatie>();
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
		return gebdat.get(Calendar.DAY_OF_MONTH) + "-" + gebdat.get(Calendar.MONTH)
				+ "-" + gebdat.get(Calendar.YEAR);
	}

	/**
	 * 
	 * @return het geslacht van deze persoon
	 */
	public abstract Geslacht getGeslacht();

	/**
	 * 
	 * @return de voorletters van de voornamen; elke voorletter wordt gevolgd door
	 *         een punt
	 */
	public String getInitialen() {
		StringBuilder init = new StringBuilder();
		for (String s : voornamen) {
			init.append(s.charAt(0) + ".");
		}
		return init.toString();
	}

	/**
	 * 
	 * @return de initialen gevolgd door een eventueel tussenvoegsel en afgesloten
	 *         door de achternaam
	 */
	public String getNaam() {
		if (tussenvoegsel.equals(""))
			return getInitialen() + " " + achternaam;
		else
			return getInitialen() + " " + tussenvoegsel + " " + achternaam;
	}

	/**
	 * @return het nummer van deze persoon
	 */
	public int getNr() {
		return persNr;
	}

	/**
	 * @return de ouders van deze persoon, indien bekend, anders null
	 */
	public Relatie getOuders() {
		return ouders;
	}

	/**
	 * @return een iterator over de relaties waar deze persoon bij betrokken is
	 */
	public Iterator<Relatie> getRelaties() {
		return relaties.iterator();
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
		if (init.length() > 0)
			init.deleteCharAt(init.length() - 1);
		return init.toString();
	}

	/**
	 * 
	 * @return de standaard gegevens van deze mens (naam, geslacht en
	 *         geboortedatum), gevolgd door de stamboomgegevens van 1 generatie
	 *         terug, mits bekend
	 */
	public ArrayList<PersoonUitGeneratie> getStamboom() {
		ArrayList<PersoonUitGeneratie> lijst = new ArrayList<PersoonUitGeneratie>();
		lijst.add(new PersoonUitGeneratie(standaardGegevens(), 0));
		if (ouders != null) {

			lijst.addAll(ouders.stamboomgegevens(1));
		}
		return lijst;
	}

	/**
	 * @return de standaard gegevens van deze mens (naam, geslacht en
	 *         geboortedatum)
	 */
	public String standaardGegevens() {
		return getNaam() + " (" + getGeslacht() + ") " + getGebdat();
	}

	/**
	 * als de ouders van deze mens onbekend zijn krijgt deze persoon ouders
	 * aangewezen en tevens wordt er bij deze ouders bekendgemaakt dat deze mens
	 * een kind is van deze ouders als de ouders bij aanroep al wel bekend zijn,
	 * verandert er niets
	 */
	public void setOuders(Relatie ouders) {
		if (this.ouders != null)
			return;

		this.ouders = ouders;
		this.ouders.krijgtKind(this);
	}

	/**
	 * @return voornamen, eventueel tussenvoegsel en achternaam, geslacht,
	 *         geboortedatum, namen van de ouders, mits bekend, en nummers van de
	 *         relaties waarbij deze persoon betrokken is (geweest)
	 */
	public String toString() {
		StringBuilder s = new StringBuilder();

		s.append(standaardGegevens());

		if (ouders != null) {
			s.append("; 1e ouder: " + ouders.getPartner1().getNaam());
			s.append("; 2e ouder: " + ouders.getPartner2().getNaam());
		}
		if (!relaties.isEmpty()) {
			s.append("; is betrokken bij relatie(s): ");

			for (Relatie r : relaties) {
				s.append(r.getNr() + " ");
			}
		}

		return s.toString();
	}

	/**
	 * als r nog niet bij deze persoon staat geregistreerd wordt r bij deze
	 * persoon geregistreerd en anders verandert er niets
	 * 
	 * @param r
	 *          een nieuwe relatie waar deze persoon bij betrokken blijkt te zijn
	 * 
	 */
	void isBetrokkenBij(Relatie r) {
		if (!relaties.contains(r))
			relaties.add(r);
	}
}
