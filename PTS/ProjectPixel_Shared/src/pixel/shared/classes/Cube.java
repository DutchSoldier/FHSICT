/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package pixel.shared.classes;

import java.io.Serializable;
import java.util.Date;

/**
 *
 * @author Bas
 */
public class Cube implements Serializable {
    private Date time;
    private String currency;
    private Double rate;
    
    /**
     *
     */
    public Cube() {  
    }
    
    /**
     *
     * @param time
     * @param currency
     * @param rate
     */
    public Cube(Date time, String currency, Double rate) {
        this.time = time;
        this.currency = currency;
        this.rate = rate;
    }
    
    /**
     *
     * @return
     */
    public Date getTime() {
        return time;
    }
    
    /**
     *
     * @return
     */
    public String getCurrency() {
        return currency;
    }
    
    /**
     *
     * @return
     */
    public Double getRate() {
        return rate;
    }
    
    /**
     *
     * @param time
     */
    public void setTime(Date time) {
        this.time = time;
    }
    
    /**
     *
     * @param currency
     */
    public void setCurrency(String currency) {
        this.currency = currency;
    }
    
    /**
     *
     * @param rate
     */
    public void setRate(Double rate) {
        this.rate = rate;
    }
    
    @Override
    public String toString() {
        return "Cube - Currency: " + currency + " Rate: " + rate;
    }
}
