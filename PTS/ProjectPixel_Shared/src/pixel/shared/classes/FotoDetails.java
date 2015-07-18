/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package pixel.shared.classes;

import java.io.Serializable;
import java.util.Date;

/**
 *
 * @author Luc
 */
public class FotoDetails implements Serializable {
    
    private String eigenaar;
    private double prijs;
    private Date datum;
    private int rating;
   
    /**
     *
     * @return
     */
    public int getRating() {
        return rating;
    }

    /**
     *
     * @return
     */
    public String getEigenaar() {
        return eigenaar;
    }

    /**
     *
     * @return
     */
    public double getPrijs() {
        return prijs;
    }

    /**
     *
     * @return
     */
    public Date getDatum() {
        return datum;
    }
    
    /**
     *
     * @param eigenaar
     * @param prijs
     * @param datum
     * @param rating  
     */
    public FotoDetails(String eigenaar, double prijs, Date datum, int rating) {
        this.eigenaar = eigenaar;
        this.prijs = prijs;
        this.datum = datum;    
        this.rating  = rating;
    }
}
