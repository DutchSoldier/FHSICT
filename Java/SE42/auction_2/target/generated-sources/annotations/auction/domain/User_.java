package auction.domain;

import auction.domain.Bid;
import auction.domain.Item;
import javax.annotation.Generated;
import javax.persistence.metamodel.ListAttribute;
import javax.persistence.metamodel.SingularAttribute;
import javax.persistence.metamodel.StaticMetamodel;

@Generated(value="EclipseLink-2.5.0.v20130507-rNA", date="2014-06-02T22:58:51")
@StaticMetamodel(User.class)
public class User_ { 

    public static volatile SingularAttribute<User, String> email;
    public static volatile ListAttribute<User, Item> items;
    public static volatile ListAttribute<User, Bid> bids;

}