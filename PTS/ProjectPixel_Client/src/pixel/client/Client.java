/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package pixel.client;

import java.rmi.NotBoundException;
import java.rmi.RemoteException;
import java.rmi.registry.LocateRegistry;
import java.rmi.registry.Registry;
import java.util.Locale;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.swing.JFrame;
import javax.swing.JOptionPane;
import javax.swing.UIManager;
import javax.swing.UnsupportedLookAndFeelException;
import pixel.client.GUI.MainFrame;
import pixel.shared.classes.Account;
import pixel.shared.classes.Constants;
import pixel.shared.interfaces.IServerCommunicator;

/**
 *
 * @author Frank
 */
public class Client {

    private static MainFrame frame;
    private static Registry registry;
    private static IServerCommunicator serverConnection;
    private static ClientCommunicator clientConnection;
    private static int clientId = -1;
    private static Account loggedinAccount;

    /**
     *
     * @return
     */
    public static MainFrame getFrame() {
        return frame;
    }

    /**
     *
     * @return
     */
    public static IServerCommunicator getServerConnection() {
        return serverConnection;
    }
    
    /**
     *
     * @return
     */
    public static int getClientId() {
        return clientId;
    }
    
    /**
     *
     * @return
     */
    public static Account getLoggedinAccount() {
        return loggedinAccount;
    }
    
    /**
     *
     * @param account
     */
    public static void setLoggedinAccount(Account account) {
        loggedinAccount = account;
    }

    /**
     *
     * @param args
     */
    public static void main(String args[]) {
        Logger.getLogger(Client.class.getName()).log(Level.INFO, "Initializing the client...");

        Thread.setDefaultUncaughtExceptionHandler(new Thread.UncaughtExceptionHandler() {
            @Override
            public void uncaughtException(Thread t, Throwable e) {
                Logger.getLogger(Client.class.getName()).log(Level.SEVERE, "A global error was caught: ", e);
            }
        });

        JFrame.setDefaultLookAndFeelDecorated(true);
        try {
            UIManager.setLookAndFeel(new org.pushingpixels.substance.api.skin.SubstanceGeminiLookAndFeel());
        } catch (UnsupportedLookAndFeelException ex) {
            Logger.getLogger(MainFrame.class.getName()).log(Level.SEVERE, null, ex);
        }

        Logger.getLogger(Client.class.getName()).log(Level.INFO, "Connecting to the server...");
        try {
            registry = LocateRegistry.getRegistry(Constants.HOST, Constants.PORT);
        } catch (RemoteException ex) {
            Logger.getLogger(Client.class.getName()).log(Level.SEVERE, null, ex);
            java.awt.EventQueue.invokeLater(new Runnable() {
                @Override
                public void run() {
                    JOptionPane.showMessageDialog(null, "Er is een fout opgetreden. Kijk of U een internet connectie heeft en probeer opnieuw.");
                }
            });
            return;
        }

        Logger.getLogger(Client.class.getName()).log(Level.INFO, "Initializing server connection...");
        try {
            serverConnection = (IServerCommunicator) registry.lookup(IServerCommunicator.class.getSimpleName());
        } catch (RemoteException | NotBoundException ex) {
            Logger.getLogger(Client.class.getName()).log(Level.SEVERE, null, ex);
            java.awt.EventQueue.invokeLater(new Runnable() {
                @Override
                public void run() {
                    JOptionPane.showMessageDialog(null, "Er is een fout opgetreden. Kijk of U een internet connectie heeft en probeer opnieuw.");
                }
            });
            return;
        }

        Logger.getLogger(Client.class.getName()).log(Level.INFO, "Initializing client communicator...");
        try {
            clientConnection = new ClientCommunicator();
        } catch (RemoteException ex) {
            Logger.getLogger(Client.class.getName()).log(Level.SEVERE, null, ex);
            java.awt.EventQueue.invokeLater(new Runnable() {
                @Override
                public void run() {
                    JOptionPane.showMessageDialog(null, "Er is een fout opgetreden.");
                }
            });
            return;
        }

        Logger.getLogger(Client.class.getName()).log(Level.INFO, "Initializing client connection...");
        try {
            clientId = serverConnection.onClientConnected(clientConnection);
        } catch (RemoteException ex) {
            Logger.getLogger(Client.class.getName()).log(Level.SEVERE, null, ex);
            java.awt.EventQueue.invokeLater(new Runnable() {
                @Override
                public void run() {
                    JOptionPane.showMessageDialog(null, "Er is een fout opgetreden.");
                }
            });
            return;
        }

        Logger.getLogger(Client.class.getName()).log(Level.INFO, "Successfully connected to the server.");

        /* Create and display the form */
        java.awt.EventQueue.invokeLater(new Runnable() {
            @Override
            public void run() {
                Locale.setDefault(new Locale("nl", "NL"));
                frame = new MainFrame();
                frame.setVisible(true);
            }
        });
    }
}
