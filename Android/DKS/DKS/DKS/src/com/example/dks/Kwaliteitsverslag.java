package com.example.dks;

import java.util.ArrayList;

public class Kwaliteitsverslag {
	private int kwaliteitsverslagNr;
	private int debiteurnummer;
	private String debiteurnaam;
	private int projectnummer;
	private String projectnaam;
	private String telefoonnummer;
	private String contactpersoon;
	private int weeknummer;
	private String straat;
	private String huisnummer;
	private String postcode;
	private String plaats;
	private String status;
	private String startDatum;
	private String gereedDatum;
	private String opmerkingen;
	private byte[] handtekeningVisschedijk;
	private byte[] handtekeningOpdrachtgever;
	private int gebruikerNr;
	private ArrayList<Vraag> vragen;
	
	public String getHuisnummer() {
		return huisnummer;
	}
	public void setHuisnummer(String huisnummer) {
		this.huisnummer = huisnummer;
	}
	public String getStartDatum() {
		return startDatum;
	}
	public void setStartDatum(String startDatum) {
		this.startDatum = startDatum;
	}
	public int getGebruikerNr() {
		return gebruikerNr;
	}
	public void setGebruikerNr(int gebruikerNr) {
		this.gebruikerNr = gebruikerNr;
	}
	public int getKwaliteitsverslagNr() {
		return kwaliteitsverslagNr;
	}
	public void setKwaliteitsverslagNr(int kwaliteitsverslagNr) {
		this.kwaliteitsverslagNr = kwaliteitsverslagNr;
	}
	public int getDebiteurnummer() {
		return debiteurnummer;
	}
	public void setDebiteurnummer(int debiteurnummer) {
		this.debiteurnummer = debiteurnummer;
	}
	public String getDebiteurnaam() {
		return debiteurnaam;
	}
	public void setDebiteurnaam(String debiteurnaam) {
		this.debiteurnaam = debiteurnaam;
	}
	public int getProjectnummer() {
		return projectnummer;
	}
	public void setProjectnummer(int projectnummer) {
		this.projectnummer = projectnummer;
	}
	public String getProjectnaam() {
		return projectnaam;
	}
	public void setProjectnaam(String projectnaam) {
		this.projectnaam = projectnaam;
	}
	public String getTelefoonnummer() {
		return telefoonnummer;
	}
	public void setTelefoonnummer(String telefoonnummer) {
		this.telefoonnummer = telefoonnummer;
	}
	public String getContactpersoon() {
		return contactpersoon;
	}
	public void setContactpersoon(String contactpersoon) {
		this.contactpersoon = contactpersoon;
	}
	public int getWeeknummer() {
		return weeknummer;
	}
	public void setWeeknummer(int weeknummer) {
		this.weeknummer = weeknummer;
	}
	public String getStraat() {
		return straat;
	}
	public void setStraat(String straat) {
		this.straat = straat;
	}
	public String getPostcode() {
		return postcode;
	}
	public void setPostcode(String postcode) {
		this.postcode = postcode;
	}
	public String getPlaats() {
		return plaats;
	}
	public void setPlaats(String plaats) {
		this.plaats = plaats;
	}
	public String getStatus() {
		return status;
	}
	public void setStatus(String status) {
		this.status = status;
	}
	public String getGereedDatum() {
		return gereedDatum;
	}
	public void setGereedDatum(String gereedDatum) {
		this.gereedDatum = gereedDatum;
	}
	public String getOpmerkingen() {
		return opmerkingen;
	}
	public void setOpmerkingen(String opmerkingen) {
		this.opmerkingen = opmerkingen;
	}
	public byte[] getHandtekeningVisschedijk() {
		return handtekeningVisschedijk;
	}
	public void setHandtekeningVisschedijk(byte[] handtekeningVisschedijk) {
		this.handtekeningVisschedijk = handtekeningVisschedijk;
	}
	public byte[] getHandtekeningOpdrachtgever() {
		return handtekeningOpdrachtgever;
	}
	public void setHandtekeningOpdrachtgever(byte[] handtekeningOpdrachtgever) {
		this.handtekeningOpdrachtgever = handtekeningOpdrachtgever;
	}
	public ArrayList<Vraag> getVragen() {
		return vragen;
	}
	public void setVragen(ArrayList<Vraag> vragen) {
		this.vragen = vragen;
	}
	
	public Kwaliteitsverslag(int kwaliteitsverslagNr, int debiteurnummer,
			String debiteurnaam, int projectnummer, String projectnaam,
			String telefoonnummer, String contactpersoon, int weeknummer,
			String straat, String huisnummer, String postcode, String plaats,
			String status, String startDatum, String gereedDatum,
			String opmerkingen, byte[] handtekeningVisschedijk,
			byte[] handtekeningOpdrachtgever, int gebruikerNr,
			ArrayList<Vraag> vragen) {
		super();
		this.kwaliteitsverslagNr = kwaliteitsverslagNr;
		this.debiteurnummer = debiteurnummer;
		this.debiteurnaam = debiteurnaam;
		this.projectnummer = projectnummer;
		this.projectnaam = projectnaam;
		this.telefoonnummer = telefoonnummer;
		this.contactpersoon = contactpersoon;
		this.weeknummer = weeknummer;
		this.straat = straat;
		this.huisnummer = huisnummer;
		this.postcode = postcode;
		this.plaats = plaats;
		this.status = status;
		this.startDatum = startDatum;
		this.gereedDatum = gereedDatum;
		this.opmerkingen = opmerkingen;
		this.handtekeningVisschedijk = handtekeningVisschedijk;
		this.handtekeningOpdrachtgever = handtekeningOpdrachtgever;
		this.gebruikerNr = gebruikerNr;
		this.vragen = vragen;
	}
}
