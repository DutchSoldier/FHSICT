package com.example.dks;


public class Afspraak {
	private int afspraakNr;
	private String afspraak;
	private String wie;
	private String datum;
	private int bezoekverslagNr;
	
	public int getBezoekverslagNr() {
		return bezoekverslagNr;
	}
	public void setBezoekverslagNr(int bezoekverslagNr) {
		this.bezoekverslagNr = bezoekverslagNr;
	}
	public int getAfspraakNr() {
		return afspraakNr;
	}
	public void setAfspraakNr(int afspraakNr) {
		this.afspraakNr = afspraakNr;
	}
	public String getAfspraak() {
		return afspraak;
	}
	public void setAfspraak(String afspraak) {
		this.afspraak = afspraak;
	}
	public String getWie() {
		return wie;
	}
	public void setWie(String wie) {
		this.wie = wie;
	}
	public String getDatum() {
		return datum;
	}
	public void setDatum(String datum) {
		this.datum = datum;
	}
	
	public Afspraak(int afspraakNr, String afspraak, String wie, String datum,
			int bezoekverslagNr) {
		super();
		this.afspraakNr = afspraakNr;
		this.afspraak = afspraak;
		this.wie = wie;
		this.datum = datum;
		this.bezoekverslagNr = bezoekverslagNr;
	}
}
