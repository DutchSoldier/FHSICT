package console;

import java.io.IOException;
import java.util.ArrayList;
import java.util.GregorianCalendar;
import java.util.InputMismatchException;
import java.util.Iterator;
import java.util.Scanner;
import stamboom.*;

public class Console {

    // **************main******************************************************
    public static void main(String[] args) throws ClassNotFoundException, IOException {
        Console console = new Console();
        MenuItem choice = console.kiesMenuItem();
        while (choice != MenuItem.EXIT) {

            switch (choice) 
            {
                case NEW_PERS:
                    console.invoerNieuwePersoon();
                    break;
                case NEW_GEZIN:
                    console.invoerNieuwGezin();
                    break;
                case HUWELIJK:
                    console.invoerHuwelijk();
                case SCHEIDING:
                    console.invoerScheiding();
                    break;
                case SHOW_PERS:
                    console.toonPersoonsgegevens();
                    break;
                case SHOW_GEZIN:
                    console.toonGezinsgegevens();
                    break;
                case LAAD_ADMINISTRATIE:
                    console.laadAdministratie();
                    break;
                case SAVE_ADMINISTRATIE:
                    console.saveAdministratie();
                    break;
            }
            choice = console.kiesMenuItem();
        }

    }
    // **********datavelden**********************************************
    private Scanner input;
    private Administratie admin;

    // **********constructoren*******************************************
    public Console() {
        input = new Scanner(System.in);
        admin = new Administratie();
        
        //test kut
        String[] vn = new String[1];
        vn[0]="test";
        GregorianCalendar cg = new GregorianCalendar();
        
        admin.addPersoon(Geslacht.MAN, vn, "baas", "van", cg, null);
    }

    // ***********methoden***********************************************
    public void invoerNieuwePersoon() {
        Geslacht geslacht = null;
        while (geslacht == null) {
            String g = readString("wat is het geslacht (m/v)");
            if (g.toLowerCase().charAt(0) == 'm') {
                geslacht = Geslacht.MAN;
            }
            if (g.toLowerCase().charAt(0) == 'v') {
                geslacht = Geslacht.VROUW;
            }
        }

        String[] vnamen;
        vnamen = readString("voornamen gescheiden door spatie").split(" ");

        String anaam;
        anaam = readString("achternaam");

        String tvoegsel;
        tvoegsel = readString("tussenvoegsel");

        GregorianCalendar gebdat;
        gebdat = readDate("geboortedatum");

        Gezin ouders;
        toonGezinnen();
        String gezinsString = readString("gezinsnummer van ouderlijk gezin");
        if (gezinsString.equals("")) {
            ouders = null;
        } else {
            ouders = admin.getGezin(Integer.parseInt(gezinsString));
        }

        admin.addPersoon(geslacht, vnamen, anaam, tvoegsel, gebdat, ouders);
    }

    public void invoerNieuwGezin() {
        System.out.println("wie is de eerste partner?");
        Persoon partner1 = selecteerPersoon();
        if (partner1 == null) {
            System.out.println("onjuiste invoer eerste partner");
            return;
        }
        System.out.println("wie is de tweede partner?");
        Persoon partner2 = selecteerPersoon();
        admin.addGezin(partner1, partner2);
    }
    
    public void invoerHuwelijk() {
         selecteerGezin();
        int gezinsNr = readInt("kies gezinsnummer");
        input.nextLine();
        GregorianCalendar datum = readDate("datum van scheiding");
        Gezin g = admin.getGezin(gezinsNr);
        if (g != null) {
            g.setScheiding(datum);
        }
    }

    public void invoerScheiding() {
        selecteerGezin();
        int gezinsNr = readInt("kies gezinsnummer");
        input.nextLine();
        GregorianCalendar datum = readDate("huwelijksdatum");
        Gezin g = admin.getGezin(gezinsNr);
        if (g != null) {
            g.setHuwelijk(datum);
        }
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

    public Gezin selecteerGezin() {
        String naam = readString("gezin van persoon met welke achternaam");
        ArrayList<Persoon> personen = admin.getPersonen(naam);
        for (Persoon p : personen) {
            Iterator<Gezin> it = p.getGezinnen();
            System.out.print(p.getNr() + "\t" + p.getNaam() + " " + p.getGebdat());
            System.out.print(" gezinnen: ");
            while (it.hasNext()) {
                System.out.print(" " + it.next().getNr());
            }
            System.out.println();
        }
        int invoer = readInt("selecteer gezinsnummer");
        input.nextLine();
        return admin.getGezin(invoer);
    }

    public MenuItem kiesMenuItem() {
        System.out.println();
        for (MenuItem m : MenuItem.values()) 
        {
            System.out.println(m.ordinal() + "\t" + m.getOmschr());
        }
        
        System.out.println();
        int maxNr = MenuItem.values().length - 1;
        int nr = readInt("maak een keuze uit 0 t/m " + maxNr);
        
        while (nr < 0 || nr > maxNr) {
            nr = readInt("maak een keuze uit 0 t/m " + maxNr);
        }
        input.nextLine();
        return MenuItem.values()[nr];
    }

    public void toonPersoonsgegevens() {
        Persoon p = selecteerPersoon();
        if (p == null) {
            System.out.println("persoon onbekend");
        } else {
            System.out.println(p.toString());
        }
    }

    public void toonGezinsgegevens() {
        Gezin r = selecteerGezin();
        if (r == null) {
            System.out.println("gezin onbekend");
        } else {
            System.out.println(r.toString());
        }
    }

    private void printSpaties(int n) {
        for (int i = 0; i < n; i++) {
            System.out.print(" ");
        }
    }

    private GregorianCalendar readDate(String helptekst) {
        String datumString = readString(helptekst + "; voer datum in (dd-mm-jjjj)");

        String[] datumSplit = datumString.split("-");
        int dag = Integer.parseInt(datumSplit[0]);
        if (dag <= 0 || dag > 32) {
            System.out.println("ongeldige dag (1..32)");
            return readDate(helptekst);
        }

        int maand = Integer.parseInt(datumSplit[1]);
        if (maand <= 0 || maand > 12) {
            System.out.println("ongeldige maand (1..12)");
            return readDate(helptekst);
        }

        int jaar = Integer.parseInt(datumSplit[2]);

        // maanden zijn binnen GregorianCalendar van 0 t/m 11 gecodeerd:
        return new GregorianCalendar(jaar, maand - 1, dag);
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

    private void toonGezinnen() {
        int nr = 0;
        Gezin r = admin.getGezin(nr);
        while (r != null) {
            System.out.println(r.toString());
            nr++;
            r = admin.getGezin(nr);
        }
    }
    
    private void laadAdministratie() throws ClassNotFoundException, IOException {
        String pad = readString("bestands pad: ");
        admin = new Administratie(pad);
        
        for(Persoon p: admin.getPersonen("baas"))
                {
                    System.out.print(p.getAchternaam());
                }
       
    }
    
    private void saveAdministratie() throws IOException {
        if(admin != null)
        {
            String pad = readString("bestands pad: ");
            admin.save(pad);
        }
    }  
}
