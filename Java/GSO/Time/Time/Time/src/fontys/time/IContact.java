/**
 *
 * @author Remi_Arts
 */

package fontys.time;
import java.util.ArrayList;

public interface IContact {
    
    String getName();
    void setName(String Name);
    void addAppointment(Appointment a);
    void removeAppointment(Appointment a);
}
