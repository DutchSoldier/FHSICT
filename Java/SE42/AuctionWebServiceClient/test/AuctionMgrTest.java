
import auctionwebserviceclient.AuctionWebServiceClient;
import java.sql.SQLException;
import java.util.ArrayList;
import org.junit.After;
import static org.junit.Assert.*;

import org.junit.Before;
import org.junit.Test;

import web.*;

public class AuctionMgrTest {

	@Before
	public void setUp() throws Exception {
		AuctionWebServiceClient.clean();
	}

	@After
	public void tearDown() throws SQLException {
		AuctionWebServiceClient.clean();
	}

	@Test
	public void getItem() {

		String email = "xx2@nl";
		String omsch = "omsch";

		User seller1 = AuctionWebServiceClient.registerUser(email);
		Category cat = new Category();
		cat.setDescription("cat");
		Item item1 = AuctionWebServiceClient.offerItem(seller1, cat, omsch);
		Item item2 = AuctionWebServiceClient.getItem(item1.getId());
		assertEquals(omsch, item2.getDescription());
		assertEquals(email, item2.getSeller().getEmail());
		AuctionWebServiceClient.clean();
	
	}

	@Test
	public void findItemByDescription() {
		AuctionWebServiceClient.clean();
		String email3 = "xx3@nl";
		String omsch = "omsch";
		String email4 = "xx4@nl";
		String omsch2 = "omsch2";

		User seller3 = AuctionWebServiceClient.registerUser(email3);
		User seller4 = AuctionWebServiceClient.registerUser(email4);
		Category cat = new Category();
		cat.setDescription("cat3");
		Item item1 = AuctionWebServiceClient.offerItem(seller3, cat, omsch);
		Item item2 = AuctionWebServiceClient.offerItem(seller4, cat, omsch);

		ArrayList<Item> res = new ArrayList<>(AuctionWebServiceClient.findItemByDescription(omsch2));
		assertEquals(0, res.size());

		res = new ArrayList<>(AuctionWebServiceClient.findItemByDescription(omsch));
		assertEquals(2, res.size());
		AuctionWebServiceClient.clean();

	}

	@Test
	public void newBid() {
		String email = "ss2@nl";
		String emailb = "bb@nl";
		String emailb2 = "bb2@nl";
		String omsch = "omsch_bb";

		User seller = AuctionWebServiceClient.registerUser(email);
		User buyer = AuctionWebServiceClient.registerUser(emailb);
		User buyer2 = AuctionWebServiceClient.registerUser(emailb2);
		// eerste bod
		Category cat = new Category();
		cat.setDescription("cat9");
		Item item1 = AuctionWebServiceClient.offerItem(seller, cat, omsch);
		Money m = new Money();
		m.setCents(10);
		m.setCurrency("eur");
		Bid new1 = AuctionWebServiceClient.newBid(item1, buyer, m);
		assertEquals(emailb, new1.getBuyer().getEmail());

		item1 = AuctionWebServiceClient.getItem(item1.getId());
		// lager bod
		Money m2 = new Money();
		m2.setCents(9);
		m2.setCurrency("eur");
		Bid new2 = AuctionWebServiceClient.newBid(item1, buyer2, m2);
		assertNull(new2);

		item1 = AuctionWebServiceClient.getItem(item1.getId());
		// hoger bod
		Money m3 = new Money();
		m3.setCents(11);
		m3.setCurrency("eur");
		Bid new3 = AuctionWebServiceClient.newBid(item1, buyer2, m3);
		assertEquals(emailb2, new3.getBuyer().getEmail());

		AuctionWebServiceClient.clean();
	}
}
