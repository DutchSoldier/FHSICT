/**
 *
 * @author Luc_Martens
 */

package fontys.time;

import java.util.ArrayList;
import java.util.Iterator;

public class Appointment implements IAppointment {
    private String subject;
    private IPeriod period;
    private ArrayList<Contact> contacts;
    
    public Appointment()
    {
        contacts = new ArrayList<Contact>();
    }
    
    @Override
    public String getSubject() 
    {
        return subject;
    }

    @Override
    public IPeriod getPeriod() 
    {
        return period;
    }

    @Override
    public Iterator<Contact> invitees() 
    {
        return contacts.iterator();
    }

    @Override
    public boolean AddContact(Contact c) 
    {
        for(Appointment a : c.getAppointments())
        {
            if (a.period.unionWith(this.period) != null)
            {
                return false;
            }            
        }
        contacts.add(c);
        return true;
    }

    @Override
    public void removeContact(Contact c) 
    {
        contacts.remove(c);
    }
    
}
