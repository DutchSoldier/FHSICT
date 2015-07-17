/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package aex.banner;
import java.awt.Color;
import java.awt.Graphics;
import java.awt.GridLayout;
import java.util.Timer;
import javax.swing.Timer;
import javax.swing.JFrame;
/**
 *
 * @author Remi_Arts
 */
public class AEXBanner{
    
    String naam;
    double koers;
    
    public void setKoersen(String Naam, double Koers)
    {
        naam = Naam;
        koers = Koers;
    }
    
    public class AEXPanel extends JPanel
    {
        
        java.util.TimerTask timer = new java.util.TimerTask();
        
        public void paintComponent(Graphics g)
        {
            
        }
        
        public void run() 
        {
  
            try
            {
                    while(true)
                    {
                    berekenNieuweWaarden();
                    repaint();
                    sleep(20);
                    }
            } 
            catch (InterruptedException e)
            {
            }
        }   

    }
}
