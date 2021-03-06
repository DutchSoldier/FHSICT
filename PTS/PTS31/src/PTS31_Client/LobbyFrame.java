/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package PTS31_Client;
import PTS31_Interfaces.IJoinableSpel;
import PTS31_Interfaces.ILobby;
import PTS31_Server.Constanten;
import PTS31_Server.Gebruiker;
import fontys.observer.RemotePropertyListener;
import java.awt.KeyEventDispatcher;
import java.awt.KeyboardFocusManager;
import java.awt.event.KeyEvent;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
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
import javax.swing.JOptionPane;

/**
 *
 * @author Simon
 */
public class LobbyFrame extends javax.swing.JFrame implements RemotePropertyListener{
    public Gebruiker gebruiker;
    ILobby lobby;
    IJoinableSpel spelToJoin;
    RemotePropertyListener rpl;
    
    /**
     * Creates new form LobbyFrame
     */
    public LobbyFrame(final Gebruiker gebruiker) throws RemoteException {
        initComponents();
        
        lbGames.addMouseListener(new MouseAdapter() {
            public void mouseClicked(MouseEvent event) {
                if(event.getClickCount() == 2) {
                    bJoinActionPerformed(null);
                }
            }
        });
        
        KeyboardFocusManager manager = KeyboardFocusManager.getCurrentKeyboardFocusManager();
        manager.addKeyEventDispatcher(new LobbyFrame.KeyDispatcher());
            
        rpl = new RemoteListener(this);
        try {
            this.lobby = (ILobby)Naming.lookup("rmi://" + Constanten.host + "/Lobby");
        } catch (NotBoundException ex) {
            Logger.getLogger(LobbyFrame.class.getName()).log(Level.SEVERE, null, ex);
        } catch (MalformedURLException ex) {
            Logger.getLogger(LobbyFrame.class.getName()).log(Level.SEVERE, null, ex);
        }
        
        lbGames.removeAll();
        ArrayList<String> games = lobby.getGameNames(rpl);
        for(String game : games)
        {
            lbGames.add(game);
        }
        lobby.getUsernames(rpl, gebruiker);
        String chatText = "";
        for (Iterator it = lobby.getChatText(rpl).iterator(); it.hasNext();) {
            String s = (String)it.next();
            chatText += s;
            if(it.hasNext()) {
                chatText += "\n";
            }
        }
        taChat.setText(chatText);
        this.gebruiker = gebruiker;
        addWindowListener(new java.awt.event.WindowAdapter() {
            @Override
            public void windowClosing(WindowEvent winEvt) {
                ((LobbyFrame)winEvt.getWindow()).cleanUp();
                System.exit(0); 
            }
        });
    }
    
    public void cleanUp() {
        try {
            lobby.leaveLobby(rpl, gebruiker.getNaam());
        } catch (RemoteException ex) {
            Logger.getLogger(LobbyFrame.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
    
    
    
    /**
     * This method is called from within the constructor to initialize the form. WARNING: Do NOT modify this code. The
     * content of this method is always regenerated by the Form Editor.
     */
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        jScrollPane3 = new javax.swing.JScrollPane();
        jList1 = new javax.swing.JList();
        bLogout = new javax.swing.JButton();
        jLabel1 = new javax.swing.JLabel();
        bJoin = new javax.swing.JButton();
        bSpectate = new javax.swing.JButton();
        bCreate = new javax.swing.JButton();
        bRatings = new javax.swing.JButton();
        jScrollPane2 = new javax.swing.JScrollPane();
        taChat = new javax.swing.JTextArea();
        tfChat = new javax.swing.JTextField();
        bSend = new javax.swing.JButton();
        lbGames = new java.awt.List();
        lbUsers = new java.awt.List();

        jList1.setModel(new javax.swing.AbstractListModel() {
            String[] strings = { "Item 1", "Item 2", "Item 3", "Item 4", "Item 5" };
            public int getSize() { return strings.length; }
            public Object getElementAt(int i) { return strings[i]; }
        });
        jScrollPane3.setViewportView(jList1);

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);

        bLogout.setText("Logout");
        bLogout.setFocusable(false);
        bLogout.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                bLogoutActionPerformed(evt);
            }
        });

        jLabel1.setText("Games:");

        bJoin.setText("Join game");
        bJoin.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                bJoinActionPerformed(evt);
            }
        });

        bSpectate.setText("Spectate game");
        bSpectate.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                bSpectateActionPerformed(evt);
            }
        });

        bCreate.setText("Create new game");
        bCreate.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                bCreateActionPerformed(evt);
            }
        });

        bRatings.setText("View ratings");
        bRatings.setFocusable(false);
        bRatings.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                bRatingsActionPerformed(evt);
            }
        });

        taChat.setEditable(false);
        taChat.setColumns(20);
        taChat.setRows(5);
        jScrollPane2.setViewportView(taChat);

        bSend.setText("Send");
        bSend.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                bSendActionPerformed(evt);
            }
        });

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addContainerGap()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(layout.createSequentialGroup()
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addGroup(layout.createSequentialGroup()
                                .addComponent(bJoin)
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                .addComponent(bSpectate))
                            .addComponent(lbGames, javax.swing.GroupLayout.PREFERRED_SIZE, 376, javax.swing.GroupLayout.PREFERRED_SIZE))
                        .addGap(21, 21, 21)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addGroup(layout.createSequentialGroup()
                                .addComponent(tfChat)
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                .addComponent(bSend))
                            .addComponent(jScrollPane2, javax.swing.GroupLayout.DEFAULT_SIZE, 286, Short.MAX_VALUE))
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addComponent(lbUsers, javax.swing.GroupLayout.PREFERRED_SIZE, 162, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addGap(12, 12, 12))
                    .addGroup(layout.createSequentialGroup()
                        .addComponent(bCreate)
                        .addGap(12, 12, 12))
                    .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                        .addComponent(jLabel1)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                        .addComponent(bRatings)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addComponent(bLogout)
                        .addContainerGap())))
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addContainerGap()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(bLogout)
                    .addComponent(jLabel1)
                    .addComponent(bRatings))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addComponent(jScrollPane2, javax.swing.GroupLayout.DEFAULT_SIZE, 337, Short.MAX_VALUE)
                    .addComponent(lbGames, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                    .addComponent(lbUsers, javax.swing.GroupLayout.Alignment.TRAILING, javax.swing.GroupLayout.DEFAULT_SIZE, 337, Short.MAX_VALUE))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addComponent(bSend)
                    .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                        .addComponent(bJoin)
                        .addComponent(bSpectate)
                        .addComponent(tfChat, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addComponent(bCreate)
                .addContainerGap())
        );

        pack();
    }// </editor-fold>//GEN-END:initComponents

    private void bSendActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_bSendActionPerformed
        // TODO add your handling code here:
                if (tfChat != null)
        {
            try {
                lobby.addChatMessage(tfChat.getText(), this.gebruiker.getNaam());
                tfChat.setText("");
            } catch (RemoteException ex) {
                Logger.getLogger(LobbyFrame.class.getName()).log(Level.SEVERE, null, ex);
            }
            tfChat.removeAll();
        }
    }//GEN-LAST:event_bSendActionPerformed

    private void bRatingsActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_bRatingsActionPerformed
        // TODO add your handling code here:
        RatingsFrame r = new RatingsFrame(gebruiker, this);
        r.setVisible(true);
        this.setVisible(false);
    }//GEN-LAST:event_bRatingsActionPerformed

    private void bCreateActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_bCreateActionPerformed
        //er komt een messagebox om de gamenaam in te vullen, daarna moet er nog een joinableSpel aangemaakt worden
        String gameNaam = JOptionPane.showInputDialog("Game name:");
        if (gameNaam != null && gameNaam.contains(" ")) {
             JOptionPane.showMessageDialog(rootPane, "De spel naam mag geen spaties bevatten.");
        }
        else {
            try {
                int i = lobby.addJoinableSpel(gameNaam, this.gebruiker);
                if(i != -1){
                    gebruiker.IsSpeler = true;
                    GameLobby gl = new GameLobby(gameNaam, gebruiker, i);
                    gl.setVisible(true);
                    lobby.leaveLobby(rpl, gebruiker.getNaam());
                    this.dispose();
                }
                else {
                    JOptionPane.showMessageDialog(rootPane, "Er bestaat al een spel met de opgegeven naam.");
                }
            } catch (RemoteException ex) {
                Logger.getLogger(LobbyFrame.class.getName()).log(Level.SEVERE, null, ex);
            }
        }
    }//GEN-LAST:event_bCreateActionPerformed

    private void bJoinActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_bJoinActionPerformed
        try {
            String gameNaam = lbGames.getSelectedItem();
            System.out.println(gameNaam);
            int i = lobby.joinGame(gameNaam, gebruiker);
            if(i != -1) {
                gebruiker.IsSpeler = true;
                GameLobby game = new GameLobby(gameNaam, gebruiker, i);
                game.setVisible(true);
                lobby.leaveLobby(rpl, gebruiker.getNaam());
                this.dispose();
            }
        } catch (RemoteException ex) {
            Logger.getLogger(LobbyFrame.class.getName()).log(Level.SEVERE, null, ex);
        }
    }//GEN-LAST:event_bJoinActionPerformed

    private void bSpectateActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_bSpectateActionPerformed
        try {
            String gameNaam = lbGames.getSelectedItem();
            System.out.println(gameNaam);
            lobby.spectateGame(gameNaam, gebruiker);
            gebruiker.IsSpeler = false;
            GameLobby game = new GameLobby(gameNaam, gebruiker, 3);
            game.setVisible(true);
            lobby.leaveLobby(rpl, gebruiker.getNaam());
            this.dispose();
        } catch (RemoteException ex) {
            Logger.getLogger(LobbyFrame.class.getName()).log(Level.SEVERE, null, ex);
        }
    }//GEN-LAST:event_bSpectateActionPerformed

    private void bLogoutActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_bLogoutActionPerformed
        cleanUp();
        StartFrame s = new StartFrame();
        s.setVisible(true);
        this.dispose();
    }//GEN-LAST:event_bLogoutActionPerformed

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton bCreate;
    private javax.swing.JButton bJoin;
    private javax.swing.JButton bLogout;
    private javax.swing.JButton bRatings;
    private javax.swing.JButton bSend;
    private javax.swing.JButton bSpectate;
    private javax.swing.JLabel jLabel1;
    private javax.swing.JList jList1;
    private javax.swing.JScrollPane jScrollPane2;
    private javax.swing.JScrollPane jScrollPane3;
    private java.awt.List lbGames;
    private java.awt.List lbUsers;
    private javax.swing.JTextArea taChat;
    private javax.swing.JTextField tfChat;
    // End of variables declaration//GEN-END:variables

    @Override
    public void propertyChange(PropertyChangeEvent pce) throws RemoteException {
        switch(pce.getPropertyName()) {
            case "Chat" :
                String chatText = "";
                for (Iterator it = ((ArrayList<String>)pce.getNewValue()).iterator(); it.hasNext();) {
                    String s = (String)it.next();
                    chatText += s;
                    if(it.hasNext()) {
                        chatText += "\n";
                    }
                }
                taChat.setText(chatText);
                break;
            case "GameNames" :
                lbGames.removeAll();
                ArrayList<String> games = (ArrayList<String>)pce.getNewValue();
                for(String game : games) {
                    lbGames.add(game);
                }
                break;
            case "UserNames" :
                lbUsers.removeAll();
                ArrayList<String> users = (ArrayList<String>)pce.getNewValue();
                for(String game : users) {
                    lbUsers.add(game);
                }
                break;
        }
    }
    public static void main(String args[]) {
        /* Set the Nimbus look and feel */
        //<editor-fold defaultstate="collapsed" desc=" Look and feel setting code (optional) ">
        /* If Nimbus (introduced in Java SE 6) is not available, stay with the default look and feel.
         * For details see http://download.oracle.com/javase/tutorial/uiswing/lookandfeel/plaf.html 
         */
        try {
            for (javax.swing.UIManager.LookAndFeelInfo info : javax.swing.UIManager.getInstalledLookAndFeels()) {
                if ("Nimbus".equals(info.getName())) {
                    javax.swing.UIManager.setLookAndFeel(info.getClassName());
                    break;
                }
            }
        } catch (ClassNotFoundException ex) {
            java.util.logging.Logger.getLogger(StartFrame.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (InstantiationException ex) {
            java.util.logging.Logger.getLogger(StartFrame.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (IllegalAccessException ex) {
            java.util.logging.Logger.getLogger(StartFrame.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (javax.swing.UnsupportedLookAndFeelException ex) {
            java.util.logging.Logger.getLogger(StartFrame.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        }
        //</editor-fold>

        /* Create and display the form */
        java.awt.EventQueue.invokeLater(new Runnable() {
            public void run() {
                try {
                    new LobbyFrame(new Gebruiker("Mitchoman", 9001)).setVisible(true);
                } catch (RemoteException ex) {
                    Logger.getLogger(LobbyFrame.class.getName()).log(Level.SEVERE, null, ex);
                }
            }
        });
    }
    
    private class KeyDispatcher implements KeyEventDispatcher 
    {
        
        @Override
        public boolean dispatchKeyEvent(KeyEvent e) 
        {
            /*if (e.getID() == KeyEvent.KEY_TYPED) 
            {
                String tekst = tfChat.getText() ;
                if (e.getKeyChar() == 8) 
                {
                    if(tekst.length() > 0 && tekst != " ") 
                    {
                        tekst = tekst.substring(0, tekst.length()-1);
                        tfChat.setText(tekst);
                    }
                }
                else 
                {    
                    tekst += e.getKeyChar();
                    tfChat.setText(tekst);
                }
            }*/
            
            if (e.getID() == KeyEvent.KEY_PRESSED) 
            {
                if (e.getKeyCode() == KeyEvent.VK_ENTER) 
                {
                    if (!tfChat.getText().isEmpty()) 
                    {
                        try 
                        {
                            lobby.addChatMessage(tfChat.getText(), gebruiker.getNaam());
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
