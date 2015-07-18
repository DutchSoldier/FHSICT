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
import pixel.client.GeneratePassword;
import pixel.shared.classes.Foto;
import pixel.shared.classes.FotoDetails;
import pixel.shared.classes.Persoon;
import pixel.shared.enums.PersoonType;

/**
 *
 * @author Frank
 */
public class BFotograafHolderPanel extends javax.swing.JPanel {

    private ArrayList<Integer> geselecteerdeFotos = new ArrayList();
    private HoofdPanel panel;
    ResourceBundle resBund;
    private Persoon persoon;
    private ArrayList<Persoon> personen;
    DefaultListModel listmodel = new DefaultListModel();
    /**
     * Creates new form FotograafHolderPanel
     *
     * @param panel
     */
    public BFotograafHolderPanel(HoofdPanel panel) {
        initComponents();
        this.panel = panel;
        this.panel.getMiniatuurWeergaven().setPanel(this); 
        
        
        refreshPersonenList();
        resBund = ResourceBundle.getBundle("pixel.resources.language.Language", Locale.getDefault());
        UpdateLanguage();
    }

    private void UpdateLanguage() {
        btn_koppel.setText(resBund.getString("LINKCUSTOMER"));
        btn_voegFotoToe.setText(resBund.getString("ADDPHOTO"));
        lbl_prijsWijzigen.setText(resBund.getString("PRICE"));
        btn_prijsWijzigen.setText(resBund.getString("EDIT"));
        tf_prijsWijzigen.setText(resBund.getString("PRICE"));
        btn_openbaar.setText(resBund.getString("OPENBAAR"));
        btn_bewerkFoto.setText(resBund.getString("EDITPHOTO"));
        klnt_lbl.setText(resBund.getString("CUSTOMERMAIL"));
        btn_plaatsFoto.setText(resBund.getString("PHOTOPLACEMENT"));
        btn_winkelwagen.setText(resBund.getString("SHOPPINGCART"));
    }

    /**
     * This method is called from within the constructor to initialize the form.
     * WARNING: Do NOT modify this code. The content of this method is always
     * regenerated by the Form Editor.
     */
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        btn_voegFotoToe = new javax.swing.JButton();
        btn_koppel = new javax.swing.JButton();
        tf_email = new javax.swing.JTextField();
        lbl_prijsWijzigen = new javax.swing.JLabel();
        tf_prijsWijzigen = new javax.swing.JTextField();
        btn_prijsWijzigen = new javax.swing.JButton();
        btn_openbaar = new javax.swing.JButton();
        klnt_lbl = new javax.swing.JLabel();
        btn_plaatsFoto = new javax.swing.JButton();
        btn_bewerkFoto = new javax.swing.JButton();
        btn_winkelwagen = new javax.swing.JButton();

        setBorder(javax.swing.BorderFactory.createTitledBorder(null, "", javax.swing.border.TitledBorder.DEFAULT_JUSTIFICATION, javax.swing.border.TitledBorder.DEFAULT_POSITION, new java.awt.Font("Tahoma", 1, 11), new java.awt.Color(0, 0, 0))); // NOI18N
        setPreferredSize(new java.awt.Dimension(514, 102));

        btn_voegFotoToe.setText("Voeg Foto's toe");
        btn_voegFotoToe.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btn_voegFotoToeActionPerformed(evt);
            }
        });

        btn_koppel.setText("Koppel klant aan foto");
        btn_koppel.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btn_koppelActionPerformed(evt);
            }
        });

        tf_email.setText("Email");
        tf_email.setSelectionColor(new java.awt.Color(50, 150, 255));
        tf_email.addMouseListener(new java.awt.event.MouseAdapter() {
            public void mouseClicked(java.awt.event.MouseEvent evt) {
                tf_emailMouseClicked(evt);
            }
        });

        lbl_prijsWijzigen.setText("Prijs:");

        tf_prijsWijzigen.setText("Prijs");
        tf_prijsWijzigen.addMouseListener(new java.awt.event.MouseAdapter() {
            public void mouseClicked(java.awt.event.MouseEvent evt) {
                tf_prijsWijzigenMouseClicked(evt);
            }
        });

        btn_prijsWijzigen.setText("Wijzig");
        btn_prijsWijzigen.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btn_prijsWijzigenActionPerformed(evt);
            }
        });

        btn_openbaar.setText("Foto's openbaren");
        btn_openbaar.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btn_openbaarActionPerformed(evt);
            }
        });

        klnt_lbl.setText("Klant Mail:");

        btn_plaatsFoto.setText("Plaats foto op product");
        btn_plaatsFoto.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btn_plaatsFotoActionPerformed(evt);
            }
        });

        btn_bewerkFoto.setText("Bewerk foto");
        btn_bewerkFoto.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btn_bewerkFotoActionPerformed(evt);
            }
        });

        btn_winkelwagen.setText("Winkelwagen");
        btn_winkelwagen.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btn_winkelwagenActionPerformed(evt);
            }
        });

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addContainerGap()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addComponent(btn_plaatsFoto)
                    .addComponent(btn_bewerkFoto)
                    .addComponent(btn_winkelwagen))
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(layout.createSequentialGroup()
                        .addGap(60, 60, 60)
                        .addComponent(btn_voegFotoToe)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                        .addComponent(btn_openbaar)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addComponent(lbl_prijsWijzigen)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                        .addComponent(tf_prijsWijzigen, javax.swing.GroupLayout.PREFERRED_SIZE, 59, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addGap(12, 12, 12))
                    .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                                .addComponent(klnt_lbl)
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                                .addComponent(tf_email, javax.swing.GroupLayout.PREFERRED_SIZE, 135, javax.swing.GroupLayout.PREFERRED_SIZE))
                            .addComponent(btn_koppel, javax.swing.GroupLayout.Alignment.TRAILING)
                            .addComponent(btn_prijsWijzigen, javax.swing.GroupLayout.Alignment.TRAILING))
                        .addContainerGap())))
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addContainerGap()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(btn_voegFotoToe)
                    .addComponent(btn_openbaar)
                    .addComponent(tf_prijsWijzigen, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(lbl_prijsWijzigen)
                    .addComponent(btn_plaatsFoto))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(btn_prijsWijzigen)
                    .addComponent(btn_bewerkFoto))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(tf_email, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(klnt_lbl)
                    .addComponent(btn_winkelwagen))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addComponent(btn_koppel))
        );
    }// </editor-fold>//GEN-END:initComponents

    private void btn_voegFotoToeActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btn_voegFotoToeActionPerformed
        System.out.println(this.panel);
        Client.getFrame().loadPanel(new AddPhotoPanel(this.panel));
    }//GEN-LAST:event_btn_voegFotoToeActionPerformed

    private void btn_openbaarActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btn_openbaarActionPerformed
        // TODO add your handling code here:
        if (panel.getMiniatuurWeergaven().getGeselecteerdeFoto() != null) {
            try {
                    Client.getServerConnection().fotoOpenbaren((int) panel.getMiniatuurWeergaven().getGeselecteerdeFoto().getFotoNummer());
                    JOptionPane.showMessageDialog(this, resBund.getString("PUBLISHEDFORMAL"), resBund.getString("PUBLISHED"), JOptionPane.INFORMATION_MESSAGE);
                } catch (RemoteException ex) {
                    Logger.getLogger(LoginPanel.class.getName()).log(Level.SEVERE, null, ex);
                }
        }
        else {
            JOptionPane.showMessageDialog(this, resBund.getString("PICTUREFIRST"), resBund.getString("ERROR"), JOptionPane.ERROR_MESSAGE);
        }
    }//GEN-LAST:event_btn_openbaarActionPerformed

    private void btn_koppelActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btn_koppelActionPerformed
        //Persoon aanmaken als deze nog niet bestaat
        if (panel.getMiniatuurWeergaven().getGeselecteerdeFoto() != null) {
            if (!tf_email.getText().equals("") && !tf_email.getText().equals(resBund.getString("EMAIL"))) {
                try {
                    String password = GeneratePassword.generateRandomPassword();
                    if (!Client.getServerConnection().klantRegistreren(tf_email.getText(), password, PersoonType.KLANT, "test", "test", getLanguageString())) {
                        JOptionPane.showMessageDialog(this, resBund.getString("EMAIL_ERRORTEXT"), resBund.getString("EMAIL_ERROR"), JOptionPane.ERROR_MESSAGE);
                    }
                } catch (RemoteException ex) {
                    Logger.getLogger(LoginPanel.class.getName()).log(Level.SEVERE, null, ex);
                }

                //foto aan klant koppelen
                try {
                    Client.getServerConnection().fotoKoppelen(tf_email.getText(), (int) panel.getMiniatuurWeergaven().getGeselecteerdeFoto().getFotoNummer());
                    JOptionPane.showMessageDialog(this, resBund.getString("LINKEDFORMAL"), resBund.getString("LINKED"), JOptionPane.INFORMATION_MESSAGE);
                } catch (RemoteException ex) {
                    Logger.getLogger(LoginPanel.class.getName()).log(Level.SEVERE, null, ex);
                }
            } else {
                JOptionPane.showMessageDialog(this, resBund.getString("VALIDEMAIL"), resBund.getString("ERROR"), JOptionPane.ERROR_MESSAGE);
            }
        } else {
            JOptionPane.showMessageDialog(this, resBund.getString("PICTUREFIRST"), resBund.getString("ERROR"), JOptionPane.ERROR_MESSAGE);
        }
    }//GEN-LAST:event_btn_koppelActionPerformed

    private void tf_emailMouseClicked(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_tf_emailMouseClicked
        if (tf_email.getText().equals(resBund.getString("EMAIL"))) {
            tf_email.setText("");
        }
    }//GEN-LAST:event_tf_emailMouseClicked

    private void btn_prijsWijzigenActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btn_prijsWijzigenActionPerformed
        double prijs = 0;
        if (tf_prijsWijzigen.getText().matches("[0-9.]+")) {
            prijs = Double.parseDouble(tf_prijsWijzigen.getText());

            Foto geselecteerdeFoto = panel.getMiniatuurWeergaven().getGeselecteerdeFoto();
            if (geselecteerdeFoto.getFotoNummer() != 0) {
                try {
                    DecimalFormat df = new DecimalFormat("#.00");
                    Double euroPrijs;

                    switch (resBund.getString("CURRENCY")) {
                        case "€":
                        Client.getServerConnection().setPrijs((int) geselecteerdeFoto.getFotoNummer(), prijs);
                        if (prijs < 1) {
                            panel.setHuidigePrijs("0" + df.format(prijs));
                        } else {
                            panel.setHuidigePrijs(df.format(prijs));
                        }
                        break;
                        case "£":
                        euroPrijs = prijs / HoofdPanel.getPondKoers();
                        Client.getServerConnection().setPrijs((int) geselecteerdeFoto.getFotoNummer(), euroPrijs);
                        if (prijs < 1) {
                            panel.setHuidigePrijs("0" + df.format(prijs));
                        } else {
                            panel.setHuidigePrijs(df.format(prijs));
                        }
                        break;
                        case "$":
                        euroPrijs = prijs / HoofdPanel.getDollarKoers();
                        Client.getServerConnection().setPrijs((int) geselecteerdeFoto.getFotoNummer(), euroPrijs);
                        if (prijs < 1) {
                            panel.setHuidigePrijs("0" + df.format(prijs));
                        } else {
                            panel.setHuidigePrijs(df.format(prijs));
                        }
                        break;
                        case "Lv":
                        euroPrijs = prijs / HoofdPanel.getLevKoers();
                        Client.getServerConnection().setPrijs((int) geselecteerdeFoto.getFotoNummer(), euroPrijs);
                        if (prijs < 1) {
                            panel.setHuidigePrijs("0" + df.format(prijs));
                        } else {
                            panel.setHuidigePrijs(df.format(prijs));
                        }
                        break;
                    }

                    JOptionPane.showMessageDialog(this, resBund.getString("PRICEEDITEDFORMAL"), resBund.getString("PRICEEDITED"), JOptionPane.INFORMATION_MESSAGE);
                } catch (RemoteException ex) {
                    Logger.getLogger(LoginPanel.class.getName()).log(Level.SEVERE, null, ex);
                }
            } else {
                JOptionPane.showMessageDialog(this, resBund.getString("PICTUREFIRST"), resBund.getString("ERROR"), JOptionPane.ERROR_MESSAGE);
            }
        } else {
            JOptionPane.showMessageDialog(this, resBund.getString("ONLYNUMBERS"), resBund.getString("ERROR"), JOptionPane.ERROR_MESSAGE);
        }
    }//GEN-LAST:event_btn_prijsWijzigenActionPerformed

    private void tf_prijsWijzigenMouseClicked(java.awt.event.MouseEvent evt) {//GEN-FIRST:event_tf_prijsWijzigenMouseClicked
        if (tf_prijsWijzigen.getText().equals(resBund.getString("PRICE"))) {
            tf_prijsWijzigen.setText("");
        }
    }//GEN-LAST:event_tf_prijsWijzigenMouseClicked

    private void btn_plaatsFotoActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btn_plaatsFotoActionPerformed
        // TODO add your handling code here:
        if (panel.getMiniatuurWeergaven().getGeselecteerdeFoto() != null) {
            panel.getMiniatuurWeergaven().getPreviewFrame().dispose();
            Client.getFrame().loadPanel(new ProductMiniaturenPanel(panel.getMiniatuurWeergaven().getGeselecteerdeFoto()));
        } else {
            JOptionPane.showMessageDialog(panel, resBund.getString("PICTUREFIRST"), resBund.getString("ERROR"), JOptionPane.ERROR_MESSAGE);
        }
    }//GEN-LAST:event_btn_plaatsFotoActionPerformed

    private void btn_bewerkFotoActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btn_bewerkFotoActionPerformed
        // TODO add your handling code here:
        if (panel.getMiniatuurWeergaven().getGeselecteerdeFoto() != null) {
            panel.getMiniatuurWeergaven().getPreviewFrame().dispose();
            Client.getFrame().loadPanel(new FotoBewerkPanel(panel.getMiniatuurWeergaven().getGeselecteerdeFoto()));
        } else {
            JOptionPane.showMessageDialog(panel, resBund.getString("PICTUREFIRST"), resBund.getString("ERROR"), JOptionPane.ERROR_MESSAGE);
        }
    }//GEN-LAST:event_btn_bewerkFotoActionPerformed

    private void btn_winkelwagenActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btn_winkelwagenActionPerformed
        // TODO add your handling code here:
        Client.getFrame().loadPanel(new WinkelwagenPanel());
    }//GEN-LAST:event_btn_winkelwagenActionPerformed

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
    
    /**
     *
     * @return
     */
    public static String getLanguageString() {
        String lang = "";
        if (Locale.getDefault().getLanguage().equals("en")) {
            lang = Locale.getDefault().getLanguage() + Locale.getDefault().getCountry();
        }
        else {
            lang = Locale.getDefault().getLanguage();
        }
        return lang;
    }
    
    private void refreshPersonenList() {
         try {
            personen = Client.getServerConnection().getPersonen();
        } catch (RemoteException ex) {
            Logger.getLogger(BFotograafHolderPanel.class.getName()).log(Level.SEVERE, null, ex);
        }
        listmodel.clear();
        for(Persoon p : personen) {
            listmodel.addElement(p.getNaam());
        }
    }
    
    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton btn_bewerkFoto;
    private javax.swing.JButton btn_koppel;
    private javax.swing.JButton btn_openbaar;
    private javax.swing.JButton btn_plaatsFoto;
    private javax.swing.JButton btn_prijsWijzigen;
    private javax.swing.JButton btn_voegFotoToe;
    private javax.swing.JButton btn_winkelwagen;
    private javax.swing.JLabel klnt_lbl;
    private javax.swing.JLabel lbl_prijsWijzigen;
    private javax.swing.JTextField tf_email;
    private javax.swing.JTextField tf_prijsWijzigen;
    // End of variables declaration//GEN-END:variables
}
