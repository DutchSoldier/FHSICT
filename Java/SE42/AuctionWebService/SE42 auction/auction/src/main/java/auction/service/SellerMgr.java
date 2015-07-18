package auction.service;

import auction.dao.ItemDAOJPAImpl;
import auction.domain.Category;
import auction.domain.Item;
import auction.domain.User;
import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;

public class SellerMgr {

    
        private ItemDAOJPAImpl DAO;
    private final EntityManagerFactory emf = Persistence.createEntityManagerFactory("veiling");
    private EntityManager em;
    
    public SellerMgr() {
        em = emf.createEntityManager();
        DAO = new ItemDAOJPAImpl(em);
    }
    /**
     * @param seller
     * @param cat
     * @param description
     * @return het item aangeboden door seller, behorende tot de categorie cat
     *         en met de beschrijving description
     */
    public Item offerItem(User seller, Category cat, String description) {
        Item i = new Item(seller, cat, description);
        DAO.create(i);
        return i;
    }
    
     /**
     * @param item
     * @return true als er nog niet geboden is op het item. Het item word verwijderd.
     *         false als er al geboden was op het item.
     */
    public boolean revokeItem(Item item) {
      //  Item i = DAO.find(item.getId());
        if(item.getHighestBid() == null) {
            DAO.remove(item);
            return true;
        } else {
            return false;
        }
    }
}
