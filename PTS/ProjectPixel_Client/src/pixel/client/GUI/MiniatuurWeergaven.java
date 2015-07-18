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
import java.awt.Point;
import java.awt.Rectangle;
import java.awt.color.ColorSpace;
import java.awt.image.BufferedImage;
import java.awt.image.BufferedImageOp;
import java.awt.image.ColorConvertOp;
import java.awt.image.RescaleOp;
import java.util.ArrayList;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.swing.JPanel;
import javax.swing.JWindow;
import pixel.client.Client;
import pixel.shared.classes.Foto;
import pixel.shared.classes.BewerkteFoto;
import pixel.shared.enums.EffectType;

/**
 *
 * @author Luc
 */
public class MiniatuurWeergaven extends javax.swing.JPanel {

    /*
     * 
     *  public bool InBounds(Location location)
     {
     if (location.X < this.MinimumLocation.X || location.X > this.MaximumLocation.X)
     return false;
     if (location.Y < this.MinimumLocation.Y || location.Y > this.MaximumLocation.Y)
     return false;
     return true;
     }
     * 
     */
    private ArrayList<Foto> fotos;
    private ArrayList<BewerkteFoto> bewerkteFotos;
    private int aantalRijen = 0;
    private int aantalKolommen = 0;
    private Foto geselecteerdeFoto;
    private JPanel panel;
    private JWindow previewFrame;

    /**
     * Creates new form MiniatuurWeergaven
     */
    public MiniatuurWeergaven() {
        initComponents();
    }

    public JWindow getPreviewFrame() {
        return previewFrame;
    }

    public void LoadPublicFotos(int dagenTerug) {
        try {
            fotos = Client.getServerConnection().getPublicFotos(dagenTerug);
            for (Foto f : fotos) {
                f.byteToFoto();
                f.genereerThumbnail();
            }
            this.repaint();
        } catch (Exception ex) {
            Logger.getLogger(MiniatuurWeergaven.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    public void LoadMijnFotos(int dagenTerug) {
        try {
            fotos = Client.getServerConnection().getMijnFotos(Client.getLoggedinAccount().getEmail(), dagenTerug);
            for (Foto f : fotos) {
                f.byteToFoto();
                f.genereerThumbnail();
            }
            this.repaint();
        } catch (Exception ex) {
            Logger.getLogger(MiniatuurWeergaven.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    public void LoadGekoppeldeFotos(int dagenTerug) {
        try {
            fotos = Client.getServerConnection().getGekoppeldeFotos(Client.getLoggedinAccount().getEmail(), dagenTerug);
            bewerkteFotos = Client.getServerConnection().getBewerkteFotos(Client.getLoggedinAccount().getEmail(), dagenTerug);
            if (bewerkteFotos != null) {
                fotos.addAll(bewerkteFotos);
            }
            for (Foto f : fotos) {
                //if (f instanceof BewerkteFoto) {
                    /*for (Foto foto : fotos) {
                 if (foto instanceof BewerkteFoto)
                 continue;
                 if (foto.getFotoNummer() == f.getFotoNummer() && foto.getFoto() != null) {
                 f.setBytes(foto.getBytes());
                 f.byteToFoto();
                 f.genereerThumbnail();
                 }
                 }*/
                //} else {
                f.byteToFoto();
                f.genereerThumbnail();
                //}
            }
            this.repaint();
        } catch (Exception ex) {
            Logger.getLogger(MiniatuurWeergaven.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    /**
     *
     * @return
     */
    public Foto getGeselecteerdeFoto() {
        return geselecteerdeFoto;
    }

    /**
     *
     * @param panel
     */
    public void setPanel(JPanel panel) {
        this.panel = panel;
    }

    /**
     *
     * @param foto
     */
    public void addPhoto(Foto foto) {
        foto.byteToFoto();
        foto.genereerThumbnail();
        this.fotos.add(foto);
        this.repaint();
    }

    @Override
    public void paintComponent(Graphics g) {
        super.paintComponent(g);
        if (fotos != null) {
            int aantalPerRij = (int) Math.floor((this.getWidth() / 110));
            if (aantalPerRij < 1) {
                aantalPerRij = 1;
            }

            if (fotos.size() >= aantalPerRij) {
                aantalKolommen = aantalPerRij;
                aantalRijen = (int) Math.ceil((double) fotos.size() / aantalKolommen);
            } else {
                aantalKolommen = fotos.size();
                aantalRijen = 1;
            }
            Dimension dim = new Dimension(this.getWidth(), aantalRijen * 110 + 40);
            this.setPreferredSize(dim);

            int rij = 0;
            int kolom = 0;
            for (Foto f : fotos) {
                if (f.getThumbnail() != null) {
                    if (kolom >= aantalPerRij) {
                        rij++;
                        kolom = 0;
                    }
                    if (f == this.geselecteerdeFoto) {
                        Color color = g.getColor();
                        g.setColor(Color.red);
                        g.fillRect(20 + kolom * 110, 20 + rij * 110, f.getThumbnail().getWidth() + 10, f.getThumbnail().getHeight() + 10);
                        g.setColor(color);
                    }

                    if (f instanceof BewerkteFoto) {
                        BewerkteFoto bf = (BewerkteFoto) f;
                        ColorSpace cs = ColorSpace.getInstance(ColorSpace.CS_GRAY);
                        BufferedImageOp biop = new ColorConvertOp(cs, null);
                        BufferedImage bi2 = biop.filter(bf.getThumbnail(), null);

                        if (bf.getEffectType() == EffectType.ZWARTWIT) {
                            Image image = bi2;
                            g.drawImage(image, 25 + kolom * 110, 25 + rij * 110, null);
                        } else if (bf.getEffectType() == EffectType.SEPIA) {
                            // Convert grayscaled image from TYPE_GRAY to TYPE_RGB.
                            BufferedImage bi3 = new BufferedImage(bf.getThumbnail().getWidth(), bf.getThumbnail().getHeight(), BufferedImage.TYPE_INT_RGB);
                            Graphics g2 = bi3.createGraphics();
                            g2.drawImage(bi2, 0, 0, null);
                            g2.dispose();

                            // Draw grayscaled TYPE_RGB image as sepia toned image via rescaling.
                            Graphics2D g2d = (Graphics2D) g;
                            float[] scales = new float[]{1.0f, 1.0f, 1.0f};
                            float[] offsets = new float[]{40.0f, 20.0f, -20.0f};
                            RescaleOp rescale = new RescaleOp(scales, offsets, null);
                            g2d.drawImage(bi3, rescale, 25 + kolom * 110, 25 + rij * 110);
                        } else {
                            g.drawImage(bf.getThumbnail(), 25 + kolom * 110, 25 + rij * 110, this);
                        }
                    } else {
                        g.drawImage(f.getThumbnail(), 25 + kolom * 110, 25 + rij * 110, this);
                    }
                    kolom++;
                }
            }
        }
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
            public void mouseClicked(java.awt.event.MouseEvent evt) {
                formMouseClicked(evt);
            }
        });
        setLayout(new java.awt.GridLayout());
    }// </editor-fold>//GEN-END:initComponents

    private void formMouseClicked(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_formMouseClicked
        Point klik = evt.getPoint();
        int rij = -1;
        int kolom = -1;

        for (int i = 0; i < aantalKolommen; i++) {
            if (klik.x > 25 + i * 110 && klik.x < (i + 1) * 110) {
                kolom = i;
            }
        }
        for (int i = 0; i < aantalRijen; i++) {
            if (klik.y > 25 + i * 110 && klik.y < (i + 1) * 110) {
                rij = i;
            }
        }

        if (rij >= 0 && kolom >= 0) {
            int fotoIndex = (int) (rij * aantalKolommen + kolom);
            try {
                geselecteerdeFoto = fotos.get(fotoIndex);
                /* (fotos.get(fotoIndex) instanceof BewerkteFoto) {
                 geselecteerdeFoto = null;
                 geselecteerdeFoto = new BewerkteFoto(0);
                 geselecteerdeFoto = fotos.get(fotoIndex);
                 } else {
                 geselecteerdeFoto = fotos.get(fotoIndex);
                 }*/
            } catch (Exception ex) {
                Logger.getLogger(MiniatuurWeergaven.class.getName()).log(Level.SEVERE, null, ex);
            }
            if (previewFrame != null) {
                previewFrame.dispose();
            }
            java.awt.EventQueue.invokeLater(new Runnable() {
                @Override
                public void run() {
                    if (geselecteerdeFoto != null) {
                        if (geselecteerdeFoto instanceof BewerkteFoto) {
                            BewerkteFoto fk = (BewerkteFoto) geselecteerdeFoto;
                            Rectangle crop = fk.getCropRect();

                            if (crop.getWidth() != 0) {
                                previewFrame = new PhotoPreviewWindow(panel, geselecteerdeFoto, fk.getEffectType(), false, crop);
                            } else {
                                previewFrame = new PhotoPreviewWindow(panel, geselecteerdeFoto, fk.getEffectType(), false);
                            }
                        } else {
                            previewFrame = new PhotoPreviewWindow(panel, geselecteerdeFoto, EffectType.NORMAAL, false);
                        }
                    }
                }
            });

            repaint();
        } else {
            geselecteerdeFoto = null;
        }
        if (panel instanceof FotograafHolderPanel) {
            ((FotograafHolderPanel) panel).showFotoDetails();
        } else if (panel instanceof FotoproducentHolderPanel) {
            ((FotoproducentHolderPanel) panel).showFotoDetails();
        } else if (panel instanceof KlantHolderPanel) {
            ((KlantHolderPanel) panel).showFotoDetails();
        } else if (panel instanceof BFotograafHolderPanel) {
            ((BFotograafHolderPanel) panel).showFotoDetails();
        }

        // TODO FIX DE FKNG FOTODETAILS SHIT HIER
        // klant werkt wel, fotograaf niet.... heeft waarschijnlijk iets veranderd met fotograaf A of B
    }//GEN-LAST:event_formMouseClicked
    // Variables declaration - do not modify//GEN-BEGIN:variables
    // End of variables declaration//GEN-END:variables
}
