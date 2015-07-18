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
import pixel.client.utils.Utils;
import pixel.shared.classes.Account;
import pixel.shared.enums.PersoonType;

/**
 * @author Frank
 */
public class LoginPanel extends javax.swing.JPanel {

    ResourceBundle resBund;
    
    /**
     * Creates new form LoginPanel
     */
    public LoginPanel() {
        initComponents();
        
        updateLanguageComboBox(0);
    }
    
    private void UpdateLanguage() {
        resBund = ResourceBundle.getBundle("pixel.resources.language.Language", Locale.getDefault());
        btn_login.setText(resBund.getString("LOGIN"));
        btn_registreren.setText(resBund.getString("REGISTER"));
        jLabel1.setText(resBund.getString("LOGINHELP"));
        lb_gebruikersnaam.setText(resBund.getString("USERNAME"));
        lb_wachtwoord.setText(resBund.getString("PASSWORD"));
        if (Client.getFrame() != null) {
            Client.getFrame().setTitle(resBund.getString("LOGINPANEL"));
        }
    }
    
    /**
     *
     * @param index
     */
    public void updateLanguageComboBox(int index) {
        this.jComboBox1.removeAllItems();
        for (Locale locale : Utils.SUPPORTED_LOCALES) {
            if (locale.getLanguage().equals("en")) {
                this.jComboBox1.addItem(locale.getDisplayLanguage(Locale.getDefault()) + " (" + locale.getCountry() + ")");
            }
            else {
                this.jComboBox1.addItem(locale.getDisplayLanguage(Locale.getDefault()));
            }
        }
        if (index != -1) {
            this.jComboBox1.setSelectedIndex(index);
        }
        UpdateLanguage();
    }

    /**
     * This method is called from within the constructor to initialize the form.
     * WARNING: Do NOT modify this code. The content of this method is always
     * regenerated by the Form Editor.
     */
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        btn_login = new javax.swing.JButton();
        tf_gebruikersnaam = new javax.swing.JTextField();
        lb_gebruikersnaam = new javax.swing.JLabel();
        lb_wachtwoord = new javax.swing.JLabel();
        tf_wachtwoord = new javax.swing.JPasswordField();
        jLabel1 = new javax.swing.JLabel();
        jComboBox1 = new javax.swing.JComboBox();
        btn_registreren = new javax.swing.JButton();

        setName("Login paneel"); // NOI18N

        btn_login.setText("Login");
        btn_login.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btn_loginActionPerformed(evt);
            }
        });

        tf_gebruikersnaam.setText("test@test.com");

        lb_gebruikersnaam.setText("Email:");

        lb_wachtwoord.setText("Wachtwoord:");

        tf_wachtwoord.setText("test");

        jLabel1.setText("Log alstublieft in met uw gebruikersnaam en wachtwoord.");

        jComboBox1.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jComboBox1ActionPerformed(evt);
            }
        });

        btn_registreren.setText("Registreren");
        btn_registreren.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btn_registrerenActionPerformed(evt);
            }
        });

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                .addContainerGap()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addComponent(jComboBox1, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(jLabel1)
                    .addGroup(layout.createSequentialGroup()
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addComponent(lb_wachtwoord)
                            .addComponent(lb_gebruikersnaam))
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addComponent(tf_gebruikersnaam, javax.swing.GroupLayout.PREFERRED_SIZE, 230, javax.swing.GroupLayout.PREFERRED_SIZE)
                            .addComponent(tf_wachtwoord, javax.swing.GroupLayout.PREFERRED_SIZE, 230, javax.swing.GroupLayout.PREFERRED_SIZE)
                            .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                                .addComponent(btn_login, javax.swing.GroupLayout.PREFERRED_SIZE, 83, javax.swing.GroupLayout.PREFERRED_SIZE)
                                .addGap(18, 18, 18)
                                .addComponent(btn_registreren)))))
                .addContainerGap(26, Short.MAX_VALUE))
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                .addContainerGap()
                .addComponent(jLabel1)
                .addGap(18, 18, 18)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(lb_gebruikersnaam)
                    .addComponent(tf_gebruikersnaam, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(lb_wachtwoord)
                    .addComponent(tf_wachtwoord, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(btn_login)
                    .addComponent(jComboBox1, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(btn_registreren))
                .addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
        );
    }// </editor-fold>//GEN-END:initComponents

    private void btn_loginActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btn_loginActionPerformed
        Account account = null;
        try {
            account = Client.getServerConnection().inloggen(tf_gebruikersnaam.getText(), Client.getServerConnection().hash(tf_wachtwoord.getText()));
        } catch (RemoteException ex) {
            Logger.getLogger(LoginPanel.class.getName()).log(Level.SEVERE, null, ex);
        }
        if (account != null) {
            
            Client.setLoggedinAccount(account);
            
            if (account.getType() == PersoonType.KLANT || account.getType() == PersoonType.FOTOGRAAF || account.getType() == PersoonType.FOTOPRODUCENT) {
                java.awt.EventQueue.invokeLater(new Runnable() {
                    @Override
                    public void run() {
                        Client.getFrame().loadPanel(new HoofdPanel());
                    }
                });
            }
        } else {
            java.awt.EventQueue.invokeLater(new Runnable() {
                @Override
                public void run() {
                    JOptionPane.showMessageDialog(null, resBund.getString("INVALIDLOG"));
                }
            });
        }
    }//GEN-LAST:event_btn_loginActionPerformed

    private void jComboBox1ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jComboBox1ActionPerformed
        int index = this.jComboBox1.getSelectedIndex();
        Locale.setDefault(Utils.SUPPORTED_LOCALES[index]);
        updateLanguageComboBox(index);
    }//GEN-LAST:event_jComboBox1ActionPerformed

    private void btn_registrerenActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btn_registrerenActionPerformed
        Client.getFrame().loadPanel(new RegisterPanel());
    }//GEN-LAST:event_btn_registrerenActionPerformed

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton btn_login;
    private javax.swing.JButton btn_registreren;
    private javax.swing.JComboBox jComboBox1;
    private javax.swing.JLabel jLabel1;
    private javax.swing.JLabel lb_gebruikersnaam;
    private javax.swing.JLabel lb_wachtwoord;
    private javax.swing.JTextField tf_gebruikersnaam;
    private javax.swing.JPasswordField tf_wachtwoord;
    // End of variables declaration//GEN-END:variables
}