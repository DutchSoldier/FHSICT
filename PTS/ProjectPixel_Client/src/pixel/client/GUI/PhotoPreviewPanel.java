/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package pixel.client.GUI;

import java.awt.Color;
import java.awt.Dimension;
import java.awt.Graphics;
import java.awt.Graphics2D;
import java.awt.Image;
import java.awt.Rectangle;
import java.awt.color.ColorSpace;
import java.awt.image.BufferedImage;
import java.awt.image.BufferedImageOp;
import java.awt.image.ColorConvertOp;
import java.awt.image.RescaleOp;
import javax.swing.JWindow;
import pixel.shared.classes.Foto;
import pixel.shared.enums.EffectType;

/**
 *
 * @author Frank
 */
public class PhotoPreviewPanel extends javax.swing.JPanel {

    private JWindow window;
    private Foto foto;
    private BufferedImage bi;
    private EffectType type;
    public int width;
    public int height;
    private boolean cropping = false;
    private boolean canCrop;
    private int x1, y1, x2, y2;
    private Rectangle crop;

    /**
     * Creates new form FotoEffectPanel
     */
    @SuppressWarnings("OverridableMethodCallInConstructor")
    public PhotoPreviewPanel(JWindow window, Foto foto, EffectType type, boolean canCrop) {
        initComponents();
        this.foto = foto;
        this.type = type;
        this.window = window;
        this.canCrop = canCrop;
        Dimension size = getFotoSize(foto.getFoto().getWidth(), foto.getFoto().getHeight());
        width = size.width;
        height = size.height;
        Image image = foto.getFoto().getScaledInstance(width, height, Image.SCALE_FAST);
        bi = new BufferedImage(width, height, BufferedImage.TYPE_INT_RGB);
        Graphics g = bi.createGraphics();
        g.drawImage(image, 0, 0, null);
        g.dispose();
    }

    /**
     *
     * @param window
     * @param foto
     * @param type
     * @param canCrop
     * @param crop
     */
    @SuppressWarnings("OverridableMethodCallInConstructor")
    public PhotoPreviewPanel(JWindow window, Foto foto, EffectType type, boolean canCrop, Rectangle crop) {
        initComponents();
        this.foto = foto;
        this.type = type;
        this.window = window;
        this.canCrop = canCrop;
        this.crop = crop;
        Dimension size = getFotoSize(foto.getFoto().getWidth(), foto.getFoto().getHeight());
        
        width = size.width;
        height = size.height;
        Dimension cropSize = getFotoSize((int)crop.getWidth(), (int)crop.getHeight());
        Double rescaleRatio = (double)cropSize.getWidth() / (double)size.getWidth();
        Rectangle rescaledCrop = getRescaledCrop(rescaleRatio, crop);
        bi = new BufferedImage(width, height, BufferedImage.TYPE_INT_RGB);
        
        Image image = foto.getFoto().getScaledInstance(width, height, Image.SCALE_FAST);
        Graphics g = bi.createGraphics();
        g.drawImage(image, 0, 0, null);
        g.dispose();

        BufferedImage cropped = bi.getSubimage(rescaledCrop.x, rescaledCrop.y, rescaledCrop.width, rescaledCrop.height);
        bi = cropped;
        this.window.setPreferredSize(new Dimension(bi.getWidth(), bi.getHeight()));
    }

    @Override
    public void paintComponent(Graphics g) {
        // Create a copy of the original image in grayscale.
        ColorSpace cs = ColorSpace.getInstance(ColorSpace.CS_GRAY);
        BufferedImageOp biop = new ColorConvertOp(cs, null);
        BufferedImage bi2 = biop.filter(bi, null);
        //bi2 = bi2.getSubimage(x1, y1, bi2.getWidth() - 2 * x1, bi2.getHeight() - 2 * y1);


        if (type == EffectType.ZWARTWIT) {
            Image image = bi2;
            g.drawImage(image, 0, 0, null);

        } else if (type == EffectType.SEPIA) {
            // Convert grayscaled image from TYPE_GRAY to TYPE_RGB.
            BufferedImage bi3 = new BufferedImage(bi.getWidth(), bi.getHeight(), BufferedImage.TYPE_INT_RGB);
            Graphics g2 = bi3.createGraphics();
            g2.drawImage(bi2, 0, 0, null);
            g2.dispose();

            // Draw grayscaled TYPE_RGB image as sepia toned image via rescaling.
            Graphics2D g2d = (Graphics2D) g;
            float[] scales = new float[]{1.0f, 1.0f, 1.0f};
            float[] offsets = new float[]{40.0f, 20.0f, -20.0f};
            RescaleOp rescale = new RescaleOp(scales, offsets, null);
            g2d.drawImage(bi3, rescale, 0, 0);

        } else if (type == EffectType.NORMAAL) {
            g.drawImage(bi, 0, 0, null);
        }

        if (cropping && canCrop) {
            g.setColor(Color.red);
            int x = 0;
            int y = 0;
            int width = 0;
            int height = 0;

            if (x1 < x2) {
                width = x2 - x1;
                x = x1;
            } else {
                width = x1 - x2;
                x = x2;
            }

            if (y1 < y2) {
                height = y2 - y1;
                y = y1;
            } else {
                height = y1 - y2;
                y = y2;
            }

            if (x < 0) {
                x = 0;
            }
            if (x > bi.getWidth()) {
                x = bi.getWidth();
            }
            if (y < 0) {
                y = 0;
            }
            if (y > bi.getHeight()) {
                y = bi.getHeight();
            }
            if (width < 0) {
                width = 0;
            }
            if (width > bi.getWidth()) {
                width = bi.getWidth();
            }
            if (height < 0) {
                height = 0;
            }
            if (height > bi.getHeight()) {
                height = bi.getHeight();
            }
            g.drawRect(x, y, width, height);
        }
    }

    public Dimension getFotoSize(int width, int height) {
        Double ratio = (double) height / (double) width;
        Dimension size = new Dimension();
        if (height > 400) {
            height = 400;
        }
        Double tempWidth = height / ratio;
        width = tempWidth.intValue();
        size.setSize(width, height);
        return size;
    }

    public Rectangle getRescaledCrop(double rescaleRatio, Rectangle crop) {
        return new Rectangle((int) (crop.getMinX() * rescaleRatio), (int) (crop.getMinY() * rescaleRatio), (int) (crop.getWidth() * rescaleRatio), (int) (crop.getHeight() * rescaleRatio));
    }

    public EffectType getEffect() {
        return type;
    }

    public void ResetImage() {
        Image image = foto.getFoto().getScaledInstance(width, height, Image.SCALE_FAST);
        BufferedImage reset = new BufferedImage(width, height, BufferedImage.TYPE_INT_RGB);
        bi = reset;
        window.setSize(reset.getWidth(), reset.getHeight());
        Graphics g = bi.createGraphics();
        g.drawImage(image, 0, 0, null);
    }

    public Rectangle getCrop() {
        return new Rectangle(x1, y1, (x2 - x1), (y2 - y1));
    }

    /**
     * This method is called from within the constructor to initialize the form.
     * WARNING: Do NOT modify this code. The content of this method is always
     * regenerated by the Form Editor.
     */
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        addMouseListener(new java.awt.event.MouseAdapter() {
            public void mousePressed(java.awt.event.MouseEvent evt) {
                formMousePressed(evt);
            }
            public void mouseReleased(java.awt.event.MouseEvent evt) {
                formMouseReleased(evt);
            }
        });
        addMouseMotionListener(new java.awt.event.MouseMotionAdapter() {
            public void mouseDragged(java.awt.event.MouseEvent evt) {
                formMouseDragged(evt);
            }
        });

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGap(0, 400, Short.MAX_VALUE)
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGap(0, 300, Short.MAX_VALUE)
        );
    }// </editor-fold>//GEN-END:initComponents

    private void formMouseDragged(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_formMouseDragged
        if (canCrop) {
            int x = evt.getX();
            int y = evt.getY();
            if (x < 0) {
                x = 0;
            }
            if (x > bi.getWidth()) {
                x = bi.getWidth();
            }
            if (y < 0) {
                y = 0;
            }
            if (y > bi.getHeight()) {
                y = bi.getHeight();
            }
            x2 = x;
            y2 = y;

            repaint();
        }
    }//GEN-LAST:event_formMouseDragged

    private void formMouseReleased(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_formMouseReleased
        if (canCrop) {
            cropping = false;
            int x = 0;
            int y = 0;
            int width = 0;
            int height = 0;

            if (x1 < x2) {
                width = x2 - x1;
                x = x1;
            } else {
                width = x1 - x2;
                x = x2;
            }

            if (y1 < y2) {
                height = y2 - y1;
                y = y1;
            } else {
                height = y1 - y2;
                y = y2;
            }

            if (x < 0) {
                x = 0;
            }
            if (x > bi.getWidth()) {
                x = bi.getWidth();
            }
            if (y < 0) {
                y = 0;
            }
            if (y > bi.getHeight()) {
                y = bi.getHeight();
            }
            if (width < 0) {
                width = 0;
            }
            if (width > bi.getWidth()) {
                width = bi.getWidth();
            }
            if (height < 0) {
                height = 0;
            }
            if (height > bi.getHeight()) {
                height = bi.getHeight();
            }

            BufferedImage cropped = bi.getSubimage(x, y, width, height);
            this.bi = cropped;

            window.setSize(new Dimension(bi.getWidth(), bi.getHeight()));
            repaint();
        }
    }//GEN-LAST:event_formMouseReleased

    private void formMousePressed(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_formMousePressed
        if (canCrop) {
            cropping = true;
            this.x1 = evt.getX();
            this.y1 = evt.getY();
            repaint();
        }
    }//GEN-LAST:event_formMousePressed
    // Variables declaration - do not modify//GEN-BEGIN:variables
    // End of variables declaration//GEN-END:variables
}
