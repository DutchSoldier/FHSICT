/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package stamboom;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.GregorianCalendar;
/**
 *
 * @author Remi_Arts
 */
public class DatabaseKoppeling{
    String host = "jdbc:derby://localhost:1527/Stamboom [ on APP]";
    String uName = "";
    String uPass= "";
    Administratie a = new Administratie();
    
    public void addGezin(int nr, int ouder1, int ouder2, GregorianCalendar huwelijk, GregorianCalendar scheiding)
    {
        
        
        try
        {
            Connection con = DriverManager.getConnection(host, uName, uPass);

            Statement s = con.createStatement();
            String query = "Insert into Gezin Values(" + nr + ", " + ouder1 + ", " + ouder2 + ", " + huwelijk + ", " + scheiding + ")";
            s.executeUpdate(query);
        }
    
        catch(SQLException err)
        {
            System.out.println(err.getMessage());
        }
    }
    
    public void addPersoon(int nr, String achternaam, String voornaam, String tussenvoegsel, GregorianCalendar gebdat, String geslacht, int gezinnr)
    {
        
        
        try
        {
            Connection con = DriverManager.getConnection(host, uName, uPass);

            Statement s = con.createStatement();
            String query = "Insert into Persoon Values(" + nr + ", '" + achternaam + "', '" + voornaam + "', '" + tussenvoegsel + "', " + gebdat + ", '" + geslacht +"', "+ gezinnr +")";
            s.executeUpdate(query);
        }
    
        catch(SQLException err)
        {
            System.out.println(err.getMessage());
        }
    }
    
    public void getPersonen()
    {
        try
        {
            Connection con = DriverManager.getConnection(host, uName, uPass);

            Statement s = con.createStatement();
            String query = "Select * From Persoon";
            s.executeQuery(query);
        }
    
        catch(SQLException err)
        {
            System.out.println(err.getMessage());
        }
    }
    
    public void getGezinnen()
    {
        try
        {
            Connection con = DriverManager.getConnection(host, uName, uPass);

            Statement s = con.createStatement();
            String query = "Select * From Gezin";
            s.executeQuery(query);
        }
    
        catch(SQLException err)
        {
            System.out.println(err.getMessage());
        }
    }
}
