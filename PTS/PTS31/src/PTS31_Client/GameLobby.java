/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package PTS31_Client;
import PTS31_Interfaces.IJoinableSpel;
import PTS31_Server.Constanten;
import PTS31_Server.Gebruiker;
import PTS31_Server.Speler;
import fontys.observer.RemotePropertyListener;
import java.awt.KeyEventDispatcher;
import java.awt.KeyboardFocusManager;
import java.awt.event.KeyEvent;
import java.awt.event.WindowEvent;
import java.beans.PropertyChangeEvent;
import java.net.MalformedURLException;
import java.rmi.Naming;
import java.rmi.NotBoundException;
import java.rmi.RemoteException;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.logging.Level;
import java.util.logging.Logger;
/**
 *
 * @author Remi_Arts
 */
public class GameLobby extends javax.swing.JFrame implements RemotePropertyListener{

    private Gebruiker gebruiker;
    private Speler speler;
    private IJoinableSpel spel;
    private RemotePropertyListener rpl;
    private int player;
    public boolean gestart;
    private WedstrijdFrame wf;
    /**
     * Creates new form GameLobby
     */

    public GameLobby(String gameNaam, final Gebruiker gebruiker, int player)  {
        initComponents();
        KeyboardFocusManager manager = KeyboardFocusManager.getCurrentKeyboardFocusManager();
        manager.addKeyEventDispatcher(new KeyDispatcher());
        this.player = player;
        try {
            this.gebruiker = gebruiker;
            rpl = new RemoteListener(this);
            spel = (IJoinableSpel)Naming.lookup("rmi://" + Constanten.host + "/" + gameNaam);
            
            /*
            ArrayList<String> gebruikers = spel.getUsernames();
            for(String gebruiker : gebruikers)
            {
                System.out.
            }
            * */
        
            String chatText = "";
            for (Iterator it = spel.getChatText(rpl, true).iterator(); it.hasNext();) {
                String s = (String)it.next();
                chatText += s;
                if(it.hasNext()) {
                    chatText += "\n";
                }
            }
            taChat.setText(chatText);
            
        } catch (NotBoundException ex) {
            Logger.getLogger(GameLobby.class.getName()).log(Level.SEVERE, null, ex);
        } catch (MalformedURLException ex) {
            Logger.getLogger(GameLobby.class.getName()).log(Level.SEVERE, null, ex);
        } catch (RemoteException ex) {
            Logger.getLogger(GameLobby.class.getName()).log(Level.SEVERE, null, ex);
        }
        Update();
        addWindowListener(new java.awt.event.WindowAdapter() {
            @Override
            public void windowClosing(WindowEvent winEvt) {
                ((GameLobby)winEvt.getWindow()).cleanUp();
                System.exit(0); 
            }
        });
    }
    
    public void cleanUp() {
        try {
            spel.changeReadyState(false);
            spel.leaveLobby(gebruiker, (player < 3), rpl, player);
        } catch (RemoteException ex) {
            Logger.getLogger(GameLobby.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    public void Update()
    {
        try {
            taChat.removeAll();
            taPlayers.removeAll();
            taSpectators.removeAll();
            String spectators = "";
            for(Iterator it = spel.getUserNames().iterator(); it.hasNext();) {
                String s = (String)it.next();
                spectators += s;
                if(it.hasNext()) {
                    spectators += "\n";
                }
            }
            taSpectators.setText(spectators);
            String players = "";
            for(Iterator it = spel.getPlayersNames().iterator(); it.hasNext();) {
                String s = (String)it.next();
                players += s;
                if(it.hasNext()) {
                    players += "\n";
                }
            }
            taPlayers.setText(players);
            if(gebruiker.IsSpeler) {
                jCheckBox1.setVisible(true);
                jCheckBox1.setEnabled(true);
            }
            else {
                jCheckBox1.setVisible(false);
                jCheckBox1.setEnabled(false);
            }
            gestart = spel.isGestart(rpl);
            if(gestart) {
                wf = new WedstrijdFrame(player, spel, this, gebruiker);
                wf.setVisible(true);
            }
        }
        /**
         * @param args the command line arguments
         */ catch (RemoteException ex) {
            Logger.getLogger(GameLobby.class.getName()).log(Level.SEVERE, null, ex);
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

        bExit = new javax.swing.JButton();
        bSend = new javax.swing.JButton();
        jLabel1 = new javax.swing.JLabel();
        jLabel2 = new javax.swing.JLabel();
        tfChat = new javax.swing.JTextField();
        jCheckBox1 = new javax.swing.JCheckBox();
        jLabel3 = new javax.swing.JLabel();
        jScrollPane5 = new javax.swing.JScrollPane();
        taSpectators = new javax.swing.JTextArea();
        jScrollPane6 = new javax.swing.JScrollPane();
        taChat = new javax.swing.JTextArea();
        jScrollPane7 = new javax.swing.JScrollPane();
        taPlayers = new javax.swing.JTextArea();

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);

        bExit.setText("Exit");
        bExit.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                bExitActionPerformed(evt);
            }
        });

        bSend.setText("Send");
        bSend.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                bSendActionPerformed(evt);
            }
        });

        jLabel1.setText("Chat:");

        jLabel2.setText("Players:");

        jCheckBox1.setText("Ready?");
        jCheckBox1.setEnabled(false);
        jCheckBox1.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jCheckBox1ActionPerformed(evt);
            }
        });

        jLabel3.setText("Spectators:");

        taSpectators.setEditable(false);
        taSpectators.setColumns(1);
        taSpectators.setRows(5);
        jScrollPane5.setViewportView(taSpectators);

        taChat.setEditable(false);
        taChat.setColumns(2);
        taChat.setRows(5);
        jScrollPane6.setViewportView(taChat);

        taPlayers.setEditable(false);
        taPlayers.setColumns(2);
        taPlayers.setRows(3);
        jScrollPane7.setViewportView(taPlayers);

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addGap(23, 23, 23)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false)
                    .addComponent(jLabel2)
                    .addGroup(layout.createSequentialGroup()
                        .addComponent(bExit)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                        .addComponent(jCheckBox1))
                    .addComponent(jLabel3)
                    .addComponent(jScrollPane7)
                    .addComponent(jScrollPane5, javax.swing.GroupLayout.DEFAULT_SIZE, 213, Short.MAX_VALUE))
                .addGap(77, 77, 77)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING, false)
                        .addGroup(layout.createSequentialGroup()
                            .addComponent(tfChat)
                            .addGap(18, 18, 18)
                            .addComponent(bSend))
                        .addComponent(jScrollPane6, javax.swing.GroupLayout.PREFERRED_SIZE, 287, javax.swing.GroupLayout.PREFERRED_SIZE))
                    .addComponent(jLabel1))
                .addContainerGap(38, Short.MAX_VALUE))
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                .addContainerGap()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(jLabel1)
                    .addComponent(jLabel2))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING, false)
                    .addGroup(javax.swing.GroupLayout.Alignment.LEADING, layout.createSequentialGroup()
                        .addComponent(jScrollPane7, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addGap(18, 18, 18)
                        .addComponent(jLabel3)
                        .addGap(18, 18, 18)
                        .addComponent(jScrollPane5))
                    .addComponent(jScrollPane6, javax.swing.GroupLayout.PREFERRED_SIZE, 366, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(tfChat, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(bSend))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(bExit)
                    .addComponent(jCheckBox1))
                .addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
        );

        pack();
    }// </editor-fold>//GEN-END:initComponents

    private void bExitActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_bExitActionPerformed
        try {
            spel.leaveLobby(gebruiker, (player < 3), rpl, player);
            if(jCheckBox1.isSelected()) {
                spel.changeReadyState(false);
            }
            LobbyFrame lf = new LobbyFrame(gebruiker);
            lf.setVisible(true);
            this.dispose();
        } catch (RemoteException ex) {
            Logger.getLogger(GameLobby.class.getName()).log(Level.SEVERE, null, ex);
        }
    }//GEN-LAST:event_bExitActionPerformed

    private void bSendActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_bSendActionPerformed
        if (!tfChat.getText().isEmpty())
        {
            try {
                spel.addChatMessage(tfChat.getText(), this.gebruiker.getNaam());
            } catch (RemoteException ex) {
                Logger.getLogger(GameLobby.class.getName()).log(Level.SEVERE, null, ex);
            }
            tfChat.setText("");
        }
    }//GEN-LAST:event_bSendActionPerformed

    private void jCheckBox1ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jCheckBox1ActionPerformed
        try {
            spel.changeReadyState(jCheckBox1.isSelected());
        } catch (RemoteException ex) {
            Logger.getLogger(GameLobby.class.getName()).log(Level.SEVERE, null, ex);
        }
    }//GEN-LAST:event_jCheckBox1ActionPerformed
    /**
     * @param args the command line arguments
     */
   
    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton bExit;
    private javax.swing.JButton bSend;
    private javax.swing.JCheckBox jCheckBox1;
    private javax.swing.JLabel jLabel1;
    private javax.swing.JLabel jLabel2;
    private javax.swing.JLabel jLabel3;
    private javax.swing.JScrollPane jScrollPane5;
    private javax.swing.JScrollPane jScrollPane6;
    private javax.swing.JScrollPane jScrollPane7;
    private javax.swing.JTextArea taChat;
    private javax.swing.JTextArea taPlayers;
    private javax.swing.JTextArea taSpectators;
    private javax.swing.JTextField tfChat;
    // End of variables declaration//GEN-END:variables

    @Override
    public void propertyChange(PropertyChangeEvent pce) throws RemoteException {
        if(pce.getPropertyName().equals("Chat")) {
            if(gestart) {
                wf.propertyChange(pce);
            } else {
                String chatText = "";
                for (Iterator it = ((ArrayList<String>)pce.getNewValue()).iterator(); it.hasNext();) {
                    String s = (String)it.next();
                    chatText += s;
                    if(it.hasNext()) {
                        chatText += "\n";
                    }
                }
                taChat.setText(chatText);
            }
        }
        else if (pce.getPropertyName().equals("spectators")) {
            taChat.removeAll();
            taPlayers.removeAll();
            taSpectators.removeAll();
            String spectators = "";
            for(Iterator it = ((ArrayList<Gebruiker>)pce.getNewValue()).iterator(); it.hasNext();) {
                Gebruiker s = (Gebruiker)it.next();
                spectators += s.getNaam();
                if(it.hasNext()) {
                    spectators += "\n";
                }
            }
            taSpectators.setText(spectators);
        }
        else if(pce.getPropertyName().equals("players")) {
            String players = "";
            for(Iterator it = ((ArrayList<Gebruiker>)pce.getNewValue()).iterator(); it.hasNext();) {
                Gebruiker s = (Gebruiker)it.next();
                players += s.getNaam();
                if(it.hasNext()) {
                    players += "\n";
                }
            }
            taPlayers.setText(players);
        }
        else if(pce.getPropertyName().equals("ready")) {
            gestart = true;
            wf = new WedstrijdFrame(player, spel, this, gebruiker);
            wf.setVisible(true);
        }
        else if(pce.getPropertyName().equals("Game Over")) {
            wf.dispose();
            LobbyFrame lf = new LobbyFrame(gebruiker);
            lf.setVisible(true);
            this.dispose();
        }
    }
    private class KeyDispatcher implements KeyEventDispatcher 
    {
        
        @Override
        public boolean dispatchKeyEvent(KeyEvent e) 
        {
            
            if (e.getID() == KeyEvent.KEY_PRESSED) 
            {
                if (e.getKeyCode() == KeyEvent.VK_ENTER) 
                {
                    if (!tfChat.getText().isEmpty()) 
                    {
                        try 
                        {
                            spel.addChatMessage(tfChat.getText(), gebruiker.getNaam());
                        } 
                        catch (RemoteException ex) 
                        {
                            Logger.getLogger(WedstrijdFrame.class.getName()).log(Level.SEVERE, null, ex);
                        }
                        tfChat.setText("");
                    }
                }
            }
            
            return false;
        }
    }

}
