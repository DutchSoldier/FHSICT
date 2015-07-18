

import auctionwebserviceclient.AuctionWebServiceClient;
import java.sql.SQLException;
import java.util.List;
import org.junit.After;
import static org.junit.Assert.*;
import web.*;


import org.junit.Before;
import org.junit.Test;

public class JPARegistrationMgrTest {


    @Before
    public void setUp() throws Exception {
	    AuctionWebServiceClient.clean();
    }
    
    @After
    public void tearDown() throws SQLException {
    }

    @Test
    public void registerUser() {
        User user1 = AuctionWebServiceClient.registerUser("xxx1@yyy");
        assertTrue(user1.getEmail().equals("xxx1@yyy"));
        User user2 = AuctionWebServiceClient.registerUser("xxx2@yyy2");
        assertTrue(user2.getEmail().equals("xxx2@yyy2"));
        User user2bis = AuctionWebServiceClient.registerUser("xxx2@yyy2");
        assertEquals(user2bis, user2);
        //geen @ in het adres
        assertNull(AuctionWebServiceClient.registerUser("abc"));
        AuctionWebServiceClient.clean();
    }

    @Test
    public void getUser() {
        User user1 = AuctionWebServiceClient.registerUser("xxx5@yyy5");
        User userGet = AuctionWebServiceClient.getUser("xxx5@yyy5");
        assertEquals(userGet, user1);
        assertNull(AuctionWebServiceClient.getUser("aaa4@bb5"));
        AuctionWebServiceClient.registerUser("abc");
        assertNull(AuctionWebServiceClient.getUser("abc"));
        AuctionWebServiceClient.clean();
    }
}
