package Classes;

public class Antwoord {
	private int antwoordNr;
	private String antwoord;
	private Boolean selected;
	private int count;
	private int vraagNr;
	
	public int getAntwoordNr() {
		return antwoordNr;
	}
	public void setAntwoordNr(int antwoordNr) {
		this.antwoordNr = antwoordNr;
	}
	public String getAntwoord() {
		return antwoord;
	}
	public void setAntwoord(String antwoord) {
		this.antwoord = antwoord;
	}
	public Boolean getSelected() {
		return selected;
	}
	public void setSelected(Boolean selected) {
		this.selected = selected;
	}
	public int getCount() {
		return count;
	}
	public void setCount(int count) {
		this.count = count;
	}
	public int getVraagNr() {
		return vraagNr;
		
	}
	public void setVraagNr(int vraagNr) {
		this.vraagNr = vraagNr;
	}
	
	public Antwoord(int antwoordNr, String antwoord,
			Boolean selected, int count, int vraagNr) {
		super();
		this.antwoordNr = antwoordNr;
		this.antwoord = antwoord;
		this.selected = selected;
		this.count = count;
		this.vraagNr = vraagNr;
	}
}
