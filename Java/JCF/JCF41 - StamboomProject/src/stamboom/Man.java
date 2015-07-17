package stamboom;

import java.util.*;

public class Man extends Persoon {

	/**
	 * 
	 */
	private static final long serialVersionUID = -7617199893548301803L;

	public Man(String[] vnamen, String anaam, String tvoegsel,
			GregorianCalendar gebdat, Relatie ouders) {
		super(vnamen, anaam, tvoegsel, gebdat, ouders);
	}

	public Geslacht getGeslacht() {
		return Geslacht.MAN;
	}

}