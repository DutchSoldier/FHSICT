package stamboom;

import java.util.*;

public class Vrouw extends Persoon {

	/**
	 * 
	 */
	private static final long serialVersionUID = 3745796626973939766L;

	public Vrouw(final String[] vnamen, final String anaam, final String tvoegsel,
			final GregorianCalendar gebdat, final Relatie ouders) {
		super(vnamen, anaam, tvoegsel, gebdat, ouders);	
	}

	public Geslacht getGeslacht() {
		return Geslacht.VROUW;
	}
	
}
