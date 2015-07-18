/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package PTS31_RMI_Objecten;

/**
 *
 * @author Luc
 */

//het object dat verstuurd wordt naar de client
//bevat de informatie die nodig is om de spellen die gejoind kunnen worden in de lobby weer te geven
public class RMI_JoinableSpel {
    private int wedstrijdId;
    private String wedstrijdNaam; 
    private boolean isVol;

    public int getWedstrijdId() {
        return wedstrijdId;
    }

    public String getWedstrijdNaam() {
        return wedstrijdNaam;
    }

    public boolean getIsVol() {
        return isVol;
    }
    
    public RMI_JoinableSpel(int wedstrijdId, String wedstrijdNaam, boolean isVol) {
        this.wedstrijdId = wedstrijdId;
        this.wedstrijdNaam = wedstrijdNaam;
        this.isVol = isVol;
    }
}
