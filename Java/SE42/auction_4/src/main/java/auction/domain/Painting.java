package auction.domain;

import javax.persistence.Entity;
import javax.persistence.Inheritance;
import javax.persistence.InheritanceType;

/**
 * Created by Subhi on 25-1-2015.
 */
@Entity
public class Painting extends Item {
    private String title;
    private String painter;

    public Painting() {

    }
    public Painting(User seller, Category category, String description, String title, String painter) {
        super(seller, category, description);
        this.title = title;
        this.painter = painter;
    }

    public String getTitle() {
        return title;
    }


    public String getPainter() {
        return painter;
    }

}
