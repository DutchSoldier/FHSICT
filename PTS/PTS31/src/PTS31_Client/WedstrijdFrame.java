/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package PTS31_Client;

import PTS31_Interfaces.IJoinableSpel;
import PTS31_Server.Constanten;
import PTS31_Server.Gebruiker;
import fontys.observer.RemotePropertyListener;
import java.applet.Applet;
import java.applet.AudioClip;
import java.awt.KeyEventDispatcher;
import java.awt.KeyboardFocusManager;
import java.awt.event.KeyEvent;
import java.awt.event.WindowEvent;
import java.awt.geom.Point2D;
import java.beans.PropertyChangeEvent;
import java.net.URL;
import java.rmi.RemoteException;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.Random;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author Luc
 */
public class WedstrijdFrame extends javax.swing.JFrame implements RemotePropertyListener {
    private class KeyDispatcher implements KeyEventDispatcher {
        
        @Override
        public boolean dispatchKeyEvent(KeyEvent e) {
            if (e.getID() == KeyEvent.KEY_PRESSED) {
                if (e.getKeyCode() == KeyEvent.VK_LEFT && spelerId != 3) {
                    direction = -1;
                    try {
                        Left = true;
                        spel.MoveSpeler(spelerId, direction);
                    } catch (RemoteException ex) {
                        Logger.getLogger(WedstrijdFrame.class.getName()).log(Level.SEVERE, null, ex);
                    }
                }
                else if (e.getKeyCode() == KeyEvent.VK_RIGHT && spelerId != 3) {
                    direction  = 1;
                    try {
                        Right = true;
                        spel.MoveSpeler(spelerId, direction);
                    } catch (RemoteException ex) {
                        Logger.getLogger(WedstrijdFrame.class.getName()).log(Level.SEVERE, null, ex);
                    }
                }
                else if (e.getKeyCode() == KeyEvent.VK_ENTER) {
                    if (!tfChat.getText().isEmpty()) {
                        try {
                            spel.addChatMessage(tfChat.getText(), gebruiker.getNaam());
                        } catch (RemoteException ex) {
                            Logger.getLogger(WedstrijdFrame.class.getName()).log(Level.SEVERE, null, ex);
                        }
                    tfChat.setText("");
                    }
                }
            }  
                
            else if (e.getID() == KeyEvent.KEY_RELEASED) {
                if (e.getKeyCode() == KeyEvent.VK_RIGHT && spelerId != 3) {
                    Right = false;
                    if(Left) {
                        direction = -1;
                    } else {
                        direction = 0;
                    }
                    try {
                        spel.MoveSpeler(spelerId, direction);
                    } catch (RemoteException ex) {
                        Logger.getLogger(WedstrijdFrame.class.getName()).log(Level.SEVERE, null, ex);
                    }
                }
                else if (e.getKeyCode() == KeyEvent.VK_LEFT && spelerId != 3) {
                    Left = false;
                    if(Right) {
                        direction = 1;
                    } else {
                        direction = 0;
                    }
                    try {
                        spel.MoveSpeler(spelerId, direction);
                    } catch (RemoteException ex) {
                        Logger.getLogger(WedstrijdFrame.class.getName()).log(Level.SEVERE, null, ex);
                    }
                }
            } 
           
            else if (e.getID() == KeyEvent.KEY_TYPED) {
                String tekst = tfChat.getText() ;
                if (e.getKeyChar() == 8) {
                    if(tekst.length() > 0) {
                        tekst = tekst.substring(0, tekst.length()-1);
                        tfChat.setText(tekst);
                    }
                }
                else {    
                    tekst += e.getKeyChar();
                    tfChat.setText(tekst);
                }
            }
            return false;
        }
    }
    
    private IJoinableSpel spel;
    private int spelerId;
    private int direction;
    public RemotePropertyListener rpl;
    private GameLobby lf;
    private Gebruiker gebruiker;
    private boolean Right;
    private boolean Left;
    private int pucktimer = 0;
    
     // sounds
    private AudioClip song;
    private ArrayList<URL> songPath = new ArrayList<URL>();
    private Random r = new Random();
    private int aantalURLs; 
    private URL soundScore;
    private URL soundLastRonde;
    private int aantalRondesGespeeld;

    public int getDirection() {
        return direction;
    }
    
    /**
     * Creates new form WedstrijdFrame
     */
    public WedstrijdFrame(int spelerId, final IJoinableSpel spel, final GameLobby lf, final Gebruiker gebruiker) {
        try {
            initComponents();
            
            try
            {
                songPath.add(new URL("file:./smw_coin.wav"));
                songPath.add(new URL("file:./smw_fireball.wav"));
                songPath.add(new URL("file:./smw_jump.wav"));
                songPath.add(new URL("file:./smw_kick.wav"));
                
                soundScore = new URL("file:./smb_stage_clear.wav");
                soundLastRonde = new URL("file:./smb_warning.wav");
                
                int aantalURLs = 4;
            }
            catch(Exception e)
            {
               //
            }
            
            this.gebruiker = gebruiker;
            this.lf = lf;
            rpl = new RemoteListener(this);

            KeyboardFocusManager manager = KeyboardFocusManager.getCurrentKeyboardFocusManager();
            manager.addKeyEventDispatcher(new KeyDispatcher());

            this.spelerId = spelerId;
            this.spel = spel;
            wedstrijdPanel.init(spelerId);

            String chatText = "";
            for (Iterator it = spel.getChatText(rpl, false).iterator(); it.hasNext();) {
                String s = (String)it.next();
                chatText += s;
                if(it.hasNext()) {
                    chatText += "\n";
                }
            }
            taChat.setText(chatText);
            lf.setVisible(false);
            addWindowListener(new java.awt.event.WindowAdapter() {
                @Override
                public void windowClosing(WindowEvent winEvt) {
                    ((WedstrijdFrame)winEvt.getWindow()).cleanUp();
                    lf.cleanUp();
                    System.exit(0); 
                }
            });
            GameLoop();
        }
        catch (RemoteException ex) {
            Logger.getLogger(WedstrijdFrame.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
    
    public void cleanUp() {
        try {
            spel.changeReadyState(false);
            spel.leaveGame(spelerId, rpl);
        } catch (RemoteException ex) {
            Logger.getLogger(GameLobby.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
    
    private void GameLoop(){
        try {
            ArrayList<Point2D.Double> spelers = spel.getSpelerLocation(rpl);
            Point2D.Double puck = spel.getPuckLocation(rpl);
            wedstrijdPanel.update(spelers, puck);
        } catch (RemoteException ex) {
            Logger.getLogger(WedstrijdFrame.class.getName()).log(Level.SEVERE, null, ex);
        }
    }         
    
    @Override
    public void propertyChange(PropertyChangeEvent pce) throws RemoteException {
        lf.setVisible(false);
        switch (pce.getPropertyName()) {
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
            case "Puck" :
                wedstrijdPanel.updatePuck((Point2D.Double)pce.getNewValue());
                if(pucktimer == 0) {
                    wedstrijdPanel.puckurl = "./smiley.png";
                }
                if((boolean)pce.getOldValue())
                {
                    pucktimer = 15;
                    wedstrijdPanel.puckurl = "./collided_smiley.png";
                    new Thread(new playingSound("collision")).start();
                }
                if(pucktimer > 0) {
                    pucktimer--;
                }
                break;
            case "Glow" :
                wedstrijdPanel.lastspeler = (int)pce.getNewValue();
                break;
            case "Speler" :
                wedstrijdPanel.updateSpelers((ArrayList<Point2D.Double>) pce.getNewValue());
                break;
            case "Scored" :
                wedstrijdPanel.scores = (int[])pce.getNewValue();
                wedstrijdPanel.rondes = 11-(int)pce.getOldValue();
                aantalRondesGespeeld++;
                
                if((Constanten.AANTAL_RONDES - 1) == aantalRondesGespeeld)
                {
                    new Thread(new playingSound("lastronde")).start();
                }
                else
                {
                    new Thread(new playingSound("scored")).start();
                }
                
                break;
        }
    }
    
    
    class playingSound implements Runnable 
    {
        int RandomInt;
        AudioClip songToPlayer;
        
        public playingSound(String toPlay) 
        {
            if(toPlay == "collision")
            {
                RandomInt = r.nextInt(songPath.size());
                songToPlayer = Applet.newAudioClip(songPath.get(RandomInt));
            }
            else if(toPlay == "scored")
            {
                songToPlayer = Applet.newAudioClip(soundScore);
            }
            else if(toPlay == "lastronde")
            {
                songToPlayer = Applet.newAudioClip(soundLastRonde);
            }
            
        }
        
        @Override
        public void run() 
        {
            songToPlayer.play();
        }
    }
    
    /**
     * This method is called from within the constructor to initialize the form. WARNING: Do NOT modify this code. The content of this
     * method is always regenerated by the Form Editor.
     */
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        jScrollPane1 = new javax.swing.JScrollPane();
        taChat = new javax.swing.JTextArea();
        wedstrijdPanel = new PTS31_Client.WedstrijdPanel();
        tfChat = new javax.swing.JTextField();

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);

        taChat.setEditable(false);
        taChat.setColumns(20);
        taChat.setRows(5);
        taChat.setFocusable(false);
        jScrollPane1.setViewportView(taChat);

        org.jdesktop.layout.GroupLayout wedstrijdPanelLayout = new org.jdesktop.layout.GroupLayout(wedstrijdPanel);
        wedstrijdPanel.setLayout(wedstrijdPanelLayout);
        wedstrijdPanelLayout.setHorizontalGroup(
            wedstrijdPanelLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
            .add(0, 590, Short.MAX_VALUE)
        );
        wedstrijdPanelLayout.setVerticalGroup(
            wedstrijdPanelLayout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
            .add(0, 0, Short.MAX_VALUE)
        );

        tfChat.setFocusable(false);

        org.jdesktop.layout.GroupLayout layout = new org.jdesktop.layout.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
            .add(layout.createSequentialGroup()
                .addContainerGap()
                .add(wedstrijdPanel, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)
                .addPreferredGap(org.jdesktop.layout.LayoutStyle.UNRELATED)
                .add(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
                    .add(jScrollPane1, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, 338, Short.MAX_VALUE)
                    .add(tfChat))
                .addContainerGap())
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
            .add(layout.createSequentialGroup()
                .addContainerGap()
                .add(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING)
                    .add(wedstrijdPanel, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                    .add(layout.createSequentialGroup()
                        .add(jScrollPane1, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, 574, Short.MAX_VALUE)
                        .addPreferredGap(org.jdesktop.layout.LayoutStyle.RELATED)
                        .add(tfChat, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE)))
                .addContainerGap())
        );

        pack();
    }// </editor-fold>//GEN-END:initComponents
    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JScrollPane jScrollPane1;
    private javax.swing.JTextArea taChat;
    private javax.swing.JTextField tfChat;
    private PTS31_Client.WedstrijdPanel wedstrijdPanel;
    // End of variables declaration//GEN-END:variables
}