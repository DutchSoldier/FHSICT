/**
 *
 * @author Luc_Martens
 */

package fontys.time;

import java.util.Iterator;

/**
 *
 * An appointment with invitees, subject and period.
 */
public interface IAppointment {
    
    /**
     * returns the subject of this appointment
     * @return The subject of this appointment
     */
    String getSubject();
    
    /**
    * returns the period of this appointment
    * @return The period of this appointment 
    */
    IPeriod getPeriod();
    
    /**
    * returns the Iterator of invited contacts for this appointment
    * @return the Iterator of invited contacts for this appointment
    */
    Iterator<Contact> invitees();
    
    /**
    * Adds a contact to the list of invitees for this appointment
    * Only contacts that have no conflicting appointments will be added
    * @param c (The Contact object to add to this appointment)
    * @return boolean of wether or not the contact was added succesfully 
    */
    boolean AddContact(Contact c);
    
    /**
    * removes a contact from the list of invitees for this appointment
    * @param c (The Contact object to remove from this appointment)
    */
    void removeContact(Contact c);          
}
