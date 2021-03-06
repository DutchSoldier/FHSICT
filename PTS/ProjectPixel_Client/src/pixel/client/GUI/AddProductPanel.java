/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package pixel.client.GUI;

import java.io.ByteArrayOutputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;
import java.rmi.RemoteException;
import java.util.Locale;
import java.util.ResourceBundle;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.swing.*;
import pixel.client.Client;
import pixel.client.GUI.photochooser.ImageFilter;
import pixel.client.GUI.photochooser.ImagePreview;
import pixel.shared.classes.Product;
import pixel.shared.classes.ProductDetails;

/**
 *
 * @author Remi_Arts
 */
public class AddProductPanel extends javax.swing.JPanel {

    private HoofdPanel panel;
    private JFileChooser fc;
    private File file;
    ResourceBundle resBund;
    private boolean wijzig;
    private Product product;

    /**
     * Creates new form ProductPanel
     *
     * @param panel
     */
    public AddProductPanel(HoofdPanel panel) {
        this.panel = panel;
        initComponents();
        wijzig = false;
        resBund = ResourceBundle.getBundle("pixel.resources.language.Language", Locale.getDefault());
        UpdateLanguage();
    }
    
    /**
     *
     * @param panel
     * @param product
     */
    public AddProductPanel(HoofdPanel panel, Product product) {
        initComponents();
        this.panel = panel;
        tf_beschrijvingProd.setText(product.getProductbeschrijving());
        tf_naamProd.setText(product.getProductnaam());
        tf_prijsProd.setText(Double.toString(product.getProductprijs()));
        tf_voorraadProd.setText(Integer.toString(product.getVoorraad()));
        this.product = product;
        System.out.println("productnr " + product.getProductnummer());
        wijzig = true;
        resBund = ResourceBundle.getBundle("pixel.resources.language.Language", Locale.getDefault());
        UpdateLanguage();
    }

    private void UpdateLanguage() {
        btn_saveProd.setText(resBund.getString("SAVE"));
        lb_beschrijvingProd.setText(resBund.getString("INFORMATION"));
        lb_naamProd.setText(resBund.getString("NAME"));
        lb_prijsProd.setText(resBund.getString("PRICEIN") + " " + resBund.getString("CURRENCY"));
        lb_productPanel.setText(resBund.getString("ADDPRODUCTHELP"));
        lb_voorraadProd.setText(resBund.getString("STOCK"));
    }

    /**
     * This method is called from within the constructor to initialize the form.
     * WARNING: Do NOT modify this code. The content of this method is always
     * regenerated by the Form Editor.
     */
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        btn_saveProd = new javax.swing.JButton();
        btn_cancelProd = new javax.swing.JButton();
        tf_naamProd = new javax.swing.JTextField();
        tf_beschrijvingProd = new javax.swing.JTextField();
        tf_voorraadProd = new javax.swing.JTextField();
        lb_naamProd = new javax.swing.JLabel();
        lb_prijsProd = new javax.swing.JLabel();
        lb_beschrijvingProd = new javax.swing.JLabel();
        lb_voorraadProd = new javax.swing.JLabel();
        tf_prijsProd = new javax.swing.JTextField();
        btn_fotoProd = new javax.swing.JButton();
        lb_productPanel = new javax.swing.JLabel();

        setName("Product Toevoegen"); // NOI18N

        btn_saveProd.setText("Opslaan");
        btn_saveProd.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btn_saveProdActionPerformed(evt);
            }
        });

        btn_cancelProd.setText("Terug");
        btn_cancelProd.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btn_cancelProdActionPerformed(evt);
            }
        });

        lb_naamProd.setText("Naam:");

        lb_prijsProd.setText("Prijs in euro's:");

        lb_beschrijvingProd.setText("Beschrijving:");

        lb_voorraadProd.setText("Voorraad:");

        btn_fotoProd.setText("Voeg foto(s) toe");
        btn_fotoProd.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btn_fotoProdActionPerformed(evt);
            }
        });

        lb_productPanel.setText("Voeg hier een nieuw product toe.");

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addContainerGap()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                        .addGap(0, 0, Short.MAX_VALUE)
                        .addComponent(btn_fotoProd))
                    .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                        .addComponent(btn_cancelProd)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                        .addComponent(btn_saveProd))
                    .addGroup(layout.createSequentialGroup()
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addComponent(lb_beschrijvingProd)
                            .addComponent(lb_voorraadProd)
                            .addComponent(lb_prijsProd))
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false)
                            .addComponent(tf_prijsProd, javax.swing.GroupLayout.Alignment.TRAILING, javax.swing.GroupLayout.DEFAULT_SIZE, 270, Short.MAX_VALUE)
                            .addComponent(tf_voorraadProd, javax.swing.GroupLayout.Alignment.TRAILING)
                            .addComponent(tf_beschrijvingProd, javax.swing.GroupLayout.Alignment.TRAILING)))
                    .addGroup(layout.createSequentialGroup()
                        .addComponent(lb_naamProd)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, 40, Short.MAX_VALUE)
                        .addComponent(tf_naamProd, javax.swing.GroupLayout.PREFERRED_SIZE, 270, javax.swing.GroupLayout.PREFERRED_SIZE))
                    .addGroup(layout.createSequentialGroup()
                        .addComponent(lb_productPanel)
                        .addGap(0, 0, Short.MAX_VALUE)))
                .addContainerGap())
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                .addContainerGap()
                .addComponent(lb_productPanel)
                .addGap(18, 18, 18)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(lb_naamProd)
                    .addComponent(tf_naamProd, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(lb_beschrijvingProd)
                    .addComponent(tf_beschrijvingProd, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addGap(15, 15, 15)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(lb_voorraadProd)
                    .addComponent(tf_voorraadProd, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addGap(18, 18, 18)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(lb_prijsProd)
                    .addComponent(tf_prijsProd, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addGap(18, 18, 18)
                .addComponent(btn_fotoProd)
                .addGap(18, 18, 18)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addComponent(btn_saveProd)
                    .addComponent(btn_cancelProd))
                .addGap(18, 18, Short.MAX_VALUE))
        );
    }// </editor-fold>//GEN-END:initComponents

    private void btn_saveProdActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btn_saveProdActionPerformed
        
        String naam = tf_naamProd.getText();
        String beschrijving = tf_beschrijvingProd.getText();
        int voorraad = Integer.parseInt(tf_voorraadProd.getText());
        double prijs = 0;
        switch (resBund.getString("CURRENCY")) {
            case "€":
                prijs = Double.parseDouble(tf_prijsProd.getText());
                break;
            case "£":
                prijs = (Double.parseDouble(tf_prijsProd.getText()) * HoofdPanel.getPondKoers());
                break;
            case "$":
                prijs = (Double.parseDouble(tf_prijsProd.getText()) * HoofdPanel.getDollarKoers());
                break;
            case "Lv":
                prijs = (Double.parseDouble(tf_prijsProd.getText()) * HoofdPanel.getLevKoers());
                break;
        }

        byte[] bytes = null;
        if(file != null) {
        if (file.exists()) {
            try {
                FileInputStream fis = new FileInputStream(file);
                ByteArrayOutputStream bos = new ByteArrayOutputStream();

                byte[] buf = new byte[fis.available()]; // 1024
                for (int readNum; (readNum = fis.read(buf)) != -1;) {
                    bos.write(buf, 0, readNum);
                }
                bytes = bos.toByteArray();

            } catch (IOException ex) {
                Logger.getLogger(Product.class.getName()).log(Level.SEVERE, null, ex);
            }
        }
        }
        if(!wijzig) {
        try {
            Client.getServerConnection().productToevoegen(naam, beschrijving, voorraad, prijs, bytes);
        } catch (RemoteException ex) {
            Logger.getLogger(RegisterPanel.class.getName()).log(Level.SEVERE, null, ex);
        }
        Client.getFrame().loadPanel(new HoofdPanel());
        }
        else {
            try {
            Client.getServerConnection().wijzigProduct(naam, beschrijving, voorraad, prijs, null, product.getProductnummer());
        } 
            catch (RemoteException ex) {
            Logger.getLogger(AddProductPanel.class.getName()).log(Level.SEVERE, null, ex);
        }
        Client.getFrame().loadPanel(new HoofdPanel());
        
        }
    }//GEN-LAST:event_btn_saveProdActionPerformed

    private void btn_fotoProdActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btn_fotoProdActionPerformed
        file = new File("%userprofile%");
        fc = new JFileChooser();
        fc.setDialogTitle(resBund.getString("ONEORMORE"));
        fc.setCurrentDirectory(file);
        fc.setApproveButtonText(resBund.getString("SELECT"));
        fc.setFileFilter(new ImageFilter());
        fc.setAcceptAllFileFilterUsed(false);
        fc.setAccessory(new ImagePreview(fc));
        fc.setMultiSelectionEnabled(false);

        int returnValue = fc.showOpenDialog(this);
        if (returnValue == JFileChooser.APPROVE_OPTION) {
            file = fc.getSelectedFile();
            System.out.println(fc.toString());
        }
    }//GEN-LAST:event_btn_fotoProdActionPerformed

    private void btn_cancelProdActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btn_cancelProdActionPerformed
        // TODO add your handling code here:
        Client.getFrame().loadPanel(panel);
    }//GEN-LAST:event_btn_cancelProdActionPerformed
    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton btn_cancelProd;
    private javax.swing.JButton btn_fotoProd;
    private javax.swing.JButton btn_saveProd;
    private javax.swing.JLabel lb_beschrijvingProd;
    private javax.swing.JLabel lb_naamProd;
    private javax.swing.JLabel lb_prijsProd;
    private javax.swing.JLabel lb_productPanel;
    private javax.swing.JLabel lb_voorraadProd;
    private javax.swing.JTextField tf_beschrijvingProd;
    private javax.swing.JTextField tf_naamProd;
    private javax.swing.JTextField tf_prijsProd;
    private javax.swing.JTextField tf_voorraadProd;
    // End of variables declaration//GEN-END:variables
}
