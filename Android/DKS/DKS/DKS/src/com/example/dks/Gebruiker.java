package com.example.dks;

import java.util.ArrayList;

public class Gebruiker {
	private int gebruikerNr;
	private String gebruikersnaam;
	private String naam;
	private String achternaam;
	private String wachtwoord;
	private String type;
	private String land;
	private String plaats;
	private String straat;
	private String huisnummer;
	private String postcode;
	private String telefoonnummer;
	private int bedrijfNr;
	private ArrayList<Controle> controles;
	private ArrayList<Werkbon> werkbon;
	private ArrayList<Bezoekverslag> bezoekverslag;
	private ArrayList<Kwaliteitsverslag> kwaliteitsverslag;
	private ArrayList<Options> options;
	private ArrayList<Identiteitsbewijs> identiteitsbewijs;
	
	public int getGebruikerNr() {
		return gebruikerNr;
	}
	public void setGebruikerNr(int gebruikerNr) {
		this.gebruikerNr = gebruikerNr;
	}
	public String getGebruikersnaam() {
		return gebruikersnaam;
	}
	public void setGebruikersnaam(String gebruikersnaam) {
		this.gebruikersnaam = gebruikersnaam;
	}
	public String getNaam() {
		return naam;
	}
	public void setNaam(String naam) {
		this.naam = naam;
	}
	public String getAchternaam() {
		return achternaam;
	}
	public void setAchternaam(String achternaam) {
		this.achternaam = achternaam;
	}
	public String getWachtwoord() {
		return wachtwoord;
	}
	public void setWachtwoord(String wachtwoord) {
		this.wachtwoord = wachtwoord;
	}
	public String getType() {
		return type;
	}
	public void setType(String type) {
		this.type = type;
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
	public String getTelefoonnummer() {
		return telefoonnummer;
	}
	public void setTelefoonnummer(String telefoonnummer) {
		this.telefoonnummer = telefoonnummer;
	}
	public int getBedrijfNr() {
		return bedrijfNr;
	}
	public void setBedrijfNr(int bedrijfNr) {
		this.bedrijfNr = bedrijfNr;
	}
	public ArrayList<Controle> getControles() {
		return controles;
	}
	public void setControles(ArrayList<Controle> controles) {
		this.controles = controles;
	}
	public ArrayList<Werkbon> getWerkbon() {
		return werkbon;
	}
	public void setWerkbon(ArrayList<Werkbon> werkbon) {
		this.werkbon = werkbon;
	}
	public ArrayList<Bezoekverslag> getBezoekverslag() {
		return bezoekverslag;
	}
	public void setBezoekverslag(ArrayList<Bezoekverslag> bezoekverslag) {
		this.bezoekverslag = bezoekverslag;
	}
	public ArrayList<Kwaliteitsverslag> getKwaliteitsverslag() {
		return kwaliteitsverslag;
	}
	public void setKwaliteitsverslag(ArrayList<Kwaliteitsverslag> kwaliteitsverslag) {
		this.kwaliteitsverslag = kwaliteitsverslag;
	}
	public ArrayList<Options> getOptions() {
		return options;
	}
	public void setOptions(ArrayList<Options> options) {
		this.options = options;
	}
	public ArrayList<Identiteitsbewijs> getIdentiteitsbewijs() {
		return identiteitsbewijs;
	}
	public void setIdentiteitsbewijs(ArrayList<Identiteitsbewijs> identiteitsbewijs) {
		this.identiteitsbewijs = identiteitsbewijs;
	}
	
	public Gebruiker(int gebruikerNr, String gebruikersnaam, String naam,
			String achternaam, String wachtwoord, String type, String land,
			String plaats, String straat, String huisnummer, String postcode,
			String telefoonnummer, int bedrijfNr,
			ArrayList<Controle> controles, ArrayList<Werkbon> werkbon,
			ArrayList<Bezoekverslag> bezoekverslag,
			ArrayList<Kwaliteitsverslag> kwaliteitsverslag,
			ArrayList<Options> options,
			ArrayList<Identiteitsbewijs> identiteitsbewijs) {
		super();
		this.gebruikerNr = gebruikerNr;
		this.gebruikersnaam = gebruikersnaam;
		this.naam = naam;
		this.achternaam = achternaam;
		this.wachtwoord = wachtwoord;
		this.type = type;
		this.land = land;
		this.plaats = plaats;
		this.straat = straat;
		this.huisnummer = huisnummer;
		this.postcode = postcode;
		this.telefoonnummer = telefoonnummer;
		this.bedrijfNr = bedrijfNr;
		this.controles = controles;
		this.werkbon = werkbon;
		this.bezoekverslag = bezoekverslag;
		this.kwaliteitsverslag = kwaliteitsverslag;
		this.options = options;
		this.identiteitsbewijs = identiteitsbewijs;
	}
}
