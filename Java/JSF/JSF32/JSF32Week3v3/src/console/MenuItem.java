package console;

public enum MenuItem {

    CHLVL("Change the koch fractal level"),
    GENERATE("Generate the koch fractal"),
    SAVE("Save the koch fractal to a file"),
    EXIT("Exit");
    
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
