/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package pixel.shared.classes;

import java.io.Serializable;
import pixel.shared.enums.FotograafType;
import pixel.shared.enums.PersoonType;

/**
 *
 * @author Frank
 */
public class Account implements Serializable {
  
    private String email;

    /**
     *
     * @return
     */
    public String getEmail() {
        return email;
    }
    
    private PersoonType type;
    
    /**
     *
     * @return
     */
    public PersoonType getType() {
        return type;
    }
    
    private FotograafType ftype;

    /**
     *
     * @return
     */
    public FotograafType getFtype() {
        return ftype;
    }
    
    /**
     *
     * @param email
     * @param type
     * @param ftype  
     */
    public Account(String email, PersoonType type, FotograafType ftype) {
        this.email = email;
        this.type = type;
        this.ftype = ftype;
    }    
}
