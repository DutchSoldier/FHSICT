/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package pixel.shared.classes;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.Date;

/**
 *
 * @author Remi_Arts
 */
public class Factuur implements Serializable{
    private int factuurnummer;
    private String email;
    private Date datum;
    private ArrayList<OrderRegel> orderregels;

    public ArrayList<OrderRegel> getOrderregels() {
        return orderregels;
    }

    public void setOrderregels(ArrayList<OrderRegel> orderregels) {
        this.orderregels = orderregels;
    }
    
    public int getFactuurnummer() {
        return factuurnummer;
    }

    public void setFactuurnummer(int factuurnummer) {
        this.factuurnummer = factuurnummer;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public Date getDatum() {
        return datum;
    }

    public void setDatum(Date datum) {
        this.datum = datum;
    }
    
    /**
     * 
     * @param factuurnummer
     * @param email
     * @param datum 
     */
    public Factuur(int factuurnummer, String email, Date datum){
        this.factuurnummer = factuurnummer;
        this.email = email;
        this.datum = datum;
    }
}
