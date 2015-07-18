package PTS31_Client;

import PTS31_RMI_Objecten.RMI_DrawableWedstrijd;
import PTS31_Server.Constanten;
import PTS31_Server.Edge;
import PTS31_Server.Level;
import java.awt.geom.Point2D;
import java.util.ArrayList;


/**
 *
 * @author Luc
 */
public class Draaien {
    Point2D.Double zwaartePunt;
    double angle;
    
    public Draaien(int spelerId) {
        zwaartePunt = new Point2D.Double(290,289+2/3); 
        if (spelerId == 1) {
            angle = 120;  
        }
        else if (spelerId == 2) {
            angle = -120;
        }
        else {
            angle = 0;
        }
    }
    
    public Point2D.Double draaiPuck(Point2D.Double puck) {
        double nieuwX = (zwaartePunt.x + 
               (puck.x - zwaartePunt.x) * Math.cos(Math.toRadians(angle))) - 
               (puck.y - zwaartePunt.y) * Math.sin(Math.toRadians(angle));
        double nieuwY = (zwaartePunt.y + 
               (puck.x - zwaartePunt.x) * Math.sin(Math.toRadians(angle))) +
               (puck.y - zwaartePunt.y) * Math.cos(Math.toRadians(angle));
        return new Point2D.Double(nieuwX, nieuwY);
    }
    
    
    
    public ArrayList<Point2D.Double> draaiSpelers(ArrayList<Point2D.Double> spelers) {
        ArrayList<Point2D.Double> result = new ArrayList<>();
        for (Point2D.Double s : spelers) {
            result.add(draaiPuck(s));
        }
        return result;
    }
}
