package stamboom;

import java.io.Serializable;
import java.util.*;

public class Relatie implements Serializable {

	private static final long serialVersionUID = 1L;

	private static int nextRelNr = 0;
	
	static int getNextRelNr() { return nextRelNr; }

	static void setNextRelNr(int nr) { nextRelNr = nr; }
	

	// *********datavelden*************************************

	private int relNr;

	private Persoon partner1;

	private Persoon partner2;

	private ArrayList<Persoon> kinderen;

	/** kan onbekend zijn */
	private GregorianCalendar start;

	/** kan onbekend zijn; als start en scheiding beide bekend dan is scheiding
	 * later dan start
	 */
	private GregorianCalendar scheiding;
	
	// *********constructoren***********************************
	
	/**
	 * er wordt een (kinderloze) relatie tussen m1 en m2 gecreeerd; de start-
	 * (en scheidings)datum is onbekend; de relatie krijgt een uniek relatienummer
	 * teoegewezen; deze relatie wordt ook bij beide personen geregistreerd
	 */
	public Relatie(Persoon m1, Persoon m2) {
		relNr = nextRelNr;
		nextRelNr++;
		partner1 = m1;
		partner2 = m2;
		kinderen = new ArrayList<Persoon>();
		start = null;
		scheiding = null;
		m1.isBetrokkenBij(this);
		m2.isBetrokkenBij(this);

	}

	// ********methoden*****************************************
	
	/**
	 * @return  alle kinderen uit deze relatie
	 */
	public Iterator<Persoon> getKinderen() {
		return kinderen.iterator();
	}

	public int getNr() {
		return relNr;
	}

	/**
	 * @return  the partner1
	 */
	public Persoon getPartner1() {
		return partner1;
	}

	/**
	 * @return  the partner2
	 */
	public Persoon getPartner2() {
		return partner2;
	}

	/**
	 * @return  de datum van scheiding (kan onbekend zijn)
	 */
	public GregorianCalendar getScheiding() {
		return scheiding;
	}

	/**
	 * @return  de datum dat deze relatie is gestart (kan onbekend zijn)
	 */
	public GregorianCalendar getStart() {
		return start;
	}

	/**
	 * als de scheidingsdatum nog onbekend was of later is dan de startdatum wordt dit de scheidingsdatum van deze relatie
	 */
	public void setScheiding(GregorianCalendar scheiding) {
		if (start != null) {
			if (start.before(scheiding))
				this.scheiding = scheiding;
		}
	}

	/**
	 * als de startdatum nog onbekend was of eerder is dan de scheidingsdatum wordt dit de startdatum van deze relatie
	 */
	public void setStart(GregorianCalendar start) {
		if (scheiding != null) {
			if (scheiding.after(start))
				this.start = start;
		}
	}

	/**
	 * 
	 * @param generatie verwijst naar het aantal generaties terug waar deze stamboom
	 * betrekking op heeft 
	 * @return de standaardgegevens (incl nummer van de generatie; generaties zijn daarbij 
	 * terug in de tijd genummerd, dwz een eerdere generatie heeft een hoger nummer)
	 * van de eerste partner, gevolgd door stamboomgegevens van diens ouders, mits bekend, 
	 * gevolgd door de standaardgegevens (incl nummer van de generatie) van de tweede partner
	 * en gevolgd door de stamboomgegevens van diens ouders, mits bekend.
	 */
	public ArrayList<PersoonUitGeneratie> stamboomgegevens(int generatie) {
		ArrayList<PersoonUitGeneratie> lijst = new ArrayList<PersoonUitGeneratie>();

		lijst.add(new PersoonUitGeneratie(partner1.getNaam()+ " (" + 
				partner1.getGeslacht() + ") " + partner1.getGebdat(), generatie));
		Relatie ouders = partner1.getOuders();
		if (ouders != null)
			lijst.addAll(ouders.stamboomgegevens(generatie + 1));

		lijst.add(new PersoonUitGeneratie(partner2.getNaam()+ " (" + 
				partner2.getGeslacht() + ") "  + partner2.getGebdat(), generatie));
		ouders = partner2.getOuders();
		if (ouders != null)
			lijst.addAll(ouders.stamboomgegevens(generatie + 1));

		return lijst;
	}
	
	/**
	 * @return het nummer van de relatie, gevolgd door de namen van de twee
	 * partners en de voornamen van de kinderen uit deze relatie
	 */
	public String toString() {
		StringBuilder s = new StringBuilder();
		s.append("relatie " + relNr + ": ");
		s.append(" " + partner1.getNaam());
		s.append(" met " + partner2.getNaam());
		s.append("; kinderen:");
		for (Persoon p : kinderen) {
			s.append(" -" + p.getVoornamen());
		}
		return s.toString();

	}
	
	void krijgtKind(Persoon m) {
		kinderen.add(m);
	}

}
