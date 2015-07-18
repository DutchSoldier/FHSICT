package PTS31_RMI_Objecten;

import java.awt.geom.Point2D;
import java.util.ArrayList;

/**
 *
 * @author Luc
 */

//het object dat verstuurd gaat worden naar de client, nodig om te tekenen
public class RMI_DrawableWedstrijd {
    private ArrayList<Point2D.Double> spelers;
    private Point2D.Double puck;
    
    public ArrayList<Point2D.Double> getSpelers() {
        return spelers;
    }
    
    public Point2D.Double getPuck() {
        return puck;
    }
    
    public RMI_DrawableWedstrijd(ArrayList<Point2D.Double> spelers, Point2D.Double puck) {
        this.spelers = spelers;
        this.puck = puck;
    }
}
