/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package auctionwebserviceclient;

import web.Bid;
import web.Item;
import web.User;

/**
 *
 * @author Remi_Arts
 */
public class AuctionWebServiceClient {

	/**
	 * @param args the command line arguments
	 */
	public static void main(String[] args) {
		// TODO code application logic here
	}

	public static java.util.List<web.Item> findItemByDescription(java.lang.String arg0) {
		web.AuctionService service = new web.AuctionService();
		web.Auction port = service.getAuctionPort();
		return port.findItemByDescription(arg0);
	}

	public static Item getItem(long arg0) {
		web.AuctionService service = new web.AuctionService();
		web.Auction port = service.getAuctionPort();
		return port.getItem(arg0);
	}

	public static Bid newBid(web.Item arg0, web.User arg1, web.Money arg2) {
		web.AuctionService service = new web.AuctionService();
		web.Auction port = service.getAuctionPort();
		return port.newBid(arg0, arg1, arg2);
	}

	public static Item offerItem(web.User arg0, web.Category arg1, java.lang.String arg2) {
		web.AuctionService service = new web.AuctionService();
		web.Auction port = service.getAuctionPort();
		return port.offerItem(arg0, arg1, arg2);
	}

	public static boolean revokeItem(web.Item arg0) {
		web.AuctionService service = new web.AuctionService();
		web.Auction port = service.getAuctionPort();
		return port.revokeItem(arg0);
	}

	public static User getUser(java.lang.String arg0) {
		web.RegistrationService service = new web.RegistrationService();
		web.Registration port = service.getRegistrationPort();
		return port.getUser(arg0);
	}

	public static User registerUser(java.lang.String arg0) {
		web.RegistrationService service = new web.RegistrationService();
		web.Registration port = service.getRegistrationPort();
		return port.registerUser(arg0);
	}

	public static void clean() {
		web.RegistrationService service = new web.RegistrationService();
		web.Registration port = service.getRegistrationPort();
		port.clean();
	}
	
}
