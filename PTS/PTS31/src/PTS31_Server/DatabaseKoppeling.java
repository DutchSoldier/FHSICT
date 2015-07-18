/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package PTS31_Server;

import PTS31_Client.StartFrame;
import PTS31_Interfaces.IDatabase;
import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;
import java.sql.*;
import java.util.ArrayList;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author Simon
 */
public class DatabaseKoppeling extends UnicastRemoteObject implements IDatabase {
    Connection con;
    String serverName   = "127.0.0.1";
    String portNumber   = "3306";
    String sid          = "pts";
    String url          = "jdbc:mysql://" + serverName + ":" + portNumber + "/" + sid;
    String username     = "root"; // root";
    String password     = ""; //"";
    Lobby2 lobby;
    
    public DatabaseKoppeling(Lobby2 lobby) throws RemoteException {
        this.lobby = lobby;
        con = null;
    }
    
    private void openConnection() throws SQLException
    {
        con = DriverManager.getConnection(url, username, password);
    }
 
    @Override
    public void register(String username, String wachtwoord) throws RemoteException 
    {
        String query = "INSERT INTO SPELER values('" + username + "', '" + wachtwoord + "', 100)";
        try 
        {
            this.openConnection();
            Statement s = con.createStatement();
            s.executeUpdate(query);   
            con.close();
        } 
        catch(SQLException ex) 
        {
            Logger.getLogger(StartFrame.class.getName()).log(Level.SEVERE, null, ex);
            throw new RemoteException("register fail");
        }
    }
    
    @Override
    public boolean checkUsername(String username) throws RemoteException 
    {
        String query = "SELECT Naam AS username FROM SPELER WHERE Naam = '" + username + "' LIMIT 1";
        //System.out.println(query);
        boolean returnBool = true;
        try 
        {
            this.openConnection();
            Statement s = con.createStatement();
            ResultSet rs = s.executeQuery(query);
            if(rs.next()) 
            {
                System.out.println(rs.getString(1));
                returnBool = false;
            }
            con.close();
        } 
        catch(SQLException ex) 
        {
            Logger.getLogger(StartFrame.class.getName()).log(Level.SEVERE, null, ex);
        }
        return returnBool;
    }
    
    @Override
    public Gebruiker login(String username, String wachtwoord) throws RemoteException 
    {
        
        int rating = 0;
        String query = "SELECT Rating FROM SPELER WHERE Naam = '" + username + "' AND Wachtwoord = '" + wachtwoord + "' LIMIT 1";
        try 
        {
            this.openConnection();
            Statement s = con.createStatement();
            ResultSet rs = s.executeQuery(query);
            
            if(rs.next()) 
            {
                rating = rs.getInt(1);
                Gebruiker g = new Gebruiker(username, rating);
                for(String a : lobby.getUsernames()) {
                    if(a.equals(g.getNaam())) {
                        return null;
                    }
                }
                for(JoinableSpel j : lobby.spellen) {
                    for(Gebruiker t : j.getToeschouwers()) {
                        if(t.getNaam().equals(g.getNaam())) {
                            return null;
                        }
                    }
                    for(Gebruiker t : j.getSpelers()) {
                        if(t.getNaam().equals(g.getNaam())) {
                            return null;
                        }
                    }
                }
                return g;
            }
            
            con.close();
        } 
        catch(SQLException ex) 
        {
            Logger.getLogger(StartFrame.class.getName()).log(Level.SEVERE, null, ex);
        }
        return null;
    }
    
    public int getRating(String username) {
        int rating = 0;
        String query = "SELECT Rating AS RATING FROM SPELER WHERE Naam = '" + username + "' LIMIT 1";
        try 
        {
            this.openConnection();
            Statement s = con.createStatement();
            ResultSet rs = s.executeQuery(query);
            if(rs.next()) 
            {
               rating = rs.getInt(1); 
            }
            con.close();
        } 
        catch(SQLException ex) 
        {
            Logger.getLogger(StartFrame.class.getName()).log(Level.SEVERE, null, ex);     
        } 
        finally 
        {
            return rating;
        }
    }
    
    @Override
    public ArrayList<String> getTopRating() throws RemoteException{
        ArrayList<String> result = new ArrayList<>();
        String query = "SELECT Naam, Rating FROM SPELER ORDER BY RATING DESC LIMIT 0 , 10";
        try
        {
            this.openConnection();
            Statement s = con.createStatement();
            ResultSet rs = s.executeQuery(query);
            while(rs.next()) 
            {
                String temp = rs.getString("NAAM") +" \t"+ rs.getInt("Rating");
                result.add(temp);
            }
        }
        catch(SQLException ex) 
        {
            Logger.getLogger(StartFrame.class.getName()).log(Level.SEVERE, null, ex);     
        } 
        finally 
        {
            return result;
        }
        
    }
    
    public void setRating(String username, int rating) 
    {
        String query = "UPDATE SPELER SET Rating = " + rating + " WHERE Naam = '" + username + "'";
        try 
        {
            this.openConnection();
            Statement s = con.createStatement();
            s.executeUpdate(query);       
            con.close();
        } 
        catch(SQLException ex) 
        {
            Logger.getLogger(StartFrame.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    @Override
    public ArrayList<Gebruiker> searchGebruiker(String zoekopdracht) throws RemoteException 
    {
        ArrayList<Gebruiker> gevondenResultaten = new ArrayList<Gebruiker>();
        
        String query = "SELECT Naam, Rating FROM SPELER WHERE Naam LIKE '%" + zoekopdracht + "%' LIMIT 30";
        try
        {
            this.openConnection();
            Statement s = con.createStatement();
            ResultSet rs = s.executeQuery(query);
            
            while(rs.next())
            {
                if(rs.getString("Naam") != null)
                {
                    gevondenResultaten.add(new Gebruiker(rs.getString("Naam"), rs.getInt("Rating")));
                }                
            }
            
            con.close();
        }
        catch(SQLException ex)
        {
            Logger.getLogger(StartFrame.class.getName()).log(Level.SEVERE, null, ex);
        }
        
        return gevondenResultaten;
    }
}
