package com.example.dks;


public class Identiteitsbewijs {
	private int IdentiteitsbewijsNr;
	private int sofinummer;
	private String naam;
	private String type;
	private String vervalDatum;
	private int gebruikerNr;
	
	public int getGebruikerNr() {
		return gebruikerNr;
	}
	public void setGebruikerNr(int gebruikerNr) {
		this.gebruikerNr = gebruikerNr;
	}
	public int getSofinummer() {
		return sofinummer;
	}
	public void setSofinummer(int sofinummer) {
		this.sofinummer = sofinummer;
	}
	public int getIdentiteitsbewijsNr() {
		return IdentiteitsbewijsNr;
	}
	public void setIdentiteitsbewijsNr(int identiteitsbewijsNr) {
		IdentiteitsbewijsNr = identiteitsbewijsNr;
	}
	public int getNummer() {
		return sofinummer;
	}
	public void setNummer(int nummer) {
		this.sofinummer = nummer;
	}
	public String getNaam() {
		return naam;
	}
	public void setNaam(String naam) {
		this.naam = naam;
	}
	public String getType() {
		return type;
	}
	public void setType(String type) {
		this.type = type;
	}
	public String getVervalDatum() {
		return vervalDatum;
	}
	public void setVervalDatum(String vervalDatum) {
		this.vervalDatum = vervalDatum;
	}
}
