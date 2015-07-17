package console;

import java.util.ArrayList;
import java.util.GregorianCalendar;
import java.util.InputMismatchException;
import java.util.Iterator;
import java.util.Scanner;

import stamboom.*;


/**
 * @author 871059
 */
public class Console {

	// **************main******************************************************
	public static void main(String[] args) {

		Console console = new Console();

		Menu choice = console.showMenu();
		while (choice != Menu.EXIT) {

			switch (choice) {

			case LOAD:
				console.laadGegevens();
				break;
			case NEW_PERS:
				console.invoerNieuwePersoon();
				break;
			case NEW_REL:
				console.invoerNieuweRelatie();
				break;
			case DIVORCE:
				console.invoerScheiding();
				break;
			case SHOW_PERS:
				console.toonPersoonsgegevens();
				break;
			case SHOW_REL:
				console.toonRelatiegegevens();
				break;
			case SHOW_TREE:
				console.toonStamboom();
				break;
			}
			choice = console.showMenu();
		}
		console.bewaarGegevens();
	}
	
	

	// **********datavelden**********************************************
	private Scanner	input;
	private Admin		admin;

	// **********constructoren*******************************************
	public Console() {
		input = new Scanner(System.in);
		admin = new Admin();
	}

	// ***********methoden***********************************************
	public void bewaarGegevens() {

		String antwoord = this.readString("opslaan (j/n)").toLowerCase();
		if (antwoord.length() > 0)
			if (antwoord.charAt(0) == 'j') {
				String bestemming = readString("bestand");
				admin.save(bestemming);
			}
	}

	public void invoerNieuwePersoon() {
		Geslacht geslacht = null;
		while (geslacht == null) {
			String g = readString("wat is het geslacht (m/v)");
			if (g.toLowerCase().charAt(0) == 'm')
				geslacht = Geslacht.MAN;
			if (g.toLowerCase().charAt(0) == 'v')
				geslacht = Geslacht.VROUW;
		}

		String[] vnamen;
		vnamen = readString("voornamen gescheiden door spatie").split(" ");

		String anaam;
		anaam = readString("achternaam");

		String tvoegsel;
		tvoegsel = readString("tussenvoegsel");

		GregorianCalendar gebdat;
		gebdat = readDate("geboortedatum");

		Relatie ouders;
		toonRelaties();
		String relString = readString("relatienummer van ouderlijke relatie");
		if (relString.equals(""))
			ouders = null;
		else
			ouders = admin.getRelatie(Integer.parseInt(relString));

		admin.addPersoon(geslacht, vnamen, anaam, tvoegsel, gebdat, ouders);
	}

	public void invoerNieuweRelatie() {
		System.out.println("wie is de eerste partner?");
		Persoon partner1 = selecteerPersoon();
		if (partner1 == null) {
			System.out.println("onjuiste invoer eerste partner");
			return;
		}

		System.out.println("wie is de tweede partner?");
		Persoon partner2 = selecteerPersoon();
		if (partner2 == null) {
			System.out.println("onjuiste invoer tweede partner");
			return;
		}

		admin.addRelatie(partner1, partner2);
	}

	public void invoerScheiding() {
		selecteerRelatie();
		int rel = readInt("kies relatienummer");
		input.nextLine();
		GregorianCalendar datum = readDate("datum van scheiding");
		Relatie r = admin.getRelatie(rel);
		if (r != null)
			r.setScheiding(datum);
	}

	public void laadGegevens() {
		String bron = readString("bestand");
		admin = new Admin(bron);
	}

	public Persoon selecteerPersoon() {
		String naam = readString("wat is de achternaam");
		ArrayList<Persoon> personen = admin.getPersonen(naam);
		for (Persoon p : personen) {
			System.out.println(p.getNr() + "\t" + p.getNaam() + " " + p.getGebdat());
		}
		int invoer = readInt("selecteer persoonsnummer");
		input.nextLine();
		Persoon p = admin.getPersoon(invoer);
		return p;
	}

	public Relatie selecteerRelatie() {
		String naam = readString("relatie van persoon met welke achternaam");
		ArrayList<Persoon> personen = admin.getPersonen(naam);
		for (Persoon p : personen) {
			Iterator<Relatie> it = p.getRelaties();
			System.out.print(p.getNr() + "\t" + p.getNaam() + " " + p.getGebdat());
			System.out.print(" relaties: ");
			while (it.hasNext()) {
				System.out.print(" " + it.next().getNr());
			}
			System.out.println();
		}
		int invoer = readInt("selecteer relatienummer");
		input.nextLine();
		Relatie r = admin.getRelatie(invoer);
		return r;
	}

	public Menu showMenu() {
		System.out.println();
		for (Menu m : Menu.values()) {
			System.out.println(m.ordinal() + "\t" + m.getOmschr());
		}
		System.out.println();
		int maxNr = Menu.values().length - 1;
		int nr = readInt("maak een keuze uit 0 t/m " + maxNr);
		while (nr < 0 || nr > maxNr) {
			nr = readInt("maak een keuze uit 0 t/m " + maxNr);
		}
		input.nextLine();
		return Menu.values()[nr];
	}

	public void toonPersoonsgegevens() {
		Persoon p = selecteerPersoon();
		if (p == null)
			System.out.println("persoon onbekend");
		else
			System.out.println(p.toString());
	}

	public void toonRelatiegegevens() {
		Relatie r = selecteerRelatie();
		if (r == null)
			System.out.println("relatie onbekend");
		else
			System.out.println(r.toString());
	}

	public void toonStamboom() {
		Persoon p = selecteerPersoon();
		if (p == null)
			System.out.println("persoon onbekend");
		else {
			ArrayList<PersoonUitGeneratie> stamboom = p.getStamboom();
			for (PersoonUitGeneratie pug : stamboom) {
				printSpaties(2 * pug.getGeneratie());
				System.out.println(pug.getTekst());
			}
		}
	}

	private void printSpaties(int n) {
		for (int i = 0; i < n; i++)
			System.out.print(" ");
	}

	private GregorianCalendar readDate(String helptekst) {
		String datumString = readString("voer datum in (dd-mm-jjjj)");

		String[] datumSplit = datumString.split("-");
		int dag = Integer.parseInt(datumSplit[0]);
		if (dag <= 0 || dag > 32) {
			System.out.println("invalide dag (1..32)");
			return readDate(helptekst);
		}

		int maand = Integer.parseInt(datumSplit[1]);
		if (maand <= 0 || maand > 12) {
			System.out.println("invalide maand (1..12)");
			return readDate(helptekst);
		}

		int jaar = Integer.parseInt(datumSplit[2]);

		return new GregorianCalendar(jaar, maand, dag);
	}

	private int readInt(String helptekst) {
		boolean invoerOk = false;
		int invoer = -1;
		while (!invoerOk) {
			try {
				System.out.print(helptekst + " ");
				invoer = input.nextInt();
				invoerOk = true;
			} catch (InputMismatchException exc) {
				System.out.println("Let op, invoer moet een getal zijn!");
				input.nextLine();
			}

		}
		return invoer;
	}

	private String readString(String helptekst) {
		System.out.print(helptekst + " ");
		String invoer = input.nextLine();
		return invoer;
	}

	private void toonRelaties() {
		int nr = 0;
		Relatie r = admin.getRelatie(nr);
		while (r != null) {
			System.out.println(r.toString());
			nr++;
			r = admin.getRelatie(nr);
		}
	}

}
