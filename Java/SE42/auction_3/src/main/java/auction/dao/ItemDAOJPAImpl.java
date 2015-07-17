package auction.dao;

import auction.domain.Item;
import java.util.List;
import javax.persistence.EntityManager;
import javax.persistence.Query;

public class ItemDAOJPAImpl implements ItemDAO {
    private EntityManager items;
    
    public ItemDAOJPAImpl(EntityManager em) {
        this.items = em;
    }

    @Override
    public int count() {
        return (Integer) items.createNativeQuery("SELECT count(*) FROM Item i")
                .getSingleResult();  
    }

    @Override
    public void create(Item item) {
        items.persist(item);
    }

    @Override
    public void edit(Item item) {
        items.merge(item);
    }
    
    @Override
    public Item find(Long id) {
        return items.find(Item.class, id);
    }
    
    @Override
    public List<Item> findAll() {
        return items.createQuery("SELECT i FROM Item i").getResultList();
    }

    @Override
    public List<Item> findByDescription(String description) {
        Query q = items.createQuery("SELECT i FROM Item i WHERE i.description = :description", Item.class);
        q.setParameter("description", description);
        return q.getResultList();
    }
    
    @Override
    public void remove(Item item) {
        items.remove(item);
    }
}
