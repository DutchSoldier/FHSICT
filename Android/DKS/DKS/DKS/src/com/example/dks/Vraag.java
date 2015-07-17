package com.example.dks;

import java.util.ArrayList;

public class Vraag {
	private int vraagNr;
	private String vraag;
	private String antwoord;
	private int kwaliteitsverslagNr;
	private int bezoekverslagNr;
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
	public int getKwaliteitsverslagNr() {
		return kwaliteitsverslagNr;
	}
	public void setKwaliteitsverslagNr(int kwaliteitsverslagNr) {
		this.kwaliteitsverslagNr = kwaliteitsverslagNr;
	}
	public int getBezoekverslagNr() {
		return bezoekverslagNr;
	}
	public void setBezoekverslagNr(int bezoekverslagNr) {
		this.bezoekverslagNr = bezoekverslagNr;
	}
	public ArrayList<Antwoord> getAntwoorden() {
		return antwoorden;
	}
	public void setAntwoorden(ArrayList<Antwoord> antwoorden) {
		this.antwoorden = antwoorden;
	}
	
	public Vraag(int vraagNr, String vraag, String antwoord,
			int kwaliteitsverslagNr, int bezoekverslagNr,
			ArrayList<Antwoord> antwoorden) {
		super();
		this.vraagNr = vraagNr;
		this.vraag = vraag;
		this.antwoord = antwoord;
		this.kwaliteitsverslagNr = kwaliteitsverslagNr;
		this.bezoekverslagNr = bezoekverslagNr;
		this.antwoorden = antwoorden;
	}
}
