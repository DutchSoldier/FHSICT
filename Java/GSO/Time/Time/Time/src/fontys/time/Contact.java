/**
 *
 * @author Remi_Arts
 */

package fontys.time;

import java.util.ArrayList;


public class Contact {
    public String name;
    ArrayList<Appointment> appointments;
    
    public Contact(String Name)
    {
        name = Name;
        appointments = new ArrayList<Appointment>();
    }
    
    public ArrayList<Appointment> getAppointments()
    {
        return appointments;
    }
    
    public String getName()
    {
        return name;
    }
    
    public void setName(String Name)
    {
        name = Name;
    }
    
    public void addAppointment(Appointment a)
    {
        appointments.add(a);
    }
    
    public void removeAppointment(Appointment a)
    {
        appointments.remove(a);
    }   
}
