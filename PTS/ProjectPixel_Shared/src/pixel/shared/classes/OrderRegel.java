/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package pixel.shared.classes;

import java.io.Serializable;

/**
 *
 * @author Remi_Arts
 */
public class OrderRegel implements Serializable{

    private int fotoklantnummer;
    private int productnummer;
    private int aantal;
    private double prijs;
    private int orderregelnummer;
    private int fotobewerktnummer;
    private int factuurnummer;
    
    public int getAantal() {
        return aantal;
    }

    public int getOrderregelnummer() {
        return orderregelnummer;
    }

    public void setOrderregelnummer(int orderregelnummer) {
        this.orderregelnummer = orderregelnummer;
    }

    public int getFotobewerktnummer() {
        return fotobewerktnummer;
    }

    public void setFotobewerktnummer(int fotobewerktnummer) {
        this.fotobewerktnummer = fotobewerktnummer;
    }

    public int getFactuurnummer() {
        return factuurnummer;
    }

    public void setFactuurnummer(int factuurnummer) {
        this.factuurnummer = factuurnummer;
    }

    public double getPrijs() {
        return prijs;
    }

    public int getFotoklantnummer() {
        return fotoklantnummer;
    }

    public void setFotoklantnummer(int fotoklantnummer) {
        this.fotoklantnummer = fotoklantnummer;
    }

    public int getProductnummer() {
        return productnummer;
    }

    public void setProductnummer(int productnummer) {
        this.productnummer = productnummer;
    }
    
    /**
     * @param ordernummer
     * @param fotoklantnummer
     * @param productnummer 
     */
    public OrderRegel(int factuurnummer, int fotoklantnummer, int productnummer, int fotobewerktnummer, int orderregelnummer, int aantal, double prijs){
        this.fotoklantnummer = fotoklantnummer;
        this.factuurnummer = factuurnummer;
        this.productnummer = productnummer;
        this.aantal = aantal;
        this.orderregelnummer = orderregelnummer;
        this.fotobewerktnummer = fotobewerktnummer;
        this.prijs = prijs;
    }
}
