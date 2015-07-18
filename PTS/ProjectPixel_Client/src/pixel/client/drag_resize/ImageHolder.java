/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package pixel.client.drag_resize;

import java.awt.Graphics;
import java.awt.Graphics2D;
import java.awt.Image;
import javax.swing.JComponent;

/**
 *
 * @author Bas
 */
public class ImageHolder extends JComponent{
    
    private Image image;
    
    /**
     *
     * @param image
     */
    public ImageHolder(Image image) {
        this.image = image;
    }
    
    /**
     * 
     * @param g 
     */
    @Override
    protected void paintComponent(Graphics g) {
        super.paintComponent(g);
        Graphics2D g2d = (Graphics2D) g;
        g2d.clearRect(0, 0, getWidth(), getHeight());
        if (image != null) {
            g2d.drawImage(image, 0, 0, getWidth(), getHeight(), this);
        } else {
            g2d.setColor(getBackground());
            g2d.fillRect(0, 0, getWidth(), getHeight());
        }
    }
    
}
