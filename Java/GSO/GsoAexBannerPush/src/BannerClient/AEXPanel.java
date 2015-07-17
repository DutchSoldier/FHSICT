/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package BannerClient;

import BannerInterfaces.IEffectenbeurs;
import BannerInterfaces.IFonds;
import BannerServer.BannerController;
import fontys.observer.RemotePropertyListener;
import java.awt.Graphics;
import java.beans.PropertyChangeEvent;
import java.net.MalformedURLException;
import java.rmi.Naming;
import java.rmi.NotBoundException;
import java.rmi.RemoteException;
import java.util.ArrayList;
import java.util.Timer;
import java.util.TimerTask;
import java.util.logging.Level;
import java.util.logging.Logger;


/**
 *
 * @author Luc
 */
public class AEXPanel extends javax.swing.JPanel implements RemotePropertyListener {
    private RemotePropertyListener rpl;
    private String koersen ="";
    private int xpos = 300;
    
    private Timer timer;
    /**
     * Creates new form AEXPanel
     */
    class update extends TimerTask {
        @Override
        public void run() {
            repaint();
        }
    }
    
    public AEXPanel() {
        initComponents();
            try {
            rpl = new RemoteListener(this);
            IEffectenbeurs beurs = (IEffectenbeurs)Naming.lookup("rmi://localhost/Beurs");
            for (IFonds f : beurs.getKoersen(rpl)) {
                koersen += f.getNaam() +": " + f.getKoers() + "   ";
            }
            
        } catch (NotBoundException | MalformedURLException | RemoteException ex) {
            Logger.getLogger(AEXPanel.class.getName()).log(Level.SEVERE, null, ex);
        } 
            
        timer = new Timer();
        timer.scheduleAtFixedRate(new AEXPanel.update(), 50, 50);
    }
    

    
    @Override
    public void propertyChange(PropertyChangeEvent pce) throws RemoteException {
        if(pce.getPropertyName().equals("Koersen")) {
            koersen = "";
            for (IFonds f : ((ArrayList<IFonds>)pce.getNewValue())) {
                koersen += f.getNaam() +": " + f.getKoers() + "   ";
            }
        }
    }
    
    @Override
    public void paintComponent(Graphics g){
        super.paintComponent(g);
        if (koersen != null) {
            g.drawString(koersen, xpos, 50);
            xpos--;
            
            if (xpos <= -koersen.length()*6 ) {
                xpos = 300;
            }
        }
    }
    
    

    /**
     * This method is called from within the constructor to initialize the form. WARNING: Do NOT modify this code. The content of this
     * method is always regenerated by the Form Editor.
     */
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGap(0, 400, Short.MAX_VALUE)
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGap(0, 300, Short.MAX_VALUE)
        );
    }// </editor-fold>//GEN-END:initComponents
    // Variables declaration - do not modify//GEN-BEGIN:variables
    // End of variables declaration//GEN-END:variables

}
