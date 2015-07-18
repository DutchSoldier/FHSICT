/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package PTS31_Server;

import java.awt.Color;
import java.awt.Point;
import java.awt.event.MouseEvent;
import java.awt.geom.Line2D;
import java.awt.geom.Point2D;
import java.util.Random;

/**
 *
 * @author Remi_Arts
 */
public class CPU extends Speler
{    
    public CPU(String naam, int Rating, Edge e, Color hue) {
        super(naam, Rating, e, hue);
    }
    
    public void volgPuck(Puck p, int cpuId)
    {         
         Point2D.Double positionPuck = p.getPositie();
         Point2D.Double positionCPU = this.getPositie();
         Point2D.Double start = this.getGoal().getBeginPoint();
         Point2D.Double end = this.getGoal().getEndPoint();
         /*Point2D.Double center =  new Point2D.Double((start.getX() + end.getX())/2, (start.getY() + end.getY())/2);
         Point2D.Double vectorEnd = new Point2D.Double(center.getX()-(end.getY()-start.getY()), center.getY()+(end.getX()-start.getX()));
         Line2D.Double l = new Line2D.Double(center, vectorEnd);
         
         if(Line2D.ptLineDist(start.getX(), start.getY(), end.getX(), end.getY(), positionPuck.getX(), positionPuck.getY()) < 250) {
             if(start.distance(positionPuck) < end.distance(positionPuck) && l.ptLineDist(positionPuck) > l.ptLineDist(positionCPU)) {
                 this.bewegen(-1);
             } else if (start.distance(positionPuck) > end.distance(positionPuck) && l.ptLineDist(positionPuck) > l.ptLineDist(positionCPU)) {
                 this.bewegen(1);
             }
         }*/
        if(Line2D.ptLineDist(start.getX(), start.getY(), end.getX(), end.getY(), positionPuck.getX(), positionPuck.getY()) < 150) {
            if (cpuId == 0) {
                if(positionPuck.getX() > positionCPU.getX()) {
                    this.bewegen(1);
                } else if (positionPuck.getY() < positionCPU.getY()) {
                    this.bewegen(-1);
                } else {
                    gaNaarMidden(cpuId);
                }
            } else if (cpuId == 1) {
                if(positionPuck.getY() > positionCPU.getY()) {
                    this.bewegen(-1);
                } else  if (positionPuck.getY() < positionCPU.getY()) {
                    this.bewegen(1);
                } else {
                    gaNaarMidden(cpuId);
                }
            } else {
                if(positionPuck.getY() > positionCPU.getY()) {
                    this.bewegen(1);
                } else if (positionPuck.getY() < positionCPU.getY()) {
                    this.bewegen(-1);
                } else {
                    gaNaarMidden(cpuId);
                }
            }
        }
        /*if(positionCPU.y - positionPuck.y < 0) {
            if(cpuId == 1 && p.getPositie().x > 220)
            {
               this.bewegen(-1);
            }
            else if (cpuId == 2 && p.getPositie().x < 320) 
            {
                this.bewegen(1);
            }
        }
        else
        {
            if(cpuId == 1 && p.getPositie().x > 220)
            {
               this.bewegen(1);
            }
            else if (cpuId == 2 && p.getPositie().x < 320)
            {
               this.bewegen(-1);
            }
        }*/
    }
    
    public void gaNaarMidden(int cpuId) {
        Point2D.Double positionCPU = this.getPositie();
        int y = (int) ((super.getGoal().getBeginPoint().y + super.getGoal().getEndPoint().y) / 2);
        
        if(positionCPU.y < y - 5) {
            if(cpuId == 1) {
               this.bewegen(-1);
            }
            else if (cpuId == 2) {
                this.bewegen(1);
            }
        }
            
        else if (positionCPU.y > y + 5) {
            if(cpuId == 1) {
               this.bewegen(1);
            }
            else if (cpuId == 2) {
               this.bewegen(-1);
            }
        }
    }         
}
