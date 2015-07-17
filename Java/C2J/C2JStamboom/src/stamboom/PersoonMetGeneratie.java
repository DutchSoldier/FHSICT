/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package stamboom;

/**
 *
 * @author Luc
 */
public class PersoonMetGeneratie {
        private String tekst;
	private int generatie; 

	public PersoonMetGeneratie(String tekst, int generatie) {
		this.tekst = tekst;
		this.generatie = generatie;
	}

	public int getGeneratie() {
		return generatie;
	}

	public String getTekst() {
		return tekst;
	}

    
}
