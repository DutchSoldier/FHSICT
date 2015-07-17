package com.example.dks;

import java.util.ArrayList;

public class Bedrijf {
	private int bedrijfNr;
	private String naam;
	private String land;
	private String plaats;
	private String straat;
	private String huisnummer;
	private String postcode;
	private ArrayList<Gebruiker> gebruikers;
	
	public int getBedrijfNr() {
		return bedrijfNr;
	}
	public void setBedrijfNr(int bedrijfNr) {
		this.bedrijfNr = bedrijfNr;
	}
	public String getNaam() {
		return naam;
	}
	public void setNaam(String naam) {
		this.naam = naam;
	}
	public String getLand() {
		return land;
	}
	public void setLand(String land) {
		this.land = land;
	}
	public String getPlaats() {
		return plaats;
	}
	public void setPlaats(String plaats) {
		this.plaats = plaats;
	}
	public String getStraat() {
		return straat;
	}
	public void setStraat(String straat) {
		this.straat = straat;
	}
	public String getHuisnummer() {
		return huisnummer;
	}
	public void setHuisnummer(String huisnummer) {
		this.huisnummer = huisnummer;
	}
	public String getPostcode() {
		return postcode;
	}
	public void setPostcode(String postcode) {
		this.postcode = postcode;
	}
	public ArrayList<Gebruiker> getGebruikers() {
		return gebruikers;
	}
	public void setGebruikers(ArrayList<Gebruiker> gebruikers) {
		this.gebruikers = gebruikers;
	}
}
