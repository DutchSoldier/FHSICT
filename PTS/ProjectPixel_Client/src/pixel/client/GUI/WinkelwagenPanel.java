/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package pixel.client.GUI;

import static java.awt.image.ImageObserver.WIDTH;
import java.rmi.RemoteException;
import java.util.Locale;
import java.util.ResourceBundle;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.swing.DefaultListModel;
import javax.swing.JOptionPane;
import pixel.client.Client;
import pixel.client.Order;
import pixel.client.Winkelwagen;

/**
 *
 * @author Remi_Arts
 */
public class WinkelwagenPanel extends javax.swing.JPanel {

    ResourceBundle resBund;
    /**
     * Creates new form WinkelwagenPanel
     */
    public WinkelwagenPanel() {
        initComponents();
        resBund = ResourceBundle.getBundle("pixel.resources.language.Language", Locale.getDefault());
        UpdateLanguage();
        
        DefaultListModel listmodel = new DefaultListModel();
        l_bestellingen.setModel(listmodel);
        for (Order o : Winkelwagen.orders) {
            listmodel.addElement(o);
        }
    }

    private void UpdateLanguage() {
        btn_terug.setText(resBund.getString("BACK"));
        btn_verwijder.setText(resBund.getString("DELETE"));
        btn_bestel.setText(resBund.getString("ORDER"));
        lb_bestel.setText(resBund.getString("ORDERS"));
    }
    /**
     * This method is called from within the constructor to initialize the form.
     * WARNING: Do NOT modify this code. The content of this method is always
     * regenerated by the Form Editor.
     */
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        jScrollPane1 = new javax.swing.JScrollPane();
        l_bestellingen = new javax.swing.JList();
        btn_bestel = new javax.swing.JButton();
        btn_verwijder = new javax.swing.JButton();
        btn_terug = new javax.swing.JButton();
        lb_bestel = new javax.swing.JLabel();

        l_bestellingen.setModel(new javax.swing.AbstractListModel() {
            String[] strings = { "Item 1", "Item 2", "Item 3", "Item 4", "Item 5" };
            public int getSize() { return strings.length; }
            public Object getElementAt(int i) { return strings[i]; }
        });
        jScrollPane1.setViewportView(l_bestellingen);

        btn_bestel.setText("Bestel");
        btn_bestel.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btn_bestelActionPerformed(evt);
            }
        });

        btn_verwijder.setText("Verwijder");
        btn_verwijder.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btn_verwijderActionPerformed(evt);
            }
        });

        btn_terug.setText("Terug");
        btn_terug.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btn_terugActionPerformed(evt);
            }
        });

        lb_bestel.setText("Bestellingen:");

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addContainerGap()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addComponent(jScrollPane1)
                    .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                        .addGap(0, 169, Short.MAX_VALUE)
                        .addComponent(btn_terug)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addComponent(btn_verwijder)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addComponent(btn_bestel))
                    .addGroup(layout.createSequentialGroup()
                        .addComponent(lb_bestel)
                        .addGap(0, 0, Short.MAX_VALUE)))
                .addContainerGap())
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addContainerGap()
                .addComponent(lb_bestel)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                .addComponent(jScrollPane1, javax.swing.GroupLayout.DEFAULT_SIZE, 143, Short.MAX_VALUE)
                .addGap(18, 18, 18)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(btn_bestel)
                    .addComponent(btn_verwijder)
                    .addComponent(btn_terug))
                .addContainerGap())
        );
    }// </editor-fold>//GEN-END:initComponents

    private void btn_bestelActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btn_bestelActionPerformed
        try {
            int factuurnummer = Client.getServerConnection().factuurToevoegen(Client.getLoggedinAccount().getEmail());
            
            for (Order o : Winkelwagen.orders) {
                //Client.getServerConnection().orderRegelToevoegen(factuurnummer, o.getProduct().getProductnummer(), o.getFoto()., WIDTH, WIDTH, WIDTH);
            }
                
        } catch (RemoteException ex) {
            Logger.getLogger(WinkelwagenPanel.class.getName()).log(Level.SEVERE, null, ex);
        }
    }//GEN-LAST:event_btn_bestelActionPerformed

    private void btn_verwijderActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btn_verwijderActionPerformed
        if (l_bestellingen.getSelectedValue() != null) {
            Order selected = (Order) l_bestellingen.getSelectedValue();
            Winkelwagen.removeOrder(selected);
            DefaultListModel model = (DefaultListModel) l_bestellingen.getModel();
            model.removeElement(selected);
        } else {
            JOptionPane.showMessageDialog(this, resBund.getString("SELECTORDER"), resBund.getString("ERROR"), JOptionPane.ERROR_MESSAGE);
        }
        
    }//GEN-LAST:event_btn_verwijderActionPerformed

    private void btn_terugActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btn_terugActionPerformed
        Client.getFrame().loadPanel(new HoofdPanel());
    }//GEN-LAST:event_btn_terugActionPerformed

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton btn_bestel;
    private javax.swing.JButton btn_terug;
    private javax.swing.JButton btn_verwijder;
    private javax.swing.JScrollPane jScrollPane1;
    private javax.swing.JList l_bestellingen;
    private javax.swing.JLabel lb_bestel;
    // End of variables declaration//GEN-END:variables
}
