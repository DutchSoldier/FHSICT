/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package PTS31_Client;

import PTS31_Interfaces.IJoinableSpel;
import PTS31_Server.Constanten;
import java.awt.Color;
import java.awt.Font;
import java.awt.FontMetrics;
import java.awt.Graphics;
import java.awt.Point;
import java.awt.geom.Point2D;
import java.io.File;
import java.io.IOException;
import java.util.ArrayList;
import java.util.logging.Logger;
import javax.imageio.ImageIO;

/**
 *
 * @author Luc
 */
public class WedstrijdPanel extends javax.swing.JPanel {
    private IJoinableSpel spel;
    private Draaien draaien;
    private int SpelerId;
    private colors kleuren;
    
    private ArrayList<Point2D.Double> spelers;
    private Point2D.Double puck;
    public int[] scores = {0,0,0};
    public int rondes = 1;
    private points punten;
    public String puckurl = "./smiley.png";
    public int lastspeler = 3;
    
    /**
     * Creates new form WedstrijdPanel
     */
    public WedstrijdPanel() {
        initComponents();
    }
    
    public void init(int spelerId) {
        this.SpelerId = spelerId;
        this.kleuren = new colors(SpelerId);
        this.punten = new points(SpelerId);
        draaien = new Draaien(SpelerId);
    }
    
    public void update(ArrayList<Point2D.Double> spelers, Point2D.Double puck) {
        for(Point2D.Double s : spelers) {
            s.setLocation(s.getX()+40, s.getY()+1);
        }
        puck.setLocation(puck.getX()+40, puck.getY()+1);
        this.spelers = draaien.draaiSpelers(spelers);
        this.puck = draaien.draaiPuck(puck);
        repaint();
    }
    
    @Override
    public void paintComponent(Graphics g) {
        super.paintComponent(g);
        //tekenen van de gekleurde randen en goals
        g.setColor(kleuren.Bottom);
        g.fillArc(1, 1, 578, 578, -150, 120);
        g.setColor(kleuren.Right);
        g.fillArc(1, 1, 578, 578, -30, 120);
        g.setColor(kleuren.Left);
        g.fillArc(1, 1, 578, 578, 90, 120);
        g.setColor(Color.WHITE);
        int[] xArray = new int[] {40, 540, 290};
        int[] yArray = new int[] {434, 434, 1};
        g.fillPolygon(xArray, yArray, 3);
        g.fillOval(190, 334, 200, 200);
        g.fillOval(315, 118, 200, 200);
        g.fillOval(65, 118, 200, 200);
        
        if (spelers != null) {
            int i = 0;
            for (Point2D.Double s : spelers) {if (SpelerId == 1) {
                if(i == 0) {
                        g.setColor(kleuren.Left);
                    } else if (i == 1) {
                        g.setColor(kleuren.Bottom);
                    } else {
                        g.setColor(kleuren.Right);
                    }
                } else if (SpelerId == 2) {
                    if(i == 0) {
                        g.setColor(kleuren.Right);
                    } else if (i == 1) {
                        g.setColor(kleuren.Left);
                    } else {
                        g.setColor(kleuren.Bottom);
                    }
                } else {
                    if(i == 0) {
                        g.setColor(kleuren.Bottom);
                    } else if (i == 1) {
                        g.setColor(kleuren.Right);
                    } else {
                        g.setColor(kleuren.Left);
                    }
                }
                i++;
                
                g.fillOval((int)Math.round(s.getX()) - Constanten.SPELER_RADIUS,
                           (int)Math.round(s.getY()) - Constanten.SPELER_RADIUS,
                           Constanten.SPELER_RADIUS * 2,
                           Constanten.SPELER_RADIUS * 2);
            }
        }
        if (puck != null) {   
            g.setColor(Color.black);
            try {
                /*g.fillOval((int)Math.round(puck.getX()) - Constanten.PUCK_RADIUS,
                           (int)Math.round(puck.getY()) - Constanten.PUCK_RADIUS,
                               Constanten.PUCK_RADIUS * 2,
                               Constanten.PUCK_RADIUS * 2);*/
                String glowurl = null;
                switch (lastspeler) {
                    case 0:
                        glowurl = "./glow_red.png";
                        break;
                    case 1:
                        glowurl = "./glow_blue.png";
                        break;
                    case 2:
                        glowurl = "./glow_green.png";
                        break;
                    case 3:
                        glowurl = "./glow_white.png";
                        break;
                }
                g.drawImage(ImageIO.read(new File(glowurl)), (int)Math.round(puck.getX()) - (Constanten.PUCK_RADIUS+5), (int)Math.round(puck.getY()) - (Constanten.PUCK_RADIUS+5), (Constanten.PUCK_RADIUS+5) * 2, (Constanten.PUCK_RADIUS+5) * 2, null);
                g.drawImage(ImageIO.read(new File(puckurl)), (int)Math.round(puck.getX()) - Constanten.PUCK_RADIUS, (int)Math.round(puck.getY()) - Constanten.PUCK_RADIUS, Constanten.PUCK_RADIUS * 2, Constanten.PUCK_RADIUS * 2, null);
            } catch (IOException ex) {
                Logger.getLogger(WedstrijdPanel.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
            }
        }
        
        g.setColor(Color.BLACK);
        // Find the size of string s in font f in the current Graphics context g.
        Font f = new Font("Arial", Font.BOLD, 20);
        FontMetrics fm   = g.getFontMetrics(f);
        for (int i = 0; i < scores.length; i++) {
            String s = "" + scores[i];
            java.awt.geom.Rectangle2D rect = fm.getStringBounds(s, g);
            int textHeight = (int)(rect.getHeight()); 
            int textWidth  = (int)(rect.getWidth());
            int x = (20  - textWidth)  / 2;
            int y = (20 - textHeight) / 2  + fm.getAscent();
            g.setFont(f);
            g.drawString(s, punten.values[i].x + x, punten.values[i].y + y);
        }
        
        
        f = new Font("Arial", Font.BOLD, 10);
        g.setFont(f);
        g.drawString("Huidige ronde: " + rondes + "/10", 10, 20);
    }

    void updatePuck(Point2D.Double puck) {
        this.puck = puck;
        puck.setLocation(puck.getX()+40, puck.getY()+1);
        this.puck = draaien.draaiPuck(puck);
        repaint();
    }

    void updateSpelers(ArrayList<Point2D.Double> spelers) {
        for(Point2D.Double s : spelers) {
            s.setLocation(s.getX()+40, s.getY()+1);
        }
        this.spelers = draaien.draaiSpelers(spelers);
        repaint();
    }

    private static class points {

        public Point[] values;
        public points(int spelerId) {
            switch (spelerId) {
                case 0:
                    values = new Point[] {
                        new Point(280, 504),
                        new Point(477, 172),
                        new Point(83, 172)
                    };
                    break;
                case 1:
                    values = new Point[] {
                        new Point(83, 172),
                        new Point(280, 504),
                        new Point(477, 172)
                    };
                    break;
                case 2:
                    values = new Point[] {
                        new Point(477, 172),
                        new Point(83, 172),
                        new Point(280, 504)
                    };
                    break;
                case 3:
                    values = new Point[] {
                        new Point(280, 504),
                        new Point(477, 172),
                        new Point(83, 172)
                    };
                    break;
            }
        }
    }

    class colors {
        public Color Left;
        public Color Bottom;
        public Color Right;
        public colors(int spelerId) {
            switch (spelerId) {
                case 0:
                    Left = Color.GREEN;
                    Bottom = Color.RED;
                    Right = Color.BLUE;
                    break;
                case 1:
                    Left = Color.RED;
                    Bottom = Color.BLUE;
                    Right = Color.GREEN;
                    break;
                case 2:
                    Left = Color.BLUE;
                    Bottom = Color.GREEN;
                    Right = Color.RED;
                    break;
                case 3:
                    Left = Color.GREEN;
                    Bottom = Color.RED;
                    Right = Color.BLUE;
                    break;
            }
        }
    }
    /**
     * This method is called from within the constructor to initialize the form. WARNING: Do NOT modify this code. The content of this
     * method is always regenerated by the Form Editor.
     */
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        org.jdesktop.layout.GroupLayout layout = new org.jdesktop.layout.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
            .add(0, 400, Short.MAX_VALUE)
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
            .add(0, 300, Short.MAX_VALUE)
        );
    }// </editor-fold>//GEN-END:initComponents
    // Variables declaration - do not modify//GEN-BEGIN:variables
    // End of variables declaration//GEN-END:variables
}
