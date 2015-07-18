/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package PTS31_Server;

import PTS31_Interfaces.ISpeler;
import java.awt.Color;
import java.awt.geom.Point2D;

/**
 *
 * @author Remi_Arts
 */
public class Speler extends Gebruiker implements ISpeler{    
    private Point2D.Double positie;
    private int radius;
    private double richting;
    private int score;
    private Color hue;
    private Edge goal;
    
    public Speler(String Naam, int Rating, Edge e, Color hue) {

        super(Naam, Rating);
        this.score = 0;
        this.radius = 20;
        this.hue = hue;

        double px = (e.getBeginPoint().x + e.getEndPoint().x) / 2;
        double py = (e.getBeginPoint().y + e.getEndPoint().y) / 2;  
        this.positie = new Point2D.Double(px,py);
       
        this.goal = e;
    }

    @Override
    public String getNaam() {
        return naam;
    }
    
    @Override
    public Color getHue() {
        return hue;
    }

    @Override
    public int getScore() {
        return score;
    }
    
    @Override
    public void setScore(int x) {
        this.score += x;
    }

    @Override
    public Point2D.Double getPositie() {
        return positie;
    }
    
    @Override
    public Edge getGoal() {
        return goal;
    }
        
    @Override
    public double getRichting() {
        return richting;
    }
    
    @Override
    public int getRadius() {
       return radius;
    }
    
    @Override
    public boolean bewegen(int dz) {
        dz = dz * 2;
        double dy = goal.getBeginPoint().y - goal.getEndPoint().y;
        double dx = goal.getBeginPoint().x - goal.getEndPoint().x;
        double a = dy/dx;
        richting = Math.atan2(a*dz,dz);
       
        if (a < 0 || a > 0) {
            if (dz < 0 && positie.x < goal.getBeginPoint().x) {
                positie.x += dz * Math.cos(richting);
                positie.y += dz * Math.sin(richting);
                return true;
            }       
            else if (dz > 0 && positie.x > goal.getEndPoint().x) {
                positie.x += (dz * Math.cos(richting)) *-1;
                positie.y += (dz * Math.sin(richting)) *-1;
                return true;
            }     
       }
       else if ((dz > 0 && positie.x < goal.getEndPoint().x) || (dz < 0 && positie.x > goal.getBeginPoint().x)) {
            positie.x += dz;
            positie.y += a*dz;
            return true;
       }
       return false;             
    }
}
