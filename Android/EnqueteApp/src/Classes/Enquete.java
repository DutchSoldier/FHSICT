package Classes;

import java.util.ArrayList;

public class Enquete {
	private int enqueteNr;
	private String naam;
	private String beschrijving;
	private Boolean anoniem;
	private Gebruiker gebruiker;
	
	ArrayList<Vraag>vragen;
	
	public int getEnqueteNr() {
		return enqueteNr;
	}
	public void setEnqueteNr(int enqueteNr) {
		this.enqueteNr = enqueteNr;
	}
	public String getNaam() {
		return naam;
	}
	public void setNaam(String naam) {
		this.naam = naam;
	}
	public String getBeschrijving() {
		return beschrijving;
	}
	public void setBeschrijving(String beschrijving) {
		this.beschrijving = beschrijving;
	}
	public Boolean getAnoniem(){
		return anoniem;
	}
	public void setAnoniem(Boolean anoniem){
		this.anoniem = anoniem;
	}
	public Gebruiker getGebruiker(){
		return gebruiker;
	}
	public void setGebruiker(Gebruiker gebruiker){
		this.gebruiker = gebruiker;
	}
	public ArrayList<Vraag> getVragen() {
		return vragen;
	}
	public void setVragen(ArrayList<Vraag> vragen) {
		this.vragen = vragen;
	}
	
	public Enquete(int enqueteNr, String naam, String beschrijving,
			Boolean anoniem, Gebruiker gebruiker, ArrayList<Vraag> vragen) {
		super();
		this.enqueteNr = enqueteNr;
		this.naam = naam;
		this.beschrijving = beschrijving;
		this.anoniem = anoniem;
		this.gebruiker = gebruiker;
		this.vragen = vragen;
	}
}
