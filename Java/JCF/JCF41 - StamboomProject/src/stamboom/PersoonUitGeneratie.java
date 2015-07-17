package stamboom;

/**
 * @author  871059
 */
public class PersoonUitGeneratie {

	private String tekst;

	private int generatie;

	public PersoonUitGeneratie(String tekst, int generatie) {
		this.tekst = tekst;
		this.generatie = generatie;
	}

	/**
	 * @return  the generatie
	 */
	public int getGeneratie() {
		return generatie;
	}

	/**
	 * @return  the tekst
	 * @uml.property  name="tekst"
	 */
	public String getTekst() {
		return tekst;
	}

}
