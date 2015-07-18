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
public class ProductDetails  implements Serializable{

    private String productnaam;
    private String productbeschrijving;
    private int voorraad;
    private double productprijs;

    /**
     *
     * @return
     */
    public String getProductnaam() {
        return productnaam;
    }

    /**
     *
     * @return
     */
    public String getProductbeschrijving() {
        return productbeschrijving;
    }

    /**
     *
     * @return
     */
    public int getVoorraad() {
        return voorraad;
    }

    /**
     *
     * @return
     */
    public double getProductprijs() {
        return productprijs;
    }
    
    /**
     * @param productnaam
     * @param productbeschrijving
     * @param voorraad
     * @param productprijs 
     */
    public ProductDetails(String productnaam, String productbeschrijving, int voorraad, double productprijs){
        this.productbeschrijving = productbeschrijving;
        this.productnaam = productnaam;
        this.productprijs = productprijs;
        this.voorraad = voorraad;
    }  
}


