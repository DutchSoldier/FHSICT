package auction.dao;

import auction.domain.User;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import javax.persistence.EntityExistsException;
import javax.persistence.EntityManager;
import javax.persistence.NoResultException;
import javax.persistence.Query;
import javax.persistence.criteria.CriteriaQuery;

public class UserDAOJPAImpl implements UserDAO {

    private final EntityManager em;

    public UserDAOJPAImpl(EntityManager entityManager) {
        em = entityManager;
    }

    @Override
    public int count() {
        Query q = em.createNamedQuery("User.count", User.class);
        return ((Long) q.getSingleResult()).intValue();
    }

    @Override
    public void create(User user) {
        em.getTransaction().begin();
        em.persist(user);
        em.getTransaction().commit();
    }

    @Override
    public void edit(User user) {
        em.merge(user);
    }

    @Override
    public List<User> findAll() {
        CriteriaQuery cq = em.getCriteriaBuilder().createQuery();
        cq.select(cq.from(User.class));
        return em.createQuery(cq).getResultList();
    }

    @Override
    public User findByEmail(String email) {
        Query q = em.createNamedQuery("User.findByEmail", User.class);
        q.setParameter("email", email);
        try {
            return (User) q.getSingleResult();
        } catch (NoResultException e) {
            return null;
        }
    }

    @Override
    public void remove(User user) {
        em.remove(em.merge(user));
    }
}
