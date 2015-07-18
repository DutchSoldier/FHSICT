/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package pixel.client;

import pixel.shared.classes.Foto;
import pixel.shared.classes.Product;

/**
 *
 * @author Luc
 */
public class Order {
    private Foto foto;
    private Product product;
    
    public Order (Foto foto, Product product) {
        this.foto = foto;
        this.product = product;
    }
    
    public Foto getFoto() {
        return foto;
    }
    
    public Product getProduct() {
        return product;
    }
    
    @Override
    public String toString() {
        return foto.getFotoNummer() + " " +  product.getProductnaam();
    }
}
