/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package auction.dao;

import auction.domain.Item;
import java.util.ArrayList;
import java.util.List;
import javax.persistence.*;
import javax.persistence.criteria.CriteriaQuery;

/**
 *
 * @author Remi_Arts
 */
public class ItemDAOJPAImpl implements ItemDAO {
    
    private final EntityManager em;
    
    public ItemDAOJPAImpl(EntityManager entityManager) {
        em = entityManager;
    }

    @Override
    public int count() {
       Query q = em.createNamedQuery("Item.count", Item.class);
       return ((Long) q.getSingleResult()).intValue();
    }

    @Override
    public void create(Item item) {
        em.getTransaction().begin();
        em.persist(item);
        em.getTransaction().commit();
    }

    @Override
    public void edit(Item item) {
        em.merge(item);
    }

    @Override
    public Item find(Long id) {
        Query q = em.createNamedQuery("Item.findById", Item.class);
        q.setParameter("id", id);
        try {
            return (Item) q.getSingleResult();
        } catch(NoResultException e) {
            return null;
        }
    }

    @Override
    public List<Item> findAll() {
        CriteriaQuery cq = em.getCriteriaBuilder().createQuery();
        cq.select(cq.from(Item.class));
        return em.createQuery(cq).getResultList();
    }

    @Override
    public List<Item> findByDescription(String description) {
        Query q = em.createNamedQuery("Item.findByDescription", Item.class);
        q.setParameter("description", description);
        try {
            return q.getResultList();
        } catch(NoResultException e) {
            return new ArrayList<>();
        }
    }

    @Override
    public void remove(Item item) {
        em.getTransaction().begin();
        em.remove(em.merge(item));
        em.getTransaction().commit();
    }
    
}
