/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package PTS31_Server;

import java.io.Serializable;

/**
 *
 * @author Remi_Arts
 */
public class Gebruiker implements Serializable{
    public String naam;
    public int rating;
    public boolean IsSpeler = false;
    public boolean InSpel = false;
    
    public Gebruiker(String Naam, int Rating)
    {
        naam = Naam;
        rating = Rating;
    }
    
    public void LogOut()
    {
        
    }

    public String getNaam() {
        return naam;
    }
}
