/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package pixel.shared.classes;

import java.io.Serializable;
import javax.persistence.*;
import pixel.shared.enums.OnlineStatus;
import pixel.shared.enums.PersoonType;

/**
 *
 * @author Remi_Arts
 */
@Entity @Table(name="Persoon")
@NamedQueries({
    @NamedQuery(name = "Persoon.getPersonen", query = "select p from Persoon as p"),
    @NamedQuery(name = "Persoon.count", query = "select count(p) from Persoon as p"),
    @NamedQuery(name = "Persoon.find", query = "select p from Persoon as p where p.email = :email"),
})
public class Persoon  implements Serializable{
    @Id
    private String email;
    @Column
    private String naam;
    @Column
    private String adres;
    @Column
    private String wachtwoord;
    @Column
    private String type;
    @Column
    private String status;
    
    public Persoon(){}
    
    public Persoon(String email, String naam, String wachtwoord, String adres, PersoonType type, OnlineStatus status) {
        this.email = email;
        this.naam = naam;
        this.wachtwoord = wachtwoord;
        this.adres = adres;
        this.type = type.toString();
        this.status = status.toString();
    }
    
    public String getEmail() {
        return email;
    }

    public String getWachtwoord() {
        return wachtwoord;
    }

    public String getType() {
        return type;
    }

    public String getStatus() {
        return status;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public String getNaam() {
        return naam;
    }
    
    public String getAdres() {
        return adres;
    }

    public void setNaam(String naam) {
        this.naam = naam;
    }
    
    public void setAdres(String adres) {
        this.adres = adres;
    }

    public void setType(String type) {
        this.type = type;
    }

    public void setStatus(OnlineStatus status) {
        this.status = status.toString();
    }

    public void setWachtwoord(String wachtwoord) {
        this.wachtwoord = wachtwoord;
    }

    public void setStatus(String status) {
        this.status = status;
    }
    
    /**
     * @param email
     * @param naam 
     */
    public Persoon(String email, String naam, String adres){
        this.naam = naam;
        this.email = email;
        this.adres = adres;
    }
    
}
