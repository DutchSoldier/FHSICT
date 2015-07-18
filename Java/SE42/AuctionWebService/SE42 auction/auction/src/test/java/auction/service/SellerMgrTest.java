package auction.service;

import auction.domain.Category;
import auction.domain.Item;
import auction.domain.User;
import java.sql.SQLException;
import nl.fontys.util.DatabaseCleaner;
import nl.fontys.util.Money;
import org.junit.After;
import static org.junit.Assert.*;

import org.junit.Before;
import org.junit.Test;

public class SellerMgrTest {

    private AuctionMgr auctionMgr;
    private RegistrationMgrJPA registrationMgr;
    private SellerMgr sellerMgr;

    @Before
    public void setUp() throws Exception {
        registrationMgr = new RegistrationMgrJPA();
        auctionMgr = new AuctionMgr();
        sellerMgr = new SellerMgr();
    }
    
    @After
    public void tearDown() throws SQLException {
        registrationMgr.Reset();
    }
    

    /**
     * Test of offerItem method, of class SellerMgr.
     */
    @Test
    public void testOfferItem() {
        System.out.println("*** TEST 1 ***");
        String omsch = "omsch";

        User user1 = registrationMgr.registerUser("xx@nl");
        Category cat = new Category("cat1");
        Item item1 = sellerMgr.offerItem(user1, cat, omsch);
        assertEquals(omsch, item1.getDescription());
        assertNotNull(item1.getId());
    }

    /**
     * Test of revokeItem method, of class SellerMgr.
     */
    @Test
    public void testRevokeItem() {
        System.out.println("*** TEST 2 ***");
        String omsch = "omsch";
        String omsch2 = "omsch2";
        
    
        User seller = registrationMgr.registerUser("sel@nl");
        User buyer = registrationMgr.registerUser("buy@nl");
        Category cat = new Category("cat1");
        
         int count = auctionMgr.findItemByDescription(omsch).size();
        assertEquals(0, count);
        
        // revoke before bidding
        Item item1 = sellerMgr.offerItem(seller, cat, omsch);
        boolean res = sellerMgr.revokeItem(item1);
        assertTrue(res);
         count = auctionMgr.findItemByDescription(omsch).size();
        assertEquals(0, count);
        
            // revoke after bid has been made
        Item item2 = sellerMgr.offerItem(seller, cat, omsch2);
        auctionMgr.newBid(item2, buyer, new Money(100, "Euro"));
        boolean res2 = sellerMgr.revokeItem(item2);
        assertFalse(res2);
        int count2 = auctionMgr.findItemByDescription(omsch2).size();
        assertEquals(1, count2);
    }

}
