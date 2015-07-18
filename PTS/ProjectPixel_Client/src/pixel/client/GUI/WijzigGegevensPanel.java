/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package pixel.client.GUI;

import java.rmi.RemoteException;
import java.util.Locale;
import java.util.ResourceBundle;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.swing.JOptionPane;
import pixel.client.Client;
import pixel.shared.classes.Account;
import pixel.shared.classes.Persoon;
import pixel.shared.enums.PersoonType;

/**
 *
 * @author Simon
 */
public class WijzigGegevensPanel extends javax.swing.JPanel {

    ResourceBundle resBund;
    Account account;
    Persoon persoon;
    PersoonType type;
    /**
     * Creates new form WijzigGegevensPanel
     */
    public WijzigGegevensPanel(){
        initComponents();
        account = Client.getLoggedinAccount();
        cb_bFotograaf.setVisible(false);
        type = account.getType();
        try {
            persoon = Client.getServerConnection().GetPersoonsGegevens(account.getEmail());
        } catch (RemoteException ex) {
            Logger.getLogger(WijzigGegevensPanel.class.getName()).log(Level.SEVERE, null, ex);
        }
        tf_wijzigNaam.setText(persoon.getNaam());
        tf_wijzigAdres.setText(persoon.getAdres());
        if(type == PersoonType.KLANT) {
            cb_bFotograaf.setVisible(true);
        }
            
        resBund = ResourceBundle.getBundle("pixel.resources.language.Language", Locale.getDefault());
        UpdateLanguage();
    }

        private void UpdateLanguage() {
        lbl_wijzigGegevens.setText(resBund.getString("WIJZIGGEGEVENS"));
        lbl_naam.setText(resBund.getString("NAME"));
        lbl_adres.setText(resBund.getString("ADDRESS"));
        lbl_oudWachtwoord.setText(resBund.getString("OLDPASSWORD"));
        cb_bFotograaf.setText(resBund.getString("BFOTOGRAAF"));
        lbl_nieuwWachtwoord.setText(resBund.getString("NEWPASSWORD"));
        btn_save.setText(resBund.getString("SAVE"));
        btn_cancel.setText(resBund.getString("CANCEL"));
    }
    /**
     * This method is called from within the constructor to initialize the form.
     * WARNING: Do NOT modify this code. The content of this method is always
     * regenerated by the Form Editor.
     */
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        btn_cancel = new javax.swing.JButton();
        btn_save = new javax.swing.JButton();
        tf_wijzigNaam = new javax.swing.JTextField();
        tf_wijzigAdres = new javax.swing.JTextField();
        tf_nieuwWachtwoord1 = new javax.swing.JPasswordField();
        tf_nieuwWachtwoord2 = new javax.swing.JPasswordField();
        lbl_nieuwWachtwoord = new javax.swing.JLabel();
        tf_oudWachtwoord = new javax.swing.JPasswordField();
        lbl_oudWachtwoord = new javax.swing.JLabel();
        lbl_naam = new javax.swing.JLabel();
        lbl_adres = new javax.swing.JLabel();
        cb_bFotograaf = new javax.swing.JCheckBox();
        lbl_wijzigGegevens = new javax.swing.JLabel();

        btn_cancel.setText("Annuleer");
        btn_cancel.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btn_cancelActionPerformed(evt);
            }
        });

        btn_save.setText("Opslaan");
        btn_save.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btn_saveActionPerformed(evt);
            }
        });

        lbl_nieuwWachtwoord.setText("Nieuw wachtwoord:");

        lbl_oudWachtwoord.setText("Oud wachtwoord:");

        lbl_naam.setText("Naam:");

        lbl_adres.setText("Adres:");

        cb_bFotograaf.setText("Word fotograaf!");

        lbl_wijzigGegevens.setText("Wijzig persoonlijke gegevens:");

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addContainerGap()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(layout.createSequentialGroup()
                        .addComponent(btn_save)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, 186, Short.MAX_VALUE)
                        .addComponent(btn_cancel))
                    .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                                .addGap(0, 0, Short.MAX_VALUE)
                                .addComponent(lbl_nieuwWachtwoord, javax.swing.GroupLayout.PREFERRED_SIZE, 111, javax.swing.GroupLayout.PREFERRED_SIZE))
                            .addGroup(layout.createSequentialGroup()
                                .addComponent(lbl_oudWachtwoord)
                                .addGap(0, 0, Short.MAX_VALUE)))
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false)
                            .addComponent(tf_nieuwWachtwoord2, javax.swing.GroupLayout.Alignment.TRAILING, javax.swing.GroupLayout.DEFAULT_SIZE, 217, Short.MAX_VALUE)
                            .addComponent(tf_oudWachtwoord, javax.swing.GroupLayout.Alignment.TRAILING)
                            .addComponent(tf_nieuwWachtwoord1, javax.swing.GroupLayout.Alignment.TRAILING)))
                    .addGroup(layout.createSequentialGroup()
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addComponent(lbl_naam)
                            .addComponent(lbl_adres))
                        .addGap(83, 83, 83)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addComponent(tf_wijzigNaam, javax.swing.GroupLayout.Alignment.TRAILING)
                            .addComponent(tf_wijzigAdres)))
                    .addGroup(layout.createSequentialGroup()
                        .addComponent(cb_bFotograaf)
                        .addGap(0, 0, Short.MAX_VALUE))
                    .addComponent(lbl_wijzigGegevens, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
                .addContainerGap())
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                .addGap(8, 8, 8)
                .addComponent(lbl_wijzigGegevens)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(tf_wijzigNaam, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(lbl_naam))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(tf_wijzigAdres, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(lbl_adres))
                .addGap(18, 18, 18)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(tf_oudWachtwoord, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(lbl_oudWachtwoord))
                .addGap(18, 18, 18)
                .addComponent(cb_bFotograaf)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, 39, Short.MAX_VALUE)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(tf_nieuwWachtwoord1, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(lbl_nieuwWachtwoord))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addComponent(tf_nieuwWachtwoord2, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addGap(18, 18, 18)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(btn_save)
                    .addComponent(btn_cancel))
                .addContainerGap())
        );
    }// </editor-fold>//GEN-END:initComponents

    private void btn_cancelActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btn_cancelActionPerformed
        // TODO add your handling code here:
        Client.getFrame().loadPanel(new HoofdPanel());
    }//GEN-LAST:event_btn_cancelActionPerformed

    private void btn_saveActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btn_saveActionPerformed
  
        if(cb_bFotograaf.isSelected() == true){
            type = PersoonType.FOTOGRAAF;
        } else {
            type = PersoonType.KLANT;
        }
        if(!tf_nieuwWachtwoord1.getText().equals("")) {
            if(tf_nieuwWachtwoord1.getText().equals(tf_nieuwWachtwoord2.getText())){
            boolean CheckWachtwoord = false;
            try {
                CheckWachtwoord = Client.getServerConnection().checkWachtwoord(persoon.getEmail(), Client.getServerConnection().hash(tf_oudWachtwoord.getText()));
            } 
            catch (RemoteException ex) {
                Logger.getLogger(WijzigGegevensPanel.class.getName()).log(Level.SEVERE, null, ex);
            }
                if(CheckWachtwoord == true) {
                    try {
                        Client.getServerConnection().wijzigPersoonEnWachtwoord(persoon.getEmail(), tf_wijzigNaam.getText(), Client.getServerConnection().hash(tf_nieuwWachtwoord1.getText()),type, tf_wijzigAdres.getText());
                        Client.getFrame().loadPanel(new HoofdPanel());
                    } 
                    catch (RemoteException ex) {
                        Logger.getLogger(WijzigGegevensPanel.class.getName()).log(Level.SEVERE, null, ex);
                    }
                }
                if(CheckWachtwoord == false) {
                    //melding dat oude wachtwoord niet klopt
                    JOptionPane.showMessageDialog(null, resBund.getString("WRONGOLDPASSWORD"));
                }
                
            }
            else {
                //melding dat wachtwoorden niet kloppen
                JOptionPane.showMessageDialog(null, resBund.getString("WRONGNEWPASSWORD"));
            }
        }
        else {
            try {
                Client.getServerConnection().wijzigPersoon(persoon.getEmail(), tf_wijzigNaam.getText(),  type, tf_wijzigAdres.getText());
                Client.getFrame().loadPanel(new HoofdPanel());
            } 
            catch (RemoteException ex) {
                Logger.getLogger(WijzigGegevensPanel.class.getName()).log(Level.SEVERE, null, ex);
            }

        }
    }//GEN-LAST:event_btn_saveActionPerformed

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton btn_cancel;
    private javax.swing.JButton btn_save;
    private javax.swing.JCheckBox cb_bFotograaf;
    private javax.swing.JLabel lbl_adres;
    private javax.swing.JLabel lbl_naam;
    private javax.swing.JLabel lbl_nieuwWachtwoord;
    private javax.swing.JLabel lbl_oudWachtwoord;
    private javax.swing.JLabel lbl_wijzigGegevens;
    private javax.swing.JPasswordField tf_nieuwWachtwoord1;
    private javax.swing.JPasswordField tf_nieuwWachtwoord2;
    private javax.swing.JPasswordField tf_oudWachtwoord;
    private javax.swing.JTextField tf_wijzigAdres;
    private javax.swing.JTextField tf_wijzigNaam;
    // End of variables declaration//GEN-END:variables
}