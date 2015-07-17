package auction.domain;

import javax.persistence.Entity;
import javax.persistence.Inheritance;
import javax.persistence.InheritanceType;

/**
 * Created by Subhi on 25-1-2015.
 */
@Entity
public class Furniture extends Item {
    private String material;

    public Furniture() {

    }
    public Furniture(User seller, Category category, String description, String material) {
        super(seller, category, description);
        this.material = material;
    }

    public String getMaterial() {
        return material;
    }

}
