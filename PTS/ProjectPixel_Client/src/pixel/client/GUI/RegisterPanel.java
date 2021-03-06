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
import javax.swing.*;
import pixel.client.Client;
import pixel.client.GeneratePassword;
import pixel.shared.enums.FotograafType;
import pixel.shared.enums.PersoonType;

/**
 *
 * @author Frank
 */
public class RegisterPanel extends javax.swing.JPanel {

    ResourceBundle resBund;

    /**
     * Creates new form RegisterPanel
     */
    public RegisterPanel() {
        initComponents();

        resBund = ResourceBundle.getBundle("pixel.resources.language.Language", Locale.getDefault());
        UpdateLanguage();
    }

    private void UpdateLanguage() {
        btn_cancelFotograaf.setText(resBund.getString("CANCEL"));
        btn_registreerFotograaf.setText(resBund.getString("REGISTER"));
        lb_adresFotograaf.setText(resBund.getString("ADDRESS"));
        lb_emailFotograaf.setText(resBund.getString("EMAIL"));
        lb_naamFotograaf.setText(resBund.getString("NAME"));
        lb_registerPanel.setText(resBund.getString("REGISTERHELP"));
    }

    /**
     * This method is called from within the constructor to initialize the form.
     * WARNING: Do NOT modify this code. The content of this method is always
     * regenerated by the Form Editor.
     */
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        tf_emailFotograaf = new javax.swing.JTextField();
        btn_registreerFotograaf = new javax.swing.JButton();
        lb_emailFotograaf = new javax.swing.JLabel();
        lb_registerPanel = new javax.swing.JLabel();
        tf_naamFotograaf = new javax.swing.JTextField();
        tf_adresFotograaf = new javax.swing.JTextField();
        lb_naamFotograaf = new javax.swing.JLabel();
        lb_adresFotograaf = new javax.swing.JLabel();
        btn_cancelFotograaf = new javax.swing.JButton();

        btn_registreerFotograaf.setText("Registreer");
        btn_registreerFotograaf.setToolTipText("");
        btn_registreerFotograaf.setName(""); // NOI18N
        btn_registreerFotograaf.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btn_registreerFotograafActionPerformed(evt);
            }
        });

        lb_emailFotograaf.setText("Email:");

        lb_registerPanel.setText("Registreer hier een fotograaf.");

        lb_naamFotograaf.setText("Naam:");

        lb_adresFotograaf.setText("Adres:");

        btn_cancelFotograaf.setText("Terug");
        btn_cancelFotograaf.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btn_cancelFotograafActionPerformed(evt);
            }
        });

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addContainerGap()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(layout.createSequentialGroup()
                        .addComponent(lb_registerPanel)
                        .addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
                    .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING)
                            .addGroup(layout.createSequentialGroup()
                                .addComponent(btn_cancelFotograaf)
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                                .addComponent(btn_registreerFotograaf))
                            .addGroup(javax.swing.GroupLayout.Alignment.LEADING, layout.createSequentialGroup()
                                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                                    .addComponent(lb_emailFotograaf)
                                    .addComponent(lb_adresFotograaf)
                                    .addComponent(lb_naamFotograaf))
                                .addGap(37, 37, 37)
                                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                                    .addComponent(tf_emailFotograaf, javax.swing.GroupLayout.Alignment.TRAILING, javax.swing.GroupLayout.DEFAULT_SIZE, 372, Short.MAX_VALUE)
                                    .addComponent(tf_adresFotograaf, javax.swing.GroupLayout.Alignment.TRAILING)
                                    .addComponent(tf_naamFotograaf))))
                        .addGap(17, 17, 17))))
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addContainerGap()
                .addComponent(lb_registerPanel)
                .addGap(18, 18, 18)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(lb_emailFotograaf)
                    .addComponent(tf_emailFotograaf, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addComponent(tf_naamFotograaf, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(lb_naamFotograaf))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addComponent(tf_adresFotograaf, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(lb_adresFotograaf))
                .addGap(18, 18, 18)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(btn_registreerFotograaf)
                    .addComponent(btn_cancelFotograaf))
                .addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
        );
    }// </editor-fold>//GEN-END:initComponents

    private void btn_registreerFotograafActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btn_registreerFotograafActionPerformed
        String email = tf_emailFotograaf.getText();
        String password = GeneratePassword.generateRandomPassword();
        PersoonType type = PersoonType.valueOf("FOTOGRAAF");
        String naam = tf_naamFotograaf.getText();
        String adres = tf_adresFotograaf.getText();
        FotograafType fotograafType = FotograafType.B;
        if (Client.getLoggedinAccount() != null) {
            fotograafType = FotograafType.A;
        }
        if (!tf_emailFotograaf.getText().equals("")) {
            if (!tf_naamFotograaf.getText().equals("")) {
                if (!tf_adresFotograaf.getText().equals("")) {
                    try {
                        if (!Client.getServerConnection().registreren(email, password, type, naam, adres, fotograafType, FotograafHolderPanel.getLanguageString())) {
                            JOptionPane.showMessageDialog(this, resBund.getString("EMAIL_ERRORTEXT"), resBund.getString("EMAIL_ERROR"), JOptionPane.ERROR);
                        }
                    } catch (RemoteException ex) {
                        Logger.getLogger(RegisterPanel.class.getName()).log(Level.SEVERE, null, ex);
                    }
                    if (Client.getLoggedinAccount() != null) {
                        Client.getFrame().loadPanel(new HoofdPanel());
                    } else {
                        Client.getFrame().loadPanel(new LoginPanel());
                    }
                } else {
                    JOptionPane.showMessageDialog(null, resBund.getString("ENTERALL"));
                }
            } else {
                JOptionPane.showMessageDialog(null, resBund.getString("ENTERALL"));
            }
        } else {
            JOptionPane.showMessageDialog(null, resBund.getString("ENTERALL"));
        }

    }//GEN-LAST:event_btn_registreerFotograafActionPerformed

    private void btn_cancelFotograafActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btn_cancelFotograafActionPerformed
        if (Client.getLoggedinAccount() != null) {
            Client.getFrame().loadPanel(new HoofdPanel());
        } else {
            Client.getFrame().loadPanel(new LoginPanel());
        }
    }//GEN-LAST:event_btn_cancelFotograafActionPerformed

    @Override
    public void removeNotify() {
        super.removeNotify();
    }
    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton btn_cancelFotograaf;
    private javax.swing.JButton btn_registreerFotograaf;
    private javax.swing.JLabel lb_adresFotograaf;
    private javax.swing.JLabel lb_emailFotograaf;
    private javax.swing.JLabel lb_naamFotograaf;
    private javax.swing.JLabel lb_registerPanel;
    private javax.swing.JTextField tf_adresFotograaf;
    private javax.swing.JTextField tf_emailFotograaf;
    private javax.swing.JTextField tf_naamFotograaf;
    // End of variables declaration//GEN-END:variables
}
