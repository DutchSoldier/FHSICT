package Classes;

import java.util.ArrayList;

public class Vraag {
	private int vraagNr;
	private String vraag;
	private String antwoord;
	private Boolean groep;
	private int enqueteNr;
	private ArrayList<Antwoord> antwoorden;
	
	public int getVraagNr() {
		return vraagNr;
	}
	public void setVraagNr(int vraagNr) {
		this.vraagNr = vraagNr;
	}
	public String getVraag() {
		return vraag;
	}
	public void setVraag(String vraag) {
		this.vraag = vraag;
	}
	public String getAntwoord() {
		return antwoord;
	}
	public void setAntwoord(String antwoord) {
		this.antwoord = antwoord;
	}
	public Boolean getGroep() {
		return groep;
	}
	public void setGroep(Boolean groep) {
		this.groep = groep;
	}
	public int getEnqueteNr() {
		return enqueteNr;
	}
	public void setEnqueteNr(int enqueteNr) {
		this.enqueteNr = enqueteNr;
	}
	public ArrayList<Antwoord> getAntwoorden() {
		return antwoorden;
	}
	public void setAntwoorden(ArrayList<Antwoord> antwoorden) {
		this.antwoorden = antwoorden;
	}
	
	public Vraag(int vraagNr, String vraag, String antwoord, Boolean groep,
			int enqueteNr, ArrayList<Antwoord> antwoorden) {
		super();
		this.vraagNr = vraagNr;
		this.vraag = vraag;
		this.antwoord = antwoord;
		this.groep = groep;
		this.enqueteNr = enqueteNr;
		this.antwoorden = antwoorden;
	}
}
