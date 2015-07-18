/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package PTS31_Server;

import java.awt.Color;
import java.awt.Point;
import java.awt.geom.Point2D;

/**
 *
 * @author Remi_Arts
 */
public class Edge 
{
    private Point2D.Double beginCoor;
    private Point2D.Double eindCoor;
    private Color hue;
    
    public Edge(Point2D.Double beginCoor, Point2D.Double eindCoor, Color hue)
    {
        this.beginCoor = beginCoor;
        this.eindCoor = eindCoor;
        this.hue = hue;
    }
    
    
    public Point2D.Double getBeginPoint() {
        return beginCoor;
    }
    
    public Point2D.Double getEndPoint() {
        return eindCoor;
    }
    
    public Color getHue() {
        return hue;
    }
    
    public boolean isDoel() {
        return (hue == Color.WHITE);
    }
}
