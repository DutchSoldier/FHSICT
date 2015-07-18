/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package pixel.client;

import java.util.ArrayList;

/**
 *
 * @author Luc
 */
public class Winkelwagen {
    public static ArrayList<Order> orders = new ArrayList<>();
    
    public Winkelwagen() {
    }
    
    public static void addOrder(Order o) {
        orders.add(o);
    }  

    public static void removeOrder(Order o) {
        orders.remove(o);
    }
}
