/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package gui;

import java.util.Iterator;
import stamboom.Administratie;
import stamboom.Gezin;
import stamboom.Persoon;
import stamboom.DatabaseKoppeling;
/**
 *
 * @author Luc
 */
public class PersoonAanmeldDialog extends javax.swing.JDialog {

    private Administratie administratie;
    DatabaseKoppeling dk = new DatabaseKoppeling();
    /**
     * Creates new form PersoonAanmeldDialog
     */
    public PersoonAanmeldDialog(java.awt.Frame parent, boolean modal, Administratie administratie) {
        super(parent, modal);
        this.setModal(true);
        this.administratie = administratie;
        initComponents();
        
        cbOuderlijkGezin.setVisible(false);
        lbOuderlijkGezin.setText("");
        
        cbOuder.removeAllItems();
        cbOuder.addItem("onbekend");
        for (Persoon p : administratie.getPersonen())
        {
            cbOuder.addItem(p);
        }
    }

    /**
     * This method is called from within the constructor to initialize the form. WARNING: Do NOT modify this code. The content of this
     * method is always regenerated by the Form Editor.
     */
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        persoonPanel2 = new gui.PersoonPanel();
        cbOuder = new javax.swing.JComboBox();
        cbOuderlijkGezin = new javax.swing.JComboBox();
        lbOuder = new javax.swing.JLabel();
        lbOuderlijkGezin = new javax.swing.JLabel();
        btnConfirm = new javax.swing.JButton();

        setDefaultCloseOperation(javax.swing.WindowConstants.DISPOSE_ON_CLOSE);

        cbOuder.setModel(new javax.swing.DefaultComboBoxModel(new String[] { "Item 1", "Item 2", "Item 3", "Item 4" }));
        cbOuder.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                cbOuderActionPerformed(evt);
            }
        });

        cbOuderlijkGezin.setModel(new javax.swing.DefaultComboBoxModel(new String[] { "Item 1", "Item 2", "Item 3", "Item 4" }));

        lbOuder.setText("Ouder");

        lbOuderlijkGezin.setText("Ouderlijk Gezin");

        btnConfirm.setText("Bevestig");
        btnConfirm.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btnConfirmActionPerformed(evt);
            }
        });

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                .addGap(0, 0, Short.MAX_VALUE)
                .addComponent(persoonPanel2, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
            .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(layout.createSequentialGroup()
                        .addGap(22, 22, 22)
                        .addComponent(lbOuder))
                    .addGroup(layout.createSequentialGroup()
                        .addGap(21, 21, 21)
                        .addComponent(lbOuderlijkGezin)))
                .addGap(18, 18, Short.MAX_VALUE)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false)
                    .addComponent(btnConfirm, javax.swing.GroupLayout.DEFAULT_SIZE, 272, Short.MAX_VALUE)
                    .addComponent(cbOuderlijkGezin, javax.swing.GroupLayout.Alignment.TRAILING, 0, 272, Short.MAX_VALUE)
                    .addComponent(cbOuder, javax.swing.GroupLayout.Alignment.TRAILING, 0, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
                .addGap(21, 21, 21))
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addComponent(persoonPanel2, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addGap(18, 18, 18)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(cbOuder, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(lbOuder))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(cbOuderlijkGezin, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(lbOuderlijkGezin))
                .addGap(18, 18, 18)
                .addComponent(btnConfirm)
                .addGap(0, 67, Short.MAX_VALUE))
        );

        pack();
    }// </editor-fold>//GEN-END:initComponents

    private void cbOuderActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_cbOuderActionPerformed
        if (cbOuder.getSelectedItem() != null && !cbOuder.getSelectedItem().equals("onbekend") )
        {
            cbOuderlijkGezin.removeAllItems();
            lbOuderlijkGezin.setText("Ouderlijk gezin");
                            
            Persoon persoon = (Persoon)cbOuder.getSelectedItem();
            Iterator<Gezin> g = persoon.getGezinnen();
            
            while (g.hasNext())
            {
                cbOuderlijkGezin.addItem(g.next());
            }
            if (cbOuderlijkGezin.getItemCount() == 0)
            {
                cbOuderlijkGezin.addItem("onbekend");
            }
            cbOuderlijkGezin.setVisible(true);
        }
        else
        {
            cbOuderlijkGezin.setVisible(false);
            lbOuderlijkGezin.setText("");
        }
    }//GEN-LAST:event_cbOuderActionPerformed

    private void btnConfirmActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btnConfirmActionPerformed
        Gezin g = null;
        if (cbOuder.getSelectedItem() != null && !cbOuder.getSelectedItem().equals("onbekend"))
        {
            if (cbOuderlijkGezin.getSelectedItem() != null && !cbOuderlijkGezin.getSelectedItem().equals("onbekend"))
            {
                g = (Gezin) cbOuderlijkGezin.getSelectedItem();
            }
        } 
        administratie.addPersoon(persoonPanel2.getGeslacht(), persoonPanel2.getVoornamen(), persoonPanel2.getAchternaam(), persoonPanel2.getTussenvoegsel(), persoonPanel2.getGebDat(), g);
        dk.addPersoon( persoonPanel2.getNr() ,persoonPanel2.getAchternaam(), persoonPanel2.getVoornamen().toString(), persoonPanel2.getTussenvoegsel(), persoonPanel2.getGebDat(),persoonPanel2.getGeslacht().toString(), g.getNr());
        this.dispose();
    }//GEN-LAST:event_btnConfirmActionPerformed

    
    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton btnConfirm;
    private javax.swing.JComboBox cbOuder;
    private javax.swing.JComboBox cbOuderlijkGezin;
    private javax.swing.JLabel lbOuder;
    private javax.swing.JLabel lbOuderlijkGezin;
    private gui.PersoonPanel persoonPanel2;
    // End of variables declaration//GEN-END:variables
}
