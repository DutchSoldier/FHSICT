/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package PTS31_Server;

import java.awt.Point;
import java.awt.geom.Point2D;

/**
 *
 * @author Remi_Arts
 */
public class Puck {
    
    private double phiAngle, snelheidX, snelheidY, snelheid;
    private Point2D.Double positie;
    private Wedstrijd wedstrijd;
    private int radius = 10;
    private Speler lastSpeler = null;
    private Speler Checking;
    
    public Puck(double snelheid, double Angle, Wedstrijd wedstrijd) {
        if (wedstrijd.getLevel().getEdges().size() == 9) {
            this.positie = new Point2D.Double(250,288+2/3);
            this.snelheid = snelheid;
            this.wedstrijd = wedstrijd;
            changeAngle(Angle);
        }
        else {
            throw new ExceptionInInitializerError("Verkeerde waarde");
        }
    }
    
    public Point2D.Double getPositie() {
        return positie;
    }
    
    public int getRadius() {
        return radius;
    }
    
    public Speler getLastSpeler() {
        return lastSpeler;
    }
    
    public Edge bewegen() {
        wedstrijd.changeCollisionHappened(false);
        
        //positie.translate(snelheidX, snelheidY);
        positie.x += snelheidX;
        positie.y += snelheidY;
        
        checkPuckSpeler();
        Edge e = checkPuckDoel();
        if(e!=null) {
            return e;
        }
        checkPuckLevel();
        return null;
    }
    
    private void fixPositie(Edge e) {
        /*Point oldPos = positie.getLocation();
        oldPos.translate(-(int)Math.round(snelheidX), -(int)Math.round(snelheidY));
        double perfectCollisionDistance = this.radius+radius;
        Point intersectionPoint = getLineLineIntersection(e.getBeginPoint().x, e.getBeginPoint().y, e.getEndPoint().x, e.getEndPoint().y, oldPos.x, oldPos.y, positie.x, positie.y);
        double xDiff = positie.x - intersectionPoint.x;
        if (xDiff < 0) {
            xDiff *= -1;
        }
        double yDiff = positie.y - intersectionPoint.y;
        if (yDiff < 0) {
            yDiff *= -1;
        }
        double currentDistance = Math.sqrt(xDiff*xDiff+yDiff*yDiff);
        double reverseDistance = (snelheid/(perfectCollisionDistance - currentDistance) / (perfectCollisionDistance));
        positie.translate((int)Math.round(-(reverseDistance * Math.cos(phiAngle))), (int)Math.round(-(reverseDistance * Math.sin(phiAngle))));*/
        
        //positie.translate(-(int)Math.round(snelheidX), -(int)Math.round(snelheidY));
        positie.x -= snelheidX;
        positie.y -= snelheidY;
        
        /*while(currentDistance<perfectCollisionDistance) {
            
            positie.translate(radius, radius);
            currentDistance = Point.distance(e.getBeginPoint().x, e.getBeginPoint().y, e.getEndPoint().x, e.getEndPoint().y);
        }*/
        
        /*double reverseAngle = -(phiAngle/Math.PI);
        if (reverseAngle < -0.5) {
            while (reverseAngle < -0.5) {
                reverseAngle += 2;
            }
        }
        else if (reverseAngle > 1.5) {
            while (reverseAngle > 1) {
                reverseAngle -= 2;
            }
        }
        
        Point intersection = getLineLineIntersection(positie.x, positie.y, positie.x + snelheidX, positie.y + snelheidY, e.getBeginPoint().x, e.getBeginPoint().y, e.getEndPoint().x, e.getEndPoint().y);
        double ballLineDistance = Line2D.ptLineDist(e.getBeginPoint().x, e.getBeginPoint().y, e.getEndPoint().x, e.getEndPoint().y, positie.x, positie.y);
        double intersectionPointDistance = Math.sqrt(Point.distance(intersection.x, intersection.y, positie.x, positie.y) - ballLineDistance);
        ballLineDistance = radius - ballLineDistance;
        double reverseSnelheid = Math.sqrt(ballLineDistance*ballLineDistance+intersectionPointDistance*intersectionPointDistance);    
        double reverseX = reverseSnelheid * Math.cos(reverseAngle);
        double reverseY = reverseSnelheid * Math.sin(reverseAngle);
        double CheckAngle = (Math.atan2(reverseY, reverseX) + 0.5 * Math.PI)/Math.PI;
        if (CheckAngle < -0.5) {
            while (CheckAngle < -0.5) {
                CheckAngle += 2;
            }
        }
        else if (CheckAngle > 1.5) {
            while (CheckAngle > 1) {
                CheckAngle -= 2;
            }
        }
        double check = phiAngle/Math.PI;
        if (CheckAngle < -0.5) {
            while (CheckAngle < -0.5) {
                CheckAngle += 2;
            }
        }
        else if (CheckAngle > 1.5) {
            while (CheckAngle > 1) {
                CheckAngle -= 2;
            }
        }
        double remainder;
        if (check - CheckAngle < 0.5 || check - CheckAngle > -0.5) {
            reverseX = -(reverseX+snelheidX);
            reverseY = -(reverseY+snelheidY);
        }
        if (reverseX == 0) {
            reverseX = -(snelheidX);
            reverseY = -(snelheidX);
        }
        this.positie.translate((int)Math.round(reverseX), (int)Math.round(reverseY));*/
    }
    
    private void bounce(Edge e) {
        //FixPositie(e, positie);
        
        /*double wallX = e.getEndPoint().x-e.getBeginPoint().x;
        double wallY = e.getEndPoint().y-e.getBeginPoint().y;
        double dotProduct = (wallX * snelheidX) + (wallY * snelheidY);
        double vectorlength = (Math.sqrt(wallX * wallX + wallY * wallY)) * (Math.sqrt(snelheidX * snelheidX + snelheidY * snelheidY));
        */
        
        double normal = Math.atan2(e.getEndPoint().y - e.getBeginPoint().y, e.getEndPoint().x - e.getBeginPoint().x);
        double diff = normal - phiAngle;
        
        changeAngle((normal+diff)/Math.PI);
        wedstrijd.changeCollisionHappened(true);
    }
    
    private double distAlong(double x, double y, double xAlong, double yAlong) {
        return (x * xAlong + y * yAlong) / Math.hypot(xAlong, yAlong);
    }
    
    private boolean checkCollision(Edge e) {
        double x1 = e.getBeginPoint().x - positie.x;
        double y1 = e.getBeginPoint().y - positie.y;
        double x2 = e.getEndPoint().x - positie.x;
        double y2 = e.getEndPoint().y - positie.y;
        double dx = x2 - x1;
        double dy = y2 - y1;
        double dr = Math.sqrt(Math.pow(dx, 2) + Math.pow(dy, 2));
        double D = x1*y2 - x2*y1;
        double delta = Math.pow(radius*0.9,2)*Math.pow(dr,2) - Math.pow(D,2);
        boolean extra = true;
        if(e.isDoel()) {
            extra = ((positie.y > 130 && positie.y < 303) || (positie.x > 150 && positie.x < 350 && positie.y > 303));
        }
        return (delta >= 0 && extra);
    }
    
        /*gebruik de richting en de radius van het bewegende object om een lijn te maken op de juiste plek
         * de lijn is de richting + 0.5 op de afstand radius. zorgen dat de lijn beide kanten op rijkt.
         * deze methode wordt aangeroepen bij elke beweging van een speler of de puck.*/
    
    public void checkBatPuck(int radius, Point2D.Double middenpunt) {
        double x1 = positie.x, y1 = positie.y;
        double x2 = middenpunt.x, y2 = middenpunt.y;
        double r1 = this.radius, r2 = radius;
        double dx = x2 - x1;
        double dy = y2 - y1;
        double d = Math.sqrt(dx*dx + dy*dy);
        if(d <= r1 + r2)
        {
            double vx1 = snelheidX, vy1 = snelheidY;
            // velocity in the direction of (dx, dy)
            double vp1 = (vx1*dx + vy1*dy) / d;
            // collision should have happened dt before
            double dt = (r1 + r2 - d) / vp1;
            // move the circles backward in time
            x1 -= vx1 * dt;
            y1 -= vy1 * dt;

            // new collision calculations at impact
            dx = x2 - x1;
            dy = y2 - y1;
            d = Math.sqrt(dx*dx + dy*dy);

            // unit vector in the direction of the collision
            double ax = dx/d;
            double ay = dy/d;

            // projection of the velocities in these axes
            double va1 =  vx1*ax + vy1*ay;
            double vb1 = -vx1*ay + vy1*ax;

            // calculate new velocity after collision
            double ed = 1;
            double vaP1 = va1 + (1 + ed) * -va1;

            // undo projections
            vx1 = vaP1*ax - vb1*ay;
            vy1 = vaP1*ay + vb1*ax;

            // move time dt forward
            x1 += vx1 * dt;
            y1 += vy1 * dt;

            // update locations and velocities
            positie.setLocation(x1, y1);
            snelheidX = vx1;
            snelheidY = vy1;
            phiAngle = Math.atan2(vy1, vx1);
            lastSpeler = Checking;
            wedstrijd.changeCollisionHappened(true);
        }
        
        //if(Point.distance(positie.x, positie.y, middenpunt.x, middenpunt.y) < this.radius+radius) {
            //ga hier alles uitrekenen om een edge voor de afkaatsing te maken.
            /*double Angle = richting;
            if (Angle < -0.5) {
                while (Angle < -0.5) {
                    Angle += 2;
                }
            }
            else if (Angle > 1.5) {
                while (Angle > 1) {
                    Angle -= 2;
                }
            }
            Angle *= Math.PI;*/
            /*if(Point.distance(positie.x, positie.y, middenpunt.x, middenpunt.y) < this.radius+radius) {
                double R2 = Math.pow(this.radius + radius, 2);
                double H = R2 - ((positie.y - middenpunt.y) * Math.cos(phiAngle) + (positie.x - middenpunt.x) * Math.pow(Math.sin(phiAngle), 2));
                double XD  =  middenpunt.x - positie.x;
                double YD  =  middenpunt.y - positie.y;
                double phi =  -Math.atan2(( 2 * R2 * Math.sin(phiAngle) + 2 * (YD * Math.cos(phiAngle) - XD * Math.sin(phiAngle)) * (2 * H * Math.cos(phiAngle) + 
                2 * XD * Math.pow(Math.sin(phiAngle), 2) - YD * Math.sin(2 * phiAngle))), ((2 * R2 - Math.pow(XD, 2) - 3 * Math.pow(YD, 2)) * Math.cos(phiAngle) + (Math.pow(XD, 2) - Math.pow(YD, 2)) * Math.cos(3 * phiAngle) + 
                8 * XD * YD * Math.pow(Math.cos(phiAngle), 2) * Math.sin(phiAngle) + 4 * H * Math.sin(phiAngle) * (-YD * Math.cos(phiAngle) + XD * Math.sin(phiAngle))));
                positie.translate((int)Math.round(middenpunt.x+Math.sin(phiAngle) * ((middenpunt.y-positie.y) * Math.cos(phiAngle)+ (positie.x-middenpunt.x) * Math.sin(phiAngle))-Math.cos(phiAngle) * Math.sqrt(H)),
                (int)Math.round(middenpunt.y+Math.cos(phiAngle) * ((positie.y-middenpunt.y) * Math.cos(phiAngle)+(-positie.x+middenpunt.x) * Math.sin(phiAngle))-Math.sin(phiAngle) * Math.sqrt(H)));
                phiAngle = phi;
            }*/
            /*FixPositie(new Edge(positie, middenpunt, Color.BLACK), radius);
            double aAngle = Math.atan2(middenpunt.y-positie.y, middenpunt.x-positie.x);
            double diff = phiAngle - aAngle;
            double Angle;
            if(diff < 0) {
                Angle = aAngle - 0.5*Math.PI;
            }
            else {
                Angle = aAngle + 0.5*Math.PI;
            }
            Point beginPoint = middenpunt.getLocation();
            double lengthX = radius * Math.cos(Angle);
            double lengthY = radius * Math.sin(Angle);
            Point endPoint = new Point((int)Math.round(beginPoint.x + lengthX), (int)Math.round(beginPoint.y + lengthY));*/
            /*double speedX = middenpunt.x + (radius * Math.cos(Angle));
            double speedY = middenpunt.y + (radius * Math.sin(Angle));
            Point beginPoint = new Point((int)Math.round(speedX), (int)Math.round(speedY));
            Angle /= Math.PI;
            Angle += 0.5;
            if (Angle < -0.5) {
                while (Angle < -0.5) {
                    Angle += 2;
                }
            }
            else if (Angle > 1.5) {
                while (Angle > 1) {
                    Angle -= 2;
                }
            }
            Angle *= Math.PI;
            speedX = middenpunt.x + (radius * Math.cos(Angle));
            speedY = middenpunt.y + (radius * Math.sin(Angle));
            Point endPoint = new Point((int)Math.round(speedX), (int)Math.round(speedY));*/
            /*Edge e = new Edge(beginPoint, endPoint, Color.BLACK);
            lastSpeler = Checking;
            Bounce(e);
        }*/
    }
    
    private void checkPuckSpeler() {
        for (Speler s : wedstrijd.getSpelers()) {
            Checking = s;
            checkBatPuck(s.getRadius(), s.getPositie());
        }
    }
    
    private Edge checkPuckDoel() {
        for (Edge e : wedstrijd.getLevel().getEdges()) {
            if(e.isDoel() && checkCollision(e)) {
                return e;
            }
        }
        return null;
    }
    
    private void checkPuckLevel() {
        for (Edge e : wedstrijd.getLevel().getEdges()) {
            if(!e.isDoel() && checkCollision(e)) {
                fixPositie(e);
                bounce(e);
            }
        }
    }
    
    private void changeAngle(double Angle) {
        if (Angle < -0.5) {
            while (Angle < -0.5) {
                Angle += 2;
            }
        }
        else if (Angle > 1.5) {
            while (Angle > 1) {
                Angle -= 2;
            }
        }
        Angle *= Math.PI;
        snelheidX = snelheid * Math.cos(Angle);
        snelheidY = snelheid * Math.sin(Angle);
        phiAngle = Angle;
    }
    
    private Point getLineLineIntersection(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4) {
        double det1And2 = det(x1, y1, x2, y2);
        double det3And4 = det(x3, y3, x4, y4);
        double x1LessX2 = x1 - x2;
        double y1LessY2 = y1 - y2;
        double x3LessX4 = x3 - x4;
        double y3LessY4 = y3 - y4;
        double det1Less2And3Less4 = det(x1LessX2, y1LessY2, x3LessX4, y3LessY4);
        if (det1Less2And3Less4 == 0){
            // the denominator is zero so the lines are parallel and there's either no solution (or multiple solutions if the lines overlap) so return null.
            return null;
        }
        double x = (det(det1And2, x1LessX2,
        det3And4, x3LessX4) /
        det1Less2And3Less4);
        double y = (det(det1And2, y1LessY2,
        det3And4, y3LessY4) /
        det1Less2And3Less4);
        return new Point((int)Math.round(x), (int)Math.round(y));
    }
    
    private double det(double a, double b, double c, double d) {
        return a * d - b * c;
    }
}
