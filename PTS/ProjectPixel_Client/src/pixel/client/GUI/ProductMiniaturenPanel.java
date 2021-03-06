/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package pixel.client.GUI;
import java.awt.Color;
import java.awt.Graphics;
import java.awt.Point;
import java.text.DecimalFormat;
import java.util.ArrayList;
import java.util.Locale;
import java.util.ResourceBundle;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import pixel.client.Client;
import pixel.shared.classes.Foto;
import pixel.shared.classes.Product;

/**
 *
 * @author Simon
 */
public class ProductMiniaturenPanel extends javax.swing.JPanel {

    ResourceBundle resBund;
    
    private ArrayList<Product> producten;
    private int aantalRijen = 0;
    private int aantalKolommen = 0;
    private Product geselecteerdProduct;
    private Foto geselecteerdeFoto;
    private KoppelProductWindow window;
    /**
     * Creates new form ProductMiniaturenPanel
     * @param foto 
     */
    public ProductMiniaturenPanel(Foto foto) {
                initComponents();
                
        resBund = ResourceBundle.getBundle("pixel.resources.language.Language", Locale.getDefault());
        UpdateLanguage();
        
        this.geselecteerdeFoto = foto;
        try {
            producten = Client.getServerConnection().getProducten();

            for (Product p : producten) {
                p.byteToFoto();
                p.genereerThumbnail();
                System.out.println(p.getProductnaam());
            }
        } catch (Exception ex) {
            Logger.getLogger(MiniatuurWeergaven.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
    
    private void UpdateLanguage() {
        btn_volgende.setText(resBund.getString("NEXT"));
        btn_vorige.setText(resBund.getString("PREVIOUS"));
        lbl_productbeschrijving.setText(resBund.getString("INFORMATION"));
        lbl_prijs.setText(resBund.getString("PRICEIN") + " " + resBund.getString("CURRENCY"));
    }
    
        /**
     *
     * @return
     */
    public Product getGeselecteerdProduct() {
        return geselecteerdProduct;
    }
        

    @Override
    public void paintComponent(Graphics g) {
        super.paintComponent(g);
        if (producten != null) {
            int aantalPerRij = (int) Math.floor((this.getWidth() / (float)110));
            if (aantalPerRij < 1) {
                aantalPerRij = 1;
            }

            if (producten.size() >= aantalPerRij) {
                aantalKolommen = aantalPerRij;
                aantalRijen = (int) Math.ceil((double) producten.size() / aantalKolommen);
            } else {
                aantalKolommen = producten.size();
                aantalRijen = 1;
            }

            int rij = 0;
            int kolom = 0;
            for (Product p : producten) {
                if (p.getThumbnail() != null) {
                    if (kolom >= aantalPerRij) {
                        rij++;
                        kolom = 0;
                    }
                    if (p == this.geselecteerdProduct) {
                        Color color = g.getColor();
                        g.setColor(Color.red);
                        g.fillRect(20 + kolom * 110, 20 + rij * 110, p.getThumbnail().getWidth() + 10, p.getThumbnail().getHeight() + 10);
                        g.setColor(color);
                    }
                    g.drawImage(p.getThumbnail(), 25 + kolom * 110, 25 + rij * 110, this);
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

        jPanel1 = new javax.swing.JPanel();
        btn_vorige = new javax.swing.JButton();
        btn_volgende = new javax.swing.JButton();
        lbl_prijs = new javax.swing.JLabel();
        lbl_naam = new javax.swing.JLabel();
        lbl_beschrijving = new javax.swing.JLabel();
        lbl_productbeschrijving = new javax.swing.JLabel();
        lbl_productnaam = new javax.swing.JLabel();
        lbl_productprijs = new javax.swing.JLabel();

        setName(""); // NOI18N
        addMouseListener(new java.awt.event.MouseAdapter() {
            public void mouseClicked(java.awt.event.MouseEvent evt) {
                formMouseClicked(evt);
            }
        });

        btn_vorige.setText("Vorige");
        btn_vorige.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btn_vorigeActionPerformed(evt);
            }
        });

        btn_volgende.setText("Volgende");
        btn_volgende.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btn_volgendeActionPerformed(evt);
            }
        });

        lbl_prijs.setText("Prijs in €");

        lbl_naam.setText("Product");

        lbl_beschrijving.setText("Beschrijving");

        lbl_productbeschrijving.setText("--");

        lbl_productnaam.setText("--");

        lbl_productprijs.setText("--");

        javax.swing.GroupLayout jPanel1Layout = new javax.swing.GroupLayout(jPanel1);
        jPanel1.setLayout(jPanel1Layout);
        jPanel1Layout.setHorizontalGroup(
            jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(jPanel1Layout.createSequentialGroup()
                .addContainerGap()
                .addComponent(btn_vorige)
                .addGap(18, 18, 18)
                .addComponent(btn_volgende)
                .addGap(18, 18, 18)
                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addComponent(lbl_naam)
                    .addComponent(lbl_prijs)
                    .addComponent(lbl_beschrijving))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(jPanel1Layout.createSequentialGroup()
                        .addComponent(lbl_productbeschrijving, javax.swing.GroupLayout.PREFERRED_SIZE, 200, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addGap(0, 0, Short.MAX_VALUE))
                    .addComponent(lbl_productprijs, javax.swing.GroupLayout.Alignment.TRAILING, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                    .addComponent(lbl_productnaam, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
                .addContainerGap())
        );
        jPanel1Layout.setVerticalGroup(
            jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, jPanel1Layout.createSequentialGroup()
                .addContainerGap(18, Short.MAX_VALUE)
                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(lbl_naam)
                    .addComponent(lbl_productnaam))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(lbl_prijs)
                    .addComponent(lbl_productprijs))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(btn_vorige)
                    .addComponent(btn_volgende)
                    .addComponent(lbl_beschrijving)
                    .addComponent(lbl_productbeschrijving))
                .addContainerGap())
        );

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addContainerGap()
                .addComponent(jPanel1, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addContainerGap(34, Short.MAX_VALUE))
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addContainerGap(192, Short.MAX_VALUE)
                .addComponent(jPanel1, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addContainerGap())
        );
    }// </editor-fold>//GEN-END:initComponents

    private void btn_volgendeActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btn_volgendeActionPerformed
        if (window != null) {
            window.dispose();
        }
        window = new KoppelProductWindow((JPanel)this, geselecteerdeFoto, geselecteerdProduct);
    }//GEN-LAST:event_btn_volgendeActionPerformed

    private void btn_vorigeActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btn_vorigeActionPerformed
        if (window != null) {
            window.dispose();
        }
        Client.getFrame().loadPanel(new HoofdPanel());
    }//GEN-LAST:event_btn_vorigeActionPerformed

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
                geselecteerdProduct = producten.get(fotoIndex);
            } catch (Exception ex) {
                Logger.getLogger(ProductMiniaturenPanel.class.getName()).log(Level.SEVERE, null, ex);
            }
            repaint();
        } 
        
        else {
            geselecteerdProduct = null;
        } 
        
        if(geselecteerdProduct != null) {
            lbl_productnaam.setText(geselecteerdProduct.getProductnaam());
            lbl_productbeschrijving.setText(geselecteerdProduct.getProductbeschrijving());
            
            DecimalFormat df = new DecimalFormat("#.00");
            Double prijs;

            switch (resBund.getString("CURRENCY")) {
                case "€":
                    prijs = geselecteerdProduct.getProductprijs();
                    if (prijs < 1) {
                        lbl_productprijs.setText("0" + df.format(prijs));
                    } else {
                        lbl_productprijs.setText(df.format(prijs));
                    }
                    break;
                case "£":
                    prijs = geselecteerdProduct.getProductprijs() * HoofdPanel.getPondKoers();
                    if (prijs < 1) {
                        lbl_productprijs.setText("0" + df.format(prijs));
                    } else {
                        lbl_productprijs.setText(df.format(prijs));
                    }
                    break;
                case "$":
                    prijs = geselecteerdProduct.getProductprijs() * HoofdPanel.getDollarKoers();
                    if (prijs < 1) {
                        lbl_productprijs.setText("0" + df.format(prijs));
                    } else {
                       lbl_productprijs.setText(df.format(prijs));
                    }
                    break;
                case "Lv":
                    prijs = geselecteerdProduct.getProductprijs() * HoofdPanel.getLevKoers();
                    if (prijs < 1) {
                        lbl_productprijs.setText("0" + df.format(prijs));
                    } else {
                       lbl_productprijs.setText(df.format(prijs));
                    }
            }
        }
    }//GEN-LAST:event_formMouseClicked

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton btn_volgende;
    private javax.swing.JButton btn_vorige;
    private javax.swing.JPanel jPanel1;
    private javax.swing.JLabel lbl_beschrijving;
    private javax.swing.JLabel lbl_naam;
    private javax.swing.JLabel lbl_prijs;
    private javax.swing.JLabel lbl_productbeschrijving;
    private javax.swing.JLabel lbl_productnaam;
    private javax.swing.JLabel lbl_productprijs;
    // End of variables declaration//GEN-END:variables
}
