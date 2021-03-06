/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package pixel.client.GUI;

import java.rmi.RemoteException;
import java.text.DecimalFormat;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.Locale;
import java.util.ResourceBundle;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.swing.DefaultListModel;
import javax.swing.JOptionPane;
import pixel.client.Client;
import pixel.shared.classes.Foto;
import pixel.shared.classes.FotoDetails;
import pixel.shared.classes.Product;
import pixel.shared.classes.ProductDetails;

/**
 *
 * @author Frank
 */
public class FotoproducentHolderPanel extends javax.swing.JPanel {

    private HoofdPanel panel;
    private ArrayList<Product> producten;
    ResourceBundle resBund;
    DefaultListModel listmodel = new DefaultListModel();

    /**
     * Creates new form FotoproducentHolderPanel
     * @param panel 
     */
    public FotoproducentHolderPanel(HoofdPanel panel) {
        this.panel = panel;
        this.panel.getMiniatuurWeergaven().setPanel(this);
        initComponents();

        l_producten.setModel(listmodel);
        refreshProductList();
        resBund = ResourceBundle.getBundle("pixel.resources.language.Language", Locale.getDefault());
        UpdateLanguage();
    }

    private void UpdateLanguage() {
        btn_productverwijderen.setText(resBund.getString("REMOVEPRODUCT"));
        btn_voegFotograafToe.setText(resBund.getString("ADDPHOTOGRAPHER"));
        btn_voegProductToe.setText(resBund.getString("ADDPRODUCT"));
        btn_productWijzigen.setText(resBund.getString("EDITPRODUCT"));
        btn_bestelgeschiedenis.setText(resBund.getString("ORDERHISTORY"));
    }

    /**
     * This method is called from within the constructor to initialize the form.
     * WARNING: Do NOT modify this code. The content of this method is always
     * regenerated by the Form Editor.
     */
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        btn_voegProductToe = new javax.swing.JButton();
        btn_voegFotograafToe = new javax.swing.JButton();
        jScrollPane1 = new javax.swing.JScrollPane();
        l_producten = new javax.swing.JList();
        btn_productverwijderen = new javax.swing.JButton();
        btn_productWijzigen = new javax.swing.JButton();
        btn_bestelgeschiedenis = new javax.swing.JButton();

        setBorder(javax.swing.BorderFactory.createTitledBorder(null, "", javax.swing.border.TitledBorder.DEFAULT_JUSTIFICATION, javax.swing.border.TitledBorder.DEFAULT_POSITION, null, new java.awt.Color(0, 0, 0)));

        btn_voegProductToe.setText("Product toevoegen");
        btn_voegProductToe.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btn_voegProductToeActionPerformed(evt);
            }
        });

        btn_voegFotograafToe.setText("Fotograaf toevoegen");
        btn_voegFotograafToe.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btn_voegFotograafToeActionPerformed(evt);
            }
        });

        l_producten.setModel(new javax.swing.AbstractListModel() {
            String[] strings = { "Item 1", "Item 2", "Item 3", "Item 4", "Item 5" };
            public int getSize() { return strings.length; }
            public Object getElementAt(int i) { return strings[i]; }
        });
        jScrollPane1.setViewportView(l_producten);

        btn_productverwijderen.setText("Product verwijderen");
        btn_productverwijderen.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btn_productverwijderenActionPerformed(evt);
            }
        });

        btn_productWijzigen.setText("Product wijzigen");
        btn_productWijzigen.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btn_productWijzigenActionPerformed(evt);
            }
        });

        btn_bestelgeschiedenis.setText("Bestelgeschiedenis");
        btn_bestelgeschiedenis.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btn_bestelgeschiedenisActionPerformed(evt);
            }
        });

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addContainerGap()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addComponent(jScrollPane1, javax.swing.GroupLayout.Alignment.TRAILING)
                    .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addGroup(layout.createSequentialGroup()
                                .addComponent(btn_productverwijderen, javax.swing.GroupLayout.PREFERRED_SIZE, 167, javax.swing.GroupLayout.PREFERRED_SIZE)
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                                .addComponent(btn_productWijzigen))
                            .addGroup(layout.createSequentialGroup()
                                .addComponent(btn_voegProductToe)
                                .addGap(0, 0, Short.MAX_VALUE)))
                        .addGap(18, 18, 18)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addComponent(btn_bestelgeschiedenis)
                            .addComponent(btn_voegFotograafToe))))
                .addContainerGap())
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addContainerGap()
                .addComponent(jScrollPane1, javax.swing.GroupLayout.DEFAULT_SIZE, 203, Short.MAX_VALUE)
                .addGap(18, 18, 18)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(btn_voegProductToe)
                    .addComponent(btn_bestelgeschiedenis))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(btn_voegFotograafToe)
                    .addComponent(btn_productverwijderen)
                    .addComponent(btn_productWijzigen))
                .addContainerGap())
        );
    }// </editor-fold>//GEN-END:initComponents

    private void btn_voegFotograafToeActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btn_voegFotograafToeActionPerformed
        Client.getFrame().loadPanel(new RegisterPanel());
    }//GEN-LAST:event_btn_voegFotograafToeActionPerformed

    private void btn_voegProductToeActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btn_voegProductToeActionPerformed
        Client.getFrame().loadPanel(new AddProductPanel(panel));
    }//GEN-LAST:event_btn_voegProductToeActionPerformed

    private void btn_productverwijderenActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btn_productverwijderenActionPerformed
        // TODO add your handling code here:
        if(l_producten.getSelectedValue() == null) {
        } 
        else {
            try {
                String productnaam = l_producten.getSelectedValue().toString();
                int productnummer = Client.getServerConnection().getProductNummer(productnaam);
                Client.getServerConnection().deleteProduct(productnummer);
                refreshProductList();
            } catch (RemoteException ex) {
                Logger.getLogger(FotoproducentHolderPanel.class.getName()).log(Level.SEVERE, null, ex);
            }
        }
    }//GEN-LAST:event_btn_productverwijderenActionPerformed

    private void btn_productWijzigenActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btn_productWijzigenActionPerformed

            // TODO add your handling code here:
            Product p = producten.get(l_producten.getSelectedIndex()); 
            Client.getFrame().loadPanel(new AddProductPanel(panel, p));
    }//GEN-LAST:event_btn_productWijzigenActionPerformed

    private void btn_bestelgeschiedenisActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btn_bestelgeschiedenisActionPerformed
        // TODO add your handling code here:
        Client.getFrame().loadPanel(new BestelGeschiedenisPanel());
    }//GEN-LAST:event_btn_bestelgeschiedenisActionPerformed

    private void refreshProductList() {
         try {
            producten = Client.getServerConnection().getProducten();
        } catch (RemoteException ex) {
            Logger.getLogger(FotoproducentHolderPanel.class.getName()).log(Level.SEVERE, null, ex);
        }
        listmodel.clear();
        for(Product p : producten) {
            listmodel.addElement(p.getProductnaam());
        }
    }
    
    /**
     *
     */
    public void showFotoDetails() {
        Foto geselecteerdeFoto = panel.getMiniatuurWeergaven().getGeselecteerdeFoto();
        if (geselecteerdeFoto == null) {
            return;
        }
        FotoDetails details = null;
        try {
            details = Client.getServerConnection().getFotoDetails((int) geselecteerdeFoto.getFotoNummer());
        } catch (RemoteException ex) {
            Logger.getLogger(HoofdPanel.class.getName()).log(Level.SEVERE, null, ex);
        }
        if (details != null) {
            panel.setFotograafNaam(details.getEigenaar());
            panel.setRating("" + details.getRating());
            panel.setLikeButtonEnabled(true);
            
            Date datum = details.getDatum();
            SimpleDateFormat dateFormat = new SimpleDateFormat("dd/MM/yyyy");
            String datumAlsString = dateFormat.format(datum);
            panel.setHuidigeDatum(datumAlsString);
            
            DecimalFormat df = new DecimalFormat("#.00");
            Double prijs;

            switch (resBund.getString("CURRENCY")) {
                case "€":
                    prijs = details.getPrijs();
                    if (prijs < 1) {
                        panel.setHuidigePrijs("0" + df.format(prijs));
                    } else {
                        panel.setHuidigePrijs(df.format(prijs));
                    }
                    break;
                case "£":
                    prijs = details.getPrijs() * HoofdPanel.getPondKoers();
                    if (prijs < 1) {
                        panel.setHuidigePrijs("0" + df.format(prijs));
                    } else {
                        panel.setHuidigePrijs(df.format(prijs));
                    }
                    break;
                case "$":
                    prijs = details.getPrijs() * HoofdPanel.getDollarKoers();
                    if (prijs < 1) {
                        panel.setHuidigePrijs("0" + df.format(prijs));
                    } else {
                        panel.setHuidigePrijs(df.format(prijs));
                    }
                    dateFormat = new SimpleDateFormat("yyyy/MM/dd");
                    datumAlsString = dateFormat.format(datum);
                    panel.setHuidigeDatum(datumAlsString);
                    break;
                case "Lv":
                    prijs = details.getPrijs() * HoofdPanel.getLevKoers();
                    if (prijs < 1) {
                        panel.setHuidigePrijs("0" + df.format(prijs));
                    } else {
                        panel.setHuidigePrijs(df.format(prijs));
                    }
                    break;
            }
        } else {
            JOptionPane.showMessageDialog(this, resBund.getString("PICTUREFIRST"), resBund.getString("ERROR"), JOptionPane.ERROR_MESSAGE);
        }
    }
    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton btn_bestelgeschiedenis;
    private javax.swing.JButton btn_productWijzigen;
    private javax.swing.JButton btn_productverwijderen;
    private javax.swing.JButton btn_voegFotograafToe;
    private javax.swing.JButton btn_voegProductToe;
    private javax.swing.JScrollPane jScrollPane1;
    private javax.swing.JList l_producten;
    // End of variables declaration//GEN-END:variables
}
