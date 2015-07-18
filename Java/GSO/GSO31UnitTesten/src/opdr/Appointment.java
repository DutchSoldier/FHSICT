/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package opdr;

import fontys.time.IPeriod;
import java.util.ArrayList;
import java.util.Iterator;

/**
 *
 * @author Frank en Kasper
 */
public class Appointment {

    private String subject;
    private IPeriod periode;
    private ArrayList<Contact> contacten;

    public Appointment(String subject, IPeriod periode) {
        this.subject = subject;
        this.periode = periode;
        contacten = new ArrayList<Contact>();
    }
    
    public String getSubject(){
        return this.subject;
    }
    
    public IPeriod getPeriod(){
        return this.periode;
    }
    
    public Iterator<Contact> invitees(){
        return contacten.iterator();
    }
    
    public boolean addContact(Contact c){
        Iterator<Contact> invitees = invitees();
        while(invitees.hasNext()){
            if (c == invitees.next())
            {
               return false;
            }    
        }
        contacten.add(c);
        c.addAppointment(this);
        return true;
    }
    
    public void removeContact(Contact c){
        Iterator<Contact> invitees = invitees();
        while(invitees.hasNext()){
            if (c == invitees.next())
            {
                invitees.remove();
                for (Contact con : contacten){
                    if (c == con)
                    {
                        contacten.remove(con);
                    }
            }
        }
        
    }
    }
}
