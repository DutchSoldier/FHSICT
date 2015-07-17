package com.example.dks;

import java.util.ArrayList;

public class Bezoekverslag {
	private int bezoekverslagNr;
	private String relatie;
	private String contactpersoon;
	private String onderwerp;
	private String gespreksOnderwerpen;
	private String gereedDatum;
	private String status;
	private byte[] handtekening;
	private int gebruikerNr;
	private ArrayList<Vraag> vragen;
	private ArrayList<Afspraak> afspraken;
	
	public int getBezoekverslagNr() {
		return bezoekverslagNr;
	}
	public void setBezoekverslagNr(int bezoekverslagNr) {
		this.bezoekverslagNr = bezoekverslagNr;
	}
	public String getRelatie() {
		return relatie;
	}
	public void setRelatie(String relatie) {
		this.relatie = relatie;
	}
	public String getContactpersoon() {
		return contactpersoon;
	}
	public void setContactpersoon(String contactpersoon) {
		this.contactpersoon = contactpersoon;
	}
	public String getOnderwerp() {
		return onderwerp;
	}
	public void setOnderwerp(String onderwerp) {
		this.onderwerp = onderwerp;
	}
	public String getGespreksOnderwerpen() {
		return gespreksOnderwerpen;
	}
	public void setGespreksOnderwerpen(String gespreksOnderwerpen) {
		this.gespreksOnderwerpen = gespreksOnderwerpen;
	}
	public String getGereedDatum() {
		return gereedDatum;
	}
	public void setGereedDatum(String gereedDatum) {
		this.gereedDatum = gereedDatum;
	}
	public String getStatus() {
		return status;
	}
	public void setStatus(String status) {
		this.status = status;
	}
	public byte[] getHandtekening() {
		return handtekening;
	}
	public void setHandtekening(byte[] handtekening) {
		this.handtekening = handtekening;
	}
	public int getGebruikerNr() {
		return gebruikerNr;
	}
	public void setGebruikerNr(int gebruikerNr) {
		this.gebruikerNr = gebruikerNr;
	}
	public ArrayList<Vraag> getVragen() {
		return vragen;
	}
	public void setVragen(ArrayList<Vraag> vragen) {
		this.vragen = vragen;
	}
	public ArrayList<Afspraak> getAfspraken() {
		return afspraken;
	}
	public void setAfspraken(ArrayList<Afspraak> afspraken) {
		this.afspraken = afspraken;
	}

	public Bezoekverslag(int bezoekverslagNr, String relatie,
			String contactpersoon, String onderwerp,
			String gespreksOnderwerpen, String gereedDatum, String status,
			byte[] handtekening, int gebruikerNr, ArrayList<Vraag> vragen,
			ArrayList<Afspraak> afspraken) {
		super();
		this.bezoekverslagNr = bezoekverslagNr;
		this.relatie = relatie;
		this.contactpersoon = contactpersoon;
		this.onderwerp = onderwerp;
		this.gespreksOnderwerpen = gespreksOnderwerpen;
		this.gereedDatum = gereedDatum;
		this.status = status;
		this.handtekening = handtekening;
		this.gebruikerNr = gebruikerNr;
		this.vragen = vragen;
		this.afspraken = afspraken;
	}
}
