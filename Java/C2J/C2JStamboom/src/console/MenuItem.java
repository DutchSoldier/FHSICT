package console;

public enum MenuItem {

    EXIT("exit"),
    NEW_PERS("registreer persoon"),
    NEW_GEZIN("registreer gezin"),
    HUWELIJK("registreer huwelijk"),
    SCHEIDING("registreer scheiding"),
    SHOW_PERS("toon gegevens persoon"),
    SHOW_GEZIN("toon gegevens gezin"),
    LAAD_ADMINISTRATIE("laad bestaande administratie"),
    SAVE_ADMINISTRATIE("sla huidige administratie op");
    
    
    private String omschr;

    private MenuItem(String omschr) {
        this.omschr = omschr;
    }

    /**
     * @return  the omschr
     * @uml.property  name="omschr"
     */
    public String getOmschr() {
        return omschr;
    }
}
