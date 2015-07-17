package webservice;

import javax.persistence.EntityManager;
import javax.persistence.Persistence;
import javax.xml.ws.Endpoint;

/**
 * Created by Subhi on 26-1-2015.
 */
public class AuctionWebService {
    public static EntityManager entityManager;
    public static final String registrationMgrUrl = "http://localhost:8081/RegistrationManager";
    public static final String auctionMgrUrl = "http://localhost:8081/AuctionManager";
    public static void main (String[] args) {
        entityManager = Persistence.createEntityManagerFactory("db").createEntityManager();

        Endpoint.publish(registrationMgrUrl, new Registration());
        Endpoint.publish(auctionMgrUrl, new Auction());
        System.out.println("launched");

    }
}
