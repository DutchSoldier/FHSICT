package bank.server;

import java.rmi.*;
import java.io.*;
import java.util.*;

import java.util.logging.Level;
import java.util.logging.Logger;
import javax.swing.*;

import bank.bankieren.*;
import bank.internettoegang.Balie;
import bank.internettoegang.IBalie;

public class BalieserverApplicatie extends JFrame {

    private static final long serialVersionUID = 3719045408845525383L;
    private String nameBank;

    public BalieserverApplicatie(String nameBank) {
        {
            FileOutputStream out = null;
            try {
                this.nameBank = nameBank;
                String address = java.net.InetAddress.getLocalHost().getHostAddress();
                int port = 1099;
                Properties props = new Properties();
                String rmiBalie = address + ":" + port + "/" + nameBank;
                props.setProperty("balie", rmiBalie);
                out = new FileOutputStream(nameBank + ".props");
                props.store(out, null);
                out.close();
                java.rmi.registry.LocateRegistry.createRegistry(port);
                IBalie balie = new Balie(new Bank(nameBank));
                Naming.rebind(nameBank, balie);
                System.out.println("counter of bank bound as " + nameBank);
                init();
            } catch (IOException ex) {
                Logger.getLogger(BalieserverApplicatie.class.getName()).log(Level.SEVERE, null, ex);
            } finally {
                try {
                    out.close();
                } catch (IOException ex) {
                    Logger.getLogger(BalieserverApplicatie.class.getName()).log(Level.SEVERE, null, ex);
                }
            }
        }


    }

    private void init() {
        setSize(250, 0);
        setTitle(nameBank + "balie is geopend");
        setVisible(true);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
    }

    public static void main(String[] arg) {
        new BalieserverApplicatie("test");
    }
}
