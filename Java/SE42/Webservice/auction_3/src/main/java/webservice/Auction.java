package webservice;

import auction.dao.UserDAO;
import auction.dao.UserDAOJPAImpl;
import auction.domain.Bid;
import auction.domain.Category;
import auction.domain.Item;
import auction.domain.User;
import auction.service.AuctionMgr;
import auction.service.SellerMgr;
import nl.fontys.util.Money;

import javax.jws.WebService;
import javax.persistence.EntityManager;
import javax.persistence.Persistence;
import java.util.List;

/**
 * Created by Subhi on 26-1-2015.
 */
@WebService
public class Auction {
    private AuctionMgr auctionMgr;
    private SellerMgr sellerMgr;
    EntityManager em;
    public Auction() {
        em = AuctionWebService.entityManager;

        auctionMgr = new AuctionMgr(em);
        sellerMgr = new SellerMgr(em);
    }

    public Item getItem(Long id) {
        return auctionMgr.getItem(id);
    }

    public List<Item> findItemByDescription(String description) {
        return auctionMgr.findItemByDescription(description);
    }

    public Bid newBid(Item item, User buyer, Money amount) {
        return auctionMgr.newBid(item, buyer, amount);
    }

    public Item offerItem(User seller, Category category, String description) {
        UserDAO ud = new UserDAOJPAImpl(em);
        User u = ud.findByEmail(seller.getEmail());
        return sellerMgr.offerItem(u, category, description);
    }

    public boolean revokeItem(Item item) {
        return sellerMgr.revokeItem(item);
    }
}
