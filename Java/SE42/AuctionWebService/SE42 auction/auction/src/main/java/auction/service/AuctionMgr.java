package auction.service;

import auction.dao.ItemDAO;
import auction.dao.ItemDAOJPAImpl;
import auction.domain.Bid;
import auction.domain.Item;
import auction.domain.User;
import java.util.ArrayList;
import java.util.List;
import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;
import nl.fontys.util.Money;

public class AuctionMgr  {
    
    private ItemDAOJPAImpl DAO;
    private final EntityManagerFactory emf = Persistence.createEntityManagerFactory("veiling");
    private EntityManager em;
    
    public AuctionMgr() {
        em = emf.createEntityManager();
        DAO = new ItemDAOJPAImpl(em);
    }

   /**
     * @param id
     * @return het item met deze id; als dit item niet bekend is wordt er null
     *         geretourneerd
     */
    public Item getItem(Long id) {
       return DAO.find(id);
    }

  
   /**
     * @param description
     * @return een lijst met items met @desciption. Eventueel lege lijst.
     */
    public List<Item> findItemByDescription(String description) {
        return DAO.findByDescription(description);
    }

    /**
     * @param item
     * @param buyer
     * @param amount
     * @return het nieuwe bod ter hoogte van amount op item door buyer, tenzij
     *         amount niet hoger was dan het laatste bod, dan null
     */
    public Bid newBid(Item item, User buyer, Money amount) {
        Bid b = item.newBid(buyer, amount);
        if(b == null) {
            return null;
        } else {
            DAO.edit(item);
            return b;
        }
    }
}
