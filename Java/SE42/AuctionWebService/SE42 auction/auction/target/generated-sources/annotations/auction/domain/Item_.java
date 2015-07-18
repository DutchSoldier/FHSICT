package auction.domain;

import auction.domain.Bid;
import auction.domain.Category;
import auction.domain.User;
import javax.annotation.Generated;
import javax.persistence.metamodel.SingularAttribute;
import javax.persistence.metamodel.StaticMetamodel;

@Generated(value="EclipseLink-2.5.1.v20130918-rNA", date="2015-06-16T11:21:52")
@StaticMetamodel(Item.class)
public class Item_ { 

    public static volatile SingularAttribute<Item, User> seller;
    public static volatile SingularAttribute<Item, Bid> highest;
    public static volatile SingularAttribute<Item, String> description;
    public static volatile SingularAttribute<Item, Long> id;
    public static volatile SingularAttribute<Item, Category> category;

}