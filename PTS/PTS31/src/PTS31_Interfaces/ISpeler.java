/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package PTS31_Interfaces;

import PTS31_Server.Edge;
import PTS31_Server.Edge;
import java.awt.Color;
import java.awt.Point;
import java.awt.geom.Point2D;

/**
 *
 * @author Luc
 */
public interface ISpeler {

    boolean bewegen(int dz);

    Edge getGoal();

    Color getHue();

    String getNaam();

    Point2D.Double getPositie();

    int getRadius();

    double getRichting();

    int getScore();

    void setScore(int x);
    
}
