package main;

import auctionmanager.Auction;
import auctionmanager.AuctionService;
import auctionmanager.Registration;
import auctionmanager.RegistrationService;

/**
 * Created by Subhi on 26-1-2015.
 */
public class AuctionManagerClient {
    public static void main(String[] args) {
        RegistrationService rs = new RegistrationService();
        Registration registration = rs.getRegistrationPort();
        System.out.println(registration.registerUser("AAXX@rrr.xx"));
    }

}
