package com.example.dks;

public class Werkbon {
	private int werkbonNr;
	private int debiteurnummer;
	private String debiteurnaam;
	private int projectnummer;
	private String projectnaam;
	private String telefoonnummer;
	private String contactpersoon;
	private int weeknummer;
	private String startDatum;
	private double uren;
	private String straat;
	private String huisnummer;
	private String postcode;
	private String plaats;
	private String extraOpmerking;
	private String status;
	private String gereedDatum;
	private String opmerkingen;
	private byte[] handtekening;
	private int gebruikerNr;
	
	public int getGebruikerNr() {
		return gebruikerNr;
	}
	public void setGebruikerNr(int gebruikerNr) {
		this.gebruikerNr = gebruikerNr;
	}
	public int getWerkbonNr() {
		return werkbonNr;
	}
	public void setWerkbonNr(int werkbonNr) {
		this.werkbonNr = werkbonNr;
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
	public String getStartDatum() {
		return startDatum;
	}
	public void setStartDatum(String startDatum) {
		this.startDatum = startDatum;
	}
	public double getUren() {
		return uren;
	}
	public void setUren(double uren) {
		this.uren = uren;
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
	public String getPlaats() {
		return plaats;
	}
	public void setPlaats(String plaats) {
		this.plaats = plaats;
	}
	public String getExtraOpmerking() {
		return extraOpmerking;
	}
	public void setExtraOpmerking(String extraOpmerking) {
		this.extraOpmerking = extraOpmerking;
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
	public byte[] getHandtekening() {
		return handtekening;
	}
	public void setHandtekening(byte[] handtekening) {
		this.handtekening = handtekening;
	}
	
	public Werkbon(int werkbonNr, int debiteurnummer, String debiteurnaam,
			int projectnummer, String projectnaam, String telefoonnummer,
			String contactpersoon, int weeknummer, String startDatum,
			double uren, String straat, String huisnummer, String postcode,
			String plaats, String extraOpmerking, String status,
			String gereedDatum, String opmerkingen, byte[] handtekening, int gebruikerNr) {
		super();
		this.werkbonNr = werkbonNr;
		this.debiteurnummer = debiteurnummer;
		this.debiteurnaam = debiteurnaam;
		this.projectnummer = projectnummer;
		this.projectnaam = projectnaam;
		this.telefoonnummer = telefoonnummer;
		this.contactpersoon = contactpersoon;
		this.weeknummer = weeknummer;
		this.startDatum = startDatum;
		this.uren = uren;
		this.straat = straat;
		this.huisnummer = huisnummer;
		this.postcode = postcode;
		this.plaats = plaats;
		this.extraOpmerking = extraOpmerking;
		this.status = status;
		this.gereedDatum = gereedDatum;
		this.opmerkingen = opmerkingen;
		this.handtekening = handtekening;
		this.gebruikerNr = gebruikerNr;
	}
}
