/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package PTS31_Server;

import java.awt.Color;

/**
 *
 * @author Remi_Arts
 */
public class Human extends Speler{
    

    public Human(String Naam, int Rating, Edge e, Color hue)
    {
        super(Naam, Rating, e, hue);
    }
    
    public int getRating() {
        return rating;
    }

    public void setRating(int Rating) {
        rating = Rating;
    }
}
