package com.example.dks;

public class Antwoord {
	private int antwoordNr;
	private String antwoord;
	private Boolean visible;
	private Boolean selected;
	private int vraagNr;
	
	public int getAntwoordNr() {
		return antwoordNr;
	}
	public void setAntwoordNr(int antwoordNr) {
		this.antwoordNr = antwoordNr;
	}
	public String getAntwoord() {
		return antwoord;
	}
	public void setAntwoord(String antwoord) {
		this.antwoord = antwoord;
	}
	public Boolean getVisible() {
		return visible;
	}
	public void setVisible(Boolean visible) {
		this.visible = visible;
	}
	public Boolean getSelected() {
		return selected;
	}
	public void setSelected(Boolean selected) {
		this.selected = selected;
	}
	public int getVraagNr() {
		return vraagNr;
	}
	public void setVraagNr(int vraagNr) {
		this.vraagNr = vraagNr;
	}
	
	public Antwoord(int antwoordNr, String antwoord, Boolean visible,
			Boolean selected, int vraagNr) {
		super();
		this.antwoordNr = antwoordNr;
		this.antwoord = antwoord;
		this.visible = visible;
		this.selected = selected;
		this.vraagNr = vraagNr;
	}
}
