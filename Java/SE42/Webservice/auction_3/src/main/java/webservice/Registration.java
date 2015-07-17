package webservice;

import auction.domain.User;
import auction.service.RegistrationMgr;

import javax.jws.WebService;
import javax.persistence.EntityManager;
import javax.persistence.Persistence;

/**
 * Created by Subhi on 26-1-2015.
 */
@WebService
public class Registration {
    private RegistrationMgr registrationMgr;
    EntityManager em;
    public Registration() {
        em = AuctionWebService.entityManager;
        registrationMgr = new RegistrationMgr(em);
    }

    public User registerUser(String email) {
        em.getTransaction().begin();
        User u = registrationMgr.registerUser(email);
        em.getTransaction().commit();
        return u;
    }

    public User getUser(String email) {
        return registrationMgr.getUser(email);
    }
}
