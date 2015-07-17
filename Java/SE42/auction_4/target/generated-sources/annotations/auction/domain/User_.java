package auction.domain;

import auction.domain.Bid;
import auction.domain.Item;
import javax.annotation.Generated;
import javax.persistence.metamodel.ListAttribute;
import javax.persistence.metamodel.SetAttribute;
import javax.persistence.metamodel.SingularAttribute;
import javax.persistence.metamodel.StaticMetamodel;

@Generated(value="EclipseLink-2.6.0.v20150210-rNA", date="2015-05-27T11:18:57")
@StaticMetamodel(User.class)
public class User_ { 

    public static volatile SetAttribute<User, Item> offeredItems;
    public static volatile ListAttribute<User, Bid> bids;
    public static volatile SingularAttribute<User, String> email;

}