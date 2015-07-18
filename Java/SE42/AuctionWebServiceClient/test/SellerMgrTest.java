

import auctionwebserviceclient.AuctionWebServiceClient;
import java.sql.SQLException;
import org.junit.After;
import static org.junit.Assert.*;

import web.*;

import org.junit.Before;
import org.junit.Test;

public class SellerMgrTest {

    @Before
    public void setUp() throws Exception {
	AuctionWebServiceClient.clean();
    }
    
    @After
    public void tearDown() throws SQLException {
    }
    

    /**
     * Test of offerItem method, of class SellerMgr.
     */
    @Test
    public void testOfferItem() {
        System.out.println("*** TEST 1 ***");
        String omsch = "omsch";

        User user1 = AuctionWebServiceClient.registerUser("xx@nl");
	Category cat = new Category();
	cat.setDescription("cat1");
        Item item1 = AuctionWebServiceClient.offerItem(user1, cat, omsch);
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
        
    
        User seller = AuctionWebServiceClient.registerUser("sel@nl");
        User buyer = AuctionWebServiceClient.registerUser("buy@nl");
        Category cat = new Category();
	cat.setDescription("cat1");
        
         int count = AuctionWebServiceClient.findItemByDescription(omsch).size();
        assertEquals(0, count);
        
        // revoke before bidding
        Item item1 = AuctionWebServiceClient.offerItem(seller, cat, omsch);
        boolean res = AuctionWebServiceClient.revokeItem(item1);
        assertTrue(res);
         count = AuctionWebServiceClient.findItemByDescription(omsch).size();
        assertEquals(0, count);
        
            // revoke after bid has been made
        Item item2 = AuctionWebServiceClient.offerItem(seller, cat, omsch2);
	Money m = new Money();
	m.setCents(100);
	m.setCurrency("Euro");
        AuctionWebServiceClient.newBid(item2, buyer, m);
	item2 = AuctionWebServiceClient.getItem(item2.getId());
        boolean res2 = AuctionWebServiceClient.revokeItem(item2);
        assertFalse(res2);
        int count2 = AuctionWebServiceClient.findItemByDescription(omsch2).size();
        assertEquals(1, count2);
    }

}
