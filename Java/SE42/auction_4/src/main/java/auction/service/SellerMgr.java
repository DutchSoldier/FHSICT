package auction.service;

import auction.dao.ItemDAO;
import auction.dao.ItemDAOJPAImpl;
import auction.domain.*;

import javax.persistence.EntityManager;

public class SellerMgr {

    private ItemDAO itemDAO;
    
    public SellerMgr(EntityManager em) {
        itemDAO = new ItemDAOJPAImpl(em);
    }

    /**
     * @param seller
     * @param cat
     * @param description
     * @return het item aangeboden door seller, behorende tot de categorie cat
     *         en met de beschrijving description
     */
    /*
    public Item offerItem(User seller, Category cat, String description) {
        Item item = new Item(seller, cat, description);
        itemDAO.create(item);
        return item;
    }*/

    public Item offerFurniture(User seller, Category cat, String description, String material) {
        Furniture furniture = new Furniture(seller, cat, description, material);
        itemDAO.create(furniture);
        return furniture;
    }

    public Item offerPainting(User seller, Category cat, String description, String title, String painter) {
        Painting painting = new Painting(seller, cat, description, title, painter);
        itemDAO.create(painting);
        return painting;
    }
     /**
     * @param item
     * @return true als er nog niet geboden is op het item. Het item word verwijderd.
     *         false als er al geboden was op het item.
     */
    public boolean revokeItem(Item item) {
        if (item.getBids().size() == 0) {
            System.out.println("deleted");
            itemDAO.remove(item);
            return true;
        }
        System.out.println("NO!!!");
        return false;
    }
}
