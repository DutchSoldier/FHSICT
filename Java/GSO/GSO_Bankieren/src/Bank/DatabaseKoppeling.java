/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package Bank;

import Client.LoginForm;
import Interfaces.IBankrekening;
import Interfaces.IDatabaseKoppeling;
import Interfaces.IKlant;
import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author Simon
 */
public class DatabaseKoppeling extends UnicastRemoteObject implements IDatabaseKoppeling {
    
    private Connection con;
    private String url;      
    private String username     = "root";
    private String password     = "";
    private Bank bank;
    
    public DatabaseKoppeling(Bank Bank) throws RemoteException {
        con = null;
        bank = Bank;
        
        String serverName   = "127.0.0.1";
        String portNumber   = "3306";
        String sid          = bank.getNaam();
        url                 = "jdbc:mysql://" + serverName + ":" + portNumber + "/" + sid;
    }
    
    private void openConnection() throws SQLException
    {
        con = DriverManager.getConnection(url, username, password);
    }
    
    public boolean HeeftRekeningNummer(int rekeningNummer) {
        String query = "Select * from REKENING WHERE NUMMER = "+rekeningNummer;
        try {
            this.openConnection();
            Statement s = con.createStatement();
            ResultSet rs = s.executeQuery(query);
            if (rs.next()) {
                return true;
            }
            else
            {
                return false;
            }           
        } catch (SQLException ex) {
            Logger.getLogger(DatabaseKoppeling.class.getName()).log(Level.SEVERE, null, ex);
        }
        return false;
    }
    
    @Override
    public IKlant Login(String naam, String wachtwoord) throws RemoteException {
        ArrayList<IBankrekening> rekeningen = new ArrayList<>();
        
        String query = "Select * from REKENING WHERE NUMMER = ANY (SELECT NUMMER FROM KLANTREKENING WHERE NAAM = (SELECT Naam FROM KLANT WHERE Naam = '"+naam+"' AND Wachtwoord = '"+wachtwoord+"'));";
        
        try 
        {
            this.openConnection();
            Statement s = con.createStatement();
            ResultSet rs = s.executeQuery(query);
            
            while(rs.next()) {
                rekeningen.add(new Bankrekening(rs.getInt("Nummer"), (double)rs.getFloat("Saldo")));
            } 
            
            if (rekeningen.size() > 0) {
                Klant k  = new Klant(naam, rekeningen, bank);

                return k;
            }
            else {
                return null;
            }
        }
        catch(SQLException ex) {
            Logger.getLogger(LoginForm.class.getName()).log(Level.SEVERE, null, ex);
        }
        return null;
    }

    @Override
    public boolean Registreren(String naam, String wachtwoord) throws RemoteException {
        String query = "INSERT INTO KLANT values('" + naam + "', '" + wachtwoord + "')";
        try 
        {
            this.openConnection();
            Statement s = con.createStatement();
            s.executeUpdate(query); 
            con.close();
            this.NieuweRekening(naam);
            return true;
        } 
        catch(SQLException ex) 
        {
            Logger.getLogger(LoginForm.class.getName()).log(Level.SEVERE, null, ex);
        }
        return false;
    }
    
    public boolean WijzigSaldo(int rekeningNummer, double bedrag) {
        String query = "UPDATE REKENING SET SALDO = SALDO + "+bedrag+" WHERE NUMMER ="+rekeningNummer;
        try {
            this.openConnection();
            Statement s = con.createStatement();
            s.executeUpdate(query);   
            con.close();
            return true;
        } catch (SQLException ex) {
            Logger.getLogger(DatabaseKoppeling.class.getName()).log(Level.SEVERE, null, ex);
        }
        return false; 
    }
    
    private int HoogsteRekeningnummer() {
        String query = "Select MAX(nummer) as nummer from REKENING";
        int maxNummer = 0;
        try 
        {
            this.openConnection();
            Statement s = con.createStatement();
            ResultSet rs = s.executeQuery(query);
            
            if(rs.next()) {
                maxNummer = rs.getInt("nummer");
            } 
        }
        catch(SQLException ex) {
        }
        return maxNummer;
    }
    
    public void NieuweRekening(String naam) {
        int rekeningNummer = this.HoogsteRekeningnummer() + 1;
        String query = "INSERT INTO REKENING values('" + rekeningNummer + "', '100')";
        try 
        {
            this.openConnection();
            Statement s = con.createStatement();
            s.executeUpdate(query);   
            query = "INSERT INTO KLANTREKENING values('" + rekeningNummer + "', '" + naam + "')";
            s.executeUpdate(query);  
            con.close();
        } 
        catch(SQLException ex) 
        {
        }
    }
}
