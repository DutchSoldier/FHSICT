import java.util.List;
import static org.junit.Assert.*;


import org.junit.Before;
import org.junit.Test;

import auction.domain.User;
import javax.persistence.EntityManager;
import javax.persistence.Persistence;
import util.DatabaseCleaner;

public class JPARegistrationMgrTest {

    private RegistrationMgr registrationMgr;
    EntityManager em = Persistence.createEntityManagerFactory("db").createEntityManager();
    @Before
    public void setUp() throws Exception {
        System.out.print("before jpareg");
        registrationMgr = new RegistrationMgr(em);
        DatabaseCleaner dc = new DatabaseCleaner(Persistence.createEntityManagerFactory("db").createEntityManager());
        dc.clean();
    }

    @Test
    public void registerUser() {
        User user1 = registrationMgr.registerUser("xxx1@yyy");
        Assert.assertTrue(user1.getEmail().equals("xxx1@yyy"));
        User user2 = registrationMgr.registerUser("xxx2@yyy2");
        Assert.assertTrue(user2.getEmail().equals("xxx2@yyy2"));
        User user2bis = registrationMgr.registerUser("xxx2@yyy2");
        Assert.assertSame(user2bis, user2);
        //geen @ in het adres
        Assert.assertNull(registrationMgr.registerUser("abc"));
    }

    @Test
    public void getUser() {
        User user1 = registrationMgr.registerUser("xxx5@yyy5");
        User userGet = registrationMgr.getUser("xxx5@yyy5");
        Assert.assertSame(userGet, user1);
        Assert.assertNull(registrationMgr.getUser("aaa4@bb5"));
        registrationMgr.registerUser("abc");
        Assert.assertNull(registrationMgr.getUser("abc"));
    }

    @Test
    public void getUsers() {
        List<User> users = registrationMgr.getUsers();
        Assert.assertEquals(0, users.size());

        em.getTransaction().begin();
        User user1 = registrationMgr.registerUser("xxx8@yyy");
        em.getTransaction().commit();
        users = registrationMgr.getUsers();
        Assert.assertEquals(1, users.size());
        System.out.println("-----------------------");
        System.out.println(user1 + " " + user1.getClass().getName());
        System.out.println(users.get(0) + " " + users.get(0).getClass().getName());
        Assert.assertSame(users.get(0), user1);


        em.getTransaction().begin();
        User user2 = registrationMgr.registerUser("xxx9@yyy");
        em.getTransaction().commit();
        users = registrationMgr.getUsers();
        Assert.assertEquals(2, users.size());

        em.getTransaction().begin();
        registrationMgr.registerUser("abc");
        em.getTransaction().commit();
        //geen nieuwe user toegevoegd, dus gedrag hetzelfde als hiervoor
        users = registrationMgr.getUsers();
        Assert.assertEquals(2, users.size());
    }
}
