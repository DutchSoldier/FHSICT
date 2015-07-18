package auction.domain;

import java.io.Serializable;
import javax.persistence.*;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlRootElement;

//Changes: Annotations.

@Entity
@NamedQueries({
    @NamedQuery(name = "User.count", query = "select count(u) from User as u"),
    @NamedQuery(name = "User.findByEmail", query = "select u from User as u where u.email = :email")
})
@XmlRootElement
@XmlAccessorType(XmlAccessType.FIELD)
public class User implements Serializable {

    @Id
    private String email; //email is uniek, dus kan ID zijn.

    public User(String email) {
        this.email = email;
    }
    
    public User() {
    }

    public String getEmail() {
        return email;
    }
}
