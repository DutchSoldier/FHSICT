/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package Client;

import Bank.RemoteListener;
import Interfaces.IBankrekening;
import Interfaces.IDatabaseKoppeling;
import Interfaces.IKlant;
import fontys.observer.RemotePropertyListener;
import java.beans.PropertyChangeEvent;
import java.rmi.RemoteException;
import java.util.ArrayList;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.swing.JOptionPane;



/**
 *
 * @author Remi_Arts
 */
public class MainForm extends javax.swing.JFrame implements RemotePropertyListener {

    /**
     * Creates new form MainForm
     */
    private ArrayList<IBankrekening> rekeningen = new ArrayList<>();
    private IKlant klant;
    private String naam;
    private String wachtwoord;
    private IDatabaseKoppeling dbk;
    
    public MainForm(IKlant k, String Naam, String Wachtwoord, IDatabaseKoppeling Dbk) throws RemoteException {
        initComponents();
        dbk = Dbk;
        naam = Naam;
        wachtwoord = Wachtwoord;
        klant = k;
        lKlant.setText("Welkom, "+ naam);
        
        RemoteListener rpl = new RemoteListener(this);
        rekeningen = klant.GetBankRekeningen(rpl);
        
            
        for (IBankrekening br : rekeningen) {
            String s = Integer.toString(br.GetNummer());
            cbRekeningen.addItem(s);
        }
        
        for (IBankrekening br : rekeningen) {
            if(Integer.toString(br.GetNummer()).equals(cbRekeningen.getSelectedItem())) {
                lSaldo.setText(Double.toString(br.GetSaldo()));
            }
        }
    }
    
    public void RefreshInterface() {
        try {
            cbRekeningen.removeAllItems();
            for (IBankrekening br : rekeningen) {
               String s = Integer.toString(br.GetNummer());
               cbRekeningen.addItem(s);
            }
            
            for (IBankrekening br : rekeningen) {
                if(Integer.toString(br.GetNummer()).equals(cbRekeningen.getSelectedItem())) {
                    lSaldo.setText(Double.toString(br.GetSaldo()));
                }
            }
        } catch (RemoteException ex) {
            Logger.getLogger(MainForm.class.getName()).log(Level.SEVERE, null, ex);
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

        lSaldo = new javax.swing.JLabel();
        lKlant = new javax.swing.JLabel();
        tfBedrag = new javax.swing.JTextField();
        tfRekeningnummer = new javax.swing.JTextField();
        bMaakOver = new javax.swing.JButton();
        tfMededelingen = new javax.swing.JTextField();
        bUitloggen = new javax.swing.JButton();
        cbRekeningen = new javax.swing.JComboBox();
        bNieuweRekening = new javax.swing.JButton();

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);
        getContentPane().setLayout(new org.netbeans.lib.awtextra.AbsoluteLayout());

        lSaldo.setText("Saldo");
        getContentPane().add(lSaldo, new org.netbeans.lib.awtextra.AbsoluteConstraints(10, 83, 48, -1));

        lKlant.setText("Naam");
        getContentPane().add(lKlant, new org.netbeans.lib.awtextra.AbsoluteConstraints(10, 11, 329, -1));

        tfBedrag.setText("Bedrag");
        getContentPane().add(tfBedrag, new org.netbeans.lib.awtextra.AbsoluteConstraints(10, 109, 65, -1));

        tfRekeningnummer.setText("Rekeningnummer");
        getContentPane().add(tfRekeningnummer, new org.netbeans.lib.awtextra.AbsoluteConstraints(93, 109, 149, -1));

        bMaakOver.setText("Maak over");
        bMaakOver.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                bMaakOverActionPerformed(evt);
            }
        });
        getContentPane().add(bMaakOver, new org.netbeans.lib.awtextra.AbsoluteConstraints(252, 108, 87, -1));

        tfMededelingen.setText("Mededelingen");
        getContentPane().add(tfMededelingen, new org.netbeans.lib.awtextra.AbsoluteConstraints(10, 159, 232, 50));

        bUitloggen.setText("Uitloggen");
        bUitloggen.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                bUitloggenActionPerformed(evt);
            }
        });
        getContentPane().add(bUitloggen, new org.netbeans.lib.awtextra.AbsoluteConstraints(252, 187, 86, -1));

        cbRekeningen.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                cbRekeningenActionPerformed(evt);
            }
        });
        getContentPane().add(cbRekeningen, new org.netbeans.lib.awtextra.AbsoluteConstraints(10, 48, 134, -1));

        bNieuweRekening.setText("Nieuwe Rekening openen");
        bNieuweRekening.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                bNieuweRekeningActionPerformed(evt);
            }
        });
        getContentPane().add(bNieuweRekening, new org.netbeans.lib.awtextra.AbsoluteConstraints(182, 47, 157, -1));

        pack();
    }// </editor-fold>//GEN-END:initComponents

    private void bMaakOverActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_bMaakOverActionPerformed
        if (!tfBedrag.getText().isEmpty() && !tfRekeningnummer.getText().isEmpty()) {
            String message ="";
            try {
                for (IBankrekening br : rekeningen) {
                    if(Integer.toString(br.GetNummer()).equals(cbRekeningen.getSelectedItem())) {
                            message = klant.Overschrijven(Double.parseDouble(tfBedrag.getText()),  br, 
                                      Integer.parseInt(tfRekeningnummer.getText()));
                            
                            if (!message.equals("Onvoldoende saldo")) {
                            this.RefreshInterface();
                            }
                    }
                }
                JOptionPane.showMessageDialog(null, message);
            } catch (RemoteException ex) {
                Logger.getLogger(MainForm.class.getName()).log(Level.SEVERE, null, ex);
            }
        } 
    }//GEN-LAST:event_bMaakOverActionPerformed

    private void cbRekeningenActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_cbRekeningenActionPerformed
        try {
            for (IBankrekening br : rekeningen) {
                if(Integer.toString(br.GetNummer()).equals(cbRekeningen.getSelectedItem())) {
                    lSaldo.setText(Double.toString(br.GetSaldo()));
                }
            }
        } catch (RemoteException ex) {
            Logger.getLogger(MainForm.class.getName()).log(Level.SEVERE, null, ex);
        }
    }//GEN-LAST:event_cbRekeningenActionPerformed

    private void bNieuweRekeningActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_bNieuweRekeningActionPerformed
        if (JOptionPane.showConfirmDialog(null, "Nieuwe rekening maken?", "Nieuwe rekening", JOptionPane.OK_CANCEL_OPTION) == JOptionPane.OK_OPTION) {
            try {
                klant.OpenBankRekening(naam);
                this.RefreshInterface();
            } catch (RemoteException ex) {
                Logger.getLogger(MainForm.class.getName()).log(Level.SEVERE, null, ex);
            }
        }
    }//GEN-LAST:event_bNieuweRekeningActionPerformed

    private void bUitloggenActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_bUitloggenActionPerformed
        LoginForm lf = new LoginForm();
        lf.setVisible(true);
        this.dispose();
    }//GEN-LAST:event_bUitloggenActionPerformed

    @Override
    public void propertyChange(PropertyChangeEvent pce) throws RemoteException {
        if(pce.getPropertyName().equals("Saldo")) {
            System.out.println("test");
            rekeningen = (ArrayList<IBankrekening>)pce.getNewValue();
            this.RefreshInterface();
        }
    }
    
    
    
    
    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton bMaakOver;
    private javax.swing.JButton bNieuweRekening;
    private javax.swing.JButton bUitloggen;
    private javax.swing.JComboBox cbRekeningen;
    private javax.swing.JLabel lKlant;
    private javax.swing.JLabel lSaldo;
    private javax.swing.JTextField tfBedrag;
    private javax.swing.JTextField tfMededelingen;
    private javax.swing.JTextField tfRekeningnummer;
    // End of variables declaration//GEN-END:variables

    
}
