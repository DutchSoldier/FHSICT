package console;

/**
 * @author  871059
 */
public enum Menu {
	EXIT("exit"), 
	LOAD("haal gegevens op uit een bestand"), 
	NEW_PERS("registreer persoon"), 
	NEW_REL("registreer relatie"), 
	DIVORCE("beeindig relatie"), 
	SHOW_PERS("toon gegevens persoon"), 
	SHOW_REL("toon gegevens relatie"), 
	SHOW_TREE("toon stamboom persoon");

	private String omschr;

	private Menu(String omschr) {
		this.omschr = omschr;
	}

	/**
	 * @return  the omschr
	 * @uml.property  name="omschr"
	 */
	public String getOmschr() {
		return omschr;
	}
}
