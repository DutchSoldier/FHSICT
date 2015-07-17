package Classes;


public class Gebruiker {
	private int gebruikerNr;
	private String naam;
	private String geslacht;
	private String geboorteDatum;
	private String email;
	private int enqueteNr;
	
	public int getGebruikerNr() {
		return gebruikerNr;
	}
	public void setGebruikerNr(int gebruikerNr) {
		this.gebruikerNr = gebruikerNr;
	}
	public String getNaam() {
		return naam;
	}
	public void setNaam(String naam) {
		this.naam = naam;
	}
	public String getGeslacht() {
		return geslacht;
	}
	public void setGeslacht(String geslacht) {
		this.geslacht = geslacht;
	}
	
	public String getGeboorteDatum() {
		return geboorteDatum;
	}
	public void setGeboorteDatum(String geboorteDatum) {
		this.geboorteDatum = geboorteDatum;
	}
	public String getEmail() {
		return email;
	}
	public void setEmail(String email) {
		this.email = email;
	}
	public int getEnqueteNr() {
		return enqueteNr;
	}
	public void setEnqueteNr(int enqueteNr) {
		this.enqueteNr = enqueteNr;
	}
	
	public Gebruiker(int gebruikerNr, String naam, String geslacht,
			String geboorteDatum, String email, int enqueteNr) {
		super();
		this.gebruikerNr = gebruikerNr;
		this.naam = naam;
		this.geslacht = geslacht;
		this.geboorteDatum = geboorteDatum;
		this.email = email;
		this.enqueteNr = enqueteNr;
	}	
}
